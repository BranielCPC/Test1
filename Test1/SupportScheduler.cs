using System;
using System.Linq;

public class SupportScheduler
{
    private List<Engineer> _engineers;
    private Random _random;

    public SupportScheduler(List<Engineer> engineers)
    {
        _engineers = engineers;
        _random = new Random();
    }

    public (Engineer, Engineer) ScheduleEngineers()
    {
        var twoWeeksAgo = DateTime.Now.AddDays(-14);
        var availableEngineers = _engineers.Where(e => !e.IsSupportScheduledToday && !e.IsSupportScheduledYesterday && e.IsSupportCompletedInLastTwoWeeks).ToList();

        if (availableEngineers.Count < 2)
        {
            throw new Exception("Not enough available engineers to schedule support.");
        }

        var firstEngineer = availableEngineers[_random.Next(availableEngineers.Count)];
        availableEngineers.Remove(firstEngineer);

        var secondEngineer = availableEngineers[_random.Next(availableEngineers.Count)];
        availableEngineers.Remove(secondEngineer);

        firstEngineer.IsSupportScheduledToday = true;
        secondEngineer.IsSupportScheduledToday = true;

        return (firstEngineer, secondEngineer);
    }

    public bool CheckSupportSchedule(int id)
    {
        var engineer = _engineers.FirstOrDefault(e => e.Id == id);
        if (engineer == null)
        {
            throw new Exception($"Engineer with id {id} not found.");
        }
        if (engineer.IsSupportScheduledToday || engineer.IsSupportScheduledYesterday)
        {
            return false;
        }
        if (!engineer.IsSupportCompletedInLastTwoWeeks)
        {
            return false;
        }
        return true;
    }
}
