using System;

namespace Lab6Var10
{
    class LinkedListStack
    {
        public Node Head { get; set; }

        public LinkedListStack()
        {
            Head = null;
        }

        public void Push(string str)
        {
            Node newNode = new Node(str, Head);
            Head = newNode;
        }

        public Node Pop()
        {
            if(Head != null)
            {
                Head = Head.Next;
                return Head;
            }
            else
            {
                return null;
            }
        }

        public Node Peek()
        {
            return Head;
        }

        public void ConsoleOutput()
        {
            Node current = Head;
            while(current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Clear()
        {
            Head = null;
        }
    }
}
