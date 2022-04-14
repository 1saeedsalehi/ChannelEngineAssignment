using Newtonsoft.Json;

namespace ChannelEngine.Api.DTOS;

public class UpdateStockInputDto
{
    [JsonProperty("MerchantProductNo")]
    public string MerchantProductNo { get; set; }

    [JsonProperty("StockLocations")]
    public List<UpdateStockInputDto.StockLocation> StockLocations { get; set; }

    public class StockLocation
    {
        [JsonProperty("StockLocationId")]
        public long StockLocationId { get; set; }
    }
}
