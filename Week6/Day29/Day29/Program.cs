namespace Day29
{
    abstract class Appliances
    {
        protected string ModelName;
        protected int Power;

        public Appliances(string modelName, int power)
        {
            ModelName = modelName;
            Power = power;
        }

        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }


    }
    interface ITimer {
        void SetTimer(int minutes);

    }
    interface IConnect
    {
        void ConnectWifi(string networkName);
    }

    class Microwave : Appliances, ITimer
    {
        public Microwave(string modelName, int powerConsumption)
            : base(modelName, powerConsumption)
        {
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Cooking food using microwave radiation.");
        }
    }

    class ElectricOven : Appliances, ITimer, IConnect
    {
        public ElectricOven(string modelName, int powerConsumption)
            : base(modelName, powerConsumption)
        {
        }

        public void ConnectWifi(string networkName)
        {
            Console.WriteLine($"{ModelName}: Connected to WiFi network '{networkName}'.");
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName}: Preheating oven to desired temperature...");
        }

        public override void Cook()
        {
            Preheat();
            Console.WriteLine($"{ModelName}: Baking food evenly.");
        }
    }
    class AirFryer : Appliances
    {
        public AirFryer(string modelName, int powerConsumption)
            : base(modelName, powerConsumption)
        {
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Quickly air-frying food with hot air.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Appliances> appliances = new List<Appliances>
        {
            new Microwave("Samsung Microwave", 1200),
            new ElectricOven("Bosch Electric Oven", 2000),
            new AirFryer("Philips Air Fryer", 1500)
        };

            Console.WriteLine("=== Cooking Process ===\n");

            // Polymorphism: All stored in one list
            foreach (Appliances appliance in appliances)
            {
                appliance.Cook();
                Console.WriteLine();
            }

            Console.WriteLine("=== WiFi Test ===\n");

            foreach (Appliances appliance in appliances)
            {
                if (appliance is IConnect wifiDevice)
                {
                    wifiDevice.ConnectWifi("Home_Network");
                }
                else
                {
                    Console.WriteLine("This device does not support WiFi.");
                }
            }

            Console.WriteLine("\n=== Timer Test ===\n");

            foreach (Appliances appliance in appliances)
            {
                if (appliance is ITimer timerDevice)
                {
                    timerDevice.SetTimer(5);
                }
                else
                {
                    Console.WriteLine("This device does not have a timer.");
                }
            }
        }
    }

}
