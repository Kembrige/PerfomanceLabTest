using System.Text.Json;

class Point
{
    public double x { get; set; }
    public double y { get; set; }
}

class CircleData
{
    public Point center { get; set; }
    public double radius { get; set; }
}

class Task3
{
    static void Main()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;

        string circlePath = Path.Combine(basePath, "circle.json");
        string pointsPath = Path.Combine(basePath, "points.json");

        string circleJson = File.ReadAllText(circlePath);
        CircleData circle = JsonSerializer.Deserialize<CircleData>(circleJson);

        string pointsJson = File.ReadAllText(pointsPath);
        List<Point> points = JsonSerializer.Deserialize<List<Point>>(pointsJson);

        double cx = circle.center.x;
        double cy = circle.center.y;
        double r2 = circle.radius * circle.radius;

        foreach (var p in points)
        {
            double dx = p.x - cx;
            double dy = p.y - cy;
            double dist2 = dx * dx + dy * dy;

            if (Math.Abs(dist2 - r2) < 1e-8)
                Console.WriteLine("0"); 
            else if (dist2 < r2)
                Console.WriteLine("1"); 
            else
                Console.WriteLine("2"); 
        }
    }
}