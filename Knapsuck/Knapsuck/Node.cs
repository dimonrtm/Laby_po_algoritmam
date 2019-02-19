using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsuck
{
    class Node
    {
        int level;
        int profit;
        double bound;
        double weight;

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public int Profit
        {
            get
            {
                return profit;
            }

            set
            {
                profit = value;
            }
        }

        public double Bound
        {
            get
            {
                return bound;
            }

            set
            {
                bound = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }
    }
}
