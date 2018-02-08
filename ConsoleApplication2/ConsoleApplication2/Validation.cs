using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Validation
    {
        public static bool IsCustomer(string no)
        {
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

        public static bool IsProduct(string no)
        {
            if (IsNumber(no))
            {
                int num = Convert.ToInt32(no);
                foreach (Product p in Program.AllProductDetails)
                {
                    if (p.ProductNo == num)
                        return true;
                }
            }
            return false;
        }

        public static bool IsStop(string no)
        {
            if (no.Equals("-1"))
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
}
