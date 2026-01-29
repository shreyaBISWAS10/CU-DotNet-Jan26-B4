namespace Day19
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public abstract void Move();

        public Vehicle(string MName){
            ModelName = MName;
        }

        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable.";
        }
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[3]
            {
                new ElectricCar("Tata Tiago EV"),
                new HeavyTruck("Tata Prima 5530.S"),
                new CargoPlane("777F")
              
            };
            foreach (var vehicle in vehicles) { 
                vehicle.Move();
                Console.WriteLine(vehicle.GetFuelStatus());
            }
        }
    }
    class ElectricCar : Vehicle
    {
        public ElectricCar(string MName) : base(MName)
        {
        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName}is gliding silently on battery power.");

        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is t 80%.";
        }


    }
    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string MName) : base(MName)
        {
        }
        public override void Move()
        {
            Console.WriteLine( $"{ModelName}is hauling cargo with high-torque diesel power.");

        }



    }
    class CargoPlane : Vehicle
    {
        public CargoPlane(string MName) : base(MName)
        {
        }
        public override void Move()
        { 
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");

        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus()+" Checking jet fuel reserves... ";
        }
    }
    
}
