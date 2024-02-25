using Microsoft.VisualBasic.FileIO;

internal class Program
{
    private static void Main(string[] args)
    {
        var inp = Console.ReadLine().Split(' ');
        int size = Convert.ToInt32(inp[0]);
        int n = Convert.ToInt32(inp[1]);

        Buff.Max_size = size;

        if (n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                var cur_package = Console.ReadLine().Split(' ');
                int cur_start = Convert.ToInt32(cur_package[0]);
                int cur_duration = Convert.ToInt32(cur_package[1]);

                //buffer is empty
                if (Buff.IsEmpty())
                {
                    Console.WriteLine(cur_start);
                    Buff.Add(cur_start + cur_duration);
                }
                //buffer is not empty and not full
                else if (Buff.IsNotFull())
                {
                    int start = cur_start > Buff.First() ? cur_start : Buff.First();
                    Console.WriteLine(start);
                    Buff.Add(start + cur_duration);
                }
                //buffer is full but first element goes out
                else if (cur_start >= Buff.Last())
                {
                    int start = cur_start > Buff.First() ? cur_start : Buff.First();
                    Console.WriteLine(start);
                    Buff.CutAndAdd(start + cur_duration);
                }
                else { Console.WriteLine(-1);  }
            }
        }
    }

    public static class Buff
    {
        public static int size = 0;
        public static int Max_size { get; set; }
        static List<int> buff = new List<int>();

        public static void Add(int val)
        {
            if (size < Max_size)
            {
                buff.Insert(0, val);
                size++;
            }
        }
        public static void CutAndAdd(int val)
        {
            if (size > 0)
            {
                buff.RemoveAt(buff.Count - 1);
                buff.Insert(0, val);
            }
        }
        public static bool IsNotFull() => (size < Max_size);
        public static bool IsEmpty() => (size == 0);
        public static int First() => buff.First();
        public static int Last() => buff.Last();
    }
}