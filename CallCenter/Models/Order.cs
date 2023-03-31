namespace CallCenter.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double? TotalPrice { get; set; }
        public bool? Status { get; set; }
        public int? Duration { get; set; }
        public string? Invoice { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? StaffId { get; set; }
        public int? CustomerId { get; set; }
        public int? ServiceId { get; set; }
        public virtual Account Staff { get; set; } = null!;
        public virtual Account Customer { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual ICollection<OrderClient> OrderClients { get; set; } = new List<OrderClient>();
        public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Description)}={Description}, {nameof(TotalPrice)}={TotalPrice.ToString()}, {nameof(Status)}={Status.ToString()}, {nameof(Duration)}={Duration.ToString()}, {nameof(Invoice)}={Invoice}, {nameof(StartedAt)}={StartedAt.ToString()}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(StaffId)}={StaffId.ToString()}, {nameof(CustomerId)}={CustomerId.ToString()}, {nameof(ServiceId)}={ServiceId.ToString()}, {nameof(Staff)}={Staff}, {nameof(Customer)}={Customer}, {nameof(Service)}={Service}, {nameof(OrderClients)}={OrderClients}, {nameof(Complaints)}={Complaints}}}";
        }
    }
}
