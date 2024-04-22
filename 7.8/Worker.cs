using System;



namespace _7._8
{
     struct Worker
    {
        private static readonly Repository repository = new Repository();

        public int id { get; set; }
        public DateTime dateTime { get; set; }

        public string FIO { get; set; }

        public int age { get; set; }

        public int height { get; set; }

        public DateTime dateOfBirth { get; set; }

        public string placeOfBirth { get; set; }

        public Worker(int id, string FIO, int age, int height, DateTime dateOfBirth, string placeOfBirth)
        {
            this.id = id;
            this.dateTime = DateTime.Now;
            this.FIO = FIO;
            this.height = height;
            this.age = age;
            this.placeOfBirth = placeOfBirth;
            this.dateOfBirth = dateOfBirth;
        }

        public Worker(string FIO, int age, int height, DateTime DateBirth, string placeBirth) :
                 this(0, FIO, age, height, DateBirth, placeBirth)
        {
            
        }
  
    
    
}
    
}
