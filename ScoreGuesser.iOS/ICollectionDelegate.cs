using System;

namespace ScoreGuesser
{
    public interface ICollectionDelegate
    {
        void ScrollToNext();
        void AddOnePoint();
    }
}
