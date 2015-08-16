namespace CoreBase.DuplicateCheckers
{
    public interface IDuplicateChecker
    {
        bool HasDuplicate(object entity);
        string GetWorkingTypeName();
        string[] BusinessKeys { get; }
    }
}