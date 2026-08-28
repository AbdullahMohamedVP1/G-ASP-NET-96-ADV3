namespace AssignmentAdv3
{
    internal class Program
    {
        static void Main(string[] args){
            Exercise1();
            Console.WriteLine();
        }
        static void Exercise1()
        {
            Console.WriteLine("---------- Exercise 1 ----------");

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("All grades: " + string.Join(", ", grades));
            Console.WriteLine("Count: " + grades.Count);
            Console.WriteLine("First: " + grades.First());
            Console.WriteLine("Last: " + grades.Last());

            grades.Sort();
            Console.WriteLine("Sorted ascending: " + string.Join(", ", grades));

            int firstAbove90 = grades.First(g => g > 90);
            Console.WriteLine("First grade above 90: " + firstAbove90);

            List<int> failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing grades (below 75): " + string.Join(", ", failing));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("After removing failing grades: " + string.Join(", ", grades));

            bool hasPerfect = grades.Any(g => g == 100);
            Console.WriteLine("Any grade equals 100: " + hasPerfect);

            List<string> gradeStrings = grades.Select(g => "Grade: " + g).ToList();
            Console.WriteLine("As strings: " + string.Join(" | ", gradeStrings));
        }
    }
}
