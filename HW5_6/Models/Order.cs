using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_6.Models
{
    class Order
    {
        public DateTime OrderDate { get; set; }
        public int AnalysisId { get; set; }
        public Order(int year,int month,int day, int analysisId)
        {
            OrderDate = new DateTime(year, month, day);
            AnalysisId = analysisId;
        }
    }
}
