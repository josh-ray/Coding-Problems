namespace Coding_Problems.Problems
{
    internal interface IProblem
    {
        int Id { get; }
        string Name { get; }
        string Difficulty { get; }

        public void Solve();
    }
}
