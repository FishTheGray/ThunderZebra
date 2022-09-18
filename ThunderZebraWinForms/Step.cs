using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    class Step
    {
        Input i;
        ISearch search;

        
        public void judge(int human, int step,int position_x, int position_y)
        {
            if (human - 1 == step % 2)
            {
                i.inserth(position_x,position_y);

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
