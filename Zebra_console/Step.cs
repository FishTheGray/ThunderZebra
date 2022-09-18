using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Step
    {
        Input i;
        ISearch search;

        public void judge(int human, int step)
        {
            if (human - 1 == step % 2)
            {
                i.insert();

            }
            else
            {
                search.Step();

            }

        }
        public void roll(int step) {
            i.insert();
        }
        public Step( Input i , ISearch search) {
            this.i = i;
            this.search = search;
        }
        public Step(Input i)
        {
            this.i = i;
            
        }
    }
}
