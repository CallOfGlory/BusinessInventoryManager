namespace WebApplication2.Models
{
    public class PurchaseOrderModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int SupplierId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public BusinessModel? Business { get; set; }
        public SupplierModel? Supplier { get; set; }
        public ICollection<PurchaseOrderItemModel> Items { get; set; } = new List<PurchaseOrderItemModel>();
    }

    public class PurchaseOrderItemModel
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityReceived { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation
        public PurchaseOrderModel? PurchaseOrder { get; set; }
        public ProductModel? Product { get; set; }
    }

    public enum PurchaseOrderStatus
    {
        Draft = 0,
        Pending = 1,
        Approved = 2,
        Ordered = 3,
        PartiallyReceived = 4,
        Received = 5,
        Cancelled = 6
    }
}
