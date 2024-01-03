using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doctor.Async.Lesson
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Hospital hospital = new Hospital();

            Patient Bruno = new Patient() { Name = "Bruno" };
            Console.WriteLine($"Sending Patient {Bruno.Name.ToUpper()}...");
            await hospital.DoctorAsyncParallel(Bruno);


            Patient Luca = new Patient() { Name = "Luca" };
            Console.WriteLine($"Sending Patient {Luca.Name.ToUpper()}...");
            await hospital.DoctorAsyncParallel(Luca);


            Console.ResetColor();
            Console.ReadLine();
        }
    }
    public class Patient
    {
        public string Name { get; set; }
    }
    public class Hospital
    {
        public async Task<string> AnalysisLab()
        {
            Console.WriteLine($"AnalysisLab: started");
            await Task.Delay(8000);
            //Console.Out.WriteLine($"-------------------------------");
            return "Blood OK";

        }
        public async Task<string> Radiology()
        {

            Console.WriteLine($"Radiology: started");
            await Task.Delay(12000);
            // Console.Out.WriteLine($"-------------------------------");


            return "TAC OK";
        }


        public async Task DoctorAsyncParallel(Patient patient)
        {

            List<Task<string>> Results = new List<Task<string>>();



            Task<string> RadiologyPromise = Radiology(); //Promise
            Task<string> AnalysisPromise = AnalysisLab(); //Promise

            Results.Add(RadiologyPromise);
            Results.Add(AnalysisPromise);




            WaitAllCheckups(Results, patient);/// Runs Taks in  parallel [ Async noAwait]
            //FluidCheckups(Results, patient);/// Runs Taks in  parallel [ Async noAwait]
            Console.ForegroundColor = ConsoleColor.Yellow;

            await Task.Run(async () =>
            {

                // Do a long task here while others tasks are running in parallel!  s
                Console.WriteLine($"DOCTOR CHECKUP -  STARTED for {patient.Name.ToUpper()}");
                await Task.Delay(new Random().Next(5000, 10000));
            });

            Console.WriteLine($"DOCTOR CHECKUP - FINISHED for {patient.Name.ToUpper()}");


            Console.ResetColor();
            // WaitAllCheckupsAndDismiss(patient);
            //  Console.WriteLine($"-------------------------------");


        }

        public async void WaitAllCheckups(List<Task<string>> tasks, Patient patient)
        {
            Console.WriteLine($"WaitAllCheckups:: STARTED for {patient.Name.ToUpper()}");

            Console.Out.WriteLine($"...Awaiting for All the exames to complete for {patient.Name.ToUpper()}...");

            var result = await Task.WhenAll(tasks); // Json  

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Out.WriteLine($"{result[0]} for {patient.Name.ToUpper()} ");
            Console.Out.WriteLine($"-------------------------------");

            Console.Out.WriteLine($"{result[1]} for {patient.Name.ToUpper()}");
            Console.Out.WriteLine($"-------------------------------");
            Console.ResetColor();
            Console.WriteLine($"WaitAllCheckups:: FINISHED for {patient.Name.ToUpper()}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{patient.Name.ToUpper()} CAN GO HOME!");
            Console.ResetColor();

        }
        public async void FluidCheckups(List<Task<string>> tasks, Patient patient)
        {
            Console.WriteLine($"FluidCheckups:: STARTED for {patient.Name.ToUpper()}");

            while (tasks.Count > 0)
            {

                Console.Out.WriteLine($"Awaiting for any of the remaining exames to complete  for {patient.Name.ToUpper()}...");

                Task<string> finishedTask = await Task.WhenAny(tasks);

                string result = await finishedTask;

                if (result == "TAC OK")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{result} for {patient.Name.ToUpper()}");

                    Console.ResetColor();
                }
                else if (result == "Blood OK")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{result} for {patient.Name.ToUpper()}");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                //Console.WriteLine($"-------------------------------");
                Console.ResetColor();

                // Remove the completed task from the list
                tasks.Remove(finishedTask);
            }

            Console.WriteLine($"FluidCheckups Finished for {patient.Name.ToUpper()}");


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{patient.Name.ToUpper()} CAN GO HOME!");
            Console.ResetColor();

            Console.WriteLine($"-------------------------------");


        }
    }
}
