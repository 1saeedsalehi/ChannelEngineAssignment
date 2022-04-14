using System;
using System.Collections.Generic;
using ChannelEngine.Core.DTOs;

namespace ChannelEngine.Tests;

public static class DataGenerator
{
    public static IEnumerable<TopSoldDto> CreateDummyData()
    {
        var product = new TopSoldDto
        {
            TotalQuantity= 20,
            ProductName = "MSGH1-S",
            GTIN = "1234567890"
        };

        var product2 = new TopSoldDto
        {
            TotalQuantity = 5,
            ProductName = "MSGH1-X",
            GTIN = "1234567890"
        };

        var product3 = new TopSoldDto
        {
            TotalQuantity = 4,
            ProductName = "MSGH1-M",
            GTIN = "1234567890"
        };

        var product4 = new TopSoldDto
        {
            TotalQuantity = 3,
            ProductName = "MSGH1-M1",
            GTIN = "1234567890"
        };

        var product5 = new TopSoldDto
        {
            TotalQuantity = 2,
            ProductName = "MSGH1-M2",
            GTIN = "1234567890"
        };


        var response = new List<TopSoldDto>
        {
            product,
            product2,
            product3,
            product4,
            product5
        };

        return response;
    }
}