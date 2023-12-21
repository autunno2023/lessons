using System;
using static Eventsdelegate.Lesson.Thermometer;

namespace Eventsdelegate.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thermometer thermometerSamsung = new Thermometer();
            thermometerSamsung.Name = "Samsung";
            thermometerSamsung.TempChanged += new OnTempChangedEventHandler(TurnOffTermostato);
            thermometerSamsung.Temp = 18;


            Thermometer thermometerArsiton = new Thermometer();
            thermometerArsiton.Name = "Arsiton";
            thermometerArsiton.TempChanged += new OnTempChangedEventHandler(TurnOffTermostato);
            thermometerArsiton.Temp = 28;


        }
        public static void TurnOffTermostato(object sender, ChangeTempEventArgs e)
        {
            Console.WriteLine(sender.GetType().GetProperty("Name").GetValue(sender));

            if (e.NewTemp < 24)
            {
                Console.WriteLine($"Nuova Temperatura impostata a {e.NewTemp} gradi!");
            }
            else
            {
                e.Cancel = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Temperatura troppo alta. Termostato spento!");
                Console.ResetColor();
                Console.WriteLine();
            }

        }
    }
    class Thermometer
    {
        public string Name { get; set; }
        public delegate void OnTempChangedEventHandler(object sender, ChangeTempEventArgs e);
        public event OnTempChangedEventHandler TempChanged;
        int temp;

        public int Temp
        {
            get { return temp; }
            set
            {
                if (temp != value)
                {

                    ChangeTempEventArgs e = new ChangeTempEventArgs(value);
                    TempChanged(this, e);
                    if (e.Cancel)
                    {
                        return;
                    }

                    temp = value;
                }
            }

        }
    }
    class ChangeTempEventArgs : EventArgs
    {
        int newTemp;
        public bool Cancel;

        public int NewTemp { get { return newTemp; } }

        public ChangeTempEventArgs(int NewTemp)
        {
            newTemp = NewTemp;
        }
    }
}
