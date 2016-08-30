namespace Destiny.Net.Core
{
    public static class DestinyErrorCodes
    {
        public static int Ok => 1;
        public static int ApiInvalidOrExpiredKey => 2101;
        public static int ApiKeyMissingFromRequest => 2102;
    }
}