using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class MyTreeSetImpl<T>:AbstractTreeSet<T>
    {
      

       

        private T value;
        private MyTreeSetImpl<T> leftChild = null;
        private MyTreeSetImpl<T> rightChild = null;
        private bool root = false;
        public Comparer<T> comparator;
        

        public MyTreeSetImpl( string strategy, T value, Comparer<T> comparator) :base(strategy){
            this.value = value;
            this.root = true;
            this.comparator = comparator;
        }

        public MyTreeSetImpl(String strategy, Comparer<T> comparator):base(strategy){
            this.comparator = comparator;
        }

        private MyTreeSetImpl(TreeTravels<T>.traverse strategy, T value, Comparer<T> comparator) :base(strategy){
            this.value = value;
            this.root = true;
            this.comparator = comparator;
        }
        override public T getValue()
        {
            return this.value;
        }
        override public MyTreeSet<T> getLeftChild()
        {
            return this.leftChild;
        }
        override public MyTreeSet<T> getRightChild()
        {
            return this.rightChild;
        }
        override public  void add(T value)
        {
            if (false == this.root)
            {
                this.value = value;
                this.root = true;
            }
            else if (comparator.Compare(value, this.getValue()) <= 0)
            {
                if (this.getLeftChild() == null)
                {
                    this.leftChild = new MyTreeSetImpl<T>(this.strategy, value, comparator);
                }
                else
                {
                    this.getLeftChild().add(value);
                }
            }
            else
            {
                if (this.getRightChild() == null)
                {
                    this.rightChild = new MyTreeSetImpl<T>(this.strategy, value, comparator);
                }
                else
                {
                    this.getRightChild().add(value);
                }
            }
        }
        override public bool contains(T value)
        {
            MyTreeSetImpl<T> t = this;
            if (this.root == true)
            {
                while (t != null)
                {
                    if (t.comparator.Compare(value, t.getValue()) == 0)
                    {
                        return true;
                    }
                    else if (t.comparator.Compare(value, t.getValue()) < 0)
                    {
                        t = (MyTreeSetImpl<T>)t.getLeftChild();
                    }
                    else
                    {
                        t = (MyTreeSetImpl<T>)t.getRightChild();
                    }
                }
            }
            return false;
        }
        override public void traverse(Action<T> traversor)
        {
            this.strategy(this, traversor);
        }
        public override bool getRoot()
        {
            return this.root;
        }
        public override int size()
        {
            List<T> list = new List<T>();
            this.traverse((i) => { list.Add(i); });
            return list.Count;
        }
        public override List<T> toArray()
        {
            List<T> list = new List<T>();
            this.traverse((i) =>
            {
                list.Add(i);
            });
            return list;
        }
        public override string toString()
        {
            StringBuilder sb = new StringBuilder();
            this.traverse((i) =>
            {
                sb.Append(i.ToString());
            });
            return sb.ToString();
        }
        public override void setValue(T value)
        {
            this.value = value;
        }
        public override void setLeftChild(MyTreeSet<T> left)
        {
            this.leftChild = (MyTreeSetImpl<T>)left;
        }
        public override void setRightChild(MyTreeSet<T> right)
        {
            this.rightChild = (MyTreeSetImpl<T>)right;
        }
        public void setRoot(bool root)
        {
            this.root = root;
        }
        public override bool remove(T el)
        {
            DeleteNode<T> del = new DeleteNode<T>();
            return del.deleteNode(this, el);
        }
        public override void updateValue(T el, T el2)
        {
            remove(el);
            add(el2);
        }
    }
}
