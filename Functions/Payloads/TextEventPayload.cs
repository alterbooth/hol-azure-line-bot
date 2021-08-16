using System.Collections.Generic;

namespace Functions.Payloads
{
    /// <summary>
    /// textイベント用ペイロード
    /// </summary>
    public class TextEventPayload
    {
        public IEnumerable<Event> Events { get; set; }

        public class Event
        {
            public string ReplyToken { get; set; }
            public string Type { get; set; }
            public EventMessage Message { get; set; }

            public class EventMessage
            {
                public string Text { get; set; }
            }
        }
    }
}
