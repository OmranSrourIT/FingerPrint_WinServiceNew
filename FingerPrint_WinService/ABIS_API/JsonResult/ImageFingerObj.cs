using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_WinService.ABIS_API.JsonResult
{
   public class ImageFingerObj
    {
        [JsonProperty("dataBytes")]
        public string dataBytes { get; set; }

        [JsonProperty("format")]
        public string format { get; set; }

    }
}
