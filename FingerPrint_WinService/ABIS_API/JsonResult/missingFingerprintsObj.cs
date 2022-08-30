using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_WinService.ABIS_API.JsonResult
{
   public class missingFingerprintsObj
    {

        [JsonProperty("missingReasonCode")]
        public string missingReasonCode { get; set; }

        [JsonProperty("missingReasonText")]
        public string missingReasonText { get; set; }

        [JsonProperty("position")]
        public string position { get; set; }
     
    }
}
