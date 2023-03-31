namespace CallCenter.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        //public override string ToString()
        //{
        //    return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}, {nameof(Description)}={Description}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(OrderDetails)}={OrderDetails}}}";
        //}
    }
}
