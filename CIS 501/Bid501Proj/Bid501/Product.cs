using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501
{
    public enum ProductStatus
    {
        open,
        closed,
        sold
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal CurrentBid { get; set; }
        public int BidCount { get; set; }
        //public DateTime TimeRemaining { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Second { get; set; }
        public ProductStatus Status { get; set; }


        public Product(string title, decimal price, int bidCount, int d, int h, int s, ProductStatus status)
        {
            Name = title;
            CurrentBid = price;
            BidCount = bidCount;
            Day = d;
            Hour = h;
            Second = s;
            //TimeRemaining = timeRemaining;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Name},{CurrentBid},{BidCount},{Day},{Hour},{Second},{Status}";
        }
    }
}
