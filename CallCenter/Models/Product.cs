namespace CallCenter.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CustomerId { get; set; }
        public virtual Account Customer { get; set; } = null!;
        public virtual ICollection<ProductClient> ProductClients { get; set; } = new List<ProductClient>();
        public virtual ICollection<OrderClientDetail> OrderClientDetails { get; set; } = new List<OrderClientDetail>();

        //public override string ToString()
        //{
        //    return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(CustomerId)}={CustomerId.ToString()}, {nameof(Customer)}={Customer}, {nameof(ProductClients)}={ProductClients}, {nameof(OrderClientDetails)}={OrderClientDetails}}}";
        //}
    }
}
