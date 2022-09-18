﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    class NegaMax : ISearch
    {
        protected Zebra game;
        protected Input input;
        protected int put_x =1;
        protected int put_y =1;

        protected Evaluate e = new Evaluate();
        public NegaMax(Zebra game)
        {
            this.game = game;
            input = game.input;
        }
        public int Nda()
        {
            return 0;
        }

        public virtual void Step()
        {
            //Random random = new();
            //do
            //{

            //    put_x = random.Next(1, 15);

            //    put_y = random.Next(1, 15);


            //} while (!input.isEmpty(put_x, put_y));

            

            getNegaMax(0);

            
            input.insert(put_x, put_y);
            System.Diagnostics.Debug.WriteLine("当前估值{0}", e.getValue(game.chessboard, game.record.Step,put_x,put_y));
            
        }
        private void getNegaMax(int depth) {
            int bestvalue = int.MinValue;
            int value = int.MinValue;
            int step = game.record.Step;
            int con = 1;
            int[,] chessbroad = new int[15,15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    chessbroad[x, y] = game.chessboard[x, y];
                }

            }
            System.Diagnostics.Debug.WriteLine("估值中");
            ////e.getValue(chessbroad, step);

            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad))
                    {
                        chessbroad[x - 1, y - 1] = step % 2 + 1;
                        value = -getNegaMax(depth, x, y, chessbroad, step + 1);

                        chessbroad[x - 1, y - 1] = 0;

                        System.Diagnostics.Debug.WriteLine("{0}/{1}", con, 255 - step + 1);
                        con++;
                        System.Diagnostics.Debug.WriteLine("解析点为({0},{1})", x, y);
                        System.Diagnostics.Debug.WriteLine("{0}",value);
                        
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
        private int getNegaMax(int depth,int position_x, int position_y, int[,] chessbroad, int step)
        {
            int bestvalue = int.MinValue;
            int value = int.MinValue;
            
            if(depth == 0)
            {
                return e.getValue(chessbroad,step,position_x,position_y);
            }
            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x , y ,chessbroad))
                    {
                        chessbroad[x-1, y-1] = step % 2 + 1;
                        value = -getNegaMax(depth - 1, x , y , chessbroad, step + 1);
                        chessbroad[x - 1, y - 1] = 0;
                        if (Math.Abs(value) == int.MaxValue)
                        {
                            return value;
                        }
                        if (value > bestvalue)
                        {
                            bestvalue = value;
                        }
                    }
                }
            }
            

            return bestvalue;
            
            
        }

        protected bool isEmpty(int x, int y, int[,] chessbroad)
        {
            if (chessbroad[x-1,y-1] == 0) {
                return true;
            }
            return false;
        }

        public int Swap(int type)
        {
            int[] start = { 4, 6, 9, 19, 20, 22, 23 };
            int swap = 1;
            foreach (int n in start)
            {
                if (n == type)
                {
                    swap = 0;
                }
            }
            
            return swap;
        }

        public List<int> Nda_genate(int n)
        {
            int bestvalue = int.MinValue;
            int value = int.MinValue;
            Stack<int> si = new Stack<int>();
            List<int> oi = new List<int>();
            int[,] chessbroad = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    chessbroad[x, y] = game.chessboard[x, y];
                }

            }
            for (int x = 1; x <= 15; x++)
            {
                for (int y = 1; y <= 15; y++)
                {
                    if (isEmpty(x, y, chessbroad))
                    {
                        chessbroad[x - 1, y - 1] = 2;
                        //value = -getNegaMax(depth, x, y, chessbroad, step + 1);
                        value = e.getValue(chessbroad, 5, x, y);
                        chessbroad[x - 1, y - 1] = 0;

                        if (value > bestvalue)
                        {
                            bestvalue = value;
                            si.Push(y);
                            si.Push(x);
                            System.Diagnostics.Debug.WriteLine("生成:\nx:"+x+"\ny:"+y);
                        }
                    }
                }
            }
            for (int i = 0; i < 2*n; i++)
            {
                oi.Add(si.Pop());
            }
            System.Diagnostics.Debug.WriteLine("数列大小:" +oi.Count );
            return oi;
        }

        public int Nda_select(List<int> li)
        {
            int bestvalue = int.MinValue;
            int value = int.MinValue;
            int bestid = 0;
            int[,] chessbroad = new int[15, 15];
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    chessbroad[x, y] = game.chessboard[x, y];
                }

            }
            for (int i = 0; i < li.Count-1; i+=2)
            {
                chessbroad[li[i] - 1, li[i+1] - 1] = 2;
                //value = -getNegaMax(depth, x, y, chessbroad, step + 1);
                value = -e.getValue(chessbroad, 5, li[i], li[i + 1] - 1);
                chessbroad[li[i] - 1, li[i + 1] - 1] = 0;
                if (value > bestvalue)
                {
                    bestvalue = value;
                    bestid = i/2 ;
                }

            }
            return bestid;
        }
    }
}
