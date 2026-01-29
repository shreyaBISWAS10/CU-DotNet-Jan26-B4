using System;

namespace Day1502
{
    internal class Order
    {
        //Private Fields
        private int _orderId;
        private string _customerName;
        private decimal _totalAmount;
        private bool _discountApplied;

        //Constructors
        public Order()
        {
            orderDate = DateTime.Today;
            orderStatus = "NEW";
            _totalAmount = 0;
            _discountApplied = false;
        }

        public Order(int orderId, string customerName) : this()
        {
            _orderId = orderId;
            CustomerName = customerName;
        }

        //Properties 
        public int OrderId
        {
            get { return _orderId; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Customer name cannot be empty");

                _customerName = value;
            }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }

        public DateTime orderDate { get; set; }
        public string orderStatus { get; set; }

        // Instance Methods 
        public void AddItem(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Item price must be positive");

            _totalAmount += price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (_discountApplied)
                throw new InvalidOperationException("Discount already applied");

            if (percentage < 1 || percentage > 30)
                throw new ArgumentException("Discount must be between 1 and 30");

            _totalAmount -= (_totalAmount * percentage / 100);
            _discountApplied = true;
        }

        public string GetOrderSummary()
        {
            return $"Order Id: {_orderId}\n" +
                   $"Customer: {_customerName}\n" +
                   $"Total Amount: {_totalAmount}\n" +
                   $"Status: {orderStatus}";
        }

       
        static void Main(string[] args)
        {
            Order order = new Order(101, "Rahul");

            order.AddItem(500);
            order.AddItem(300);
            order.ApplyDiscount(10);

            Console.WriteLine(order.GetOrderSummary());
        }
    }
}
