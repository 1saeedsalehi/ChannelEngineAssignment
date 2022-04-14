using AutoMapper;
using ChannelEngine.Api.DTOS;
using ChannelEngine.Core.DTOs;

namespace ChannelEngine.Services;

public class DefaultMappingProfile : Profile
{
    public DefaultMappingProfile()
    {

        CreateMap<UpdateStockInputDto, UpdateStockDto>();

        CreateMap<UpdateStockInputDto.StockLocation, UpdateStockDto.StockLocation>()
            .ForMember(x => x.Stock, opt => opt.MapFrom(x => 25));
    }
}
