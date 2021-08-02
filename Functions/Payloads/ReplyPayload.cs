using System.Collections.Generic;

namespace Functions.Payloads
{
    /// <summary>
    /// reply APIリクエスト用ペイロード
    /// </summary>
    public class ReplyPayload
    {
        public string ReplyToken { get; set; }
        public IEnumerable<TextMessage> Messages { get; set; }

        public class TextMessage
        {
            public string Type { get; set; } = "text";
            public string Text { get; set; }
        }
    }
}
