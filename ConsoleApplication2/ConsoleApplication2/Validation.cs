using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Validation
    {
        public static bool IsCustomerShop(int no)
        {
            foreach (Order o in Program.AllOrder)
            {
                if (o.CustomerDetail.CustomerNo == no)
                    return true;
            }
            return false;
        }

        public static bool IsCustomer(string no)
        {
            if (IsStop(no))
                Program.start();

            if (IsNumber(no))
            {
                int num = Convert.ToInt32(no);
                foreach (Customer c in Program.AllCustomerDetails)
                {
                    if (c.CustomerNo == num)
                        return true;
                }
            }
            return false;
        }

        public static bool IsEmployee(string no)
        {
            if (IsStop(no))
                Program.start();
            if(IsNumber(no))
            {
                int num = Convert.ToInt32(no);
                foreach (Employee e in Program.AllEmployeeDetails)
                {
                    if (e.EmployeeNo == num)
                        return true;
                }
            }
            return false;
        }

        public static bool IsProductAvail(int no, string num)
        {
            if (num.Equals("0"))
            {
                return false;
            }
            if(IsNumber(num))
            {
                int number = Convert.ToInt32(no);
                foreach (OrderDetail od in Program.AllOrderDetails)
                {
                    if (no == od.OrderNoRef)
                    {
                        if (od.ProductDetail.ProductNo == number)
                            return false;
                    }
                }
            }
            return true;
        }

        public static bool IsProduct(string no)
        {
            if(no.Equals("0"))
            {
                return false;
            }
            if (IsNumber(no))
            {
                int num = Convert.ToInt32(no);
                foreach (Product p in Program.AllProductDetails)
                {
                    if (p.ProductNo == num)
                        return false;
                }
            }
            return true;
        }

        public static bool IsStop(string no)
        {
            if (no.Equals("0"))
                return true;
            return false;
        }

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
            else if (no.Equals("0"))
            {
                Program.start();
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

        public static bool ChkOrderNo(string no)
        {
            int num = Convert.ToInt32(no);
            foreach (Order o in Program.AllOrder)
            {
                if (o.OrderNo == num)
                    return true;
            }
            return false;
        }

        public static bool IsOrderAvail(string no)
        {
            if (no.Equals("0"))
                return false;
            if (no.Equals(""))
                return true;
            else
            {
                if (IsNumber(no))
                {
                    foreach (Order o in Program.AllOrder)
                    {
                        if (o.OrderNo == Convert.ToInt32(no))
                            return false;
                    }
                }
                return true;
            }
        }

        public static bool IsDiscount(string name)
        {
            if (IsNumber(name) || name.Equals(""))
            {
                return false;
            }
            return true;
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
            if (no.Equals("0"))
                return false;
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

        public static bool IsShoped(string no)
        {
            if(no.Equals("0"))
                return false;
            if(IsNumber(no))
            {
                int num = Convert.ToInt32(no);
                foreach(Product p in Program.AllProductDetails)  
                {
                    if(p.ProductNo == num)
                        return false;
                }
            }
            return true;
        }
    }
}
