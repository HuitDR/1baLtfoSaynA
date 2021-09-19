using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace AnyaSoftLab1
{
    public class Mass : IEnumerable<string>
    {
        private string[] STRING;
        private int lowIndex;
        private int highIndex;

        public Mass(int lIndex, int hIndex) //Произвольный индекс массива типа строка
        {
            int size = hIndex - lIndex + 1;
            if(size < 0) throw new ArgumentException();
            STRING = new string[size];
            this.lowIndex = lIndex;
            this.highIndex = hIndex;
        }

        public string this[int index] //получение и определение ячейки
        {
            get
            {
                if (index < lowIndex || index > lowIndex + STRING.Length) return "За пределами моего понимания." + System.Environment.NewLine + "PS. C#";
                return STRING[index - lowIndex];
            }
            set
            {
                if (index < lowIndex || index > lowIndex + STRING.Length) Console.WriteLine("За пределами моего понимания." + System.Environment.NewLine + "PS. C#");
                STRING[index - lowIndex] = value;
            }
        }

        public static Mass ConcatDistinct(Mass first, Mass second)
        {
            int lowIndex = (first.lowIndex < second.lowIndex ? first.lowIndex : second.lowIndex);
            int highIndex = (first.highIndex > second.highIndex ? first.highIndex : second.highIndex);
            Mass newString = new Mass(lowIndex, highIndex);
            newString.STRING = first.STRING.Concat(second.STRING).Distinct().ToArray();
            return newString;
        }

        public static Mass Concat(Mass first, Mass second)
        {
            int lowIndex = (first.lowIndex < second.lowIndex ? first.lowIndex : second.lowIndex);
            int highIndex = (first.highIndex > second.highIndex ? first.highIndex : second.highIndex);
            Mass newString = new Mass(lowIndex, highIndex);
            newString.STRING = first.STRING.Concat(second.STRING).ToArray();
            return newString;
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < STRING.Length; i++)
                yield return STRING[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        public static int low;
        public static int high;
        public static Mass STR;
        public static Mass STR1;
        public static Mass STRSLIV;
        public static Mass STRSCEP;

        public static Mass Indexa()
        {
            string Consolew;
            Console.Write("Введите ограничения массива через пробел: ");
            Consolew = Console.ReadLine();
            string[] ind = Consolew.Split(" ");
            int lw = Int32.Parse(ind[0]);
            int hg = Int32.Parse(ind[1]);
            low = lw; high = hg;
            Mass STR = new Mass (lw, hg);
            for (int i = lw; i < hg + 1; i++) { Console.Write("Massive element [" + i + "] = "); STR[i] = Console.ReadLine(); };
            return STR;
        }//Установка индексов для массива

        public static void Vivod(Mass STR) { Console.WriteLine("Вывод массива: "); for (int i = low; i < high + 1; i++) { Console.WriteLine("Massive element [" + i + "] - " + STR[i]); }; }

        public static void Vivods(Mass STR) { Console.WriteLine("Вывод массива: "); foreach(var a in STR) { Console.WriteLine("Massive element - " + a); }; }

        public static void Stroka(int o) { Console.WriteLine("Элемент который вы выбрали: {0}",STR[o]); }

        static void Main(string[] args)
        {
            Label Exit;
            Label Menus;
        Menus:
            Console.WriteLine("Menu Loader Release");
            Console.WriteLine("1) Произвести выбор произвольных индексов и заполнение массива1");
            Console.WriteLine("2) Вывести весь массив");
            Console.WriteLine("3) Вывести нужный элемент");
            Console.WriteLine("4) Произвести выбор произвольных индексов и заполнение массива2");
            Console.WriteLine("5) Слить массив1 и массив2");
            Console.WriteLine("6) вывести слитый массив");
            Console.WriteLine("7) Сцепить массив1 и массив2");
            Console.WriteLine("8) вывести сцепленый массив");
            Console.WriteLine("Любая цифирка кроме 1-8) Выход");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    STR = Indexa(); break;//робит
                case 2:
                    Console.Clear();
                    Vivod(STR); break;
                case 3:
                    Console.Clear();
                    Console.Write("Какой элемент хочешь?: ");
                    Stroka(Int32.Parse(Console.ReadLine())); break;
                case 4:
                    Console.Clear();
                    STR1 = Indexa(); break;
                case 5:
                    Console.Clear();
                    STRSLIV = Mass.ConcatDistinct(STR, STR1); break;
                case 6:
                    Console.Clear();
                    Vivods(STRSLIV);break;
                case 7:
                    Console.Clear();
                    STRSCEP = Mass.Concat(STR, STR1); break;
                case 8:
                    Console.Clear();
                    Vivods(STRSCEP); break;
                default: goto Exit; 
            }
            goto Menus;
        Exit: Console.WriteLine("пока");
        }
    }
}
    