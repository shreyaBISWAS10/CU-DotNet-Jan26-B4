using System.Diagnostics.CodeAnalysis;

namespace Week4Assessment
{
    class Inpatient : Patient
    {
        public int DaysStayed {  get; set; }
        public decimal DailyRate {  get; set; }

        public Inpatient(string name, decimal basefee, int daysstayed,decimal dailyrate) : base(name, basefee)
        {
            DailyRate = dailyrate;
            DaysStayed = daysstayed;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
    }
    class OutPatient : Patient
    {
        public decimal ProcedureFee {  get; set; }
        public OutPatient(string name, decimal basefee, decimal procedurefee) : base(name, basefee)
        {
           ProcedureFee = procedurefee;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }
    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }
        public EmergencyPatient(string name, decimal basefee, int severitylevel) : base(name, basefee)
        {
            SeverityLevel= severitylevel;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }

    }
    class HospitalBilling
    {
        private List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
        public void GenerateDailyReport()
        {
            foreach (Patient p in patients)
            {
               
                Console.WriteLine(
                    $"{p.Name}\t - {p.CalculateFinalBill().ToString("C2")}"
                );
            }

        }
        public decimal CalculateTotalRevenue()
        {
            decimal sum = 0;
            foreach (Patient p in patients)
            {
                sum += p.CalculateFinalBill();
            }
            return sum;
        }
        public int GetInpatientCount()
        {
            int cnt = 0;
            foreach (Patient p in patients)
            {
               if(p is Inpatient){
                    cnt++;
                }
            }
            return cnt;

        }
    }
    internal class Patient
    {
        public string Name {  get; set; }
        public decimal BaseFee { get; set; }

        public Patient(string name, decimal basefee)
        {
            Name = name;
            BaseFee = basefee;
        }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
        public Patient()
        {

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            HospitalBilling billing = new HospitalBilling();
            billing.AddPatient(new Inpatient("Suzanne", 2000, 3, 1500));
            billing.AddPatient(new OutPatient("Samaira", 1000, 3500));
            billing.AddPatient(new EmergencyPatient("Kabeer", 500, 5));
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Daily Report:");
            billing.GenerateDailyReport();
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Total Revenue is : {billing.CalculateTotalRevenue()}");
            Console.WriteLine($"Total Inpatient Count is : {billing.GetInpatientCount()}");


                

        }
    }
}
