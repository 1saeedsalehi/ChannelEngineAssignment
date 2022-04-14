using System;
using System.Collections.Generic;
using ChannelEngine.Core.DTOs;

namespace ChannelEngine.Tests;

public static class DataGenerator
{
    public static IEnumerable<ProductDto> CreateDummyData()
    {
        var product = new ProductDto
        {
            TotalQuantity= 20,
            ProductName = "MSGH1-S",
            GTIN = "1234567890"
        };

        var product2 = new ProductDto
        {
            TotalQuantity = 5,
            ProductName = "MSGH1-X",
            GTIN = "1234567890"
        };

        var product3 = new ProductDto
        {
            TotalQuantity = 4,
            ProductName = "MSGH1-M",
            GTIN = "1234567890"
        };

        var product4 = new ProductDto
        {
            TotalQuantity = 3,
            ProductName = "MSGH1-M1",
            GTIN = "1234567890"
        };

        var product5 = new ProductDto
        {
            TotalQuantity = 2,
            ProductName = "MSGH1-M2",
            GTIN = "1234567890"
        };


        var response = new List<ProductDto>
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