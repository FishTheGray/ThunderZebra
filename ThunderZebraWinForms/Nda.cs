using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    public class Nda
    {
        int n;
        Zebra game;
        Input ip;

        ISearch search;
        List<int> vs = new List<int>();//备选点
        void input() {//输入n个备选的点
            //int x, y;

            for (int i = 0; i < n; i++)
            {

                //do
                //{
                //    System.Diagnostics.Debug.WriteLine("请输入x值:");
                //    //x = Convert.ToInt32(System.Diagnostics.Debug.ReadLine());
                //    System.Diagnostics.Debug.WriteLine("请输入y值:");
                //    //y = Convert.ToInt32(System.Diagnostics.Debug.ReadLine());

                //} while (!ip.isEmpty(x, y));
                //vs.Add(x);
                //vs.Add(y);
            }
        }
        public void input(int x ,int y)
        {
            vs.Add(x);
            vs.Add(y);
            System.Diagnostics.Debug.WriteLine("x=" + x);
            System.Diagnostics.Debug.WriteLine("x=" + y);


        }
        public List<int> genate()
        {
            //int x, y;
            List<int> li = new List<int>();
            //Random random = new Random();

            //for (int i = 0; i < n; i++)
            //{

            //    do
            //    {
            //        x = random.Next(1,15);
            //        y = random.Next(1, 15);

            //    } while (!ip.isEmpty(x, y));
            //    System.Diagnostics.Debug.WriteLine("生成的点是{0},{1}",x,y);
            //    vs.Add(x);
            //    li.Add(x);
            //    vs.Add(y);
            //    li.Add(y);
            //}
            //return li;
            li =search.Nda_genate(n);
            vs = li;

            for (int i = 0; i*2 <= li.Count; i+=2)
            {
                System.Diagnostics.Debug.WriteLine("生成的点是{0},{1}", li[i], li[i+1]);
            }
            return li;

        }
        public void select()
        {
            //自动选择

            //Random random = new Random();
            //int c = random.Next(1, n);
            int c = search.Nda_select(vs);
            int x = vs[2*c];
            int y = vs[2 * c+1];
            System.Diagnostics.Debug.WriteLine("选定的点为:{0},{1}",x,y);
            ip.insert(x,y);
        }
        void man_select() {
            System.Diagnostics.Debug.WriteLine("选择第几个点?");
            //int c = Convert.ToInt32(System.Diagnostics.Debug.ReadLine()) - 1;
            //int x = vs[2 * c];
            //int y = vs[2 * c + 1];
            //System.Diagnostics.Debug.WriteLine("选定的点为:{0},{1}", x, y);
            //ip.insert(x, y);
        }
        public void man_select(int c)
        {
            //System.Diagnostics.Debug.WriteLine("选择第几个点?");
            //int c = Convert.ToInt32(System.Diagnostics.Debug.ReadLine()) - 1;
            int x = vs[2 * c];
            int y = vs[2 * c + 1];
            System.Diagnostics.Debug.WriteLine("选定的点为:{0},{1}", x, y);
            ip.insert(x, y);
        }
        public void begin()
        {
            if (game.camp.Human == 2 ) {
                input();
                select();
            }
            else
            {
                genate();
                man_select();
            }
        }
        public Nda(Zebra game)
        {
            this.n = game.camp.n;
            this.ip = game.input;
            this.game = game;
            System.Diagnostics.Debug.WriteLine("开始五手n打,n值为{0}", this.n);
            //begin();
        }
        public Nda(Zebra game ,ISearch search)
        {
            this.n = game.camp.n;
            this.ip = game.input;
            this.game = game;
            this.search = search;
            System.Diagnostics.Debug.WriteLine("开始五手n打,n值为{0}", this.n);
            //begin();
        }




    }
}
