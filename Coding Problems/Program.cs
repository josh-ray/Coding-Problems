using Coding_Problems;

int dividend = 10;
int divisor = 2;

byte test = (byte)dividend;

int quotient = test >> 1;  // 10 / 2 = 5
int q2 = (byte)33 >> 3;  // 33 / 8 = 4
int q3 = (byte)55 >> 4;  // 55 / 16 = 3
int q4 = (byte)55 >> 3;  // 55 / 8 = 6
int q5 = ((byte)55 >> 3) + (8-7);  // 55 / 7 = 7 (how?)

//int q6 = ((byte)347 >> 6) + (64-55); // 347 / 55
int q6 = (int)(((uint)347 >> 6) + (64-55)); // 347 / 55 = 6

Console.WriteLine("**** WELCOME ****");
Console.WriteLine();

// Get users source selection
// 1 = LeetCode, 2 = Geeks for Geeks, q to Quit
string sourceSelection = ProgramUtility.GetUsersSourceSelection();

if (sourceSelection != "q")
{
    _ = int.TryParse(sourceSelection, out int selection);

    // package name of selected GFG category
    string? selectedCategory = string.Empty;
    if (selection == 2)
    {
        selectedCategory = ProgramUtility.GetUsersGFGCategorySelection();
    }

    // Get problems list and prompt user to select one
    Dictionary<int, Type> problemsList = ProgramUtility.GetProblemsList(selection, selectedCategory);

    // Print list, prompt user, and solve selection
    ProgramUtility.PrintPromptAndProblemsListToConsole(problemsList);
    ProgramUtility.GetUsersProblemSelectionAndSolve(problemsList);
}

Console.WriteLine("Thank you. Come again!");
