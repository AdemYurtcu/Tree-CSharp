using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    abstract class AbstractTreeSet<T> :MyTreeSet<T>
    {
        public abstract void add(T value);
        public abstract bool contains(T el);
        public abstract bool remove(T el);
        public abstract void traverse(Action<T> traversal);
        public abstract MyTreeSet<T> getRightChild();
        public abstract void setRightChild(MyTreeSet<T> right);
        public abstract MyTreeSet<T> getLeftChild();
        public abstract void setLeftChild(MyTreeSet<T> left);
        public abstract void updateValue(T el, T el2);
        public abstract int size();
        public abstract List<T> toArray();
        public abstract bool getRoot();
        public abstract T getValue();
        public abstract void setValue(T value);
        public abstract string toString();

        protected  TreeTravels<T>.traverse strategy;
        private static TreeTravels<T>.traverse inOrder = (MyTreeSet<T> t, Action<T> traverser) =>
        {
            if (t.getRoot() == true)
            {
                if (t != null)
                {
                    if (null != t.getLeftChild())
                    {
                       inOrder(t.getLeftChild(), traverser);
                    }
                    traverser.Invoke(t.getValue());
                    if (null != t.getRightChild())
                    {
                        inOrder(t.getRightChild(), traverser);
                    }
                }
            }
        };
        private static TreeTravels<T>.traverse preOrder = (MyTreeSet<T> t, Action<T> traverser) =>
        {
            if (t.getRoot() == true)
            {
                if (t != null)
                {
                    traverser.Invoke(t.getValue());
                    if (null != t.getLeftChild())
                    {
                        preOrder(t.getLeftChild(), traverser);
                    }                   
                    if (null != t.getRightChild())
                    {
                        preOrder(t.getRightChild(), traverser);
                    }
                }
            }
        };
        private static TreeTravels<T>.traverse postOrder = (MyTreeSet<T> t, Action<T> traverser) =>
        {
            if (t.getRoot() == true)
            {
                if (t != null)
                {
                    if (null != t.getLeftChild())
                    {
                        postOrder(t.getLeftChild(), traverser);
                    }
                    if (null != t.getRightChild())
                    {
                        postOrder(t.getRightChild(), traverser);
                    }
                    traverser.Invoke(t.getValue());
                }
            }
        };
        Dictionary<string, TreeTravels<T>.traverse> methodMap = new Dictionary<string, TreeTravels<T>.traverse>();
        private void fillMethodMap()
        {
            methodMap.Add("inorder", inOrder);
            methodMap.Add("preorder", preOrder);
            methodMap.Add("postorder", postOrder);
        }

        protected AbstractTreeSet(TreeTravels<T>.traverse strategy)
        {
            this.strategy = strategy;
        }
        protected AbstractTreeSet(string strategy)
        {
            setStrategy(strategy);
        }
        
        public void setStrategy(string strategy)
        {
            fillMethodMap();
            this.strategy = methodMap[strategy]; 
        }
    }
}
