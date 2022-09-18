using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    class Evaluate
    {

        //int step;




        //int[] value = { 15, 20, 200, 20, 200, 10000, 10010, 10000, 100000, 1000000, int.MaxValue, 10 };
        int[] value = { 15, 20, 200, 20, 200, 1000000, 1000001, 100000, 1000001, 2000000, int.MaxValue, 10 };
                        //死二,冲二,活二,死三,冲三,活三,跳三,死四,冲四,活四,五

        public Evaluate() {

            
        }
        //private Boolean fullBanCheck(int[,] chessbroad)
        //{
        //    int c = 0;
        //    BannedHand hand = new BannedHand(chessbroad);
        //    for (int x = 1; x <= 15; x++)
        //    {
        //        for (int y = 1; y <= 15; y++)
        //        {
        //            if (chessbroad[x-1,y-1]==2) {
        //                if (!hand.isBH(x,y)) {
        //                    c++;
        //                }
        //            }
        //        }
        //    }
        //    if (c == 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
                    
        //}
        private Boolean BanCheck(int[,] chessbroad,int position_x,int position_y)
        {
            int c = 0;
            BannedHand hand = new BannedHand(chessbroad);
            
                
                    
            if (!hand.isBH(position_x, position_y))
            {
                c++;
            }
                 
            if (c == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getValue(int[,]chessbroad,int step, int position_x, int position_y)
        {
            int bee;
            if (step % 2 == 0)
            {
                if (BanCheck(chessbroad, position_x, position_y))
                {
                    bee = calc(chessbroad, step);
                }
                else
                {

                    if (step % 2 == 0)
                    {
                        bee = int.MaxValue;
                    }
                    else
                    {
                        bee = -int.MaxValue;
                    }
                }
                
            }
            else
            {
                bee = calc(chessbroad, step);
            }


            return bee;


        }
        int calc(int[,] chessboard , int step)
        {
            Index i = new Index(chessboard);
            List<int[]> vb = new List<int[]>();
            int score,sb,sw;
            //死二 0
            vb.Add(new int[] { 1, 2, 2, 1 });
            //冲二 1 2
            vb.Add(new int[] { 0, 2, 2, 1 });
            vb.Add(new int[] { 1, 2, 2, 0 });
            //活二 3
            vb.Add(new int[] { 0, 2, 2, 0 });
            //死三 4
            vb.Add(new int[] { 1, 2, 2, 2, 1 });
            //冲三 5 6
            vb.Add(new int[] { 0, 2, 2, 2, 1 });
            vb.Add(new int[] { 1, 2, 2, 2, 0 });
            //活三 7 8 9
            vb.Add(new int[] { 0, 0, 2, 2, 2, 0 });
            vb.Add(new int[] { 0, 2, 2, 2, 0, 0 });
            vb.Add(new int[] { 0, 0, 2, 2, 2, 0, 0 });
            //跳三 10 11 
            vb.Add(new int[] { 0, 2, 0, 2, 2, 0 });
            vb.Add(new int[] { 0, 2, 2, 0, 2, 0 });
            //死四 12
            vb.Add(new int[] { 2, 2, 2, 2 });
            //冲四 13 14 15 16 17 
            vb.Add(new int[] { 2, 0, 2, 2, 2 });
            vb.Add(new int[] { 2, 2, 0, 2, 2 });
            vb.Add(new int[] { 2, 2, 2, 0, 2 });
            vb.Add(new int[] { 0, 2, 2, 2, 2 });
            vb.Add(new int[] { 2, 2, 2, 2, 0 });
            //活四 18
            vb.Add(new int[] { 0, 2, 2, 2, 2, 0 });
            //五 19
            vb.Add(new int[] { 2, 2, 2, 2, 2});

            vb.Add(new int[] { 0, 0, 2, 0, 0 });
            try
            {
                checked
                {
                    sb = value[0] * i.shapeCampare(vb[0]);
                    sb += value[1] * (i.shapeCampare(vb[1]) + i.shapeCampare(vb[2]));
                    sb += value[2] * i.shapeCampare(vb[3]);
                    sb += value[3] * i.shapeCampare(vb[4]);
                    sb += value[4] * (i.shapeCampare(vb[5]) + i.shapeCampare(vb[6]));
                    sb += value[5] * (i.shapeCampare(vb[7]) + i.shapeCampare(vb[8]) - i.shapeCampare(vb[9]));
                    sb += value[6] * (i.shapeCampare(vb[10]) + i.shapeCampare(vb[11]));
                    sb += value[7] * i.shapeCampare(vb[12]);
                    sb += value[8] * (i.shapeCampare(vb[13]) + i.shapeCampare(vb[14]) + i.shapeCampare(vb[15]) + i.shapeCampare(vb[16]) + i.shapeCampare(vb[17]) - i.shapeCampare(vb[18]));
                    sb += value[9] * i.shapeCampare(vb[18]);
                    sb += value[10] * i.shapeCampare(vb[19]);
                    sb += value[11] * i.shapeCampare(vb[20]);
                }
            }
            catch (OverflowException)
            {
                sb = int.MaxValue;
                //System.Windows.Forms.MessageBox.Show("黑方溢出");
            }
            //Console.WriteLine("当前黑方分数为{0}",sb);



            List<int[]> vw = new List<int[]>();
            //死二 0
            vw.Add(new int[] { 2, 1, 1, 2 });
            //冲二 1 2
            vw.Add(new int[] { 0, 1, 1, 2 });
            vw.Add(new int[] { 2, 1, 1, 0 });
            //活二 3
            vw.Add(new int[] { 0, 1, 1, 0 });
            //死三 4
            vw.Add(new int[] { 2, 1, 1, 1, 2 });
            //冲三 5 6
            vw.Add(new int[] { 0, 1, 1, 1, 2 });
            vw.Add(new int[] { 2, 1, 1, 1, 0 });
            //活三 7 8 9
            vw.Add(new int[] { 0, 0, 1, 1, 1, 0 });
            vw.Add(new int[] { 0, 1, 1, 1, 0, 0 });
            vw.Add(new int[] { 0, 0, 1, 1, 1, 0, 0 });
            //跳三 10 11 
            vw.Add(new int[] { 0, 1, 0, 1, 1, 0 });
            vw.Add(new int[] { 0, 1, 1, 0, 1, 0 });
            //死四 12
            vw.Add(new int[] { 1, 1, 1, 1 });
            //冲四 13 14 15 16 17 
            vw.Add(new int[] { 1, 0, 1, 1, 1 });
            vw.Add(new int[] { 1, 1, 0, 1, 1 });
            vw.Add(new int[] { 1, 1, 1, 0, 1 });
            vw.Add(new int[] { 0, 1, 1, 1, 1 });
            vw.Add(new int[] { 1, 1, 1, 1, 0 });
            //活四 18
            vw.Add(new int[] { 0, 1, 1, 1, 1, 0 });
            //五 19
            vw.Add(new int[] { 1, 1, 1, 1, 1 });

            vw.Add(new int[] { 0, 0, 1, 0, 0 });
            try
            {
                checked
                {
                    sw = value[0] * i.shapeCampare(vw[0]);
                    sw += value[1] * (i.shapeCampare(vw[1]) + i.shapeCampare(vw[2]));
                    sw += value[2] * i.shapeCampare(vw[3]);
                    sw += value[3] * i.shapeCampare(vw[4]);
                    sw += value[4] * (i.shapeCampare(vw[5]) + i.shapeCampare(vw[6]));
                    sw += value[5] * (i.shapeCampare(vw[7]) + i.shapeCampare(vw[8]) - i.shapeCampare(vw[9]));
                    sw += value[6] * (i.shapeCampare(vw[10]) + i.shapeCampare(vw[11]));
                    sw += value[7] * i.shapeCampare(vw[12]);
                    sw += value[8] * (i.shapeCampare(vw[13]) + i.shapeCampare(vw[14]) + i.shapeCampare(vw[15]) + i.shapeCampare(vw[16]) + i.shapeCampare(vw[17]) - i.shapeCampare(vw[18]));
                    sw += value[9] * i.shapeCampare(vw[18]);
                    sw += value[10] * i.shapeCampare(vw[19]);
                    sw += value[11] * i.shapeCampare(vw[20]);
                    sw *= 9;
                    sw /= 10;
                }
            }
            catch (OverflowException)
            {
                sw = int.MaxValue;
                //System.Windows.Forms.MessageBox.Show("白方溢出");

            }
            
            //Console.WriteLine("当前白方分数为{0}", sw);
             
                score = sb - sw;

            if (step % 2 == 0)
            {
                score *= -1;

            }
            //Console.WriteLine("当前阵营分数为{0}", score);
            return score;
        }
        
    }
}
