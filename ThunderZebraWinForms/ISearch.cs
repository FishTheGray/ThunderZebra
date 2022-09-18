using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderZebraWinForms
{
    public interface ISearch
    {
        public int Swap(int type);
        public List<int> Nda_genate(int n);
        public int Nda_select(List<int> li);
        public void Step();

    }
}
