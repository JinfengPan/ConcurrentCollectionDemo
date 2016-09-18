//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ConcurrentDemo
//{
//    public class StockControllerk
//    {
//        ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();
//        int _totalQuantityBought;
//        int _totalQuantitySold;
//        private ToDoQueue _toDoQueue;

//        public StockController(ToDoQueue bonusCalculator)
//        {
//            this._toDoQueue = bonusCalculator;
//        }


//        public void BuyStock(SalesPerson person, string item, int quantity)
//        {
//            _stock.AddOrUpdate(item, quantity, (key, oldValue) => oldValue + quantity);
//            Interlocked.Add(ref _totalQuantityBought, quantity);
//            _toDoQueue.AddTrade(new Trade(person, -quantity));
//        }

//        public bool TrySellItem(SalesPerson person, string item)
//        {
//            bool success = false;
//            int newStockLevel = _stock.AddOrUpdate(item,
//                (itemName) =>
//                {
//                    success = false;
//                    return 0;
//                },
//                (itemName, oldValue) =>
//                {
//                    if (oldValue == 0)
//                    {
//                        success = false;
//                        return 0;
//                    }
//                    else
//                    {
//                        success = true;
//                        return oldValue - 1;
//                    }
//                });

//            if (success)
//            {
//                Interlocked.Increment(ref _totalQuantitySold);

//                _toDoQueue.AddTrade(new Trade(person, 1));
//            }
               

//            return success;

//        }

//        public bool TrySellItem2(string item)
//        {
//            int newStockLevel = _stock.AddOrUpdate(item, -1, (key, oldValue) => oldValue - 1);

//            if (newStockLevel < 0)
//            {
//                _stock.AddOrUpdate(item, 1, (key, oldValue) => oldValue + 1);
//                return false;
//            }
//            else
//            {
//                Interlocked.Increment(ref _totalQuantitySold);
//                return true;
//            }
//        }

//        public void DisplayStatus()
//        {
//            int totalStock = _stock.Values.Sum();
//            Console.WriteLine("\r\nBought = " + _totalQuantityBought);
//            Console.WriteLine("Sold = " + _totalQuantitySold);
//            Console.WriteLine("Stock = " + totalStock);

//            int error = totalStock + _totalQuantitySold - _totalQuantityBought;

//            if(error == 0)
//                Console.WriteLine("Stock levels match");
//            else
//            {
//                Console.WriteLine("Error in stock level: "+ error);
//            }

//            Console.WriteLine();
//            Console.WriteLine("Stock levels by item:");
//            foreach (var itemName in Program.AllShirtNames)
//            {
//                int stockLevel = _stock.GetOrAdd(itemName, 0);
//                Console.WriteLine("{0, -30}: {1}", itemName,stockLevel);
//            }
//        }
//    }

//    public class Trade
//    {
//        public SalesPerson Person { get; private set; }

//        public int QuantitySold { get; private set; }
//        public Trade(SalesPerson person, int quantitySold)
//        {
//            this.Person = person;
//            this.QuantitySold = quantitySold;
//        }
//    }
//}
