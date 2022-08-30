using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_WinService.ABIS_API.JsonResult
{
      public  class HandObj
    {
        [JsonProperty("postion")]
        public string position { get; set; }


        [JsonProperty("image")]

        public Dictionary<string, ImageHandObj> image { get; set; }


        [JsonProperty("fingerprints")]
        public Dictionary<string, fingerprintsObj> Fingerprints { get; set; }


        [JsonProperty("missingFingerprints")]
        public Dictionary<string, missingFingerprintsObj> missingFingerprints { get; set; }


    }
}
