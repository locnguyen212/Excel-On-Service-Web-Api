namespace CallCenter.Models
{
    public partial class ProductClient
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? ClientId { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;

        //public override string ToString()
        //{
        //    return $"{{{nameof(Id)}={Id.ToString()}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(ClientId)}={ClientId.ToString()}, {nameof(ProductId)}={ProductId.ToString()}, {nameof(Product)}={Product}, {nameof(Client)}={Client}}}";
        //}
    }
}
