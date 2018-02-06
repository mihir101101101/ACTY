using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Employee
    {
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

    class Product
    {
        private int productno;
        private string productname;
        private int unitprice;
        private bool isactive;

        public int ProductNo { get { return productno; } set { productno = value; } }
        public string ProductName { get { return productname; } set { productname = value; } }
        public int UnitPrice { get { return unitprice; } set { unitprice = value; } }
        public bool IsActive { get { return isactive; } set { isactive = value; } }
    }

    class Customer
    {
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

    class Order
    {
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


        public int OrderNo { get { return orderno; } set { orderno = value; } }
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
        private int ordernoref;
        private Product productdetail;
        private int unitprice;
        private int quantity;
        private int amount;
        private int discountamount;
        private int grandtotal;
        private DateTime createddate;
        private DateTime modifieddate;

        public int OrderNoRef { get { return ordernoref; } set { ordernoref = value; } }
        public Product ProductDetail { get { return productdetail; } set { productdetail = value; } }
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

    class Validation
    {
        public static bool IsOrderNo(string no)
        {
            if (no.Equals(""))
            {
                return true;
            }

            int n = Convert.ToInt32(no);
            foreach (Order v_order in Program.AllOrder)
            {
                if (n == v_order.OrderNo)
                    return true;
            }
            return false;
        }

        public static bool IsEmpty(string name)
        {
            if (name == "")
                return true;
            return false;
        }

        public static bool IsEmpty(int name)
        {
            if (name == 0)
                return true;
            return false;
        }

        public static bool IsQuantity(int no)
        {
            if (no == 0)
                return true;
            return false;
        }
    }

    class Show
    {
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
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", e.EmployeeNo, e.FirstName+" "+e.LastName, e.Address, e.City, e.State, e.PstalCode);
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

        public static void showAllOrder()
        {
            if (Program.AllOrder.Count <= 0)
            {
                Console.WriteLine("No Order Avilable");
                return;
            }
            Console.WriteLine("NO\tCustomer Name\tEmployee Name\tOrder Date\tAddress\t\tCity\tState\tPIN\tCountry\tDate");
            foreach (Order o in Program.AllOrder)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",o.OrderNo, o.CustomerDetail.CustomerName, o.EmployeeDetail.FirstName, o.OrderDate, o.ShipAddress, o.ShipCity, o.ShipState, o.ShipPostalCode, o.ShipCountry,o.CreatedDate);
                Console.WriteLine("\nProduct name\tPrice\tQuantity\tAmount\tDiscount\tTotal\tDate\t\t\tChange Date");
                int no = o.OrderNo;
                foreach (OrderDetail od in Program.AllOrderDetails)
                {
                    if (od.OrderNoRef == no)
                        Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}\t{4}\t\t{5}\t{6}\t{7}",od.ProductDetail.ProductName, od.UnitPrice, od.Quantity, od.Amount, od.DiscountAmount, od.GrandTotal, od.CreatedDate, od.ModifiedDate);
                }
            }
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
                        return new Tuple<bool, int>(true, i);
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
                foreach (Product loop_p in AllProductDetails)
                {
                    if (loop_p.ProductName.Equals(name))
                        return new Tuple<bool, int>(true, i);
                    i++;
                }
            }
            return new Tuple<bool, int>(false, 0);
        }







        

        static Customer AddCustomerDetails()
        {
            Console.WriteLine("\n\n\t\t\t\tCustomer Details : ");
            Console.WriteLine("==================================================");

            int C_no = AllCustomerDetails.Count + 1;

            string C_name;

            do
            {
                Console.Write("Enter Name : ");
                C_name = Console.ReadLine().ToLower();
            } while (Validation.IsEmpty(C_name));

            var t = CheckAvilability(C_name, "Customer");

            if (t.Item1)
            {
                return (Customer)AllCustomerDetails[t.Item2];
            }

            string C_addr;
            do
            {
                Console.Write("Enter Address : ");
                C_addr = Console.ReadLine();
            } while (Validation.IsEmpty(C_addr));


            string C_city;
            do
            {
                Console.Write("Enter City : ");
                C_city = Console.ReadLine();
            } while (Validation.IsEmpty(C_city));


            string C_state;
            do
            {
                Console.Write("Enter State : ");
                C_state = Console.ReadLine();
            } while (Validation.IsEmpty(C_state));

            string post;
            do
            {
                Console.Write("Enter Postal Code : ");
                post = Console.ReadLine();
            } while (Validation.IsEmpty(post));
            int C_postal = Convert.ToInt32(post);


            string C_country;
            do
            { 
                Console.Write("Enter Country : ");
                C_country = Console.ReadLine();
            }while(Validation.IsEmpty(C_country));


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

            string E_fname, E_lname;

            do
            {
                Console.Write("Enter First Name : ");
                E_fname = Console.ReadLine().ToLower();
            } while (Validation.IsEmpty(E_fname));

            do
            {
                Console.Write("Enter Last Name : ");
                E_lname = Console.ReadLine().ToLower();
            } while (Validation.IsEmpty(E_lname));

            string E_name = E_fname + " " + E_lname;

            var t = CheckAvilability(E_name, "Employee");

            if (t.Item1)
            {
                return (Employee)AllEmployeeDetails[t.Item2];
            }

            string E_addr;
            do
            {
                Console.Write("Enter Address : ");
                E_addr = Console.ReadLine();
            }while(Validation.IsEmpty(E_addr));

            string E_city;
            do
            {
                Console.Write("Enter City : ");
                E_city = Console.ReadLine();
            } while (Validation.IsEmpty(E_city));

            string E_state;
            do
            {
                Console.Write("Enter State : ");
                E_state = Console.ReadLine();
            } while (Validation.IsEmpty(E_state));

            
            int E_postal;
            string post;
            do
            {
                Console.Write("Enter Postal Code : ");
                post = Console.ReadLine();
            } while (Validation.IsEmpty(post));
            E_postal = Convert.ToInt32(post);


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

            string P_name;

            do
            {
                Console.Write("Enter Product Name : ");
                P_name = Console.ReadLine().ToLower();
            } while (Validation.IsEmpty(P_name));

            var t = CheckAvilability(P_name, "Product");

            if (t.Item1)
            {
                return (Product)AllProductDetails[t.Item2];
            }


            string post;
            do
            {
                Console.Write("Enter Unit Price : ");
                post = Console.ReadLine();
            } while (Validation.IsEmpty(post));
            int P_unit = Convert.ToInt32(post);



            Console.Write("Is Product Active( Yes/No ) : ");
            string ch = Console.ReadLine().ToLower();

            bool P_active = true;
            if (ch.Equals("no"))
                P_active = false;

            Product p = new Product();
            p.ProductNo = P_no;
            p.ProductName = P_name;
            p.UnitPrice = P_unit;
            p.IsActive = P_active;

            AllProductDetails.Add(p);
            return p;
        }

        static void AddOrder()
        {
            string no;
            do
            {
                Console.Write("Order Number : ");
                no = Console.ReadLine();
            } while (Validation.IsOrderNo(no));
            int O_no = Convert.ToInt32(no);

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

        static void AddOrderDetails()
        {
            int len = AllOrder.Count;
            Order temp_o = (Order)AllOrder[len - 1];
            string wannadd;
            do
            {
                OrderDetail od = new OrderDetail();
                od.OrderNoRef = temp_o.OrderNo;
                od.ProductDetail = AddProduct();

                if (od.ProductDetail.IsActive)
                {
                    Console.WriteLine("\n\n\t\t\t\tOrder Details : ");
                    Console.WriteLine("==================================================");

                    Console.Write("Product Unit Price is {0}; Your Price : ", od.ProductDetail.UnitPrice);
                    int OD_unit = Convert.ToInt32(Console.ReadLine());

                    int OD_quantity;
                    do
                    {
                        Console.Write("Enter Quantity : ");
                        OD_quantity = Convert.ToInt32(Console.ReadLine());
                    } while (OD_quantity < 1);

                    Console.Write("Enter Discount : ");
                    int OD_discount = Convert.ToInt32(Console.ReadLine());

                    DateTime OD_create = DateTime.Now;
                    DateTime OD_modifi = DateTime.Now;


                    od.UnitPrice = OD_unit;
                    od.Quantity = OD_quantity;
                    od.Amount = od.ProductDetail.UnitPrice * OD_quantity;
                    od.DiscountAmount = OD_discount;
                    od.GrandTotal = od.Amount - OD_discount;
                    od.CreatedDate = OD_create;
                    od.ModifiedDate = OD_modifi;

                    AllOrderDetails.Add(od);
                }

                Console.WriteLine("==================================================");
                Console.Write("Add Product? (Yes/No) : ");
                wannadd = Console.ReadLine().ToLower();
            } while (wannadd != "no");
        }







        static void UpadteOrder()
        {
            Console.Write("\nEnter Order Number : ");
            int update_no = Convert.ToInt32(Console.ReadLine());
            Show.showOrderDetails(update_no);

            int index = 0;
            int len = Program.AllOrderDetails.Count;
            OrderDetail od = new OrderDetail();
            int update_product_no;

            do
            {
                bool flag = false;
                Console.Write("\nEnter Product Number : ");
                update_product_no = Convert.ToInt32(Console.ReadLine());
                int c_quantity;

                for (int i = 0; i < len; i++)
                {
                    od = (OrderDetail)Program.AllOrderDetails[i];
                    if (od.ProductDetail.ProductNo == update_product_no)
                    {
                        flag = true;
                        index = i;
                        break;
                    }
                }

                if (flag)
                {
                    do
                    {
                        Console.Write("Enter Quantity : ");
                        c_quantity = Convert.ToInt32(Console.ReadLine());
                        od.Quantity = c_quantity;
                    } while (Validation.IsQuantity(c_quantity));

                    od.Amount = od.UnitPrice * od.Quantity;
                    od.GrandTotal = od.Amount - od.DiscountAmount;
                    od.ModifiedDate = DateTime.Now;

                    Program.AllOrderDetails[index] = od;

                    Show.showOrderDetails(od.OrderNoRef);
                    od.Show();
                }
                else
                {
                    Console.WriteLine("\nNo product avilable : ");
                }
            } while (update_product_no != 0);
        }






        static void DeleteOrder()
        {
            Console.Write("Enter No : ");
            int del_no = Convert.ToInt32(Console.ReadLine());

            foreach (OrderDetail del_od in Program.AllOrderDetails)
            {
                if (del_od.OrderNoRef == del_no)
                {
                    del_od.Show();
                }
            }

            Console.Write("\nWant to delete? (yes/no) : ");
            string ans = Console.ReadLine().ToLower();

            if (ans.Equals("yes"))
            {
                ArrayList itemsToRemove1 = new ArrayList();

                foreach (OrderDetail del_od in Program.AllOrderDetails) 
                {
                    if (del_od.OrderNoRef == del_no)
                    {
                        itemsToRemove1.Add(del_od);
                    }
                }

                foreach(OrderDetail d in itemsToRemove1) 
                {
                    Program.AllOrderDetails.Remove(d);
                }

                foreach (Order del_o in AllOrder)
                {
                    if (del_o.OrderNo == del_no)
                    {
                        AllOrder.Remove(del_o);
                        break;
                    }
                }
            }
        }


        static void ProductStatus()
        {
            int up_no;
            int len = Program.AllProductDetails.Count;

            do
            {
                Show.showProductAvilability();
                Console.Write("Enter No : ");
                up_no = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < len; i++)
                {
                    Product p = (Product)Program.AllProductDetails[i];
                    if (p.ProductNo == up_no)
                    {
                        bool status = p.IsActive;
                        p.IsActive = !status;
                        break;
                    }
                }
            } while (up_no != 0);
        }




        public static void View()
        {
            Console.WriteLine("\n\n\n\n=================================================================================");
            Console.WriteLine("1. Employee\t\t2. Customer\t\t3. Product\t\t4. Order");
            Console.WriteLine("=================================================================================");


            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Show.showAllEmployee();
                    break;
                case 2:
                    Show.showAllCustomer();
                    break;
                case 3:
                    Show.showAllProduct();
                    break;
                case 4:
                    Show.showAllOrder();
                    break;
            }
        }

        static void LastDetails(bool all=false)
        {
            Console.Write("Enter Customer name : ");
            string name = Console.ReadLine().ToLower();


            ArrayList temp = Program.AllOrder;
            temp.Reverse();

            Console.WriteLine("Product No\t\tProduct Name\t\tPrice\t\tQuantity\t\tAmount\t\tDiscount\t\tTotal\t\tDate");
            foreach(Order o in temp)
            {
                if (o.CustomerDetail.CustomerName.Equals(name))
                {
                    int i = o.OrderNo;
                    foreach (OrderDetail od in AllOrderDetails)
                    {
                        if (i == od.OrderNoRef)
                        {
                            Show.showLastCustomer(od);
                        }
                    }
                    if (!all)
                        break;
                }
            }
        }

        static void LastUnitPrice()
        {
            Console.WriteLine("Enter Product name : ");
            string name = Console.ReadLine();

            ArrayList temp = Program.AllOrderDetails;
            temp.Reverse();

            foreach (OrderDetail od in temp)
            {
                if (od.ProductDetail.ProductName.Equals(name))
                {
                    Console.WriteLine("Last Unit Price of {0} is {1}", od.ProductDetail.ProductName, od.UnitPrice);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            int input;
            do
            {
                Console.WriteLine("\n\n\n\n===============================================================================================================");
                Console.WriteLine("1. Add Order\t\t\t2. Update Order\t\t\t\t3. Delete Order\t\t\t4. View Details");
                Console.WriteLine("5. Last Order Detail\t\t6. Last Order's UnitPrice\t\t7. Product Avilability\t\t0. Exit");
                Console.WriteLine("===============================================================================================================");

                input = Convert.ToInt32(Console.ReadLine());

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
                    case 7:
                        ProductStatus();
                        break;
                    case 5:
                        LastDetails();
                        break;
                    case 6:
                        LastUnitPrice();
                        break;
                    case 4:
                        View();
                        break;
                }
            } while (input != 0);
        }
    }
}
