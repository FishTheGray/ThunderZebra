using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Input
    {
        int[,] chessboard;
        private Camp camp;
        private Record record;
        public Boolean BH = true;
        public BannedHand hand ;

        public Boolean isEmpty(int posistion_x, int posistion_y)
        {
            if (posistion_x <= 15 && posistion_x >= 1 && posistion_y <= 15 && posistion_y >= 1)
            {
                if (chessboard[posistion_x - 1, posistion_y - 1] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        Boolean isCamp()
        {
            return true;
        }
        
        public void insert()
        {
            int x, y;
            do
            {
                
            Console.WriteLine("输入x值");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入y值");
            y = Convert.ToInt32(Console.ReadLine());
            
                
            } while (!isEmpty(x, y));
            insert(x, y);
            
            


        }        
        public void insert(int posistion_x,int posistion_y) {
            
                    chessboard[posistion_x - 1, posistion_y - 1] = record.Step % 2 + 1;
                    record.insert(posistion_x, posistion_y);
                    if (record.Step % 2 == 0)
                    {


                        BH = hand.isBH(posistion_x, posistion_y);
                    }



              


           
        }
        public Input(int[,] cb) {
            chessboard = cb;
        }
        public Input() { 
        }
       

        public Input(int[,] cb, Camp camp, Record record) 
        {
            this.camp = camp;
            this.record = record;
            chessboard = cb;
            hand = new BannedHand(chessboard);
        }
    }
}
