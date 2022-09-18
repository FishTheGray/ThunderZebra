using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Regret
    {

        Record rc;
        public Boolean isRegret =false;
        public void regret(int[,] cb)
        {
            for (int i = 0; i < 2; i++) {
                rc.withDraw(cb);
            }
            Console.WriteLine("悔棋成功");
            isRegret = false;
        }
        public Regret(Record rc) {
            this.rc = rc;
        }
    }
}
