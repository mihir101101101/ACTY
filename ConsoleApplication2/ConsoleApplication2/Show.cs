using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Show
    {
        public static void showAllCustomerName()
        {
            Console.WriteLine("NO\tName\t\tCity");
            foreach (Customer c in Program.AllCustomerDetails)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", c.CustomerNo, c.CustomerName, c.City);
            }
        }

        public static void showAllEmployeeName()
        {
            Console.WriteLine("NO\tName\t\tCity");
            foreach (Employee e in Program.AllEmployeeDetails)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", e.EmployeeNo, e.FirstName + " " + e.LastName, e.City);
            }
        }

        public static void showAllProductName()
        {
            foreach (Product p in Program.AllProductDetails)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", p.ProductNo, p.ProductName, p.UnitPrice, p.IsActive);
            }
        }

        public static void showOrderDetails(int no)
        {
            Console.WriteLine("No\t\tName\t\tUTP\t\tQTY");
            foreach (OrderDetail od in Program.AllOrderDetails)
            {
                if (od.OrderNoRef == no)
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", od.ProductDetail.ProductNo, od.ProductDetail.ProductName, od.UnitPrice, od.Quantity);
            }
        }

        public static void showProductAvilability()
        {
            Console.WriteLine("No\t\tName\t\tAvilability");
            foreach (Product p in Program.AllProductDetails)
            {
                Console.WriteLine(p.ProductNo + "\t\t" + p.ProductName + "\t\t" + p.IsActive);
            }
        }

        public static void showLastCustomer(OrderDetail od)
        {
            Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}", od.ProductDetail.ProductNo, od.ProductDetail.ProductName, od.UnitPrice, od.Quantity, od.Amount, od.DiscountAmount, od.GrandTotal, od.CreatedDate);
        }

        public static void showAllEmployee()
        {
            if (Program.AllEmployeeDetails.Count <= 0)
            {
                Console.WriteLine("No Employee Avilable");
                return;
            }
            Console.WriteLine("NO\tName\t\tAddress\t\tCity\t\tState\tPin Code");
            foreach (Employee e in Program.AllEmployeeDetails)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", e.EmployeeNo, e.FirstName + " " + e.LastName, e.Address, e.City, e.State, e.PstalCode);
            }
        }

        public static void showAllCustomer()
        {
            if (Program.AllCustomerDetails.Count <= 0)
            {
                Console.WriteLine("No Customer Avilable");
                return;
            }
            Console.WriteLine("NO\tName\tAddress\t\tCity\tState\tPin Code\tCountry");
            foreach (Customer c in Program.AllCustomerDetails)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t\t{6}", c.CustomerNo, c.CustomerName, c.Address, c.City, c.State, c.PstalCode, c.Country);
            }
        }

        public static void showAllProduct()
        {
            if (Program.AllProductDetails.Count <= 0)
            {
                Console.WriteLine("No Product Avilable");
                return;
            }
            Console.WriteLine("NO\tName\tPrice\tStatus");
            foreach (Product p in Program.AllProductDetails)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", p.ProductNo, p.ProductName, p.UnitPrice, p.IsActive);
            }
        }

        public static void AllOrder()
        {
            if (Program.AllOrder.Count <= 0)
            {
                Console.WriteLine("No Order Avilable");
                return;
            }
            Console.WriteLine("NO\t\tEmployee Name\t\tCustomer Name\t\tDate");
            foreach (Order o in Program.AllOrder)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", o.OrderNo, o.EmployeeDetail.FirstName + " " + o.EmployeeDetail.LastName, o.CustomerDetail.CustomerName, o.OrderDate);
            }
        }

        public static void showAllOrder()
        {
            if (Program.AllOrder.Count <= 0)
            {
                Console.WriteLine("No Order Avilable");
                return;
            }
            Console.WriteLine("\n\nNO\tCustomer Name\tEmployee Name\tOrder Date\tAddress\t\tCity\tState\tPIN\tCountry\tDate");
            foreach (Order o in Program.AllOrder)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", o.OrderNo, o.CustomerDetail.CustomerName, o.EmployeeDetail.FirstName, o.OrderDate, o.ShipAddress, o.ShipCity, o.ShipState, o.ShipPostalCode, o.ShipCountry, o.CreatedDate);
                Console.WriteLine("\nProduct name\tPrice\tQuantity\tAmount\tDiscount\tTotal\tDate\t\t\tChange Date");
                int no = o.OrderNo;
                foreach (OrderDetail od in Program.AllOrderDetails)
                {
                    if (od.OrderNoRef == no)
                        Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}\t{4}\t\t{5}\t{6}\t{7}", od.ProductDetail.ProductName, od.UnitPrice, od.Quantity, od.Amount, od.DiscountAmount, od.GrandTotal, od.CreatedDate, od.ModifiedDate);
                }
                Console.WriteLine("\n\n\n\n");
            }
        }

    }
}
