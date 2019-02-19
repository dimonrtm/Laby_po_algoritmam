using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsuck
{
    class BranchAndBound
    {
        private int N;
        private int Weight;
        private Item []arr;

        public BranchAndBound(int N,int Weight,Item[]arr)
        {
            this.N = N;
            this.Weight = Weight;
            this.arr = arr;
        }

        public int knapsack()
        {
            IComparer<Item> itemComparer = new ItemComparer();
            Array.Sort(arr, itemComparer);
            Queue<Node> Q = new Queue<Node>();
            Node u = new Node();
            Node v = new Node();
            u.Level = -1;
            u.Profit = 0;
            u.Weight = 0;
            Q.Enqueue(u);
            int maxProfit = 0;
            while(Q.Count!=0)
            {
                u = Q.Dequeue();
                if(u.Level==-1)
                {
                    v.Level = 0;
                }
                if(u.Level==N-1)
                {
                    continue;
                }
                v.Level = u.Level + 1;
                v.Weight = u.Weight + arr[v.Level].Weight;
                v.Profit = u.Profit + arr[v.Level].Value;
                if(v.Weight<=Weight&&v.Profit>maxProfit)
                {
                    maxProfit = v.Profit;
                }
                v.Bound = bound(v);
                if(v.Bound>maxProfit)
                {
                    Node temp = new Node();
                    temp.Level = v.Level;
                    temp.Profit = v.Profit;
                    temp.Weight = v.Weight;
                    temp.Bound = v.Bound;
                    Q.Enqueue(temp);
                }
                v.Weight = u.Weight;
                v.Profit = u.Profit;
                v.Bound = bound(v);
                if(v.Bound>maxProfit)
                {
                    Node temp = new Node();
                    temp.Level = v.Level;
                    temp.Profit = v.Profit;
                    temp.Weight = v.Weight;
                    temp.Bound = v.Bound;
                    Q.Enqueue(temp);
                }
            }
            return maxProfit; 
        }

        private double bound(Node u)
        {
            if(u.Weight>=Weight)
            {
                return 0;
            }

            double profitBound = u.Profit;
            int j = u.Level + 1;
            double totweight = u.Weight;
            while((j<N)&&(totweight+arr[j].Weight<=Weight))
            {
                totweight += arr[j].Weight;
                profitBound += arr[j].Value;
                j++;
            }
            if(j<N)
            {
                profitBound += (Weight - totweight) *arr[j].Value /arr[j].Weight;
            }
            return profitBound;
        }
    }
}
