using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using Week5Assessment;

namespace Week5Assessment
{
    public class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; }
        public RestrictedDestinationException(string location) : base($"Shipment to {location} is restricted.") 
        {
            DeniedLocation = location;
        }
    }
    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message) { }
    }

    public abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        static List<string> restrictedZones = new List<string> {
           "Unknown Island",
           "North Pole"
        };
        public Shipment() { }

        public Shipment(string trackingId, double weight, string destination,bool fragile,bool reinforced)
        {
           
            TrackingId = trackingId;
            Weight = weight;
            Destination = destination;
            IsFragile = fragile;
            IsReinforced = reinforced;

 
        }

        public abstract void ProcessShipment();

        protected void ValidateShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException($"Weight must be greater than zero. Shipment: {TrackingId}");

            if (IsFragile && !IsReinforced)
                throw new InsecurePackagingException($"Fragile shipment must be reinforced. Shipment: {TrackingId}");

            if (restrictedZones.Contains(Destination))
                throw new RestrictedDestinationException(Destination);
        }


    }
    public class ExpressShipment : Shipment
    {
        public ExpressShipment(string id, double weight, string destination,bool fragile, bool reinforced) : base(id, weight, destination,fragile,reinforced) { }

        public override void ProcessShipment()
        {
            ValidateShipment();
            Console.WriteLine($"Express shipment {TrackingId} processed quickly.");
        }


    }
    public class HeavyFreight: Shipment{
        public bool HasHeavyLiftPermit { get; set; }
        public HeavyFreight(string id, double weight, string destination, bool permit,bool fragile, bool reinforced) : base(id, weight, destination,fragile,reinforced)
        {
            HasHeavyLiftPermit = permit;
        }
        public override void ProcessShipment()
        {
            ValidateShipment();
            if (Weight > 1000 && !HasHeavyLiftPermit)
                throw new Exception($"Heavy lift permit required.Shipment: {TrackingId}");

            Console.WriteLine($"Heavy freight {TrackingId} processed successfully.");
        }
    }
    public interface ILoggable
    {
        void SaveLog(String message) { }

    }
    class LogManager : ILoggable
    {
        static string file = "shipment_audit.log";
        static string directory = @"..\..\..\";
        static string filePath = Path.Combine(directory, file);
        public void  SaveLog(string message) {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now}:{message}");

            }

        }
       
    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager logger = new LogManager();
            List<Shipment> shipments = new List<Shipment>();
            try
            {
                shipments.Add(new ExpressShipment("EXP001", 200, "Delhi",true,true));
                shipments.Add(new HeavyFreight("HVY001", 1500, "Mumbai", false,false,false));
                shipments.Add(new ExpressShipment("EXP002", -5, "Chennai",false,false));
                shipments.Add(new ExpressShipment("EXP003", 100, "North Pole",false,false));
                shipments.Add(new ExpressShipment("EXP004", 999, "Kolkata",true,false));
            }
            catch (Exception ex)
            {
                logger.SaveLog($"Initialization Error: {ex.Message}");
            }
            foreach (var shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog($"Shipment {shipment.TrackingId} processed successfully.");
                }
                catch (RestrictedDestinationException ex)
                {
                    logger.SaveLog($"Security Alert: {ex.DeniedLocation}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.SaveLog($"Data Entry Error: {ex.Message}");
                }
                catch (InsecurePackagingException ex)
                {
                    logger.SaveLog($"Packaging Error:  {ex.Message}");
                }
                catch (Exception ex)
                {
                    logger.SaveLog($"General Error: {ex.Message}");
                }


                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {shipment.TrackingId}");
                }
            }
        }
    }
}
