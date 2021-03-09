namespace Students.Application.Common.CommitTag
{
    
    /// <summary>
    /// Used to Tag Handlers That Requires to Execute SaveChanges After the Handler Finishes
    /// </summary>
    public interface ICommitable
    {
        int transctionCount { get; set; }
    }
}