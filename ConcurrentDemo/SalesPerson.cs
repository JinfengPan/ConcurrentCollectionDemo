//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Xml;

//namespace ConcurrentDemo
//{
//    public class SalesPerson
//    {
//        public string Name { get; set; }

//        public SalesPerson(string name)
//        {
//            this.Name = name;
//        }

//        public void Work(StockController controller, TimeSpan workDay)
//        {
//            Random rand = new Random(Name.GetHashCode());
//            DateTime start = DateTime.Now;

//            while (DateTime.Now - start < workDay)
//            {
//                bool buy = (rand.Next(6) == 0);
//                string itemName = Program.AllShirtNames[rand.Next(Program.AllShirtNames.Count)];

//                if (buy)
//                {
//                    int quantity = rand.Next(9) + 1;
//                    controller.BuyStock(this, itemName, quantity);
//                    DisplayPurchase(itemName, quantity);


//                }
//                else
//                {
//                    bool success = controller.TrySellItem(this, itemName);
//                    DisplaySaleAttempt(success, itemName);
//                }
//            }

//            Console.WriteLine("SalesPerson {0} signing off", this.Name);
//        }


//        public void DisplayPurchase(string itemName, int quantity)
//        {
//            Console.WriteLine("Thread {0}: {1} bought {2} of {3}", Thread.CurrentThread.ManagedThreadId, this.Name, quantity, itemName);
//        }

//        public void DisplaySaleAttempt(bool success, string itemName)
//        {
//            int ThreadId = Thread.CurrentThread.ManagedThreadId;

//            if(success)
//                Console.WriteLine((string.Format("Thread {0}: {1} sold {2}", ThreadId, this.Name, itemName)));
//            else
//            {
//                Console.WriteLine(string.Format("Thread {0}; {1}: Out of stock of {2}", ThreadId, this.Name, itemName));
//            }

//        }
//    }
//}
