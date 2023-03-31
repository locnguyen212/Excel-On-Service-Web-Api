namespace CallCenter.Models
{
    public partial class OrderClientDetail
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? OrderClientId { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual OrderClient OrderClient { get; set; } = null!;

        //public override string ToString()
        //{
        //    return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Description)}={Description}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(OrderClientId)}={OrderClientId.ToString()}, {nameof(ProductId)}={ProductId.ToString()}, {nameof(Product)}={Product}, {nameof(OrderClient)}={OrderClient}}}";
        //}
    }
}
