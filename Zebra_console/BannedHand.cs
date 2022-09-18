using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class BannedHand
    {
         
        private int[,] chessboard = new int[15, 15];
        Index index;
        int B = 0;

        

        public BannedHand(int[,] chessboard)
        {
            this.chessboard = chessboard;
         
            


        }
        private void TTsearch(int position_x, int position_y) {
            int[,] check = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    check[x, y] = chessboard[x, y];
                }

            }
            index = new Index(check);
            int[] s1 = { 0, 2, 2, 2, 0, 0 };
            int[] s2 = { 0, 0, 2, 2, 2, 0 };
            int[] s3 = { 0, 2, 0, 2, 2, 0 };
            int[] s4 = { 0, 2, 2, 0, 2, 0 };
            int[] s5 = { 0, 0, 2, 2, 2, 0, 0 };
            check[position_x-1, position_y-1] = 0;
            int be = index.shapeCampare(s1) + index.shapeCampare(s2) + index.shapeCampare(s3) + index.shapeCampare(s4) - index.shapeCampare(s5);
            check[position_x-1, position_y-1] = 2;
            int af = index.shapeCampare(s1) + index.shapeCampare(s2) + index.shapeCampare(s3) + index.shapeCampare(s4) - index.shapeCampare(s5);
            if (af - be >= 2)
            {
                B++;
            }
        }
        private void FFsearch(int position_x, int position_y)
        {
            int[,] check = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    check[x, y] = chessboard[x, y];
                }

            }
            index = new Index(check);

            int[] s1 = { 2, 0, 2, 2, 2 };
            int[] s2 = { 2, 2, 0, 2, 2 };
            int[] s3 = { 2, 2, 2, 0, 2 };
            int[] s4 = { 0, 2, 2, 2, 2 };
            int[] s5 = { 2, 2, 2, 2, 0 };
            int[] s6 = { 0, 2, 2, 2, 2, 0 };
            check[position_x-1, position_y-1] = 0;
            int be = index.shapeCampare(s1) + index.shapeCampare(s2) + index.shapeCampare(s3) + index.shapeCampare(s4) + index.shapeCampare(s5) - index.shapeCampare(s6);
            check[position_x-1, position_y-1] = 2;
            int af = index.shapeCampare(s1) + index.shapeCampare(s2) + index.shapeCampare(s3) + index.shapeCampare(s4) + index.shapeCampare(s5) - index.shapeCampare(s6);
            if (af - be >= 2)
            {
                B++;
            }
        }
        private void Lsearch(int position_x, int position_y)
        {
            int[,] check = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    check[x, y] = chessboard[x, y];
                }

            }
            index = new Index(check);

            int[] s1 = { 2, 2, 2, 2, 2, 2 };
            check[position_x-1, position_y-1] = 2;
            int af = index.shapeCampare(s1);
            if (af  >= 1)
            {
                B++;
            }
        }

        public Boolean isBH(int position_x,int  position_y)//true表示没有禁手
        {

            Task t1 = new Task(() => TTsearch(position_x, position_y));
            Task t2 = new Task(() => FFsearch(position_x, position_y));
            Task t3 = new Task(() => Lsearch(position_x, position_y));
            t1.Start();
            t2.Start();
            t3.Start();
            Task.WaitAll(t1, t2, t3);


            if (B!=0) {
                
                return false;
            }
            return true;
        }
    }
}
