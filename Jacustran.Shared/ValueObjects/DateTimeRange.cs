namespace Jacustran.SharedKernel.ValueObjects;

public class DateTimeRange : ValueObject<DateTimeRange>
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateTimeRange(DateTime start, DateTime end)
    {
        if (start > end) throw new ArgumentException("Start date cannot be greater than end date", nameof(start));
        
        Start = start;
        End = end;
    }

    public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start + duration) { }


    public DateTimeRange NewEndDate(DateTime newEndDate) => new DateTimeRange(Start, newEndDate);

    public bool Overlaps(DateTimeRange other) => Start < other.End && End > other.Start;
    


    protected override bool EqualsCore(DateTimeRange other) => Start == other.Start && End == other.End;        
    protected override int GetHashCodeCore() => HashCode.Combine(Start, End);
    
}
