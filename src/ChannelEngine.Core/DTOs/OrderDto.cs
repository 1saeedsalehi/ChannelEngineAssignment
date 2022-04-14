
namespace ChannelEngine.Core.DTOs;

using System;
using Newtonsoft.Json;

public class OrderDto
{
    [JsonProperty("Content")]
    public Orders[] Orders { get; set; }

    [JsonProperty("Count")]
    public long Count { get; set; }

    [JsonProperty("TotalCount")]
    public long TotalCount { get; set; }

    [JsonProperty("ItemsPerPage")]
    public long ItemsPerPage { get; set; }

    [JsonProperty("StatusCode")]
    public long StatusCode { get; set; }

    [JsonProperty("LogId")]
    public object LogId { get; set; }

    [JsonProperty("Success")]
    public bool Success { get; set; }

    [JsonProperty("Message")]
    public object Message { get; set; }

    [JsonProperty("ValidationErrors")]
    public ValidationErrors ValidationErrors { get; set; }
}


public class ValidationErrors
{
}

public class Orders
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("ChannelName")]
    public string ChannelName { get; set; }

    [JsonProperty("ChannelId")]
    public long ChannelId { get; set; }

    [JsonProperty("GlobalChannelName")]
    public string GlobalChannelName { get; set; }

    [JsonProperty("GlobalChannelId")]
    public long GlobalChannelId { get; set; }

    [JsonProperty("ChannelOrderSupport")]
    public string ChannelOrderSupport { get; set; }

    [JsonProperty("ChannelOrderNo")]
    public string ChannelOrderNo { get; set; }

    [JsonProperty("MerchantOrderNo")]
    public string MerchantOrderNo { get; set; }

    [JsonProperty("Status")]
    public string Status { get; set; }

    [JsonProperty("IsBusinessOrder")]
    public bool IsBusinessOrder { get; set; }

    [JsonProperty("CreatedAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("UpdatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("MerchantComment")]
    public object MerchantComment { get; set; }

    [JsonProperty("BillingAddress")]
    public IngAddress BillingAddress { get; set; }

    [JsonProperty("ShippingAddress")]
    public IngAddress ShippingAddress { get; set; }

    [JsonProperty("SubTotalInclVat")]
    public double SubTotalInclVat { get; set; }

    [JsonProperty("SubTotalVat")]
    public double SubTotalVat { get; set; }

    [JsonProperty("ShippingCostsVat")]
    public long ShippingCostsVat { get; set; }

    [JsonProperty("TotalInclVat")]
    public double TotalInclVat { get; set; }

    [JsonProperty("TotalVat")]
    public double TotalVat { get; set; }

    [JsonProperty("OriginalSubTotalInclVat")]
    public double OriginalSubTotalInclVat { get; set; }

    [JsonProperty("OriginalSubTotalVat")]
    public double OriginalSubTotalVat { get; set; }

    [JsonProperty("OriginalShippingCostsInclVat")]
    public long OriginalShippingCostsInclVat { get; set; }

    [JsonProperty("OriginalShippingCostsVat")]
    public long OriginalShippingCostsVat { get; set; }

    [JsonProperty("OriginalTotalInclVat")]
    public double OriginalTotalInclVat { get; set; }

    [JsonProperty("OriginalTotalVat")]
    public double OriginalTotalVat { get; set; }

    [JsonProperty("Lines")]
    public Line[] Lines { get; set; }

    [JsonProperty("ShippingCostsInclVat")]
    public long ShippingCostsInclVat { get; set; }

    [JsonProperty("Phone")]
    public string Phone { get; set; }

    [JsonProperty("Email")]
    public string Email { get; set; }

    [JsonProperty("CompanyRegistrationNo")]
    public object CompanyRegistrationNo { get; set; }

    [JsonProperty("VatNo")]
    public object VatNo { get; set; }

    [JsonProperty("PaymentMethod")]
    public string PaymentMethod { get; set; }

    [JsonProperty("PaymentReferenceNo")]
    public object PaymentReferenceNo { get; set; }

    [JsonProperty("CurrencyCode")]
    public string CurrencyCode { get; set; }

    [JsonProperty("OrderDate")]
    public DateTimeOffset OrderDate { get; set; }

    [JsonProperty("ChannelCustomerNo")]
    public object ChannelCustomerNo { get; set; }

    [JsonProperty("ExtraData")]
    public ExtraData ExtraData { get; set; }
}

public class IngAddress
{
    [JsonProperty("Line1")]
    public string Line1 { get; set; }

    [JsonProperty("Line2")]
    public object Line2 { get; set; }

    [JsonProperty("Line3")]
    public object Line3 { get; set; }

    [JsonProperty("Gender")]
    public string Gender { get; set; }

    [JsonProperty("CompanyName")]
    public object CompanyName { get; set; }

    [JsonProperty("FirstName")]
    public string FirstName { get; set; }

    [JsonProperty("LastName")]
    public string LastName { get; set; }

    [JsonProperty("StreetName")]
    public string StreetName { get; set; }

    [JsonProperty("HouseNr")]
    public string HouseNr { get; set; }

    [JsonProperty("HouseNrAddition")]
    public object HouseNrAddition { get; set; }

    [JsonProperty("ZipCode")]
    public string ZipCode { get; set; }

    [JsonProperty("City")]
    public string City { get; set; }

    [JsonProperty("Region")]
    public object Region { get; set; }

    [JsonProperty("CountryIso")]
    public string CountryIso { get; set; }

    [JsonProperty("Original")]
    public object Original { get; set; }
}

public class ExtraData
{
    [JsonProperty("Extra Data")]
    public string ExtraDataExtraData { get; set; }
}

public class Line
{
    [JsonProperty("Status")]
    public string Status { get; set; }

    [JsonProperty("IsFulfillmentByMarketplace")]
    public bool IsFulfillmentByMarketplace { get; set; }

    [JsonProperty("Gtin")]
    public string Gtin { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }

    [JsonProperty("StockLocation")]
    public StockLocation StockLocation { get; set; }

    [JsonProperty("UnitVat")]
    public double UnitVat { get; set; }

    [JsonProperty("LineTotalInclVat")]
    public double LineTotalInclVat { get; set; }

    [JsonProperty("LineVat")]
    public double LineVat { get; set; }

    [JsonProperty("OriginalUnitPriceInclVat")]
    public double OriginalUnitPriceInclVat { get; set; }

    [JsonProperty("OriginalUnitVat")]
    public double OriginalUnitVat { get; set; }

    [JsonProperty("OriginalLineTotalInclVat")]
    public double OriginalLineTotalInclVat { get; set; }

    [JsonProperty("OriginalLineVat")]
    public double OriginalLineVat { get; set; }

    [JsonProperty("OriginalFeeFixed")]
    public long OriginalFeeFixed { get; set; }

    [JsonProperty("BundleProductMerchantProductNo")]
    public object BundleProductMerchantProductNo { get; set; }

    [JsonProperty("JurisCode")]
    public object JurisCode { get; set; }

    [JsonProperty("JurisName")]
    public object JurisName { get; set; }

    [JsonProperty("VatRate")]
    public long VatRate { get; set; }

    [JsonProperty("ExtraData")]
    public object[] ExtraData { get; set; }

    [JsonProperty("ChannelProductNo")]
    public long ChannelProductNo { get; set; }

    [JsonProperty("MerchantProductNo")]
    public string MerchantProductNo { get; set; }

    [JsonProperty("Quantity")]
    public long Quantity { get; set; }

    [JsonProperty("CancellationRequestedQuantity")]
    public long CancellationRequestedQuantity { get; set; }

    [JsonProperty("UnitPriceInclVat")]
    public double UnitPriceInclVat { get; set; }

    [JsonProperty("FeeFixed")]
    public long FeeFixed { get; set; }

    [JsonProperty("FeeRate")]
    public long FeeRate { get; set; }

    [JsonProperty("Condition")]
    public string Condition { get; set; }

    [JsonProperty("ExpectedDeliveryDate")]
    public DateTimeOffset ExpectedDeliveryDate { get; set; }
}

public class StockLocation
{
    [JsonProperty("Id")]
    public long Id { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }
}


