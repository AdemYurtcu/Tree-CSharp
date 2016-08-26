using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TreeTravels<T>
    {
        public delegate void traverse(MyTreeSet<T> tree, Action<T> traverser);
    }
}
