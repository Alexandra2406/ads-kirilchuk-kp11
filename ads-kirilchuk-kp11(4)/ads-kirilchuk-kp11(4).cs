using System;

//node structure
class Node
{
    public int data;
    public Node next;
};

class LinkedList
{
    Node head;

    public LinkedList()
    {
        head = null;
    }
    //Add new element at the start of the list
    public void AddFirst(int data)
    {
        Node newNode = new Node();
        newNode.data = data;
        newNode.next = head;
        head = newNode;
    }
    //Add new element at the end of the list
    public void AddLast(int data)
    {
        Node newNode = new Node();
        newNode.data = data;
        newNode.next = null;
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = new Node();
            temp = head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = newNode;
        }
    }
    //Inserts a new element at the given position
    public void AddAtPosition(int data, int pos)
    {
        Node newNode = new Node();
        newNode.data = data;
        newNode.next = null;

        if (pos < 1)
        {
            Console.Write("\nPosition should be >= 1.");
        }
        else if (pos == 1)
        {
            newNode.next = head;
            head = newNode;
        }
        else
        {

            Node temp = new Node();
            temp = head;
            for (int i = 1; i < pos - 1; i++)
            {
                if (temp != null)
                {
                    temp = temp.next;
                }
            }

            if (temp != null)
            {
                newNode.next = temp.next;
                temp.next = newNode;
            }
            else
            {
                Console.Write("\nThe Previous Node is Null.");
            }
        }
    }
    //Delete first node of the list
    public void DeleteFirst()
    {
        if (this.head != null)
        {
            Node temp = this.head;
            this.head = this.head.next;
            temp = null;
        }
    }
    //Delete last node of the list
    public void DeleteLast()
    {
        if (this.head != null)
        {
            if (this.head.next == null)
            {
                this.head = null;
            }
            else
            {
                Node temp = new Node();
                temp = this.head;
                while (temp.next.next != null)
                    temp = temp.next;
                Node lastNode = temp.next;
                temp.next = null;
                lastNode = null;
            }
        }
    }
    //Delete an element at the given position
    public void DeleteAtPosition(int pos)
    {
        if (pos < 1)
        {
            Console.Write("\nPosition should be >= 1.");
        }
        else if (pos == 1 && head != null)
        {
            Node nodeToDelete = head;
            head = head.next;
            nodeToDelete = null;
        }
        else
        {
            Node temp = new Node();
            temp = head;
            for (int i = 1; i < pos - 1; i++)
            {
                if (temp != null)
                {
                    temp = temp.next;
                }
            }
            if (temp != null && temp.next != null)
            {
                Node nodeToDelete = temp.next;
                temp.next = temp.next.next;
                nodeToDelete = null;
            }
            else
            {
                Console.Write("\nThe Node is Already Null.");
            }
        }
    }
    //Display the content of the list
    public void Print()
    {
        Node temp = new Node();
        temp = this.head;
        if (temp != null)
        {
            Console.Write("The List Contains: ");
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The List is Empty.");
        }
    }

    //Search an element in the list
    public int SearchElement(int searchValue)
    {
        Node temp = new Node();
        temp = this.head;
        int found = 0;
        int i = 0;

        if (temp != null)
        {
            while (temp != null)
            {
                i++;
                if (temp.data == searchValue)
                {
                    found++;
                    break;
                }
                temp = temp.next;
            }
            if (found == 1)
            {
                Console.WriteLine(searchValue + " is found at index = " + i + ".");
            }
            else
            {
                Console.WriteLine(searchValue + " is not found in the list.");
            }
        }
        else
        {
            Console.WriteLine("The List is Empty.");
        }
        return i;
    }
    //Find the minimum element
    public (int, int) Min()
    {
        Node temp = new Node();
        temp = this.head;
        Node tmp = new Node();
        tmp = this.head;
        int i = 0;
        int Min = int.MaxValue;
        while (temp != null)
        {
            if (Min > temp.data)
                Min = temp.data;
            temp = temp.next;
        }
        while (tmp != null)
        {
            i++;
            if (tmp.data == Min)
            {
                break;
            }
            tmp = tmp.next;
        }
        return (Min, i);
    }
    public void CustomInterface(LinkedList List)
    {
        bool b = true;
        Console.WriteLine($"{"Input '0' if you want to ",20} {"Display the content of the list ",20}");
        Console.WriteLine($"{"Input '1' if you want to ",20} {"Add new element at the start of the list",20}");
        Console.WriteLine($"{"Input '2' if you want to ",20} {"Add new element at the end of the list",20}");
        Console.WriteLine($"{"Input '3' if you want to ",20} {"Inserts a new element at the given position",20}");
        Console.WriteLine($"{"Input '4' if you want to ",20} {"Delete first node of the list",15}");
        Console.WriteLine($"{"Input '5' if you want to ",20} {"Delete last node of the list",15}");
        Console.WriteLine($"{"Input '6' if you want to ",20} {"Delete an element at the given position",20}");
        Console.WriteLine($"{"Input '7' if you want to ",20} {"Search an element in the list",15}");
        Console.WriteLine($"{"Input '8' if you want to ",20} {"Find the minimum element",15}");
        Console.WriteLine($"{"Input '9' if you want to ",20} {"Find the minimum element and Inserts a new element after minimum element",25}");
        Console.WriteLine();
        int i = int.Parse(Console.ReadLine());
        if (i == 0)
            List.Print();
        else if (i == 1)
        {
            Console.WriteLine("Input element : "); int data = int.Parse(Console.ReadLine());
            List.AddFirst(data);
        }
        else if (i == 2)
        {
            Console.WriteLine("Input element : "); int data = int.Parse(Console.ReadLine());
            List.AddLast(data);
        }
        else if (i == 3)
        {
            Console.WriteLine("Input element : "); int data = int.Parse(Console.ReadLine());
            Console.WriteLine("Input position : "); int pos = int.Parse(Console.ReadLine());
            List.AddAtPosition(data, pos);
        }
        else if (i == 4)
        {
            List.DeleteFirst();
        }
        else if (i == 5)
        {
            List.DeleteLast();
        }
        else if (i == 6)
        {
            Console.WriteLine("Input position : "); int pos = int.Parse(Console.ReadLine());
            List.DeleteAtPosition(pos);
        }
        else if (i == 7)
        {
            Console.WriteLine("Input element : "); int data = int.Parse(Console.ReadLine());
            List.SearchElement(data);
            Console.WriteLine(List.SearchElement(data));
        }
        else if (i == 8)
        {
            (int Min, int pos) = List.Min();
            Console.WriteLine($"{"Minimum Element is : " + Min,20}");
            Console.WriteLine($"{"The Position of Minimum Element is : " + pos,20}");
        }
        else if (i == 9)
        {
            Console.WriteLine("Input element : "); int data = int.Parse(Console.ReadLine());
            (int Min, int pos) = List.Min();
            Console.WriteLine($"{"Minimum Element is : " + Min,20}");
            Console.WriteLine($"{"The Position of Minimum Element is : " + pos,20}");
            List.AddAtPosition(data, pos + 1);
        }
        else
        {
            b = false;
            Console.WriteLine();
            Console.WriteLine("Input Error");
            Console.WriteLine();
            Console.WriteLine($"{"Input '0' if you want to Continue ",20}");
            Console.WriteLine($"{"Input '1' if you don`t want to Continue ",20}");
            Console.WriteLine();
            int j = int.Parse(Console.ReadLine());
            if (j == 0)
            {
                Console.WriteLine();
                CustomInterface(List);
            }
            else if (j == 1)
            {
                return;
            }
            else
            {
                Console.WriteLine();
                CustomInterface(List);
            }
        }
        if (b == true)
        {
            Console.WriteLine();
            Console.WriteLine($"{"Input '0' if you want to Continue ",20}");
            Console.WriteLine($"{"Input '1' if you don`t want to Continue ",20}");
            Console.WriteLine();
            int j = int.Parse(Console.ReadLine());
            if (j == 0)
            {
                Console.WriteLine();
                CustomInterface(List);
            }
            else if (j == 1)
            {
                return;
            }
            else
            {
                Console.WriteLine();
                CustomInterface(List);
            }
        }
    }
};

class Program
{
    static void Main(string[] args)
    {
        LinkedList MyList = new LinkedList();

        MyList.AddLast(10);
        MyList.AddLast(15);
        MyList.AddLast(-54);
        MyList.AddLast(69);
        MyList.AddLast(-156);
        MyList.AddLast(85);
        MyList.AddLast(1);
        MyList.AddLast(-200);
        MyList.AddLast(56);
        MyList.AddLast(79);

        MyList.CustomInterface(MyList);
    }
}