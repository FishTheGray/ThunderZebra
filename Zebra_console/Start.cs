using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Start
    {
        
        int[] TM = new int[4];
        Zebra game;
        Record rc;
        ISearch search;
        int Type;
        int[] Add = {0,1, 1,1, 2,1, 1,0, 2,0, 1,-1, 2,-1, 0,-2, 1,-2, 2,-2, 0,-3, 1,-3, 2,-3,
                     1,1, 1,0, 1,-1, 1,-2, 1,-3, 0,-1, 0,-2, 0,-3, -1,-2, -1,-3, -2,-2, -2,-3, -3,-3};
        /*
         *直指开局(0,1)
         x值可以取负
            1.寒星局(0,1)
            2.溪月局(1,1)
            3.疏月局(2,1)
            4.花月局(1,0)
            5.残月局(2,0)
            6.雨月局(1,-1)
            7.金星局(2,-1)
            8.松月局(0,-2)
            9.丘月局(1,-2)
            10.新月局(2,-2)
            11.瑞星局(0,-3)
            12.山月局(1,-3)
            13.游星局(2,-3)
         *斜指开局(1,1)
            xy值可以互换
            14.长星局(1,1)
            15.峡月局(1,0)
            16.恒星局(1,-1)
            17.水月局(1,-2)
            18.流星局(1,-3)
            19.云月局(0,-1)
            20.浦月局(0,-2)
            21.岚月局(0,-3)
            22.银月局(-1,-2)
            23.明星局(-1,-3)
            24.斜月局(-2,-2)
            25.名月局(-2,-3)
            26.彗星局(-3,-3)
            1.寒星局
            2.溪月局
            3.疏月局
            4.花月局
            5.残月局
            6.雨月局
            7.金星局
            8.松月局
            9.丘月局
            10.新月局
            11.瑞星局
            12.山月局
            13.游星局
            14.长星局
            15.峡月局
            16.恒星局
            17.水月局
            18.流星局
            19.云月局
            20.浦月局
            21.岚月局
            22.银月局
            23.明星局
            24.斜月局
            25.名月局
            26.彗星局
        */


        void input()//输入启动值
    {
            do
            {
                Console.WriteLine("choose 1-26 to set start");
                Type = Convert.ToInt32(Console.ReadLine());
            } while (!(Type >= 1 && Type <= 28));
          


        add();
        trans();
    }

    private void trans()
    {
        int r ;
        int c ;
        int f ;
        Console.WriteLine("确认输入:0.确认1.修改");
        c = Convert.ToInt32(Console.ReadLine());
        if(c == 1)
        {
            if(Type < 13)
            {
                TM[0] = 0;
                TM[1] = 1;
            }
            else
            {
                TM[0] = 1;
                TM[1] = 1;
            }
                TM[2] =Add[2*Type -2] ;
                TM[3] =Add[2 * Type-1];
                int x ;
                int y ;
                Console.WriteLine("对称?0.否1.是");
                f = Convert.ToInt32(Console.ReadLine());
                if (f == 1)
                {
                    flip();



                    x = 7;
                    y = 7;
                    game.chessboard[x, y] = 2;
                    rc.insert(x + 1, y + 1);
                    game.chessboard[x, y] = 0;
                    x += TM[0];
                    y += TM[1];
                    game.chessboard[x, y] = 0;
                    x += TM[2];
                    y += TM[3];
                    game.chessboard[x, y] = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        rc.withDraw(game.chessboard);
                    }

                    x = 7;
                    y = 7;
                    game.chessboard[x, y] = 2;
                    rc.insert(x + 1, y + 1);
                    x += TM[0];
                    y += TM[1];
                    game.chessboard[x, y] = 1;
                    rc.insert(x + 1, y + 1);
                    x += TM[2];
                    y += TM[3];
                    game.chessboard[x, y] = 2;
                    rc.insert(x + 1, y + 1);
                    game.display();
                }
                x = 7;
                y = 7;
                game.chessboard[x, y] = 0;
                x += TM[0];
                y += TM[1];
                game.chessboard[x, y] = 0;
                x += TM[2];
                y += TM[3];
                game.chessboard[x, y] = 0;
                for (int i = 0; i < 3; i++)
                {
                    rc.withDraw(game.chessboard);
                }
                Console.WriteLine("旋转:0.上1.右2.下3.左");
            r = Convert.ToInt32(Console.ReadLine());
                rote(r);

                x = 7;
                y = 7;
                game.chessboard[x, y] = 2;
                rc.insert(x + 1, y + 1);
                x += TM[0];
                y += TM[1];
                game.chessboard[x, y] = 1;
                rc.insert(x + 1, y + 1);
                x += TM[2];
                y += TM[3];
                game.chessboard[x, y] = 2;
                rc.insert(x + 1, y + 1);
                game.display();

                
                

            }

    }

        private void flip()
        {
            if (Type > 13)
            {
                int t = TM[2];
                TM[2] = TM[3];
                TM[3] = t;
            }
            else
            {
                TM[2] *= -1;
            }
        }

        private void rote(int r)
        {
            int[] TMr=new int[4];
            switch (r)
            {
                case 0:
                    for (int i = 0; i < 4; i++)
                    {
                        TMr[i] = TM[i];
                    }
                    break;
                case 1:
                    TMr[0] = TM[1];
                    TMr[1]= -TM[0];
                    TMr[2] = TM[3];
                    TMr[3] = -TM[2];
                    break;
                case 2:
                    TMr[0] = -TM[0];
                    TMr[1] = -TM[1];
                    TMr[2] = -TM[2];
                    TMr[3] = -TM[3];
                    break;
                case 3:
                    TMr[0] = -TM[1];
                    TMr[1] = TM[0];
                    TMr[2] = -TM[3];
                    TMr[3] = TM[2];
                    break;
                default:
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                TM[i] = TMr[i];
            }
        }

    void generate()//生成启动值
    {
        int[] start = {4,6,9,19,20,22,23 };
        Random ran = new Random();
        Type = start[ran.Next(0,6)];
        string[] op= { "寒星", "溪月","疏月","花月" ,"残月","雨月" ,"金星" ,"松月" ,"丘月" ,"新月","瑞星","山月","游星",
                        "长星","峡月","恒星","水月","流星","云月","浦月","岚月","银月","明星","斜月","名月","彗星"};
        Console.WriteLine("生成{0}局",op[Type - 1 ]);

        add();

    }
    void init()//初始化游戏
    {

            //for (int i = 1; i <= 26; i++)
            //{
            //    Type = i;
            //    add();
            //    string[] op = { "寒星", "溪月","疏月","花月" ,"残月","雨月" ,"金星" ,"松月" ,"丘月" ,"新月","瑞星","山月","游星",
            //            "长星","峡月","恒星","水月","流星","云月","浦月","岚月","银月","明星","斜月","名月","彗星"};
            //    Console.WriteLine("{1}生成{0}局", op[Type - 1],Type);
            //    search.Step();
            //    restart();


            //}


            if (game.camp.Human == 2)
            {
                input();
            }
            else
            {
                generate();
            }
            game.camp.getSwap(search , Type);
            Step s4 = new(game.input, search);
            s4.judge(game.camp.Human, game.record.Step);
            game.display();
            _ = new Nda(game);
            game.display();
            Loop l = new(game, search);
            l.judge();

        }

    private void add()//指定开局添加棋子
    {


         
            int x = 7;
            int y = 7;
            game.chessboard[x, y] = 2;
            rc.insert(x + 1, y + 1);
            if (Type > 13) {
                x += 1;
                y += 1;
            }
            else
            {
                x += 0;
                y += 1;
            }
            game.chessboard[x, y] = 1;
            rc.insert(x + 1, y + 1);
            x += Add[2 * Type -2];
            y += Add[2 * Type -1];
            game.chessboard[x, y] = 2;
            rc.insert(x + 1, y + 1);
            game.display();
        }
        public void restart() {
            game = new Zebra();
            rc = game.record;
            search = new NegaMax(game);


            init();
        }
        public Start()
        {
            game = new Zebra();
            rc = game.record;
            search = new NegaAlpha(game);
            

            init();
        }
        
    }
    
}
