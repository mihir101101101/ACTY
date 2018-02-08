using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class OrderDetail
    {
        private int ordernoref;
        private Product productdetail;
        private double unitprice;
        private int quantity;
        private double amount;
        private double discountamount;
        private double grandtotal;
        private DateTime createddate;
        private DateTime modifieddate;

        public int OrderNoRef { get { return ordernoref; } set { ordernoref = value; } }
        public Product ProductDetail { get { return productdetail; } set { productdetail = value; } }
        public double UnitPrice { get { return unitprice; } set { unitprice = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public double DiscountAmount { get { return discountamount; } set { discountamount = value; } }
        public double GrandTotal { get { return grandtotal; } set { grandtotal = value; } }
        public DateTime CreatedDate { get { return createddate; } set { createddate = value; } }
        public DateTime ModifiedDate { get { return modifieddate; } set { modifieddate = value; } }

        public void Show()
        {
            Console.WriteLine("Name             : {0}", this.productdetail.ProductName);
            Console.WriteLine("Unite Price      : {0}", this.unitprice);
            Console.WriteLine("Quantity         : {0}", this.quantity);
            Console.WriteLine("Amount           : {0}", this.amount);
            Console.WriteLine("Discount         : {0}", this.discountamount);
            Console.WriteLine("Total            : {0}", this.GrandTotal);
            Console.WriteLine("Create Date      : {0}", this.CreatedDate);
            Console.WriteLine("Modified Date    : {0}", this.modifieddate);
            Console.WriteLine("Product Avilable : {0}", this.productdetail.IsActive);
        }
    }
}
