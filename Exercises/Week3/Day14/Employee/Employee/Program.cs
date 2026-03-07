namespace Employee
{
    enum Department
    {
        Sales,
        Accounts,
        IT
    }

    internal class Person
    {
        private int Id;
        public void SetId(int id)
        {
            this.Id = id;
        }
        public int GetId()
        {
            return Id;
        }

        public string Name { get; set; }

        private Department department;

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 50000 && value <= 90000)
                    salary = value;
                else
                    Console.WriteLine("Salary must be between the specified range");
            }
        }
        public void Display()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Department: " + department);
            Console.WriteLine("Salary: " + salary);
        }

        static void Main(string[] args)
        {

            Person emp = new Person();

            emp.SetId(101);
            emp.Name = "Shreya";
            emp.Department = Department.IT;
            emp.Salary = 75000;

            emp.Display();


        }
    }
}
