namespace Students.Application.Schools.Queries.GetClass
{
    public class GetClassDto
    {
        public int ClassId { get; set; }
        public string ClassTitle { get; set; }
        public int? UserCount { get; set; }
    }
}