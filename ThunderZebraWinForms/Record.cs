using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    public class Record
    {
        List<int> record;
        int step = 0;

        public int Step{
            get => step + 1;
        }
        
        public void export( string first  ,string last,  string place ,string campaign,int result) 
        {
            List<string> vs = new List<string>();
            List<string> context = new List<string>();
            string a = "";
            for (int i = 0; i < record.Count; i+=2)
            {
                if (record[i] != 0 && record[i+1] != 0)
                {
                    a += ";";
                    if (i / 2 % 2 == 0)
                    {
                        a += "B";
                    }
                    else
                    {
                        a += "W";
                    }
                    int x = record[i] + 64;
                    a += "(" + ((char)x).ToString() + "," + record[i + 1] + ")";
                }
                
                
            }
            a += "}";
            context.Add(a);
            vs.Add("C5");
            
            vs.Add(first);
            
            vs.Add(last);
            
            int c = result;
            switch (c)
            {
                case 0:
                    vs.Add("先手胜");
                    break;
                case 1:
                    vs.Add("后手胜");
                    break;
                case 2:
                    vs.Add("和棋");
                    break;

            }
            
            vs.Add(place);
            
            vs.Add(campaign);
            string name = vs[0] + "-" + vs[1]  + " vs " + vs[2] + "-" + vs[3] + ".txt";
            string[] head = { "{[", vs[0], "][", vs[1], "][", vs[2], "][", vs[3], "][xxxx-xx-xx xx:xx ", vs[4], "][", vs[5], "]" };
            string[] tail = context.ToArray();
            using (StreamWriter sw = new StreamWriter(name))
            {
                foreach (string s in head)
                {
                    sw.Write(s);

                }
                foreach (string s in tail)
                {
                    sw.Write(s);

                }
            }

                
            



        }
        public void insert(int postion_x,int postion_y)
        {
            record.Add(postion_x);
            record.Add(postion_y);
            step = record.Count / 2;
        }
        public (int position_x, int position_y) getLast() {
            int x = record[2 * step - 2];
            int y = record[2 * step - 1];
            return (x, y);
        }
        public void withDraw(int[,] cb)
        {
            
           // for (int i = 1; i <= 2; i++)
            //{
                step = record.Count / 2;
            cb[record[2 * step - 2] - 1, record[2 * step - 1] - 1] = 0;
            record.RemoveAt(2 * step - 1);
            record.RemoveAt(2 * step - 2);
           // }
                step = record.Count / 2;
        }
        public Record()
        {

            record = new List<int>();
        }
    }
}
