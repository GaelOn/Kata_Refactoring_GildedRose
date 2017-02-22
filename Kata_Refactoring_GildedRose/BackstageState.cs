using System;

namespace GildedRose
{

    public interface IBackstageState
    {
        int ComputeQuality(IItem item);
        IBackstageState UpdateState(IItem item);
    }

    public class NoMoreValue : IBackstageState
    {
        public int ComputeQuality(IItem item)
        {
            return 0;
        }

        public IBackstageState UpdateState(IItem item)
        {
            return this;
        }
    }

    public class SoCloseToTheDate : IBackstageState
    {
        public int ComputeQuality(IItem item)
        {
            return item.Quality + 3;
        }

        public IBackstageState UpdateState(IItem item)
        {
            if (item.SellIn < 0)
            {
                return new NoMoreValue();
            }
            return this;
        }
    }

    public class OldSchoolConcertInFewTime : IBackstageState
    {
        public int ComputeQuality(IItem item)
        {
            return item.Quality + 2;
        }

        public IBackstageState UpdateState(IItem item)
        {
            if (item.SellIn < 5)
            {
                return (new SoCloseToTheDate()).UpdateState(item);
            }
            return this;
        }
    }

    public class ConcertTicketBuyJustSaveTheDate : IBackstageState
    {
        public int ComputeQuality(IItem item)
        {
            return item.Quality + 1;
        }

        public IBackstageState UpdateState(IItem item)
        {
            if (item.SellIn < 10)
            {
                return (new OldSchoolConcertInFewTime()).UpdateState(item);
            }
            return this;
        }
    }
}
