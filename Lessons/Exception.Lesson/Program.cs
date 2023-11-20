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
            catch (Under18OrderException ex)
            {
                Console.WriteLine($"Informa i genitori");
            }
            catch (GeneralOrderException ex)
            {
                Console.WriteLine($"Metto il cliente in blacklist");
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

                throw; // Invece di proseguire con l'esecuzionedi un codice potenzialmente nocivo
                       // con throw, fermo l'esecuzione e informa il chimante.  
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
            catch  // Non volendo intercettare l'exception, tolgo i parametri e rimando indietro il l'errore
            {
                throw;
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
    class GeneralOrderException : System.Exception
    {
        public GeneralOrderException(string Message) : base(Message)
        {

        }
    }
    class Under18OrderException : GeneralOrderException
    {
        public Under18OrderException(string Message) : base(Message)
        {

        }
    }
}
