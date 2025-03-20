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
        Dưỡng_ẩm_phục_hồi,
        Kiểm_soát_dầu_thanh_lọc_da,
        Làm_dịu_giảm_kích_ứng,
        Làm_sạch_ngừa_mụn,
        Duy_trì_sức_khỏe_da
    }
}
