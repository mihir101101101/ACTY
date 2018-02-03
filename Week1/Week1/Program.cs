using System;
using System.Collections;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Employee  {
        private int employeeno;
        private string firstname;
        private string lastname;
        private string address;
        private string city;
        private string state;
        private int postalcode;

        public int EmployeeNo { get { return employeeno; } set { employeeno = value; } }
        public string FirstName { get { return firstname; } set { firstname = value; } }
        public string LastName { get { return lastname; } set { lastname = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public int PstalCode { get { return postalcode; } set { postalcode = value; } }
    }

    class Product   {
        private int productno;
        private string productname;
        private int unitprice;
        private bool isactive;

        public int ProductNo { get { return productno; } set { productno = value; } }
        public string ProductName { get { return productname; } set {productname = value; } }
        public int UnitPrice { get { return unitprice; } set { unitprice = value; } }
        public bool IsActive { get { return isactive; } set { isactive = value; } }
    }

    class Customer  {
        private int customerno;
        private string customername;
        private string address;
        private string city;
        private string state;
        private int postalcode;
        private string country;


        public int CustomerNo { get { return customerno; } set { customerno = value; } }
        public string CustomerName { get { return customername; } set { customername = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public int PstalCode { get { return postalcode; } set { postalcode = value; } }
        public string Country { get { return country; } set { country = value; } }
    }
    
    class Order {
        private int orderno;
        private Customer customerdetail;
        private Employee employeedetail;
        private string orderdate;
        private string shipname;
        private string shipaddress;
        private string shipcity;
        private string shipstate;
        private int shippostalcode;
        private string shipcountry;
        private DateTime createddate;
        private DateTime modifieddate;
       

        public int OrderNo { get { return orderno; } set { orderno = value;} }
        public Customer CustomerDetail { get { return customerdetail; } set { customerdetail = value; } }
        public Employee EmployeeDetail { get { return employeedetail; } set { employeedetail = value; } }
        public string OrderDate { get { return orderdate; } set { orderdate = value; } }
        public string ShipAddress { get { return shipaddress; } set { shipaddress = value; } }
        public string ShipName { get { return shipname; } set { shipname = value; } }
        public string ShipCity { get { return shipcity; } set { shipcity = value; } }
        public string ShipState { get { return shipstate; } set { shipstate = value; } }
        public int ShipPostalCode { get { return shippostalcode; } set { shippostalcode = value; } }
        public string ShipCountry { get { return shipcountry; } set { shipcountry = value; } }
        public DateTime CreatedDate { get { return createddate; } set { createddate = value; } }
        public DateTime ModifiedDate { get { return modifieddate; } set { modifieddate = value; } }
    }

    class OrderDetail
    {
        private Product productdetail;
        private int unitprice;
        private int quantity;
        private int amount;
        private int discountamount;
        private int grandtotal;
        private DateTime createddate;
        private DateTime modifieddate;

        public Product ProProductDetail { get { return productdetail; } set { productdetail = value; } }
        public int UnitPrice { get { return unitprice; } set { unitprice = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int Amount { get { return amount; } set { amount = value; } }
        public int DiscountAmount { get { return discountamount; } set { discountamount = value; } }
        public int GrandTotal { get { return grandtotal; } set { grandtotal = value; } }
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

    class Program
    {
        public static ArrayList AllCustomerDetails = new ArrayList();
        public static ArrayList AllEmployeeDetails = new ArrayList();
        public static ArrayList AllProductDetails = new ArrayList();
        public static ArrayList AllOrder = new ArrayList();
        public static ArrayList AllOrderDetails = new ArrayList();

        static Tuple<bool, int> CheckAvilability(string name, string InWhich)
        {
            if (InWhich == "Employee")
            {
                int i = 0;
                foreach (Employee loop_e in AllEmployeeDetails)
                {
                    if ((loop_e.FirstName + " " + loop_e.LastName).Equals(name))
                        return new Tuple<bool, int>(true,i);
                    i++;
                }
            }
            else if (InWhich == "Customer")
            {
                int i = 0;
                foreach (Customer loop_c in AllCustomerDetails)
                {
                    if (loop_c.CustomerName.Equals(name))
                        return new Tuple<bool, int>(true, i);
                    i++;
                }
            }
            else if (InWhich == "Product")
            {
                int i = 0;
                foreach(Product loop_p in AllProductDetails)
                {
                    if(loop_p.ProductName.Equals(name))
                        return new Tuple<bool, int>(true, i);
                    i++;
                }
            }
            return new Tuple<bool, int>(false, 0);
        }

        static void AddOrder()
        {
            Console.Write("Order Number : ");
            int O_no = Convert.ToInt32(Console.ReadLine());

            int len = AllEmployeeDetails.Count;
            
            Order o = new Order();
            o.OrderNo = O_no;
            o.CustomerDetail = AddCustomerDetails(); ;
            o.EmployeeDetail = AddEmployeeDetails(); ;
            o.OrderDate = DateTime.Now.ToString("dd/mm/yyyy");
            o.ShipName = o.CustomerDetail.CustomerName;
            o.ShipAddress = o.CustomerDetail.Address;
            o.ShipCity = o.CustomerDetail.City;
            o.ShipState = o.CustomerDetail.State;
            o.ShipPostalCode = o.CustomerDetail.PstalCode;
            o.ShipCountry = o.CustomerDetail.Country;
            o.CreatedDate = DateTime.Today;
            o.ModifiedDate = DateTime.Today;

            AllOrder.Add(o);
        }

        static Customer AddCustomerDetails()
        {
            Console.WriteLine("\n\n\t\t\t\tCustomer Details : ");
            Console.WriteLine("==================================================");

            int C_no = AllCustomerDetails.Count + 1;

            Console.Write("Enter Name : ");
            string C_name = Console.ReadLine().ToLower();

            var t = CheckAvilability(C_name, "Customer");

            if (t.Item1)
            {
                return (Customer)AllCustomerDetails[t.Item2];
            }

            Console.Write("Enter Address : ");
            string C_addr = Console.ReadLine();

            Console.Write("Enter City : ");
            string C_city = Console.ReadLine();

            Console.Write("Enter State : ");
            string C_state = Console.ReadLine();

            Console.Write("Enter Postal Code : ");
            int C_postal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Country : ");
            string C_country = Console.ReadLine();

            Customer c = new Customer();
            c.CustomerNo = C_no;
            c.CustomerName = C_name;
            c.Address = C_addr;
            c.City = C_city;
            c.State = C_state;
            c.PstalCode = C_postal;
            c.Country = C_country;

            AllCustomerDetails.Add(c);
            return c;
        }

        static Employee AddEmployeeDetails()
        {
            Console.WriteLine("\n\n\t\t\t\tEmployee Details : ");
            Console.WriteLine("==================================================");

            int E_no = AllEmployeeDetails.Count + 1;

            Console.Write("Enter First Name : ");
            string E_fname = Console.ReadLine().ToLower();

            Console.Write("Enter Last Name : ");
            string E_lname = Console.ReadLine().ToLower();

            string E_name = E_fname + " " + E_lname;

            var t = CheckAvilability(E_name, "Employee");

            if (t.Item1)
            {
                return (Employee)AllEmployeeDetails[t.Item2];
            }

            Console.Write("Enter Address : ");
            string E_addr = Console.ReadLine();

            Console.Write("Enter City : ");
            string E_city = Console.ReadLine();

            Console.Write("Enter State : ");
            string E_state = Console.ReadLine();

            Console.Write("Enter Postal Code : ");
            int E_postal = Convert.ToInt32(Console.ReadLine());

            Employee e = new Employee();
            e.EmployeeNo = E_no;
            e.FirstName = E_fname;
            e.LastName = E_lname;
            e.Address = E_addr;
            e.City = E_city;
            e.State = E_state;
            e.PstalCode = E_postal;

            AllEmployeeDetails.Add(e);
            return e;
        }

        static Product AddProduct()
        {
            Console.WriteLine("\n\n\t\t\t\tProduct Details : ");
            Console.WriteLine("==================================================");

            int P_no = AllProductDetails.Count + 1;

            Console.Write("Enter Product Name : ");
            string P_name = Console.ReadLine().ToLower();

            var t = CheckAvilability(P_name, "Product");

            if (t.Item1)
            {
                return (Product)AllProductDetails[t.Item2];
            }

            Console.Write("Enter Unit Price : ");
            int P_unit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Is Product Active( Yes/No ) : ");
            string ch = Console.ReadLine().ToLower();

            bool P_active = false;

            if(ch.Equals("yes"))
                P_active = true;

            Product p = new Product();
            p.ProductNo = P_no;
            p.ProductName = P_name;
            p.UnitPrice = P_unit;
            p.IsActive = P_active;

            AllProductDetails.Add(p);
            return p;
        }

        static void AddOrderDetails()
        {
            OrderDetail od = new OrderDetail();
            od.ProProductDetail = AddProduct();

            Console.WriteLine("\n\n\t\t\t\tOrder Details : ");
            Console.WriteLine("==================================================");
          
            Console.Write("Enter Quantity : ");
            int OD_quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Discount : ");
            int OD_discount = Convert.ToInt32(Console.ReadLine());

            DateTime OD_create = DateTime.Now;
            DateTime OD_modifi = DateTime.Now;

            
            od.UnitPrice = od.ProProductDetail.UnitPrice;
            od.Quantity = OD_quantity;
            od.Amount = od.ProProductDetail.UnitPrice * OD_quantity;
            od.DiscountAmount = OD_discount;
            od.GrandTotal = od.Amount - OD_discount;
            od.CreatedDate = OD_create;
            od.ModifiedDate = OD_modifi;

            AllOrderDetails.Add(od);
            od.Show();
        }

        

        static void UpadteOrder()
        {

        }

        static void DeleteOrder()
        {

        }

        static void Main(string[] args)
        {
            int input;
            do
            {
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. Exit");

                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AddOrder();
                        AddOrderDetails();
                        Console.ReadKey();
                        break;
                    case 2:
                        UpadteOrder();
                        break;
                    case 3:
                        DeleteOrder();
                        break;
                }
            } while (input != 4);
        }
    }
}
