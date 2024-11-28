using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class DoubleCircleList<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    int count = 0;
    Node Head;


    public int GetCount()
    {
        return count;
    }
    public void AddAtStart(T value)
    {
        if (Head == null)
        {
            Node newNode = new Node(value);
            Head = newNode;
            Head.Next = newNode;
            Head.Previous = newNode;
            count++;
        }
        else
        {
            Node newNode = new Node(value);
            Node LastNode = SearchLastNode();
            LastNode.Next = newNode;
            newNode.Previous = LastNode;
            Head.Previous = newNode;
            newNode.Next = Head;
            Head = newNode;
            count++;
        }

    }

    public void AddAtEnd(T value)
    {
        if (Head == null)
        {
            AddAtStart(value);
        }
        else
        {
            Node newNode = new Node(value);
            Node LastNode = SearchLastNode();
            LastNode.Next = newNode;
            newNode.Previous = LastNode;
            newNode.Next = Head;
            Head.Previous = newNode;
            count++;
        }

    }

    public void AddAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddAtStart(value);
        }
        else if (position == count)
        {
            AddAtEnd(value);
        }
        else if (position > count)
        {
            throw new NullReferenceException("No puedes hacer eso");
        }
        else
        {
            int i = 0;
            Node newNode = new Node(value);
            Node aux = Head;
            while (i < position - 1)
            {
                aux = aux.Next;
                i++;
            }
            Node FuturePast = aux.Next;
            aux.Next = newNode;
            newNode.Previous = aux;
            newNode.Next = FuturePast;
            FuturePast.Previous = newNode;
            count++;
        }
    }

    public void DeleteAtStart()
    {
        if (Head == null)
        {
            throw new NullReferenceException("No hay nada que borrar");
        }
        else if (Head.Next == Head)
        {
            Head = null;
        }
        else
        {

            Node lastNode = SearchLastNode();
            Node aux = Head.Next;
            lastNode.Next = aux;
            aux.Previous = lastNode;
            Head = null;
            Head = aux;

            count--;

        }
    }

    public void DeleteAtEnd()
    {
        if (Head.Next == Head)
        {
            DeleteAtStart();
        }
        else
        {
            Node lastNode = SearchLastNode();
            Node aux = lastNode.Previous;
            aux.Next = Head;
            Head.Previous = aux;
            lastNode = null;
            count--;
        }

    }

    public void DeleteAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteAtStart();
        }
        else if (position == count - 1)
        {
            DeleteAtEnd();
        }
        else if (position >= count)
        {
            throw new NullReferenceException("No puedes hacer eso");
        }
        else
        {
            int i = 0;
            Node aux = Head;
            while (i < position - 1)
            {
                aux = aux.Next;
                i++;
            }
            Node newFuture = aux.Next.Next;
            aux.Next = newFuture;
            newFuture.Previous = aux;
            count--;


        }



    }
    public T GetValueAtStart()
    {
        if (Head == null)
        {
            throw new NullReferenceException("No hay nada que retornar");
        }
        else
        {
            return Head.Value;
        }
    }

    public T GetValueAtEnd()
    {
        if (Head == null)
        {
            throw new NullReferenceException("No hay nada que retornar");
        }
        else if (Head.Next == Head)
        {
            return GetValueAtStart();
        }
        else
        {
            return SearchLastNode().Value;
        }
    }
    public T GetValueAtPosition(int position)
    {
        if (position == 0)
        {
            return GetValueAtStart();
        }
        else if (position == count)
        {
            return GetValueAtEnd();
        }
        else if (position > count)
        {
            throw new NullReferenceException("No puedes hacer eso");
        }
        else
        {
            Node aux = Head;
            int i = 0;
            while (i < position)
            {
                i++;
                aux = aux.Next;
            }
            return aux.Value;
        }
    }

    public Node SearchLastNode()
    {
        if (Head == null)
        {
            throw new NullReferenceException("No hay que buscar");
        }
        else
        {
            Node aux = Head;
            while (aux.Next != Head)
            {
                aux = aux.Next;

            }
            return aux;
        }
    }

   



}
