using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
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
        public static bool IsNumber(string number)
        {
            return (System.Text.RegularExpressions.Regex.IsMatch(number, "^[0-9]+$"));
        }

        public static bool IsOrderNo(string no)
        {
            if (no.Equals(""))
            {
                return true;
            }
            else
            {
                if (Validation.IsNumber(no))
                {
                    int n = Convert.ToInt32(no);
                    foreach (Order v_order in Program.AllOrder)
                    {
                        if (n == v_order.OrderNo)
                            return true;
                    }
                }
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

        public static bool IsQuantity(string no)
        {

            if (no.Equals(""))
                return true;
            else if (IsNumber(no))
            {
                int n = Convert.ToInt32(no);
                if (n > 0)
                    return false;
            }
            return true;
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
                Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", o.OrderNo, o.CustomerDetail.CustomerName, o.EmployeeDetail.FirstName, o.OrderDate, o.ShipAddress, o.ShipCity, o.ShipState, o.ShipPostalCode, o.ShipCountry, o.CreatedDate);
                Console.WriteLine("\nProduct name\tPrice\tQuantity\tAmount\tDiscount\tTotal\tDate\t\t\tChange Date");
                int no = o.OrderNo;
                foreach (OrderDetail od in Program.AllOrderDetails)
                {
                    if (od.OrderNoRef == no)
                        Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}\t{4}\t\t{5}\t{6}\t{7}", od.ProductDetail.ProductName, od.UnitPrice, od.Quantity, od.Amount, od.DiscountAmount, od.GrandTotal, od.CreatedDate, od.ModifiedDate);
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

        Program()
        {
            string[] c1 = { "1", "Akash", "Kansara street", "Amreli", "Gujarat", "365601", "India" };
            string[] c2 = { "2", "Vijay", "Vejalpur", "Ahmedabad", "Gujarat", "360001", "India" };
            string[] c3 = { "3", "Malik", "Tower chock", "Kolkata", "Bangal", "48001", "India" };
            string[] c4 = { "4", "Mihir", "Palghar", "Mumbai", "Maharastra", "410001", "India" };
            List<string[]> Clist = new List<string[]>() { c1, c2, c3, c4 };

            string[] e1 = { "1", "Aksay", "Goradiya", "Palghar", "Mumbai", "Maharastra", "410001" };
            string[] e2 = { "2", "Mihir", "Manek", "Tower chock", "Kolkata", "Bangal", "48001" };
            string[] e3 = { "3", "Tejas", "Jethva", "Vejalpur", "Ahmedabad", "Gujarat", "360001" };
            List<string[]> Elist = new List<string[]>() { e1, e2, e3 };

            string[] p1 = { "1", "Wanish", "50", "yes" };
            string[] p2 = { "2", "Arial", "60", "yes" };
            string[] p3 = { "3", "Mouse", "150", "yes" };
            string[] p4 = { "4", "Key Bord", "250", "no" };
            string[] p5 = { "5", "Shoes", "699", "yes" };
            string[] p6 = { "6", "Watch", "550", "yes" };
            string[] p7 = { "7", "Beg", "499", "yes" };
            string[] p8 = { "8", "Bike", "49000", "no" };
            List<string[]> Plist = new List<string[]>() { p1, p2, p3, p4, p5, p6, p7, p8 };

            AddCustomer(Clist);
            AddEmployee(Elist);
            AddProduct(Plist);
        }

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
                    string qt;
                    do
                    {
                        Console.Write("Enter Quantity : ");
                        qt = Console.ReadLine();
                    } while (Validation.IsQuantity(qt));
                    od.Quantity = Convert.ToInt32(qt);
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

                foreach (OrderDetail d in itemsToRemove1)
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

        static void LastDetails(bool all = false)
        {
            Console.Write("Enter Customer name : ");
            string name = Console.ReadLine();


            ArrayList temp = Program.AllOrder;
            temp.Reverse();

            Console.WriteLine("Product No\t\tProduct Name\t\tPrice\t\tQuantity\t\tAmount\t\tDiscount\t\tTotal\t\tDate");
            foreach (Order o in temp)
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

        static void AddCustomer(List<string[]> list)
        {
            foreach (string[] str in list)
            {
                Customer c = new Customer();
                c.CustomerNo = Convert.ToInt32(str[0]);
                c.CustomerName = str[1];
                c.Address = str[2];
                c.City = str[3];
                c.State = str[4];
                c.PstalCode = Convert.ToInt32(str[5]);
                c.Country = str[6];

                AllCustomerDetails.Add(c);
            }
        }

        static void AddEmployee(List<string[]> list)
        {
            foreach (string[] str in list)
            {
                Employee e = new Employee();
                e.EmployeeNo = Convert.ToInt32(str[0]);
                e.FirstName = str[1];
                e.LastName = str[2];
                e.Address = str[3];
                e.City = str[4];
                e.State = str[5];
                e.PstalCode = Convert.ToInt32(str[6]);

                AllEmployeeDetails.Add(e);
            }
        }

        static void AddProduct(List<string[]> list)
        {
            foreach (string[] str in list)
            {
                Product p = new Product();
                p.ProductNo = Convert.ToInt32(str[0]);
                p.ProductName = str[1];
                p.UnitPrice = Convert.ToInt32(str[2]);
                string s = str[3];
                if (s.Equals("yes"))
                    p.IsActive = true;
                else
                    p.IsActive = false;

                AllProductDetails.Add(p);
            }
        }

        static int fillCustomerDetails()
        {
            string C_name;
            do
            {
                Console.Write("\nEnter Customer Name : ");
                C_name = Console.ReadLine();
            } while (Validation.IsEmpty(C_name));

            var t = CheckAvilability(C_name, "Customer");

            if (t.Item1)
            {
                return t.Item2;
            }
            return -1;
        }

        static int fillEmployeeDetails()
        {
            string E_fname, E_lname;

            do
            {
                Console.Write("\nEnter First Name : ");
                E_fname = Console.ReadLine();
            } while (Validation.IsEmpty(E_fname));

            do
            {
                Console.Write("Enter Last Name : ");
                E_lname = Console.ReadLine();
            } while (Validation.IsEmpty(E_lname));

            string E_name = E_fname + " " + E_lname;

            var t = CheckAvilability(E_name, "Employee");

            if (t.Item1)
            {
                return t.Item2;
            }
            return -1;
        }

        static Product fillProductDetails()
        {
            int P_no = AllProductDetails.Count + 1;

            string P_name;
            do
            {
                Console.Write("\nEnter Product Name : ");
                P_name = Console.ReadLine();
            } while (Validation.IsEmpty(P_name));

            var t = CheckAvilability(P_name, "Product");

            if (t.Item1)
            {
                return (Product)AllProductDetails[t.Item2];
            }
            return fillProductDetails();
        }

        static void AddOrder()
        {
            string no;
            do
            {
                Console.Write("Order Number : ");
                no = Console.ReadLine();
            } while (Validation.IsOrderNo(no) || !Validation.IsNumber(no));
            int O_no = Convert.ToInt32(no);

            Order o = new Order();
            o.OrderNo = O_no;



            int chk;
            do
            {
                chk = fillCustomerDetails();   
            }while(chk == -1);
            o.CustomerDetail = (Customer)AllCustomerDetails[chk];

            int ehk;
            do
            {
                ehk = fillEmployeeDetails();
            } while (ehk == -1);
            o.EmployeeDetail = (Employee)AllEmployeeDetails[ehk];

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
                od.ProductDetail = fillProductDetails();

                if (od.ProductDetail.IsActive)
                {
                    Console.Write("Product Unit Price is {0} (Enter to skip) : ", od.ProductDetail.UnitPrice);
                    string price = Console.ReadLine();
                    int OD_unit;

                    if (price.Equals(""))
                    {
                        OD_unit = od.ProductDetail.UnitPrice;
                    }
                    else
                    {
                        OD_unit = Convert.ToInt32(price);
                    }

                    string qt;
                    int OD_quantity = 1;
                    do
                    {
                        Console.Write("Enter Quantity (Enter to skip) (default 1) : ");
                        qt = Console.ReadLine();
                        if (qt.Equals(""))
                        {
                            break;
                        }
                    } while (Validation.IsQuantity(qt));


                    string dis;
                    int OD_discount = 0;
                    bool flag = true;
                    do
                    {
                        Console.Write("Enter Discount (Enter to skip) : ");
                        dis = Console.ReadLine();
                        if (dis.Equals(""))
                        {
                            OD_discount = 0;
                            flag = false;
                        }
                        else
                        {
                            if (Validation.IsNumber(dis))
                            {
                                flag = false;
                                OD_discount = Convert.ToInt32(dis);
                            }
                        }
                    } while (flag);

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
                else
                {
                    Console.WriteLine("Product not avilable");
                }
                Console.Write("\nAdd Product? (Yes/No) : ");
                wannadd = Console.ReadLine().ToLower();
            } while (wannadd != "no");
        }

        static void Main(string[] args)
        {
            Program p = new Program();
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
