﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public static ArrayList AllCustomerDetails = new ArrayList();
        public static ArrayList AllEmployeeDetails = new ArrayList();
        public static ArrayList AllProductDetails = new ArrayList();
        public static ArrayList AllOrder = new ArrayList();
        public static ArrayList AllOrderDetails = new ArrayList();

        Program()
        {
            string[] c1 = { "1", "Akash", "Kansara street", "Amreli   ", "Gujarat   ", "365601", "India" };
            string[] c2 = { "2", "Vijay", "Vejalpur      ", "Ahmedabad", "Gujarat   ", "360001", "India" };
            string[] c3 = { "3", "Malik", "Tower chock   ", "Kolkata  ", "Bangal    ", "480001", "India" };
            string[] c4 = { "4", "Mihir", "Palghar       ", "Mumbai   ", "Maharastra", "410001", "India" };
            List<string[]> Clist = new List<string[]>() { c1, c2, c3, c4 };

            string[] e1 = { "1", "Aksay", "Goradiya", "Palghar", "Mumbai", "Maharastra", "410001" };
            string[] e2 = { "2", "Mihir", "Manek", "Tower chock", "Kolkata", "Bangal", "48001" };
            string[] e3 = { "3", "Tejas", "Jethva", "Vejalpur", "Ahmedabad", "Gujarat", "360001" };
            List<string[]> Elist = new List<string[]>() { e1, e2, e3 };

            string[] p1 = { "1", "Wanish", "50", "yes" };
            string[] p2 = { "2", "Arial", "60", "yes" };
            string[] p3 = { "3", "Mouse", "150", "yes" };
            string[] p4 = { "4", "KeyBord", "250", "no" };
            string[] p5 = { "5", "Shoes", "699", "yes" };
            string[] p6 = { "6", "Watch", "550", "yes" };
            string[] p7 = { "7", "Beg", "499", "yes" };
            string[] p8 = { "8", "Bike", "49000", "no" };
            List<string[]> Plist = new List<string[]>() { p1, p2, p3, p4, p5, p6, p7, p8 };

            AddCustomer(Clist);
            AddEmployee(Elist);
            AddProduct(Plist);
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

        static Tuple<bool, int> CheckAvilability(int name, string InWhich)
        {
            if (InWhich == "Employee")
            {
                int i = 0;
                foreach (Employee loop_e in AllEmployeeDetails)
                {
                    if (loop_e.EmployeeNo.Equals(name))
                        return new Tuple<bool, int>(true, i);
                    i++;
                }
            }
            else if (InWhich == "Customer")
            {
                int i = 0;
                foreach (Customer loop_c in AllCustomerDetails)
                {
                    if (loop_c.CustomerNo.Equals(name))
                        return new Tuple<bool, int>(true, i);
                    i++;
                }
            }
            else if (InWhich == "Product")
            {
                int i = 0;
                foreach (Product loop_p in AllProductDetails)
                {
                    if (loop_p.ProductNo.Equals(name))
                        return new Tuple<bool, int>(true, i);
                    i++;
                }
            }
            return new Tuple<bool, int>(false, 0);
        }

        static void UpadteOrder()
        {
            if (AllOrder.Count == 0)
            {
                Console.WriteLine("No Order Placed Yet...!");
                return;
            }
            Show.AllOrder();
            string up_no;
            do
            {
                Console.Write("\nEnter Order Number : ");
                up_no = Console.ReadLine();
                if (Check.chkOrderNo(up_no))
                {
                    Console.WriteLine("No Order Number Found..!");
                }
            } while (Validation.IsOrderAvail(up_no));

            if(up_no.Equals("0"))
                start();

            int update_no = Convert.ToInt32(up_no);

            int index = 0;
            int len = Program.AllOrderDetails.Count;
            OrderDetail od = new OrderDetail();

            int update_product_no;
            do
            {
                Show.showOrderDetails(update_no);
                bool flag = false;
                string pro_no;
                do
                {
                    Console.Write("\nEnter Product Number (Exit 0) : ");
                    pro_no = Console.ReadLine();
                    if(Check.chkProductNo(update_no, pro_no))
                    {
                        Console.WriteLine("No Product Avialable Within Order \n");
                    }
                } while (!Validation.IsNumber(pro_no));

                if (pro_no.Equals("0"))
                    start();

                update_product_no = Convert.ToInt32(pro_no);
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

                    if (qt.Equals("0"))
                        start();

                    od.Quantity = Convert.ToInt32(qt);
                    od.Amount = od.UnitPrice * od.Quantity;
                    od.GrandTotal = od.Amount - od.DiscountAmount;
                    od.ModifiedDate = DateTime.Now;

                    Program.AllOrderDetails[index] = od;

                    //Show.showOrderDetails(od.OrderNoRef);
                    Console.WriteLine("\nNo\tName\t\tQuantity\tAmount\tTotal");
                    od.Show();
                }
                else
                {
                    //Console.WriteLine("No Product Available!");
                }
            } while (true);
        }

        static void DeleteOrder()
        {
            string del;
            do
            {
                if (AllOrder.Count == 0)
                {
                    Console.WriteLine("No Order Placed Yet...!");
                    return;
                }
                do
                {
                    Show.AllOrder();
                    Console.Write("\nEnter No : ");
                    del = Console.ReadLine();
                    if (del.Equals("0"))
                        break;
                    if (Check.chkOrderNo(del))
                    {
                        Console.WriteLine("No Order Number Found..!");
                    }
                } while (Check.chkOrderNo(del));

                if (del.Equals("0"))
                    start();

                int del_no = Convert.ToInt32(del);

                Console.WriteLine("No\tName\t\tQuantity\tAmount\tTotal");
                foreach (OrderDetail del_od in Program.AllOrderDetails)
                {
                    if (del_od.OrderNoRef == del_no)
                    {
                        del_od.Show();
                    }
                }

                Console.Write("Want to delete? (Yes : 1 | No : 0) : ");
                string ans = Console.ReadLine();

                if (ans.Equals("1"))
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
            } while (!del.Equals("0"));
            
        }

        static void ProductStatus()
        {
            int up_no;
            int len = Program.AllProductDetails.Count;

            do
            {
                Show.showProductAvilability();
                string no;
                do
                {
                    Console.Write("\nEnter Product Number To Toggle Available (Exit 0) : ");
                    no = Console.ReadLine();
                    if (Validation.IsProduct(no))
                    {
                        Console.WriteLine("No Product Available..!");
                    }
                }while(Validation.IsProduct(no));
                
                if(no.Equals("0"))
                    start();

                up_no = Convert.ToInt32(no);
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
            if (AllOrder.Count == 0)
                Console.WriteLine("No Order Placed Yet...!");
            else
            {
                int index = AllOrder.Count - 1;
                Order o = (Order)AllOrder[index];
                int no = o.OrderNo;

                Console.WriteLine("Order No\tEmployee Name\tCustomer Name\tCity\t\tCountry\tOrder Date\tCreated Date");
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}",o.OrderNo, o.EmployeeDetail.FirstName, o.CustomerDetail.CustomerName, o.ShipCity, o.ShipCountry, o.OrderDate, o.CreatedDate);
                Console.WriteLine("========================================================================================");
                Console.WriteLine("Product No\tProduct Name\tPrice\tQuantity\tAmount\tDiscount\tTotal");
                foreach (OrderDetail od in AllOrderDetails)
                {
                    if (od.OrderNoRef == no)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t{3}\t\t{4}\t{5}\t\t{6}", od.ProductDetail.ProductNo, od.ProductDetail.ProductName, od.ProductDetail.UnitPrice, od.Quantity, od.Amount, od.DiscountAmount, od.GrandTotal);
                    }
                }
            }
        }

        static void LastUnitPrice()
        {
            if (AllOrder.Count == 0)
                Console.WriteLine("No Order Placed Yet...!");
            else
            {
                int index = AllOrder.Count - 1;
                Order o = (Order)AllOrder[index];
                int no = o.OrderNo;

                foreach (OrderDetail od in AllOrderDetails)
                {
                    if(od.OrderNoRef == no)
                    {
                        Console.WriteLine("Last unit price of {0} is : {1}", od.ProductDetail.ProductName, od.UnitPrice);
                    }
                }
            }
        }

        public static void View()
        {
            Console.WriteLine("\n\n=================================================================================");
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



        static Customer fillCustomerDetails()
        {
            Show.showAllCustomerName();
            string C_no;
            do
            {
                Console.Write("\nEnter Customer No : ");
                C_no = Console.ReadLine();
            } while (!Validation.IsCustomer(C_no));

            if (Validation.IsStop(C_no))
                Program.start();

            int no = Convert.ToInt32(C_no);

            var t = CheckAvilability(no, "Customer");

            if (t.Item1)
            {
                return (Customer)Program.AllCustomerDetails[t.Item2];
            }
            return fillCustomerDetails();
        }

        static Employee fillEmployeeDetails()
        {
            Show.showAllEmployeeName();
            string E_no;
            do
            {
                Console.Write("\nEnter Employee No: ");
                E_no = Console.ReadLine();
            } while (!Validation.IsEmployee(E_no));

            if (Validation.IsStop(E_no))
                Program.start();

            int no = Convert.ToInt32(E_no);
            var t = CheckAvilability(no, "Employee");

            if (t.Item1)
            {
                return (Employee)Program.AllEmployeeDetails[t.Item2];
            }
            return fillEmployeeDetails();
        }

        static Product fillProductDetails()
        {
            Show.showAllProductName();

            string P_no;
            do
            {
                Console.Write("\nEnter Product No : ");
                P_no = Console.ReadLine();
            } while (Validation.IsProduct(P_no));

            if (Validation.IsStop(P_no))
                Program.start();

            int no = Convert.ToInt32(P_no);
            var t = CheckAvilability(no, "Product");

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
                if (Validation.IsNumber(no))
                {
                    if (Validation.ChkOrderNo(no))
                    {
                        Console.WriteLine("Order No Allready Avilable..!");
                    }
                }
            } while (Validation.IsOrderNo(no) || !Validation.IsNumber(no));

            int O_no = Convert.ToInt32(no);

            Order o = new Order();
            o.OrderNo = O_no;
            o.CustomerDetail = fillCustomerDetails();
            o.EmployeeDetail = fillEmployeeDetails();
            o.OrderDate = DateTime.Now.ToString("dd/MM/yyyy");
            o.ShipName = o.CustomerDetail.CustomerName;
            o.ShipAddress = o.CustomerDetail.Address;
            o.ShipCity = o.CustomerDetail.City;
            o.ShipState = o.CustomerDetail.State;
            o.ShipPostalCode = o.CustomerDetail.PstalCode;
            o.ShipCountry = o.CustomerDetail.Country;
            o.CreatedDate = DateTime.Today;
            o.ModifiedDate = DateTime.Today;

            AddOrderDetails(o);
            //AllOrder.Add(o);
        }

        static void AddOrderDetails(Order temp_o)
        {
            ArrayList temp = new ArrayList();
            string wannadd;

            do
            {   
                OrderDetail od = new OrderDetail();
                od.OrderNoRef = temp_o.OrderNo;
                od.ProductDetail = fillProductDetails();

                if (od.ProductDetail.IsActive)
                {
                    double OD_unit = 0;
                    string price;
                    do
                    {
                        Console.Write("Product Unit Price is {0} : ", od.ProductDetail.UnitPrice);
                        price = Console.ReadLine();
                    } while (Validation.IsEmpty(price) || !Validation.IsNumber(price));

                    if (price.Equals("0"))
                    { temp.Clear(); Program.start(); }

                    else
                    {
                        OD_unit = Convert.ToDouble(price);
                    }

                    string qt;
                    int OD_quantity = 1;
                    do
                    {
                        Console.Write("Enter Quantity : ");
                        qt = Console.ReadLine();
                    } while (Validation.IsQuantity(qt));

                    if (qt.Equals("0"))
                    { temp.Clear(); Program.start(); }
                    OD_quantity = Convert.ToInt32(qt);



                    string dis;
                    double OD_discount = 0;
                    do
                    {
                        Console.Write("Enter Discount (Hit Enter to Skip) : ");
                        dis = Console.ReadLine();
                    } while (Validation.IsDiscount(dis));
                    if (dis.Equals("0"))
                    {
                        temp.Clear();
                        Program.start();
                    }

                    if (!dis.Equals(""))
                    {
                        OD_discount = Convert.ToInt32(dis);
                    }


                    DateTime OD_create = DateTime.Now;
                    DateTime OD_modifi = DateTime.Now;


                    od.UnitPrice = OD_unit;
                    od.Quantity = OD_quantity;
                    od.Amount = OD_unit * OD_quantity;
                    od.DiscountAmount = OD_discount;
                    od.GrandTotal = od.Amount - OD_discount;
                    od.CreatedDate = OD_create;
                    od.ModifiedDate = OD_modifi;

                    
                    temp.Add(od);
                    //AllOrderDetails.Add(od);
                }
                else
                {
                    Console.WriteLine("Product not avilable");
                }
                Console.Write("\nHit Enter for more items (Exit 0) : ");
                wannadd = Console.ReadLine();
            } while (wannadd != "0");
            foreach (OrderDetail od in temp)
            {
                AllOrderDetails.Add(od);
            }
            temp.Clear();
            AllOrder.Add(temp_o);
        }

        static void ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo;
            Process Process;

            ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
            ProcessInfo.CreateNoWindow = false;
            ProcessInfo.UseShellExecute = true;

            Process = Process.Start(ProcessInfo);
        }

        public static void start()
        {
            int input;
            string inp;
            do
            {
                Console.WriteLine("\n\n\n\n===============================================================================================================");
                Console.WriteLine("1. Add Order\t\t\t2. Update Order\t\t\t\t3. Delete Order\t\t\t4. View Details");
                Console.WriteLine("5. Last Order Detail\t\t6. Last Order's UnitPrice\t\t7. Product Avilability\t\t0. Exit");
                Console.WriteLine("===============================================================================================================");
                do
                {
                    inp = Console.ReadLine();
                } while (!Validation.IsNumber(inp));
                
                input = Convert.ToInt32(inp);

                switch (input)
                {
                    case 0:
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        break;
                    case 1:
                        AddOrder();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    case 2:
                        UpadteOrder();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    case 3:
                        DeleteOrder();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    case 7:
                        ProductStatus();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    case 5:
                        LastDetails();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    case 6:
                        LastUnitPrice();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    case 4:
                        View();
                        Console.WriteLine("Hit Enter For Menu.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong");
                        break;
                }
            } while (input != 0);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            start();
        }
    }
}