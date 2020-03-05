using System;

namespace Pliance.SDK.Contract.Entities
{
    public class LastChanged
    {
        public DateTime TimestampUtc { get; }
        public string Checkpoint { get; }

        public LastChanged(DateTime timestampUtc, string checkpoint)
        {
            TimestampUtc = timestampUtc;
            Checkpoint = checkpoint;
        }
    }
}