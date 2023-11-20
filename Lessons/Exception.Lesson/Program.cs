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

                Console.WriteLine("Insert Number:");
                input = Console.ReadLine();
                int.TryParse(input, out inputNumber);

                Console.WriteLine("Inserted Number:{0}", inputNumber);
                Order(TotOrder, inputNumber); // Close Program
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
                // 1-  La connessione non vieniva chiusa. Ora chiude anche iin caso di  re-throw 


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
                throw; // Invece di proseguire con l'esecuzionedi un codice potenzialmente nocivo
                       // con throw, fermo l'esecuzione e informa il chimante.
            }


            ConfirmOrder(FriendsNumber);// Ordine non esesguito
        }
        static bool Payment(int TotOrder, int FriendsNumber)
        {
            throw new System.Exception();
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
