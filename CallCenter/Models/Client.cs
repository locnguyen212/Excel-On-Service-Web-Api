namespace CallCenter.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CustomerId { get; set; }
        public virtual Account Customer { get; set; } = null!;
        public virtual ICollection<ProductClient> ProductClients { get; set; } = new List<ProductClient>();

        //public override string ToString()
        //{
        //    return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Phone)}={Phone}, {nameof(Description)}={Description}, {nameof(Email)}={Email}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(CustomerId)}={CustomerId.ToString()}, {nameof(Customer)}={Customer}, {nameof(ProductClients)}={ProductClients}}}";
        //}
    }
}
