using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_kommivoyajora
{
    class APPROX_TSP
    {
        private double[,] adj;
        private int N;

        public APPROX_TSP(int N,double [,] adj)
        {
            this.N = N;
            this.adj = adj;
        }

        public List<Vertex> TSP()
        {
            Vertex[] mst = MST();
            Vertex v = mst[0];
            List<Vertex> result=new List<Vertex>();
            step(v, mst, result);
            result.Add(v);
            return result;
        }

        private void step(Vertex v,Vertex[]mst,List<Vertex> result)
        {
            if(!result.Contains(v))
            {
                result.Add(v);
            }
            List<Vertex> temp = new List<Vertex>();
            for (int i = 0; i < N; i++)
            { 
                if (mst[i].Pred != null && mst[i].Pred.Number==v.Number)
                {
                    temp.Add(mst[i]);
                }
            }
            if(temp.Count!=0)
            {
                for(int i=0;i<temp.Count;i++)
                {
                    step(temp[i],mst,result);
                }
            }
            else
            {
                while(v.Pred!=null)
                {
                    v = v.Pred;
                    if(!result.Contains(v))
                    {
                        result.Add(v);
                    }
                }
            }
        }

        private Vertex [] MST()
        {
            Vertex[] listVertex = new Vertex[N];
            for(int i=0;i<listVertex.Length;i++)
            {
                Vertex v = new Vertex();
                v.Number = i;
                v.Key = Double.MaxValue;
                v.Pred = null;
                listVertex[i] = v;
            }
            listVertex[0].Key = 0;
            List<Vertex> Q = new List<Vertex>(listVertex);
            while(Q.Count!=0)
            {
                Vertex u = extractMin(Q);
                for(int j=0;j< N;j++)
                {
                    if(u.Number==j)
                    {
                        continue;
                    }
                    if(Q.Contains(listVertex[j])&&adj[u.Number,listVertex[j].Number]<listVertex[j].Key)
                    {
                        listVertex[j].Pred = u;
                        listVertex[j].Key = adj[u.Number, listVertex[j].Number];
                    }
                }
            }
            return listVertex;
        }
       private Vertex extractMin(List<Vertex>Q)
        {
            Vertex min = new Vertex();
            min.Key = Double.MaxValue;
            for(int i=0;i<Q.Count;i++)
            {
                if(Q[i].Key<min.Key)
                {
                    min = Q[i];
                }
            }
            Q.Remove(min);
            return min;
        }
    }

    class Vertex
    {
        private int number;
        private double key;
        private Vertex pred;

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number= value;
            }
        }

        public double Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public Vertex Pred
        {
            get
            {
                return pred;
            }

            set
            {
                pred = value;
            }
        }
    }

   
}
