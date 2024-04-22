using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _7._8
{
    class Repository
    {

       private string fileName = "EmployeesData.txt";


        public List<Worker> workers { get; set; }

       
        public Repository()
        {
            
        
        workers = GetAllWorkers();
        }
       



        public int GetNewId()

        {
            string line = "";

            if (!System.IO.File.Exists(fileName))
            {
                return 1;
            }

            if (System.IO.File.ReadAllLines(fileName).Length == 0)
            {
                return 1;
            }
            string[] lastLine = File.ReadLines(fileName).Last().Split('#');
            int id = Convert.ToInt32(lastLine[0]) +1;
            return id;
        }
      
        public void PrintWorkers(List<Worker> workersList)
        {
            if(File.Exists(fileName))
            {
                foreach(Worker worker in workersList) {
              
                  string data =
                     worker.id + "#" +
                     worker.dateTime + "#" +
                     worker.FIO + "#" +
                     worker.age + "#" +
                     worker.height + "#" +
                     worker.dateOfBirth + "#" +
                     worker.placeOfBirth;
                    Console.WriteLine(data.Replace("#"," "));

                }
            }
            else
            {
                Console.WriteLine("Файл не существует");
            }
        }
        
        public List<Worker> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();
            string line = "";
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] dataLine = line.Split('#');
                        int id = int.Parse(dataLine[0]);
                        DateTime dateTime = DateTime.Parse(dataLine[1]);
                        string FIO = dataLine[2];
                        int age = int.Parse(dataLine[3]);
                        int height = int.Parse(dataLine[4]);
                        DateTime dateOfBirth = DateTime.Parse(dataLine[5]);
                        string placeOfBirth = dataLine[6];
                        Worker worker = new Worker(id,FIO,age,height,dateOfBirth,placeOfBirth);

                        workers.Add(worker);
                    }

                }
            }
                
           
            return workers;
            
        }

        public object GetWorkerById(int id)
        {
            List<Worker>workerId = new List<Worker>();
            foreach(Worker worker in workers)
            {
                if (worker.id == id)
                {

                    workerId.Add(worker);
                    return workerId;
                }
            }
            return null;
        }

        public void DeleteWorker(string id)
        {
            string line = "";
            List<string> data = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string lineId = line.Split('#')[0];
                    if (lineId != id)
                    {
                        data.Add(line);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (string workerId in data)
                {

                    sw.WriteLine(workerId);

                }
            }

            }
            
        

        public void AddWorker(Worker worker)
        {
            worker.id = GetNewId();
            string employeeData =
                worker.id + "#" +
                worker.dateTime + "#" +
                worker.FIO + "#" +
                worker.age + "#" +
                worker.height + "#" +
                worker.dateOfBirth + "#" +
                worker.placeOfBirth;
            using(StreamWriter sw = new StreamWriter(fileName, append:true))
            {
                sw.WriteLine(employeeData);
            }
            
        }

        public List<Worker> GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo) { 
     
            List<Worker> sortedWorkers = new List<Worker>();
            foreach(Worker worker in workers)
            {
                if((worker.dateOfBirth> dateFrom) && (worker.dateOfBirth < dateTo))
                {
                    sortedWorkers.Add(worker);
                }
            }
            return sortedWorkers ;
            
        }
    }
}

