using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class test : ISearch
    {
        Zebra game;
        Input input;
        int x, y;
        public test(Zebra game)
        {
            this.game = game;
            input = game.input;
        }
        public int Nda()
        {
            return 0;
        }
        
        public void Step()
        {
            
            Random random = new ();
            do
            {
 
                x = random.Next(1,15);

                y = random.Next(1, 15);


            } while (!input.isEmpty(x, y));
            input.insert(x, y);
            
        }

        public int Swap(int type)
        {
            Random random = new();
            return random.Next(0,1);
        }
    }
}
