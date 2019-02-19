using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsuck
{
    class DescentComparer:IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            double r1 = (double)x.Value / x.Weight;
            double r2 = (double)y.Value / y.Weight;
            if (r1 > r2)
            {
                return -1;
            }
            else if (r1 == r2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
