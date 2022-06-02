using System;

public class linkedList
{
    node head = null;
    node sorted;]
    public class node
    {
        public int val;
        public node next;

        public node(int val)
        {
            this.val = val;
        }
    }

    node sortedMerge(node a, node b)
    {
        node result = null;
        if (a == null)
            return b;
        if (b == null)
            return a;
        if (a.val <= b.val)
        {
            result = a;
            result.next = sortedMerge(a.next, b);
        }
        else
        {
            result = b;
            result.next = sortedMerge(a, b.next);
        }
        return result;
    }

    node mergeSort(node h)
    {
        if (h == null || h.next == null)
            return h;
        int cn = countNodes(h);
        if (cn <= M)
            return insertionSort(h);
        node middle = getMiddle(h);
        node nextofmiddle = middle.next;
        middle.next = null;
        node left = mergeSort(h);
        node right = mergeSort(nextofmiddle);
        node sortedlist = sortedMerge(left, right);
        return sortedlist;
    }
    node getMiddle(node h)
    {
        if (h == null)
            return h;
        node fastptr = h.next;
        node slowptr = h;
        while (fastptr != null)
        {
            fastptr = fastptr.next;
            if (fastptr != null)
            {
                slowptr = slowptr.next;
                fastptr = fastptr.next;
            }
        }
        return slowptr;
    }
    int countNodes(node temp)
    {
        int i = 0;
        while (temp != null)
        {
            i++;
            temp = temp.next;
        }
        return i;
    }
    node insertionSort(node headref)
    {
        sorted = null;
        node current = headref;
        while (current != null)
        {
            node next = current.next;
            sortedInsert(current);
            current = next;
        }

        head = sorted;
        return head;
    }
    void sortedInsert(node newnode)
    {
        if (sorted == null || sorted.val >= newnode.val)
        {
            newnode.next = sorted;
            sorted = newnode;
        }
        else
        {
            node current = sorted;
            while (current.next != null &&
                    current.next.val < newnode.val)
            {
                current = current.next;
            }
            newnode.next = current.next;
            current.next = newnode;
        }
    }
    void push(int new_data)
    {
        node new_node = new node(new_data);
        new_node.next = head;
        head = new_node;
    }
    public void push_back(int newElement)
    {
        node newNode = new node(newElement);
        newNode.next = null;
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            node temp = head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = newNode;
        }
    }
    void printList(node headref)
    {
        double g = Math.Sqrt(countNodes(headref));
        while (headref != null)
        {
            if (g > Convert.ToDouble(headref.val))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(headref.val + " ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(headref.val + " ");
                Console.ResetColor();
            }
            headref = headref.next;
        }
    }
    void ReverseList() // якщо це передбачалося, то додаю код реверсии 
    {
        node prev = null, current = head, next = null;
        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        head = prev;
    }
    void Delete(int value)
    {
        if (head == null) return;
        if (head.val == value)
        {
            head = head.next;
            return;
        }
        var n = head;
        while (n.next != null)
        {
            if (n.next.val == value)
            {
                n.next = n.next.next;
                return;
            }
            n = n.next;
        }
    }
    static int M;
    public static void Main(String[] args)
    {
        int j = СustomInterface();
        linkedList li = new linkedList();
        if (j == 1)
        {
            li = Case1();
        }
        else if (j == 2)
        {
            li = Case2();
        }
        Console.WriteLine("Вiдсортований Linked List :");
        li.printList(li.head);
        Console.ReadKey();
    }
    private static int СustomInterface()
    {
        Console.WriteLine("Введення з клавiатури - введiть 1");
        Console.WriteLine("Контрольний приклад   - введiть 2");
        int j = Convert.ToInt32(Console.ReadLine());
        return j;
    }
    private static linkedList Case1()
    {
        Console.WriteLine("Введiть елементи листа :");
        string[] s = Console.ReadLine().Split(' ', ',', '.', ';');
        Console.WriteLine("Введiть параметр М :");
        M = Convert.ToInt32(Console.ReadLine());
        double SN = Math.Sqrt(s.Length);
        linkedList li = new linkedList();
        for (int i = 0; i < s.Length; i++)
        {
            if (SN <= Convert.ToDouble(s[i]))
                li.push_back(Convert.ToInt32(s[i]));
        }
        // Apply merge Sort  
        li.head = li.mergeSort(li.head);
        for (int i = 0; i < s.Length; i++)
        {
            if (SN > Convert.ToInt32(s[i]))
                li.push(Convert.ToInt32(s[i]));
        }
        return li;
    }
    private static linkedList Case2()
    {
        linkedList li = new linkedList();
        linkedList li2 = new linkedList();
        li.push_back(25);
        li.push_back(24);
        li.push_back(23);
        li.push_back(22);
        li.push_back(20);
        li.push_back(18);
        li.push_back(15);
        li.push_back(16);
        li.push_back(10);
        li.push_back(10);
        li.push_back(9);
        li.push_back(7);
        li.push_back(5);
        li.push_back(4);
        li.push_back(3);
        li.push_back(2);
        li.push_back(1);
        li.printList(li.head);
        Console.WriteLine();
        Console.WriteLine("M = 4");
        M = 4;
        int countN = li.countNodes(li.head);
        double g = Math.Sqrt(countN);
        node n = li.head;
        for (int i = 0; i < countN; i++)
        {
            if (g > n.val)
            {
                li2.push_back(Convert.ToInt32(n.val));
                li.Delete(Convert.ToInt32(n.val));
            }
            n = n.next;
        }
        // Apply merge Sort  
        li.head = li.mergeSort(li.head);
        node n2 = li2.head;
        int countN2 = li2.countNodes(li2.head);
        for (int i = 0; i < countN2; i++)
        {
            li.push(Convert.ToInt32(n2.val));
            n2 = n2.next;
        }
        return li;
    }
}