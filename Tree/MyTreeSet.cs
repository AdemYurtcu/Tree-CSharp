using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tree
{
    interface MyTreeSet <T>
    {
        void add(T value);

        bool contains(T el);

        bool remove(T el);
        
        void traverse(Action<T> traversal);
        
        MyTreeSet<T> getRightChild();

        void setRightChild(MyTreeSet<T> right);

        MyTreeSet<T> getLeftChild();

        void setLeftChild(MyTreeSet<T> left);

        void updateValue(T el, T el2);

        int size();

        List<T> toArray();

        bool getRoot();

        T getValue();

        void setValue(T value);

        string toString();

        void setStrategy(string strategy);
    }
}
