using System;
using System.Collections.Generic;
using System.Text;

namespace MaxSum
{
    public class Node
    {
        public int value;
        public int distance;
        public bool? left = null;
        public bool? right = null;

        public Node(int v, int d, bool? left, bool? right)
        {
            this.value = v;
            this.distance = d;
            this.left = left;
            this.right = right;
        }

        public bool LeftNotYetVisited()
        {
            if (left == false)
            {
                return false;
            }

            return true;
        }

        public bool RightNotYetVisited()
        {
            if (right == false)
            {
                return false;
            }

            return true;
        }
    }
}
