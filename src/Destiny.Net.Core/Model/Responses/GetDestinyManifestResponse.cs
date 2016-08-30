using System.Collections.Generic;

namespace Destiny.Net.Core.Model.Responses
{
    public class GetDestinyManifestResponse : DestinyResponse
    {
        public override string Id => Version;
        public string Version { get; set; }
        public string MobileAssetContentPath { get; set; }
        public IEnumerable<MobileGearAssetDataBase> MobileGearAssetDataBases { get; set; }
        public MobileWorldContentPaths MobileWorldContentPaths { get; set; }
        public MobileGearCDN MobileGearCDN { get; set; }

        public static string BuildApiPath()
        {
            return "Manifest";
        }
    }
}