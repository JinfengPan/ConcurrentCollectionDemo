//using System;
//using System.Collections.Concurrent;
//using System.Threading;

//namespace ConcurrentDemo
//{
//    public class ToDoQueue
//    {
//        private readonly BlockingCollection<Trade> _queue 
//            = new BlockingCollection<Trade>(new ConcurrentQueue<Trade>());

//        private bool _workingDayComplete = false;
//        private readonly StaffLogsForBonuses _staffLogs;

//        public ToDoQueue(StaffLogsForBonuses staffResults)
//        {
//            _staffLogs = staffResults;
//        }




//        public void AddTrade(Trade transaction)
//        {
//            _queue.Add(transaction);


//        }

//        public void CompleteAdd()
//        {
//            _queue.CompleteAdding();
//        }

//        public void MonitorAndLogTrades()
//        {
//            try
//            {
//                Trade nextTransaction = _queue.Take();
//                _staffLogs.ProcessTrade(nextTransaction);
//                Console.WriteLine("Processing transaction from " + nextTransaction.Person.Name);
//            }
//            catch (InvalidOperationException ex)
//            {
//                Console.WriteLine(ex.Message);

//                return;
//            }
//        }
//    }
//}