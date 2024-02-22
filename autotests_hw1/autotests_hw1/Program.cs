namespace autotests_hw1
{
    internal class Program
    {
        public static int BookProblem(int n, int p)
        {
            if (p <= n / 2) return Convert.ToInt32(p / 2);
            else
            {
                if (n - p == 1 && n % 2 == 0)
                {
                    return 1;
                }
                else return BookProblem(n, n - p);
            }
        }

        public static string KangarooProblem(int x1, int v1, int x2, int v2)
        {
            int firstStep1 = x1 + v1;
            int firstStep2 = x2 + v2;
            if (x1 > x2 || (x1 < x2 && v1 < v2))
            {
                return "no";
            }
            if (firstStep1 == firstStep2 || firstStep2 % firstStep1 == 0)
            {
                return "yes";
            }
            else if ((x1 - x2) / (v1 - v2) == 0 || (x2 - x1) / (v2 - v1) == 0)
            {
                return "yes";
            }
            return "no";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Number Line Jumps\nВведите x1, v1, x2, v2");
            string[] input = Console.ReadLine().Trim().Split(" ");
            int x1 = Convert.ToInt32(input[0]);
            int v1 = Convert.ToInt32(input[1]);
            int x2 = Convert.ToInt32(input[2]);
            int v2 = Convert.ToInt32(input[3]);
            Console.WriteLine(KangarooProblem(x1, v1, x2, v2));

            Console.WriteLine("Drawing Book\nВведите n и p");
            string[] input2 = Console.ReadLine().Trim().Split(" ");
            int n = Convert.ToInt32(input2[0]);
            int p = Convert.ToInt32(input2[1]);
            Console.WriteLine(BookProblem(n, p));

        }
    }
}