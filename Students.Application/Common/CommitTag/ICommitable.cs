namespace Students.Application.Common.CommitTag
{
    
    /// <summary>
    /// Used to Tag Handlers That Requires SaveChanges
    /// </summary>
    public interface ICommitable
    {
        int transctionCount { get; set; }
    }
}