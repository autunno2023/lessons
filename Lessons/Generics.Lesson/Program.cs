using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Generics.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // pROBLEM #1
            #region  cUSTOMER
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Bruno", Age = 40 });
            customers.Add(new Customer() { Name = "Anna", Age = 30 });
            customers.Add(new Customer() { Name = "Marco", Age = 40 });
            customers.Add(new Customer() { Name = "Diego", Age = 20 });
            customers.Add(new Customer() { Name = "Maria", Age = 24 });
            customers.Add(new Customer() { Name = "Laura", Age = 50 });
            #endregion 
            CreatePersonCsv(@"D\Logs", "GenericsLessonPersonCsv.csv", customers);

            #region  aCCOUNT
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account() { Saldo = 1000m, AccountNumber = 44545450 });
            accounts.Add(new Account() { Saldo = 2000m, AccountNumber = 54545450 });
            accounts.Add(new Account() { Saldo = 3000m, AccountNumber = 48845250 });
            accounts.Add(new Account() { Saldo = 4000m, AccountNumber = 454554545 });
            accounts.Add(new Account() { Saldo = 5000m, AccountNumber = 454542424 });
            accounts.Add(new Account() { Saldo = 6000m, AccountNumber = 454554554 });
            #endregion
            CreateAccountCsv(@"D\Logs", "GenericsLessonAccountCsv.csv", accounts);



            // pROBLEM #2
            #region bOth TYpes

            #endregion
            CreateGenericCsv(@"D\Logs", "GenericsLessonAccountCsv.csv", accounts);
            CreateGenericCsv(@"D\Logs", "GenericsLessonAccountCsv.csv", customers);


            // pROBLEM #3
            #region aLL tYPES 
            // 1000 TYPES ????  
            #endregion



            #region Generic List 


            MyGenericList<Person> people = new MyGenericList<Person>();

            #region initialization 
            people.AddItem(new() { Name = "Bruno", Age = 40 });
            people.AddItem(new() { Name = "Marco", Age = 30 });
            people.AddItem(new() { Name = "Diego", Age = 20 });
            people.AddItem(new() { Name = "Anna", Age = 10 });
            people.AddItem(new() { Name = "Maria", Age = 24 });
            people.AddItem(new() { Name = "Laura", Age = 50 });
            #endregion
            #endregion
        }

        public

        #region tYPED_mETHODS
        static void CreatePersonCsv(string path, string fileName, List<Customer> customers)
        {
            StringBuilder sb = new StringBuilder();

            string completePath = Path.Combine(path, fileName);
            if (!File.Exists(completePath))
            {
                string header = string.Format("Name,Age");
                sb.AppendLine(header);
            }
            foreach (var customer in customers)
            {
                sb.AppendLine(customer.Name + "," + customer.AccountNumber);
            }

            File.AppendAllText(completePath, sb.ToString());
        }
        static void CreateAccountCsv(string path, string fileName, List<Account> accounts)
        {
            StringBuilder sb = new StringBuilder();

            string completePath = Path.Combine(path, fileName);
            if (!File.Exists(completePath))
            {
                string header = string.Format("Name,Age");
                sb.AppendLine(header);
            }
            foreach (var account in accounts)
            {
                sb.AppendLine(account.AccountId + "," + account.Saldo);
            }

            File.AppendAllText(completePath, sb.ToString());
        }
        #endregion
        #region pARTIAL_gENERIC_mETHODS
        static void CreateGenericCsv<T>(string path, string fileName, List<T> dati)
        {
            StringBuilder sb = new StringBuilder();

            string completePath = Path.Combine(path, fileName);

            if (!File.Exists(completePath))
            {
                string header = string.Format("Name,Age");
                sb.AppendLine(header);
            }

            foreach (var dato in dati)
            {
                if (dato is Account account)
                    sb.AppendLine($"{account.Saldo},{account.Saldo}");
                if (dato is Customer customer)
                    sb.AppendLine($"{customer.Name},{customer.Age}");
            }

            File.AppendAllText(completePath, sb.ToString());
        }
        #endregion
        #region tOTAL_gENERIC_mETHODS
        static void CreateGenericAllTypesCsv<T>(string path, string fileName, List<T> data)
        {
            // Works with All Types in the World!
        }
        #endregion

    }
}



