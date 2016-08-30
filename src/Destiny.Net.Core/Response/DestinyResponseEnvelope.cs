namespace Destiny.Net.Core.Response
{
    public class DestinyResponseEnvelope
    {
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public DestinyMessageData MessageData { get; set; }
    }
}