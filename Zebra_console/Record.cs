using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Record
    {
        List<int> record;
        int step = 0;

        public int Step{
            get => step + 1;
        }
        public void export()
        {//格式:
            //标题:<小组号码>-<小组名称1> vs <小组名称2>-<结果>.txt
            //表头:{[小组号码][小组名称1][小组名称2][结果][xxxx-xx-xx xx:xx <地点>][比赛名称];
            //内容:<B/W>(X,y);
            //表尾:}
            //string[] names = new string[] { "Zara Ali", "Nuha Ali" };
            //using (StreamWriter sw = new StreamWriter("names.txt"))
            //{
            //   foreach (string s in names)
            //    {
            //        sw.WriteLine(s);
            //
            //    }
            //}
            List<string> vs = new List<string>();
            Console.WriteLine("小组编码:");
            vs.Add(Console.ReadLine());
            Console.WriteLine("先手:");
            vs.Add(Console.ReadLine());
            Console.WriteLine("后手:");
            vs.Add(Console.ReadLine());
            Console.WriteLine("选择结果:0.先手胜1.后手胜2.平局");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 0:
                    vs.Add("先手胜");
                    break;
                case 1:
                    vs.Add("后手胜");
                    break;
                case 2:
                    vs.Add("平局");
                    break;
                
            }
            Console.WriteLine("地点:");
            vs.Add(Console.ReadLine());
            Console.WriteLine("比赛名称:");
            vs.Add(Console.ReadLine());
            Console.WriteLine("导出成功");
            vs.Add(Console.ReadLine());
            string name = vs[0] + "-" + vs[1] + vs[2] + " vs " + "-" + vs[3] + ".txt";
            string[] head = { "{[",vs[0],"][",vs[1],"][",vs[2],"][",vs[3],"][xxxx-xx - xx xx: xx",vs[4],"][",vs[4],"];",};
        }
        public void insert(int postion_x,int postion_y)
        {
            record.Add(postion_x);
            record.Add(postion_y);
            step = record.Count / 2;
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
