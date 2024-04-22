using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            //repository.AddStreamReader();
            Console.WriteLine(
                "Введите 1, чтоб вывести все данные на экран\n" +
                "Введите 2, чтоб получить работника по Id\n" +
                "Введите 3, чтобы дополнить данные\n" +
                "Введите 4, чтобы удалить сотрудника по Id\n" +
                "Введите 5  для сортировки по выбранному параметру\n" +
                "Введите 6 для вывода сотрудников родившихся в определенном периоде времени)");
            string workMode = Console.ReadLine();


        

            switch (workMode)
            {
                case "3":
                    Console.WriteLine("Введите имя нового сотрудника");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите возраст сотрудника");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите рост сотрудника");
                    int height = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите дату рождения в формате гггг.мм.дд");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите место рождения");
                    string birthPlace = Console.ReadLine();
                    Worker worker = new Worker(name, age, height, birthDate, birthPlace);
                    repository.AddWorker(worker);
                    break;
                case "4":
                    Console.WriteLine("Введите Id");
                    repository.DeleteWorker(Console.ReadLine());
                    break;
                case "1":
                    repository.PrintWorkers(repository.workers);
                    break;
                case "2":
                    Console.WriteLine("Введите Id");
                    List<Worker> workerById = (List<Worker>)repository.GetWorkerById(int.Parse(Console.ReadLine()));
                    if (workerById != null)
                    {
                        repository.PrintWorkers(workerById);
                    }
                    else
                    {
                        Console.WriteLine("Такого работника нет");
                    }
                    break;
                case "5":

                    Console.WriteLine("Введите имя поля");
                    List<Worker> sortedWorkers = repository.workers;
                    string sortPara = Console.ReadLine();
                    //repository.workers.Sort(new Comparison<Worker>((x, y) => String.Compare(x.Name, y.Name)))
                    switch (sortPara)
                    {
                        case "Name":
                            sortedWorkers = sortedWorkers.OrderBy(x => x.FIO).ToList();
                            break;
                        case "DateOfBirth":
                            sortedWorkers = sortedWorkers.OrderBy(x => x.dateOfBirth).ToList();
                            break;
                        case "PlaceOfBirth":
                            sortedWorkers = sortedWorkers.OrderBy(x => x.placeOfBirth).ToList();
                            break;
                    }

                    repository.PrintWorkers(sortedWorkers);
                    break;

                case "6":
                    Console.WriteLine("Введите дату 1 в формате гггг.мм.дд.");
                    DateTime dateFrom = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите дату 2 в формате гггг.мм.дд.");
                    DateTime dateTo = DateTime.Parse(Console.ReadLine());

                    repository.PrintWorkers(repository.GetWorkersBetweenTwoDates(dateFrom, dateTo));
                    break;

            }

            Console.ReadKey();
        }
    }
}