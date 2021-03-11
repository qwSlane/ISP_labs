using System;
using static System.Console;

namespace lab_2
{
    class Program
    {
        static void Counter(string dateString)
        {                 //date

            int[] numbers = new int[12];

            for (int n = 0; n < dateString.Length-1; n++) 
            {
            
                if ((char) dateString[n]>=48 && (char)dateString[n] <=58)
                {

                    int a = Convert.ToInt32(dateString[n]-48);
                    numbers[a]++;

                }     
            }

            for (int i = 0; i < 10; i++)
                WriteLine($"{i}: {numbers[i]}");
        
        }

        static void DateNow() 
        {     //date

            DateTime date = DateTime.Now;

            string[] dateString = { date.ToLocalTime().ToString(), date.ToUniversalTime().ToString() };

            for (int i = 0; i < 2; i++) 
            {

                WriteLine(dateString[i]);
                Counter(dateString[i]);
 
            }
        }

        static void StringChanger()  //string
        {
            WriteLine("введите строку");
            string mane = ReadLine();

            string edited = "";
            edited = edited.Insert(0,mane);

            for (int i = 0; i < mane.Length - 1; i++)
            {
                if (mane[i] == 'a' | mane[i] == 'e' | mane[i] == 'i' | mane[i] == 'o' | mane[i] == 'u')
                {

                    if (i<mane.Length && mane[i + 1] == 'z')
                    {
                        string a = "a";
                        edited = edited.Remove(i + 1, 1);
                        edited =edited.Insert(i+1,a);
                    }

                    else if (i < mane.Length)
                    { 
                        string a = "" + (char)(mane[i + 1] + 1);
                        edited = edited.Remove(i + 1, 1);
                        edited = edited.Insert(i + 1, a);
                    }
                } 
            }

            WriteLine("{0}", edited);
        }

        static void LongProof()
        {
            ulong min, max;

            WriteLine(" Введите нижний предел ");
            while (!ulong.TryParse(ReadLine(), out min))
            {
                WriteLine(" Введите нижний предел ");
            }

            WriteLine(" Введите верхний предел ");
            while (!ulong.TryParse(ReadLine() , out max)  | min>=max)
            {
                 WriteLine(" Введите верхний предел ");
            }
            WriteLine($"Максимальная степень:{MaxDegree(max) - MaxDegree(min-1) }");
        }

        static ulong MaxDegree(ulong x)
        {
            ulong degree = 0;

            while (x!=0) 
            {
                x /= 2;
                degree += (x);
            }

            return degree ;
        }
        static void Main()
        {
            bool tr = true;
            int request;

            while (tr)
            {
                WriteLine("1 - дата в двух форматах");
                WriteLine("2 - замена после гласных");
                WriteLine("3 - максимальная степень делителя факториала");
                WriteLine("4 - выход");


                while (!int.TryParse(ReadLine(), out request))
                {
                    WriteLine("Ошибка ввода ");
                }

                switch (request)
                {
                    case 1:
                        DateNow();
                        break;

                    case 2:
                        StringChanger();
                        break;
                    case 3:
                        LongProof();
                        break;
                    case 4:
                        tr = false;
                        break;
                    default:
                        WriteLine("Ошибка ввода");
                        break;

                }
            }
        }
    }
}

