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

                //Console.WriteLine("Insert Number:");
                //input = Console.ReadLine();
                //int.TryParse(input, out inputNumber);

                do
                {
                    Console.WriteLine("Insert a valid number:");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out inputNumber) || (int.TryParse(input, out inputNumber) && inputNumber < 1));

                Order(TotOrder, inputNumber);
                Console.WriteLine("Ordine inviato con sucecsso!");

            }

            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();


            }
            finally
            {
                // 1-  La connessione non vieniva chiusa. Ora chiude anche in caso di  re-throw 


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Close DB connection");
                Console.ResetColor();

            }
        }
        static void Order(int TotOrder, int FriendsNumber)
        {
            try
            {
                Console.WriteLine("Open DB connection");
                Payment(TotOrder, FriendsNumber);
            }
            catch
            {
                throw; // Invece di proseguire con l'esecuzione di un codice potenzialmente nocivo
                       // con throw, fermo l'esecuzione e informo il chimante dell'errore avvenuto.
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
