using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    class PVS : NegaAlpha
    {
        public PVS(Zebra game)
            : base(game)
        {

        }
        public override void Step()
        {
            int x, y;
            (x, y) = game.record.getLast();
            int[,] chessbroad = new int[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    chessbroad[i, j] = game.chessboard[i,j];
                }

            }

            PVSsearch(2,x,y, int.MaxValue, -int.MaxValue,chessbroad,game.record.Step);
                      

            input.insert(put_x, put_y);
        }
        private int PVSsearch(int depth, int position_x, int position_y, int alpha, int beta, int[,] chessbroad, int step)
        {
            int best = 0;
            int value = 0;
            if (depth == 0)
            {
                return e.getValue(chessbroad, step, position_x, position_y);
            }
            //找到第一个空位置
            int i = 1;
            int j = 1;
            while (!isEmpty(i, j, chessbroad))
            {
                i++;
                if (i >= 15)
                {
                    j++;
                    i = 1;
                }
                if (j >= 15)
                {
                    break;
                }
            }
            chessbroad[i - 1, j - 1] = step % 2 + 1;
            //全窗搜索
            best = -PVSsearch(depth - 1, i, j, -beta, -alpha, chessbroad, step + 1);
            chessbroad[i - 1, j - 1] = 0;
            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad) && (x != i && y != j))
                    {
                        if (best < beta)
                        {
                            if (best > alpha)
                            {
                                alpha = best;
                            }
                            i = 1;
                            j = 1;
                            while (!isEmpty(i, j, chessbroad))
                            {
                                i++;
                                if (i >= 15)
                                {
                                    j++;
                                    i = 1;
                                }
                                if (j >= 15)
                                {
                                    break;
                                }
                            }
                            chessbroad[i - 1, j - 1] = step % 2 + 1;
                            value = -PVSsearch(depth - 1, i, j, -alpha - 1, -alpha, chessbroad, step + 1);
                            //fail-high,重新搜索
                            if (value > alpha && value < beta)
                            {
                                best = -PVSsearch(depth - 1, i, j, -beta, -value, chessbroad, step + 1);
                            }
                            else
                            {
                                if (value > best)
                                {
                                    best = value;//命中
                                    put_x = x;
                                    put_y = y;
                                }
                            }

                            chessbroad[i - 1, j - 1] = 0;
                        }
                    }
                }
            }

            return best;
        }
        //private void startPVS(int depth)
        //{
        //    int best = 0;
        //    int value = 0;
        //    int step = game.record.Step;
        //    int[,] chessbroad = new int[15, 15];
        //    for (int x = 0; x < 15; x++)
        //    {
        //        for (int y = 0; y < 15; y++)
        //        {
        //            chessbroad[x, y] = game.chessboard[x, y];
        //        }

        //    }
        //    System.Diagnostics.Debug.WriteLine("估值中");
        //    ////e.getValue(chessbroad, step);
        //    for (int x = 1; x <= 15; x++)
        //    {
        //        for (int y = 1; y <= 15; y++)
        //        {
        //            if (isEmpty(x, y, chessbroad))
        //            {
        //                chessbroad[x - 1, y - 1] = step % 2 + 1;
        //                value = -PVSsearch(depth - 1, x, y, -20000, 10000, chessbroad, step + 1);
        //                //负极大值      负极小值
        //                chessbroad[x - 1, y - 1] = 0;

                        

        //                //System.Diagnostics.Debug.WriteLine("解析点为({0},{1})", x, y);
        //                //System.Diagnostics.Debug.WriteLine("{0}", value);
        //                if (value > best)
        //                {
        //                    best = value;
        //                    put_x = x;
        //                    put_y = y;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
