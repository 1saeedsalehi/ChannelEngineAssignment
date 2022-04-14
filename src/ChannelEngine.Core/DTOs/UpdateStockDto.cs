using Newtonsoft.Json;

namespace ChannelEngine.Core.DTOs;
public class UpdateStockDto
{
    [JsonProperty("MerchantProductNo")]
    public string MerchantProductNo { get; set; }

    [JsonProperty("Stock")]
    public long Stock { get; set; }
    

}
