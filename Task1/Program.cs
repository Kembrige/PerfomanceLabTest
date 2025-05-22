class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Размер массива (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Длина интервала (m): ");
        int m = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        for (int i = 0; i < n; i++)
            array[i] = i + 1;

        List<string> parts = new List<string>();
        List<int> path = new List<int>();
        for (int start = 0; start < n; start++)
        {
            List<int> part = new List<int>();
            for (int i = 0; i < m; i++)
            {
                int index = (start + i) % n;
                part.Add(array[index]);
            }

            parts.Add(string.Join("", part));
            path.Add(array[start]); 
        }

        Console.WriteLine("Массив: " + string.Join("", array));
        Console.WriteLine("Интервалы: " + string.Join(", ", parts));
        Console.WriteLine("Путь: " + string.Join(", ", path));
    }
}

