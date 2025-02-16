using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceType
    {
        trị_liệu_da_mặt, 
        triệt_lông, 
        massage, 
        làm_móng, 
        makeup_trị_liệu
    }
}
