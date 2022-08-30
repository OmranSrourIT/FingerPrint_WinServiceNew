using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrint_WinService.ABIS_API.JsonResult
{
    class RootObject
    {
        [JsonProperty("Hand")]
        public HandObj Hand { get; set; }

    }
}
