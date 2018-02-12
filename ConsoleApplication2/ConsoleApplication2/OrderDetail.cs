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
            Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t{4}", this.productdetail.ProductNo, this.productdetail.ProductName, this.quantity, this.amount, this.GrandTotal);
        }
    }
}
