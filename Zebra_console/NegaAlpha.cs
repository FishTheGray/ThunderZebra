using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    class NegaAlpha : NegaMax
    {
        public NegaAlpha(Zebra game)
            : base(game)
        {

        }
        public override void Step()
        {
            alphabeta(1);


            input.insert(put_x, put_y);
            Console.WriteLine("当前估值{0}", e.getValue(game.chessboard, game.record.Step,put_x,put_y));
        }
        private void alphabeta(int depth)
        {
            int bestvalue = int.MinValue;
            int value = int.MinValue;
            int step = game.record.Step;
            int con = 1;
            int[,] chessbroad = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    chessbroad[x, y] = game.chessboard[x, y];
                }

            }
            Console.WriteLine("估值中");
            ////e.getValue(chessbroad, step);

            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad))
                    {
                        chessbroad[x - 1, y - 1] = step % 2 + 1;
                        value = -alphabeta(depth - 1, x, y, -int.MaxValue, int.MaxValue, chessbroad, step + 1);
                                                            //负极大值      负极小值
                        chessbroad[x - 1, y - 1] = 0;

                        Console.WriteLine("{0}/{1}", con, 255 - step + 1);
                        con++;
                        Console.WriteLine("解析点为({0},{1})", x, y);
                        Console.WriteLine("{0}", value);
                        if (value > bestvalue)
                        {
                            bestvalue = value;
                            put_x = x;
                            put_y = y;
                        }
                    }
                }
            }
        }
        private int alphabeta(int depth, int position_x, int position_y,int alpha ,int beta, int[,] chessbroad, int step)
        {
            
            int value;
            
            if (depth == 0)
            {
                return e.getValue(chessbroad, step,position_x,position_y);
            }
            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad))
                    {
                        chessbroad[x - 1, y - 1] = step % 2 + 1;
                        value = -alphabeta(depth - 1, x, y, -beta, -alpha,chessbroad, step + 1);
                        chessbroad[x - 1, y - 1] = 0;
                        //if (value > bestvalue)
                        //{
                        //    bestvalue = value;
                        //}
                        if (Math.Abs(value) == int.MaxValue)
                        {
                            return value;
                        }
                        if (value >= alpha)
                        {
                            alpha = value;
                        }
                        if (alpha >= beta)
                        {
                            break;
                        }

                        
                    }
                }
            }   
            return alpha;





        }



    }    
}
