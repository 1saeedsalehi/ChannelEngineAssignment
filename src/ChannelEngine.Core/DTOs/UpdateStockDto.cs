using Newtonsoft.Json;

namespace ChannelEngine.Core.DTOs;
public class UpdateStockDto
{
    [JsonProperty("MerchantProductNo")]
    public string MerchantProductNo { get; set; }

    [JsonProperty("StockLocations")]
    public List<UpdateStockDto.StockLocation> StockLocations { get; set; }

    public class StockLocation
    {
        [JsonProperty("Stock")]
        public long Stock { get; set; }

        [JsonProperty("StockLocationId")]
        public long StockLocationId { get; set; }
    }
}
