using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsuck
{
    class GreedyAlgoritm
    {
        private int N;
        private int Weight;
        private Item[] arr;

        public GreedyAlgoritm(int N,int Weight,Item [] arr)
        {
            this.N = N;
            this.Weight = Weight;
            this.arr = arr;
        }

        public double knapsack()
        {
            IComparer<Item> itemComparer = new DescentComparer();
            Array.Sort(arr, itemComparer);
            double currWeght = 0;
            double finalValue = 0;
            for(int i=0;i< N;i++)
            {
                if(currWeght+arr[i].Weight<=Weight)
                {
                    currWeght += arr[i].Weight;
                    finalValue += arr[i].Value;
                }
                //else
                //{
                //    double remain = Weight - currWeght;
                //    finalValue += arr[i].Value * (remain / arr[i].Weight);
                //    break;
                //}
            }
            return finalValue;
        }
    }
}
