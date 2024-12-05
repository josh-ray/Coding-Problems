using Coding_Problems.Problems;

namespace Coding_Problems
{
    internal static class ProgramUtility
    {
        public static string GetUsersSourceSelection()
        {
            Console.WriteLine("Please enter the number of the problems source to use:");
            Console.WriteLine("    1) LeetCode");
            Console.WriteLine("    2) Geeks For Geeks");
            Console.WriteLine("    q) Quit");

            string? sourceSelection = string.Empty;
            bool inputValid = false;
            while (!inputValid)
            {
                sourceSelection = Console.ReadLine();

                if (sourceSelection == "q"
                    || sourceSelection == "1"
                    || sourceSelection == "2")
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Please enter a valid selection: 1: LC, 2: GFG, q: Quit");
            }

            return sourceSelection ?? "q";
        }

        public static string GetUsersGFGCategorySelection()
        {
            // Get GFG category selection
            Dictionary<int, string> categories = GetGFGCategories();

            Console.WriteLine();
            Console.WriteLine("Please enter a number for the desired problem category:");
            foreach (var category in categories)
            {
                Console.WriteLine($"    {category.Key}) {InsertSpaces(category.Value)}");
            }

            string selectedCategory = string.Empty;
            bool inputValid = false;
            while (!inputValid)
            {
                string? categorySelection = Console.ReadLine();

                if (int.TryParse(categorySelection, out int catId))
                {
                    if (categories.TryGetValue(catId, out string? value))
                    {
                        selectedCategory = value;
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Given number ({catId}) is not a valid category. Please try again.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid selection from the categories listed:");
                }
            }

            return selectedCategory;
        }

        public static Dictionary<int, Type> GetProblemsList(int selection, string selectedCategory)
        {
            // TODO: Should add problem complete marker interface to filter work in progress problems?
            Type? type;
            Func<Type, bool> linqPredicate;

            if (selection == 1)
            {
                // LeetCode
                type = typeof(ILeetCodeProblem);
                linqPredicate = (p) => type.IsAssignableFrom(p) && !p.IsInterface;
            }
            else
            {
                // GFG
                type = typeof(IGeeksForGeeksProblem);
                linqPredicate = (p) => type.IsAssignableFrom(p) && !p.IsInterface && (p.Namespace?.Contains(selectedCategory) ?? false);
            }

            IEnumerable<Type>? types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(linqPredicate);

            return types.ToDictionary(t => ExtractProblemId(t.Name), t => t);
        }

        public static void PrintPromptAndProblemsListToConsole(Dictionary<int, Type> problems)
        {
            List<KeyValuePair<int, Type>> sortedKVList = [.. problems];  // replaces .toList()
            sortedKVList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));

            Console.WriteLine();
            Console.WriteLine("Please enter a problem number from the solutions listed or q to quit:");
            foreach (var problem in sortedKVList)
            {
                Console.WriteLine($"    {problem.Key,4}) {problem.Value.Name}"); // replaces Key.ToString().PadLeft(4)
            }
        }

        public static void GetUsersProblemSelectionAndSolve(Dictionary<int, Type> problemsList)
        {
            string? problemSelection = string.Empty;
            bool inputValid = false;
            while (!inputValid)
            {
                problemSelection = Console.ReadLine();

                if (problemSelection == "q") { break; }

                if (int.TryParse(problemSelection, out int pId))
                {
                    if (problemsList.TryGetValue(pId, out Type? value))
                    {
                        BuildAndRunProblem(value);
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Given number ({pId}) is not registered as a solved problem. Please try again.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid selection from the solutions listed or q to quit:");
                }
            }
        }

        private static void BuildAndRunProblem(Type problemType)
        {
            IProblem problem = (IProblem)Activator.CreateInstance(problemType)!; // null forgiving operator (!)
            SolveAndReport(problem, $"{problem.Name} #{problem.Id} ({problem.Difficulty})");
        }

        private static void SolveAndReport(IProblem problem, string message)
        {
            Console.WriteLine();
            Console.WriteLine($"{message}:");
            Console.WriteLine();
            problem.Solve();
            Console.WriteLine("");
        }

        private static int ExtractProblemId(string name)
        {
            int sepIndex = name.IndexOf('_');
            string value = name[(sepIndex + 1)..];
            return int.Parse(value);
        }

        private static Dictionary<int, string> GetGFGCategories()
        {
            IEnumerable<string> gfgNamespaces = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.Namespace?.Contains("GeeksForGeeks") ?? false)
            .Select(t => ExtractFinalSegment(t.Namespace!))
            .Distinct()
            .OrderBy(s => s);

            int count = 1;
            return gfgNamespaces.ToDictionary(n => count++, n => n);
        }

        private static string ExtractFinalSegment(string path)
        {
            int lastPeriodIndex = path.LastIndexOf('.');
            return path[(lastPeriodIndex + 1)..];
        }

        private static string InsertSpaces(string pascalCased)
        {
            List<Char> charList = [];
            bool firstProcessed = false;
            foreach (var character in pascalCased)
            {
                if (!firstProcessed)
                {
                    charList.Add(character);
                    firstProcessed = true;
                    continue;
                }

                if (char.IsUpper(character))
                {
                    charList.Add(' ');
                }

                charList.Add(character);
            }

            return string.Join("", charList);
        }

    }
}
