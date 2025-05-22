class Task4
{
    static void Main()
    {

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "array.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        int[] array = File.ReadAllLines(filePath)
                         .Where(line => !string.IsNullOrWhiteSpace(line))
                         .Select(int.Parse)
                         .ToArray();

        if (array.Length == 0)
        {
            Console.WriteLine("Файл пуст.");
            return;
        }

        Array.Sort(array);
        int median = array[array.Length / 2];

        int moves = array.Sum(x => Math.Abs(x - median));

        Console.WriteLine($"Минимальное количество ходов: {moves}");
    }
}