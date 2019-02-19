using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_kommivoyajora
{
    class BranchAndBound
    {
        int N;
        double[,] adj;
        int[] finalPath;
        bool[] visited;
        double finalRes = Double.MaxValue;

        public int[] FinalPath
        {
            get
            {
                return finalPath;
            }

            set
            {
                finalPath = value;
            }
        }

        public double FinalRes
        {
            get
            {
                return finalRes;
            }
        }

        public BranchAndBound(int N,double [,] adj)
        {
            this.N = N;
            this.adj = adj;
            finalPath = new int[N+1];
            visited = new bool[N];
        }

        public void TSP()
        {
            int[] currentPath = new int[N + 1];
            double currBound = 0;
            visited = new bool[N + 1];
            for(int i=0;i< N;i++)
            {
                currBound += (firstMin(i) + secondMin(i));
            }
            currBound = currBound / 2;
            visited[0] = true;
            currentPath[0] = 0;
            TSPRec(currBound, 0, 1, currentPath);
        }

        private double firstMin(int i)
        {
            double min = Double.MaxValue;
            for(int k=0;k< N;k++)
            {
                if(adj[i,k]<min&&i!=k)
                {
                    min = adj[i, k];
                }
            }
            return min;
        }

        private double secondMin(int i)
        {
           double first = Double.MaxValue;
            double second = Double.MaxValue;
            for(int j=0; j<N;j++)
            {
                if(i==j)
                {
                    continue;
                }
                if(adj[i,j]<=first)
                {
                    second = first;
                    first = adj[i, j];
                }
                else if(adj[i,j]<=second&&adj[i,j]!=first)
                {
                    second = adj[i, j];
                }
            }
            return second;
        }

        private void TSPRec(double currBound,double currWeght,int level,int []currPath)
        {
            if(level==N)
            {
                if(adj[currPath[level-1],currPath[0]]!=0)
                {
                    double currRes = currWeght + adj[currPath[level - 1], currPath[0]];
                    if(currRes<finalRes)
                    {
                        CopyToFinal(currPath);
                        finalRes = currRes;
                    }
                }
                return;
            }
            for(int i=0;i<N;i++)
            {
                if(adj[currPath[level-1],i]!=0&&visited[i]==false)
                {
                    double temp = currBound;
                    currWeght += adj[currPath[level - 1], i];
                    if (level == 1)
                    {
                        currBound -= ((firstMin(currPath[level - 1]) + firstMin(i)) / 2);
                    }
                    else
                    {
                        currBound -= ((secondMin(currPath[level - 1]) + firstMin(i)) / 2);
                    }
                    if (currBound + currWeght < finalRes)
                    {
                        currPath[level] = i;
                        visited[i] = true;
                        TSPRec(currBound, currWeght, level + 1, currPath);
                    }
                    currWeght -= adj[currPath[level - 1], i];
                    currBound = temp;
                    visited = new bool[N+1];
                    for(int j=0;j<=level-1;j++)
                    {
                        visited[currPath[j]] = true;
                    }
                } 
            }
        }

        private void CopyToFinal(int [] currPath)
        {
            for(int i=0;i< N;i++)
            {
                finalPath[i] = currPath[i];
            }
            finalPath[N] = currPath[0];
        }
    }
}
