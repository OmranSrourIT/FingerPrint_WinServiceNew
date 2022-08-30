using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_WinService.ABIS_API.JsonResult
{
   public class fingerprintsObj
    {

        [JsonProperty("postion")]
        public string position { get; set; }

        [JsonProperty("image")]
        public Dictionary<string, ImageFingerObj> image { get; set; }

    }
}
