using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class DeleteNode<T>
    {
        MyTreeSetImpl<T> parent = null;
        MyTreeSetImpl<T> changeNode = null;
        MyTreeSetImpl<T> replecementParent = null;
        bool right = false,left=false;

        public bool deleteNode(MyTreeSetImpl<T> node, T value)
        {
            if (node.getRoot() == false)
            {
                return false;
            }
            if (node.comparator.Compare(value, node.getValue()) == 0)
            {
                if (node.getLeftChild() == null && node.getRightChild() == null)
                {
                    if (this.parent != null)
                    {
                        if (this.right == true)
                        {
                            this.parent.setRightChild(this.changeNode);
                        }
                        else
                        {
                            this.parent.setLeftChild(this.changeNode);
                        }

                    }
                    else
                    {
                        node.setRoot(false);
                    }
                    return true;
                }
                if (null != node.getLeftChild() && null != node.getRightChild())
                {
                    this.right = false;
                    this.left = false;
                    node.setValue(minNodeValue(node));
                    return true;
                }
                if (node.getLeftChild() != null)
                {
                    if (this.parent != null)
                    {
                        if (this.left == true)
                        {
                            this.parent.setLeftChild(node.getLeftChild());
                        }
                        else
                        {
                            this.parent.setRightChild(node.getLeftChild());
                        }
                        return true;
                    }
                    else
                    {
                        node.setValue(node.getLeftChild().getValue());
                        node.setLeftChild(this.changeNode);
                        return true;
                    }

                }
                if (node.getRightChild() != null)
                {
                    if (this.parent != null)
                    {
                        if (this.right == true)
                        {
                            this.parent.setRightChild(node.getRightChild());
                        }
                        else
                        {
                            this.parent.setLeftChild(node.getRightChild());
                        }
                        return true;
                    }
                    else
                    {
                        node.setValue(node.getRightChild().getValue());
                        node.setRightChild(this.changeNode);
                        return true;
                    }

                }
            }
            this.parent = node;
            if (node.comparator.Compare(node.getValue(), value) > 0)
            {
                this.left = true;
                this.right = false;
                return deleteNode((MyTreeSetImpl<T>)node.getLeftChild(), value);
            }
            if (node.comparator.Compare(node.getValue(), value) < 0)
            {
                this.right = true;
                this.left = false;
                return deleteNode((MyTreeSetImpl<T>)node.getRightChild(), value);
            }
            return false;
        }

        private T minNodeValue(MyTreeSetImpl<T> node)
        {
            if (node.getLeftChild() == null) {
             T value = node.getValue();
            if (node.getRightChild() != null) {
                if (this.left == false) {
                    this.replecementParent.setRightChild(node.getRightChild());
                    return value;
                } else {
                    this.replecementParent.setLeftChild(node.getRightChild());
                    return value;
                }
            } else {
                if (this.left == false) {
                    this.replecementParent.setRightChild(this.changeNode);
                    return value;
                } else {
                    this.replecementParent.setLeftChild(this.changeNode);
                    return value;
                }
            }
        }
        this.replecementParent = (MyTreeSetImpl<T>) node;
        if (this.right == false) {
            this.right = true;
            return minNodeValue((MyTreeSetImpl<T>)node.getRightChild());
        } else {
            this.left = true;
            return minNodeValue((MyTreeSetImpl<T>)node.getLeftChild());
        }
        }
    }
}
