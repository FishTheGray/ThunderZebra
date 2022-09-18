using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zebra_console
{
    class Tree
    {
        public Node root;
        public Tree(int x, int y, int[,] chessboard, int value) {
            root = new(x,y,chessboard,value);
        }
        
        
    }
    class Node {
        int x, y;
        int[,] chessboard;
        int value;
        public Node(int x ,int y ,int[,]chessboard,int value)
        {
            this.x = x;
            this.y = y;
            this.chessboard = chessboard;
            this.value = value;
        }
        public Node subnode;
        public Node siblingnode;
        public void addsub(Node i) {
            if (subnode == null)
            {
                subnode = i;
            }
            else
            {
               subnode.addsibling(i);
            }
        }

        public  void addsibling(Node i)
        {
            if (siblingnode == null)
            {
                siblingnode = i;
            }
            else
            {
                siblingnode.addsibling(i);
            }
        }
        public void delsub(Node i)
        {
            if(subnode!= null)
            {
                if (subnode == i)
                {
                    if (subnode.siblingnode != null)
                    {
                        subnode = subnode.siblingnode;
                    }
                    else
                    {
                        subnode = null;
                    }
                }
                else
                {
                    subnode.delsibling(i);
                }
            }
            
        }

        public void delsibling(Node i)
        {
            if (siblingnode != null)
            {
                if (siblingnode == i)
                {
                    if (siblingnode.siblingnode != null)
                    {
                        siblingnode = siblingnode.siblingnode;
                    }
                    else
                    {
                        siblingnode = null;
                    }


                }
                else
                {
                    siblingnode.delsibling(i);
                }
            }
            
        }
    }
}
