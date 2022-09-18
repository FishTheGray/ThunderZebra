using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Nda
    {
        int n;
        Zebra game;
        Input ip;

        ISearch search;
        List<int> vs = new List<int>();
        void input() {//输入n个备选的点
            int x, y;

            for (int i = 0; i < n; i++)
            {

                do
                {
                    Console.WriteLine("请输入x值:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入y值:");
                    y = Convert.ToInt32(Console.ReadLine());

                } while (!ip.isEmpty(x, y));
                vs.Add(x);
                vs.Add(y);
            }
        }
        void genate()
        {
            int x, y;
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {

                do
                {
                    x = random.Next(1,15);
                    y = random.Next(1, 15);

                } while (!ip.isEmpty(x, y));
                Console.WriteLine("生成的点是{0},{1}",x,y);
                vs.Add(x);
                vs.Add(y);
            }

        }
        void select()
        {
            //自动选择
            Random random = new Random();
            int c = random.Next(1, n);
            int x = vs[2*c];
            int y = vs[2 * c+1];
            Console.WriteLine("选定的点为:{0},{1}",x,y);
            ip.insert(x,y);
        }
        void man_select() {
            Console.WriteLine("选择第几个点?");
            int c = Convert.ToInt32(Console.ReadLine()) - 1;
            int x = vs[2 * c];
            int y = vs[2 * c + 1];
            Console.WriteLine("选定的点为:{0},{1}", x, y);
            ip.insert(x, y);

        }
        private void begin()
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
            Console.WriteLine("开始五手n打,n值为{0}", this.n);
            begin();
        }

        

        
    }
}
