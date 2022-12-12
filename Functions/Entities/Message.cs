using System;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// 返信メッセージ
    /// </summary>
    public class Message
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// テキスト
        /// </summary>
        public string Text { get; set; }

        // TODO 「返信条件（閾値）」や「テンプレート・Flexメッセージに対応したパラメータ」等を必要に応じて追加
    }
}
