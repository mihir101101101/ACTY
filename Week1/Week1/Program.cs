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

        public Order(int no, Customer c, Employee e)
        {
            this.orderno = no;
            this.customerdetail = c;
            this.employeedetail = e;
            this.orderdate = DateTime.Today.ToString("dd-MM-yyyy");
            this.shipname = c.CustomerName;
            this.shipaddress = c.Address;
            this.shipcity = c.City;
            this.shipstate = c.State;
            this.shippostalcode = c.PstalCode;
            this.shipcountry = c.Country;
            this.createddate = DateTime.Now;
            this.modifieddate = DateTime.Now;            
        }
       
        public int OrderNo { get { return orderno; } set { orderno = value;} }
        public Customer CustomerDetail { get { return customerdetail; } set { customerdetail = value; } }
        public Employee EmployeeDetail { get { return employeedetail; } set { employeedetail = value; } }
        public string OrderDate { get { return orderdate; } set { orderdate = value; } }
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
        private Product[] productdetail;
        private int unitprice;
        private int quantity;
        private int amount;
        private int discountamount;
        private int grandtotal;
        private DateTime createddate;
        private DateTime modifieddate;

        public Product[] ProProductDetail { get { return productdetail; } set { productdetail = value; } }
        public int UnitPrice { get { return unitprice; } set { unitprice = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int Amount { get { return amount; } set { amount = value; } }
        public int DiscountAmount { get { return discountamount; } set { discountamount = value; } }
        public int GrandTotal { get { return grandtotal; } set { grandtotal = value; } }
        public DateTime CreatedDate { get { return createddate; } set { createddate = value; } }
        public DateTime ModifiedDate { get { return modifieddate; } set { modifieddate = value; } }
    }

    class Program
    {
        public static ArrayList AllCustomerDetails = new ArrayList();
        public static ArrayList AllEmployeeDetails = new ArrayList();
        public static ArrayList AllProductDetails = new ArrayList();
        public static ArrayList AllOrder = new ArrayList();
        public static ArrayList AllOrderDetails = new ArrayList();

        static void AddCustomerDetails()
        {
            Console.WriteLine("\n\n\t\t\t\tCustomer Details : ");
            Console.WriteLine("==================================================");

            Console.Write("Enter Name : ");
            string C_name = Console.ReadLine();

            Console.Write("\nEnter Address : ");
            string C_addr = Console.ReadLine();

            Console.Write("\nEnter City : ");
            string C_city = Console.ReadLine();

            Console.Write("\nEnter State : ");
            string C_state = Console.ReadLine();

            Console.Write("\nEnter Postal Code : ");
            int C_postal = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter Country : ");
            string C_country = Console.ReadLine();

            Customer c = new Customer();
            c.CustomerName = C_name;
            c.Address = C_addr;
            c.City = C_city;
            c.State = C_state;
            c.PstalCode = C_postal;
            c.Country = C_country;

            AllCustomerDetails.Add(c);
        }

        static void AddEmployeeDetails()
        {
            Console.WriteLine("\n\n\t\t\t\tEmployee Details : ");
            Console.WriteLine("==================================================");

            Console.Write("Enter First Name : ");
            string E_fname = Console.ReadLine();

            Console.Write("Enter Last Name : ");
            string E_lname = Console.ReadLine();

            Console.Write("\nEnter Address : ");
            string E_addr = Console.ReadLine();

            Console.Write("\nEnter City : ");
            string E_city = Console.ReadLine();

            Console.Write("\nEnter State : ");
            string E_state = Console.ReadLine();

            Console.Write("\nEnter Postal Code : ");
            int E_postal = Convert.ToInt32(Console.ReadLine());

            Employee e = new Employee();
            e.FirstName = E_fname;
            e.LastName = E_lname;
            e.Address = E_addr;
            e.City = E_city;
            e.State = E_state;
            e.PstalCode = E_postal;

            AllEmployeeDetails.Add(e);
        }

        static void AddProduct()
        {
            Console.WriteLine("\n\n\t\t\t\tProduct Details : ");
            Console.WriteLine("==================================================");

            Console.Write("Enter Product No : ");
            int P_no = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name : ");
            string P_name = Console.ReadLine();

            Console.Write("\nEnter Unit Price : ");
            int P_unit = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nIs Product Active( Yes/No ) : ");
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
        }

        static void AddOrderDetails()
        {
            do
            {
                AddProduct();
                int len = AllProductDetails.Count;

                Console.WriteLine("\n\n\t\t\t\tOrder Details : ");
                Console.WriteLine("==================================================");

                Product temp_p = (Product)AllProductDetails[len-1];
                int OD_unit = temp_p.UnitPrice;

                Console.Write("Enter Quantity : ");
                int OD_quantity = Convert.ToInt32(Console.ReadLine());

                int OD_amount = OD_unit * OD_quantity;

                Console.Write("Enter Discount : ");
                int OD_discount = Convert.ToInt32(Console.ReadLine());

                int OD_total = OD_amount - OD_discount;

                DateTime OD_create = DateTime.Now;
                DateTime OD_modifi = DateTime.Now;

                OrderDetail od = new OrderDetail();
                od.ProductDetail = temp_p;
            }while//Here

        }

        static void AddOrder()
        {
            Console.Write("Order Number : ");
            int O_no= Convert.ToInt32(Console.ReadLine());

            AddCustomerDetails();
            AddEmployeeDetails();

            int len = AllEmployeeDetails.Count;

            Order order = new Order(O_no, (Customer)AllCustomerDetails[len - 1], (Employee)AllEmployeeDetails[len - 1]);
            AllOrder.Add(order);
        }

        static void UpadteOrder()
        {

        }

        static void DeleteOrder()
        {

        }

        static void Main(string[] args)
        {
            
            
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Update Order");
            Console.WriteLine("3. Delete Order");

            int input = Convert.ToInt32(Console.ReadKey());

            switch (input)
            {
                case 1:
                    AddOrder();
                    AddOrderDetails();

                    break;
                case 2:
                    UpadteOrder();
                    break;
                case 3:
                    DeleteOrder();
                    break;
            }
            
        }
    }
}
