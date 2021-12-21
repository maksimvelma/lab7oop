using System;

namespace lab7
{
    public class AirBoard
    {
        private string _name { get; set; }
        private static int maxPassengers = 99;
        public static void AddPassenger()
        {
            Console.Clear();
            Console.Write("Введiть кількість пасажирів: ");
            int passengers = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть імена пасажирів: ");
            string[] names = Console.ReadLine().Split(' ');
            if (passengers == names.Length)
            {
                try
                {

                    if (passengers > maxPassengers)
                    {
                        throw new KilkistException($"ПОМИЛКА: Не поміститься скільки пасажирів");
                    }
                    else
                    {
                        Statistic.CurPass++;
                        Statistic.sname = names;
                        Console.WriteLine(names);
                        Console.WriteLine("Пасажири успішно додані на рейс:> " + Statistic.CurPass + " | " + maxPassengers);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (passengers > names.Length)
            {
                Console.WriteLine("ПОМИЛКА: Не всі імена пасажирів вказані: " + names.Length + " | " + passengers);
            }
            else if (passengers < names.Length)
            {
                Console.WriteLine("ПОМИЛКА: Імен більше, ніж має бути: " + names.Length + " | " + passengers);
            }
            Console.Write("-=-=-=-=-=-=-");
            Console.Write(" ");
            Program.Main();
        }
    }
    public class Plane
    {
        public static void Rise()
        {
            Console.Clear();
            Console.Write("Введіть довжину смуги: ");
            int stripLength = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (stripLength <= 0)
                {
                    throw new SmugaRozgonuException($"ПОМИЛКА: Неможливо створити літак - вказана неправильна довжина смуги розгону: "+ stripLength);
                    Statistic.stateFLYER = "Недостатньо місця";
                } else {
                    Statistic.CurLeng = stripLength;
                    Statistic.stateFLYER = "Готовий";
                    Console.WriteLine("Літак готовий до польоту");
                    Console.WriteLine("Вказана довжина смуги розгону: " + Statistic.CurLeng);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("-=-=-=-=-=-=-");
            Console.Write(" ");
            Program.Main();
        }
    }
    public static class Statistic
    {
        public static string[] sname;
        public static string landingPlace = "Не вказано";
        public static int CurPass;
        public static int CurLeng;
        public static string stateFLYER = "Не вказано";
    }
    public class KilkistException : Exception
    {
        public KilkistException(string aMessage) : base(aMessage) { }
    }
    public class SmugaRozgonuException : Exception
    {
        public SmugaRozgonuException(string aMessage) : base(aMessage) { }
    }
    public class Program
    {
        private static string[] args;
        private static void Commands() {
            args = Console.ReadLine().Split(' ');
            if (args[0] == "AddPass")
            {
                AirBoard.AddPassenger();
            }
            if (args[0] == "SetLenght")
            {
                Plane.Rise();
            }
            if (args[0] == "InfoGet")
            {
                Console.WriteLine("-----=Пасажири=-----");
                Console.WriteLine("Усього пасажирів: "+Statistic.CurPass);
                Console.WriteLine("Імена пасажирів: " + Statistic.sname);
                Console.WriteLine("-----=Літак=-----");
                Console.WriteLine("Довжина злітної смуги: " + Statistic.CurLeng);
                Console.WriteLine("Готовність зльоту: " + Statistic.stateFLYER);
            }
            if (args[0] == "exit")
            {
                return;
            }
            Commands();
        }
        public static void Main()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("AddPass -> Додати пасажира");
            Console.WriteLine("SetLenght -> Змінити довжину злітної смуги");
            Console.WriteLine("InfoGet -> Отримати поточні дані");
            Commands();
        }
    }
}
© 2021 GitHub, Inc.
Terms
Privacy
Secu