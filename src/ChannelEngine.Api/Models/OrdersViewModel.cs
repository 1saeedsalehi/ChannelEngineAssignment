using ChannelEngine.Core.DTOs;

namespace ChannelEngine.Api.Models;

public class OrdersViewModel
{
    public List<OrderDto> Orders { get; set; }
    public List<ProductDto> TopSoldProducts { get; set; }
}
