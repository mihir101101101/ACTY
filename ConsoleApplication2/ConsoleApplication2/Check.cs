using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Check
    {
        public static bool chkOrderNo(string no)
        {
            if (Validation.IsNumber(no))
            {
                int num = Convert.ToInt32(no);
                foreach (Order o in Program.AllOrder)
                {
                    if (o.OrderNo == num)
                        return false;
                }
            }
            return true;
        }

        public static bool chkProductNo(int o_no, string p_no)
        {
            if (Validation.IsNumber(p_no))
            {
                int no = Convert.ToInt32(p_no);
                foreach (OrderDetail od in Program.AllOrderDetails)
                {
                    if (od.OrderNoRef == o_no)
                    {
                        if (od.ProductDetail.ProductNo == no)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
