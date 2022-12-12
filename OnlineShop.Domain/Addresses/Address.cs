﻿using OnlineShop.Domain.Models;
using OnlineShop.Domain.SalesOrderHeaders;

namespace OnlineShop.Domain.Addresses;

/// <summary>
/// Street address information for customers.
/// </summary>
public partial class Address : IBaseModel, IDisposable
{
    /// <summary>
    /// First street address line.
    /// </summary>
    public string AddressLine1 { get; set; } = null!;

    /// <summary>
    /// Second street address line.
    /// </summary>
    public string? AddressLine2 { get; set; }

    /// <summary>
    /// Name of the city.
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// Name of state or province.
    /// </summary>
    public string StateProvince { get; set; } = null!;

    public string CountryRegion { get; set; } = null!;

    /// <summary>
    /// Postal code for the street address.
    /// </summary>
    public string PostalCode { get; set; } = null!;

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; } = new List<CustomerAddress>();

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; } = new List<SalesOrderHeader>();

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; } = new List<SalesOrderHeader>();

    public void Dispose()
    {
    }

    public int Id { get; set; }
}
