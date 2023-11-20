using System;
using System.Threading;

namespace Exception.Lesson
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                string input;
                int inputNumber;
                int TotOrder = 100;

                #region INPUT
                Console.WriteLine("Insert Number:");
                input = Console.ReadLine();
                int.TryParse(input, out inputNumber);
                #endregion
                #region CAST_INPUT
                Console.WriteLine("Inserted Number:{0}", inputNumber);
                Order(TotOrder, inputNumber); // Close Program
                Console.WriteLine("Ordine inviato con sucecsso!");
                #endregion
            }

            catch (System.Exception ex)
            {
                #region Exception
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
                #endregion

            }
        }
        static void Order(int TotOrder, int FriendsNumber)
        {
            try
            {
                Console.WriteLine("Open DB connection");
                Payment(TotOrder, FriendsNumber);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error during Order...");
            }
            ConfirmOrder(FriendsNumber);// Ordine non esesguito
        }
        static bool Payment(int TotOrder, int FriendsNumber)
        {
            return TotOrder % FriendsNumber == 0 ? true : false;
        }
        static void ConfirmOrder(int FriendsNumber)
        {
            for (int i = 0; i < FriendsNumber; i++)
            {
                Console.WriteLine($"Seding mail to customer {i}");
                Thread.Sleep(1000);
            }
        }

    }
}
