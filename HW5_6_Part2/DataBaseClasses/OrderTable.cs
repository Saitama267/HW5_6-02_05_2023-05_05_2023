using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_6_Part2.DataBaseClasses
{
    class OrderTable
    {
        private HW_3DB _dbContext;
        public OrderTable()
        {
            _dbContext = new HW_3DB();
        }

        public void OrderInsert(Orders order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
        public void OrderDelete(int id)
        {
            Orders order = _dbContext.Orders.FirstOrDefault(s => s.Ord_id == id);
   
            if (order != null)
            {
                
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
            else
            {

                throw new Exception("Order doesn't exist!");
            }
        }

        public void OrderUpdate(int id, Orders ord)
        {
            Orders order = _dbContext.Orders.FirstOrDefault(s => s.Ord_id == id);

            if (order != null)
            {
                order.Ord_datetime = ord.Ord_datetime;
                order.Ord_an= ord.Ord_an;

                _dbContext.SaveChanges();
            }
            else
            {

                throw new Exception("Student doesn't exist!");
            }
        }
        public void Show(int year)
        {
            Console.WriteLine("Id\t\tDate\t\tAnalysisId");
            Console.WriteLine("\n------------------------------------\n");
            foreach (var order in _dbContext.Orders)
            {
                if (order.Ord_datetime.Value.Year==year)
                {
                    Console.WriteLine($"{order.Ord_id}\t\t{order.Ord_datetime}\t\t{order.Ord_an}");
                }
               
                
            }
            Console.WriteLine("\n------------------------------------\n");
        }
    }
}
