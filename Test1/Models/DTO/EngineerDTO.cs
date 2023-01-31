namespace Test1.Models.DTO
{
    public class EngineerDTO
    {
        public string? Fname { get; set; } //?Next to the string is to make nonnullable
        public string? Lname { get; set; }
        public bool LastWork { get; set; }
        public int Id { get; set; }
    }
}
