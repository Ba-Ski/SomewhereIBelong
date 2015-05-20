using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    enum Color
    {
        red,
        black
    };

    //Просто я могу
    class RBNode<T> where T : IComparable<T>
    {

        public T key;
        public Color color;
        public RBNode<T> left;
        public RBNode<T> right;
        public RBNode<T> p;// parent

        public RBNode()
        {
            color = Color.red;
            left = null;
            right = null;
            p = null;
            key = default(T);

        }


        public static bool operator <(RBNode<T> first, RBNode<T> second)
        {
            return first.key.CompareTo(second.key) < 0;
        }
        public static bool operator >(RBNode<T> first, RBNode<T> second)
        {
            return first.key.CompareTo(second.key) > 0;
        }


    }

    class RBTree<T> where T : IComparable<T>
    {

        private RBNode<T> _root;

        public RBTree()
        {
            _root = null;

        }
        public RBTree(T[] source, int count) : this()
        {
            for (int i = 0; i < count; i++)
            {
                RBNode<T> node = new RBNode<T>();
                node.key = source[i];
                Insert(node);
            }
        }

        public void Insert(RBNode<T> node)
        {
            RBNode<T> y = null;
            RBNode<T> x = _root;

            while (x != null)
            {
                y = x;
                if (x > node) x = x.left;
                else x = x.right;
            }

            node.p = y;

            if (y == null)
            {
                _root = node;
            }
            else if (y > node)
                y.left = node;
            else y.right = node;

            node.left = null;
            node.right = null;
            node.color = Color.red;
            RBInsertFixUp(node);
        }

        public bool Serach(T key)
        {
            return SearchImp(key, _root);
        }

        private bool SearchImp(T key, RBNode<T> curnode)
        {
            if (curnode.key.CompareTo(key) < 0)
            {
                if (curnode.right != null) return SearchImp(key, curnode.right);
            }
            else
                if (curnode.key.CompareTo(key) > 0)
                {
                    if (curnode.left != null)
                    {
                        return SearchImp(key, curnode.left);
                    }
                }
                else
                {
                    return true;
                }
            return false;
        }
        private void RBInsertFixUp(RBNode<T> node)
        {
            RBNode<T> y;
            while (node.p.color == Color.red)
            {
                if (node.p == node.p.p.left)
                {
                    y = node.p.p.right;
                    if (y.color == Color.red)
                    {
                        node.p.color = Color.black;
                        y.color = Color.black;
                        node.p.p.color = Color.red;
                        node = node.p.p;
                        continue;
                    }
                    else if (node == node.p.right)
                    {
                        node = node.p;
                        LeftRotate(node);
                    }

                    node.p.color = Color.black;
                    node.p.p.color = Color.red;
                    RightRotate(node.p.p);

                }
                else
                {
                    y = node.p.p.left;
                    if (y.color == Color.red)
                    {
                        node.p.color = Color.black;
                        y.color = Color.black;
                        node.p.p.color = Color.red;
                        node = node.p.p;
                        continue;
                    }
                    else if (node == node.p.left)
                    {
                        node = node.p;
                        RightRotate(node);
                    }

                    node.p.color = Color.black;
                    node.p.p.color = Color.red;
                    LeftRotate(node.p.p);
                }
            }
            _root.color = Color.black;
        }
        private void LeftRotate(RBNode<T> x)
        {
            RBNode<T> y;
            y = x.right;
            x.right = y.left;

            if (y.left != null)
                y.left.p = x;
            y.p = x.p;

            if (x.p == null)
                _root = y;
            else if (x == x.p.left)
                x.p.left = y;
            else x.p.right = y;

            y.left = x;
            x.p = y;

        }
        private void RightRotate(RBNode<T> x)
        {
            RBNode<T> y;
            y = x.left;
            x.left = y.right;

            if (y.right != null)
                y.right.p = x;
            y.p = x.p;

            if (x.p == null)
                _root = y;
            else if (x == x.p.right)
                x.p.right = y;
            else x.p.left = y;

            y.right = x;
            x.p = y;
        }



        public List<T> BFS()
        {
            List<T> keys = new List<T>();
            RBNode<T> node = _root;
            Queue<RBNode<T>> queue = new Queue<RBNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                RBNode<T> item = queue.Dequeue();
                if(item.left!=null) queue.Enqueue(item.left);
                if(item.right!=null) queue.Enqueue(item.right);
                keys.Add(item.key);
            }

            return keys;
        }
    }

    
}
