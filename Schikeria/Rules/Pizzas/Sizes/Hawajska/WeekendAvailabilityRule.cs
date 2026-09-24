using Schikeria.Interfaces.Rules.Pizzas.Hawajska;

namespace Schikeria.Rules.Pizzas.Sizes.Hawajska
{
    public class WeekendAvailabilityRule :
        IWeekendAvailabilityRule
    {
        public bool IsSatisfied() =>
            DateTime.Now.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday;
    }
}
