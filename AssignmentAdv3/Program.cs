namespace AssignmentAdv3
{
    internal class Program
    {
        static void Main(string[] args){
            Exercise1();
            Console.WriteLine();
            Exercise2();
            Console.WriteLine();
            Exercise3();
            Console.WriteLine();
        }
        #region Exercise1
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
        #endregion

        #region Exercice2,3
        static void Exercise2()
        {
            Console.WriteLine("---------- Exercise 2 ----------");

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>
        {
            { 500, "Ahmed" },
            { 200, "Sara" },
            { 800, "Ali" },
            { 350, "Mona" }
        };

            Console.WriteLine("Leaderboard sorted by score:");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine(entry.Key + " => " + entry.Value);
            }

            var firstEntry = leaderboard.First();
            Console.WriteLine("First key: " + firstEntry.Key);
            Console.WriteLine("First value: " + firstEntry.Value);

            Console.WriteLine("Score 500 exists: " + leaderboard.ContainsKey(500));

            if (leaderboard.TryGetValue(999, out string player999))
            {
                Console.WriteLine("Player with 999: " + player999);
            }
            else
            {
                Console.WriteLine("No player found with score 999");
            }

            leaderboard.Remove(200);
            Console.WriteLine("After removing score 200:");
            foreach (var entry in leaderboard)
            {
                Console.WriteLine(entry.Key + " => " + entry.Value);
            }
        }

        static void Exercise3()
        {
            Console.WriteLine("---------- Exercise 3 ----------");

            Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            { "Omar", "0100000001" },
            { "Laila", "0100000002" },
            { "Hassan", "0100000003" },
            { "Nour", "0100000004" }
        };

            phoneBook["Youssef"] = "0100000005";
            Console.WriteLine("Added Youssef using [] syntax");

            try
            {
                phoneBook.Add("Omar", "0111111111");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error using .Add(): " + ex.Message);
            }

            bool added = phoneBook.TryAdd("Omar", "0111111111");
            Console.WriteLine("TryAdd for duplicate Omar succeeded: " + added);

            bool found = phoneBook.TryGetValue("Sara", out string saraPhone);
            Console.WriteLine("Search for Sara found: " + found);

            string contact = phoneBook.GetValueOrDefault("Karim", "Not Found");
            Console.WriteLine("Karim: " + contact);

            Console.WriteLine("Keys: " + string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));
        }
        #endregion
    }
}
