using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Program
    {

        static HashTable hashTable;
        static HashTable2 hashTable2;
        Entry[] nodes;
        static Entry n;
        GateFlights[] nodes1;
        static Value value;
        static Key key;
        static void Main(string[] args)
        {
            int i;
            hashTable = new HashTable(10);
            hashTable2 = new HashTable2(10);
            do
            {
                Console.WriteLine("заповнити геш-таблицю контрольними значеннями - 1");
                Console.WriteLine("додати новий елемент                          - 2");
                Console.WriteLine("видалити елемент за ключем                    - 3");
                Console.WriteLine("знайти елемент за ключем                      - 4");
                Console.WriteLine("вивести геш-таблицю                           - 5");
                Console.WriteLine("додаткові операції, sameGateFlights           - 6");
                i = Convert.ToInt32(Console.ReadLine());
                if(i == 1)
                {
                    Value value1 = new Value("Paris", "A1", 2022, "March", 25, 6, 25);
                    Key key1 = new Key("Code2");
                    Add(hashTable, hashTable2, key1, value1);
                    Value value2 = new Value("New York", "A2", 2022, "March", 26, 7, 25);
                    Key key2 = new Key("Code3");
                    Add(hashTable, hashTable2, key2, value2);
                    Value value3 = new Value("Madrid", "A3", 2022, "March", 26, 8, 25);
                    Key key3 = new Key("Code4");
                    Add(hashTable, hashTable2, key3, value3);
                }
                else if (i == 2)
                {
                    Console.WriteLine("Введіть key:");
                    string key_ = Console.ReadLine();
                    key = new Key(key_);
                    Console.WriteLine("Введіть aeroportOfArrival:");
                    string aeroportOfArrival = Console.ReadLine();
                    Console.WriteLine("Введіть gate");
                    string gate = Console.ReadLine();
                    Console.WriteLine("Введіть year");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введіть month");
                    string month = Console.ReadLine();
                    Console.WriteLine("Введіть day");
                    int day = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введіть hour");
                    int hour = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введіть minute");
                    int minute = Convert.ToInt32(Console.ReadLine());
                    value = new Value(aeroportOfArrival, gate, year, month, day, hour, minute);
                    Add(hashTable, hashTable2, key, value);
                }
                else if(i == 3)
                {
                    Console.WriteLine("Введіть key:");
                    string key_ = Console.ReadLine();
                    key = new Key(key_);
                    Remove(key, hashTable, hashTable2);
                }
                else if(i == 4)
                {
                    Console.WriteLine("Введіть key:");
                    string key_ = Console.ReadLine();
                    key = new Key(key_);
                    n = hashTable.findEntry(key);
                    if (n != null)
                    {
                        Console.WriteLine(hashTable.nodes[i].key.key + " "
                            + n.value.aeroportOfArrival + " "
                            + n.value.gate + " "
                            + n.value.departureTime.year + " "
                            + n.value.departureTime.month + " "
                            + n.value.departureTime.day + " "
                            + n.value.departureTime.time.hour + ":"
                            + n.value.departureTime.time.minute + " ");
                        if (n.value.isDelayed != null)
                            Console.WriteLine(
                                +n.value.isDelayed.hour + ":"
                                + n.value.isDelayed.minute);
                    }
                    else
                        Console.WriteLine("not found");
                }
                else if(i == 5)
                {
                    HashTable.Write(hashTable);
                }
                else if(i == 6)
                {
                    Console.WriteLine("Введіть gate:");
                    string gate = Console.ReadLine();
                    hashTable2.sameGateFlights(gate);
                }
            }
            while (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6);           
            
            
            Console.ReadKey();
        }
        public static void Remove(Key key, HashTable hashTable, HashTable2 hashTable2)
        {
            string gate = hashTable.findGate(key);
            hashTable.removeEntry(key);
            hashTable2.Remove(gate);
        }
        public static void Add(HashTable hashTable, HashTable2 hashTable2, Key key, Value value)
        {
            (key, value) = hashTable.AddEntry(key, value);
            hashTable.insertEntry(key, value);
            hashTable2.Add(value.gate, key);
        }
    }
    public class time
    {
        public int hour { get; set; }
        public int minute { get; set; }

        public time(int hour, int minute)
        {
            this.hour = hour;
            this.minute = minute;
        }

    }
    public class TimeDate
    {
        public int year { get; set; }
        public string month { get; set; }
        public int day { get; set; }
        public time time { get; set; }
        public TimeDate(int year, string month, int day, int hour, int minute)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.time = new time(hour, minute);
        }
    }
    public class Value
    {
        public string aeroportOfArrival { get; set; }
        public string gate { get; set; }
        public TimeDate departureTime { get; set; }
        public Delayed isDelayed { get; set; }
        public Value(string aeroportOfArrival, string gate, int year, string month, int day, int hour, int minute)
        {
            this.aeroportOfArrival = aeroportOfArrival;
            this.gate = gate;
            this.departureTime = new TimeDate(year, month, day, hour, minute);
        }
    }
    public class Key
    {
        public string key { get; set; }
        public Key(string key)
        {
            this.key = key;
        }
    }
    public class Delayed
    {
        public int hour { get; set; }
        public int minute { get; set; }

        public Delayed(int hour, int minute)
        {
            this.hour = hour;
            this.minute = minute;
        }
    }
    class Entry
    {
        public Key key;
        public Value value;
        public bool DELETED;
        public Entry()
        {
            DELETED = false;
        }

    }
    public class GateFlights
    {
        public string gate;
        public Key flightCode;
        public bool DELETED = false;
        public GateFlights()
        {
            DELETED = true;
        }

    }
    class HashTable2
    {
        public HashTable2(int s)
        {
            nodes1 = new GateFlights[s];
            loadness = 0;
            size = s;
        }
        public double loadness;
        public static int size;
        public GateFlights[] nodes1;

        int j = 0;
        public void sameGateFlights(string gate)
        {
            for (int i = 0; i < size; i++)
            {
                if (nodes1[i] != null)
                    if (nodes1[i].gate == gate)
                        Console.WriteLine(nodes1[i].gate + " " + nodes1[i].flightCode.key);
            }
        }
        public void Add(string gate, Key flightCode)
        {
            int i = getHash(gate, j);
            if (nodes1[i] == null)
            {
                nodes1[i] = new GateFlights();
                nodes1[i].gate = gate;
                nodes1[i].flightCode = flightCode;
                loadness++;
            }
            else
            {
                j++;
                Add(gate, flightCode);
            }
            if (loadness == size)
                Rehashing();
        }
        public void Rehashing()
        {
            size *= 2;
            Console.WriteLine(HashTable2.size);
        }
        public static int hashCode(string str)
        {
            int hash = 0;
            foreach (var s in str)
            {
                hash += Convert.ToInt32(s);
            }
            return hash;
        }
        public static int getHash(string str, int i)
        {
            int h = (hashCode(str) + i) % size;
            return h;
        }
        public void Remove(string gate)
        {
            GateFlights g = find(gate);
            if (g != null)
            {
                g.gate = null;
                g.flightCode = null;
                g.DELETED = true;
                loadness--;
            }
        }
        public GateFlights find(string gate)
        {
            if (gate == null)
                return null;
            else
            {
                foreach (GateFlights g in nodes1)
                {
                    if(g != null)
                    if (g.gate.ToString() == gate.ToString())
                        return g;
                }
                return null;
            }
        }
    }
    class HashTable
    {

        public HashTable(int s)
        {
            nodes = new Entry[s];
            loadness = 0;
            size = s;
        }

        public double loadness;
        public static int size;
        public Entry[] nodes;
        public int j = 0;

        public static void Write(HashTable hashTable)
        {
            for (int i = 0; i < size; i++)
            {
                if (hashTable.nodes[i] != null && hashTable.nodes[i].DELETED != true)
                {
                    Console.WriteLine(hashTable.nodes[i].key.key + " "
                        + hashTable.nodes[i].value.aeroportOfArrival + " "
                        + hashTable.nodes[i].value.gate + " "
                        + hashTable.nodes[i].value.departureTime.year + " "
                        + hashTable.nodes[i].value.departureTime.month + " "
                        + hashTable.nodes[i].value.departureTime.day + " "
                        + hashTable.nodes[i].value.departureTime.time.hour + ":"
                        + hashTable.nodes[i].value.departureTime.time.minute + " ");
                    if (hashTable.nodes[i].value.isDelayed != null)
                        Console.WriteLine(
                            +hashTable.nodes[i].value.isDelayed.hour + ":"
                            + hashTable.nodes[i].value.isDelayed.minute);
                }
            }
        }
        public static int hashCode(string str)
        {
            int hash = 0;
            foreach (var s in str)
            {
                hash += Convert.ToInt32(s);
            }
            return hash;
        }
        public static int getHash(string str, int i)
        {
            int h = (hashCode(str) + i) % size;
            return h;
        }
        public void insertEntry(Key key, Value value)
        {
            int i = getHash(key.ToString(), j);
            if (nodes[i] == null || nodes[i].DELETED == true)                
            {
                nodes[i] = new Entry();
                nodes[i].key = key;
                nodes[i].value = value;
                loadness++;
            }
            else
            {
                j++;
                insertEntry(key, value);
            }
            if (loadness == size)
                Rehashing();
        }
        public void removeEntry(Key key)
        {
            Entry e = findEntry(key);
            if (e != null)
                if(e.DELETED != true)
            {
                e.key = null;
                e.value = null;
                e.DELETED = true;
                loadness--;
            }
        }
        public void Rehashing()
        {
            size *= 2;
            Console.WriteLine(HashTable.size);
        }
        public string findGate(Key key)
        {
            if (key == null)
                return null;
            else
            {
                foreach (Entry e in nodes)
                {
                    if(e != null && e.DELETED != true)
                    if (e.key.ToString() == key.ToString())
                    {
                        return e.value.gate;
                    }
                }
                return null;
            }
        }
        public Entry findEntry(Key key)
        {

            if (key == null)
                return null;
            else
            {
                foreach (Entry e in nodes)
                {
                    if (e != null && e.DELETED != true)
                        if (e.key.ToString() == key.ToString())
                        {
                            return e;
                        }
                }
                return null;
            }
        }
        public (Key, Value) AddEntry(Key key, Value value)
        {
            int i = 0;
            int R;
            while (i < size)
            {
                if (nodes[i] != null)if( nodes[i].DELETED != true)
                {
                    R = (nodes[i].value.departureTime.time.hour * 60 + nodes[i].value.departureTime.time.minute) -
                        (value.departureTime.time.hour * 60 + value.departureTime.time.minute);
                        Console.WriteLine(R);
                    if (nodes[i].value.gate.ToString() == value.gate.ToString() &&
                        nodes[i].value.departureTime.year == value.departureTime.year &&
                        nodes[i].value.departureTime.month.ToString() == value.departureTime.month.ToString() &&
                        nodes[i].value.departureTime.day == value.departureTime.day &&

                        R < 105)
                    {
                        value.isDelayed = new Delayed((105 - R) / 60, (105 - R) % 60);
                    }
                }
                i++;
            }
            return (key, value);
        }
    }
}