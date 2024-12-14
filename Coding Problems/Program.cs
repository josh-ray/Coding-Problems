using Coding_Problems;

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
