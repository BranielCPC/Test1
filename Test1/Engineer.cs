public class Engineer
{
    public int Id { get; set; }
    public string? Fname { get; set; } //?Next to the string is to make nonnullable
    public string? Lname { get; set; }
    public bool LastWork { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? LastUpdated { get; set; }
    public bool IsSupportCompletedInLastTwoWeeks { get; internal set; }
    public bool IsSupportScheduledYesterday { get; internal set; }
    public bool IsSupportScheduledToday { get; internal set; }
    public DateTime LastSupportDate { get; set; }
    public object? HalfDayShifts { get; internal set; }

}
