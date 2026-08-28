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
            Exercise4();
            Console.WriteLine();
            Exercise5();
            Console.WriteLine();
            Exercise6();
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

        #region Exercise4,5,6
        static void Exercise4()
        {
            Console.WriteLine("---------- Exercise 4 ----------");

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");

            Console.WriteLine("Count: " + emails.Count);
            Console.WriteLine("Only 2 are stored because the comparer is case insensitive so duplicates with different casing are treated as the same email");

            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            HashSet<int> unionSet = new HashSet<int>(setA);
            unionSet.UnionWith(setB);
            Console.WriteLine("Union: " + string.Join(", ", unionSet));

            HashSet<int> intersectSet = new HashSet<int>(setA);
            intersectSet.IntersectWith(setB);
            Console.WriteLine("Intersect: " + string.Join(", ", intersectSet));

            HashSet<int> exceptSet = new HashSet<int>(setA);
            exceptSet.ExceptWith(setB);
            Console.WriteLine("Except: " + string.Join(", ", exceptSet));

            HashSet<int> subsetCheck = new HashSet<int> { 1, 2 };
            Console.WriteLine("{1,2} is subset of Set A: " + subsetCheck.IsSubsetOf(setA));
        }
        static void Exercise5()
        {
            Console.WriteLine("---------- Exercise 5 ----------");

            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Report.pdf");
            printQueue.Enqueue("Invoice.pdf");
            printQueue.Enqueue("Letter.docx");
            printQueue.Enqueue("Resume.pdf");
            printQueue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue contents: " + string.Join(", ", printQueue));
            Console.WriteLine("Count: " + printQueue.Count);

            string next = printQueue.Peek();
            Console.WriteLine("Next to print (Peek): " + next);

            while (printQueue.Count > 0)
            {
                string doc = printQueue.Dequeue();
                Console.WriteLine("Printing: " + doc);
            }

            bool success = printQueue.TryDequeue(out string result);
            Console.WriteLine("TryDequeue on empty queue succeeded: " + success + " result is null or default: " + (result == null));
        }
        static void Exercise6()
        {
            Console.WriteLine("---------- Exercise 6 ----------");

            Stack<string> history = new Stack<string>();
            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            Console.WriteLine("Current page (Peek): " + history.Peek());

            for (int i = 0; i < 3; i++)
            {
                string leftPage = history.Pop();
                Console.WriteLine("Leaving: " + leftPage);
            }

            Console.WriteLine("Current page after going back: " + history.Peek());

            while (history.Count > 0)
            {
                history.Pop();
            }

            bool popped = history.TryPop(out string page);
            Console.WriteLine("TryPop on empty stack succeeded: " + popped + " page is null or default: " + (page == null));
        }
        #endregion
    }
}
