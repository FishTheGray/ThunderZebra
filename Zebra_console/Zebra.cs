using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Zebra
    {
        public Camp camp;
        public Record record;
        public Input input;

        //chessboard is  2D-array,point (x,y)  is in the index (x-1,y-1) , 0 for empty,1 for white,2 for black
        public int[,] chessboard = new int[15, 15];
        public static void Main(string[] agrs)
        {
            Zebra game = new Zebra();
            ISearch search = new NegaAlpha(game);
            Loop l = new Loop(game, search);
            l.judge();



            //Start start = new Start();
            //Console.ReadLine();
        }
        public Zebra() {
            camp = new Camp();
            record = new Record();
            input = new Input(chessboard,camp ,record);
        }
        
        

        public void display()
        {
            for (int y = 14; y >= 0; y--)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (chessboard[x,y] == 0)
                    {
                        Console.Write("[ ]");
                    }
                    if (chessboard[x,y] == 1)
                    {
                        Console.Write(" O ");
                    }
                    if (chessboard[x,y] == 2)
                    {
                        Console.Write(" @ ");
                    }

                }
                Console.Write("\n");
            }
        }
        
       
    }
    class Camp
    {
        private int human;
        public int Human
        {
            get => human;
        }
        private int N = 2;
        public int n {
            get => N;
        }
        int s;//0交换1不交换
        public Camp()
        {
            Console.WriteLine("人类,输入你的阵营:\n1.白2.黑");
            human = Convert.ToInt32(Console.ReadLine());
            if (human == 2)
            {
                Console.WriteLine("输入N值");
                N = Convert.ToInt32(Console.ReadLine());


            }
            else
            {
                Console.WriteLine("N值为{0}", N);
            }


        }
        void input()
        {
            Console.WriteLine("swap?0.yes1.no");
            s = Convert.ToInt32(Console.ReadLine());

        }
        void swap()
        {
            if (s == 0)
            {
                human = human == 1 ? 2 : 1;
                Console.WriteLine("交换完成");
            }


        }
        void generate()
        {
            Random ran = new Random();
            s = ran.Next(0, 1);
            if (s == 0)
            {
                Console.WriteLine("我方选择交换");
            }
            else
            {
                Console.WriteLine("我方选择不交换");
            }
        }
        void generate(ISearch search ,int type)
        {
            s = search.Swap(type);
            if (s == 0)
            {
                Console.WriteLine("我方选择交换");
            }
            else
            {
                Console.WriteLine("我方选择不交换");
            }
        }

        public void getSwap()
        {
            
            if (human == 2)
            {
                generate();

            }
            else
            {
                input();
            }
            swap();
        }
        public void getSwap(ISearch search , int type)
        {

            if (human == 2)
            {
                generate(search,type);

            }
            else
            {
                input();
            }
            swap();
        }
    }
}

