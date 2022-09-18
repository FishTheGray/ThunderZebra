using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Index
    {
        private int[,] cb;
        private int num = 0;

        public Index(int[,] cb)
        {
            this.cb = cb;
        }

        List<int> getLine(int position_x, int position_y,int r,int b,int length) {
            List<int> line = new List<int>();
            int x = position_x - 1;
            int y = position_y - 1;
            for (int i = 0; i < length; i++)
            {
                line.Add(cb[x, y]);
                x += r;
                y -= b;
            }
            return line;
        
        }
        Boolean campare(List<int> source, List<int> destine) {

            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] != destine[i])
                {
                    return false;
                }
                
            }
            return true;
        }
        void search(int r, int b,  List<int> source) {
            int x0, xt,y0,yt;
            int length = source.Count;
            x0 = 1;
            y0 = 1;
            xt = 15;
            yt = 15;
            if (r < 0) 
            {
                
                x0 += length-1;
            }
            if(r>0)
            {
                xt -= length - 1;
            }
            if (b < 0)
            {
                
                yt -= length - 1;
            }
            if(b > 0)
            {
                y0 += length - 1;
            }
            int x, y;
            x = x0;
            while (x<=xt)
            {
                y = y0;
                while (y<=yt)
                {
                    
                    if (campare(source,getLine(x,y,r,b,length)))
                    {
                        num++;
                    }
                    y++;
                }
                x++;
            }

        }
        public int shapeCampare(int[] s)
        {
            num = 0;
            List<int> source = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                source.Add(s[i]);
            }

            Task t1 = new Task(() =>
            {
                search(1, 0, source);
            });
            Task t2 = new Task(() =>
            {
                search(1, 1, source);
            });
            Task t3 = new Task(() =>
            {
                search(0, 1, source);
            });
            Task t4 = new Task(() =>
            {
                search(-1, 1, source);
            });
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            Task.WaitAll(t1, t2, t3, t4);
            return num;
        }
    }
}
