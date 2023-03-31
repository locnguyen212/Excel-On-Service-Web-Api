namespace CallCenter.Models
{
    public partial class OrderClient
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? StaffId { get; set; }
        public int? OrderId { get; set; }
        public virtual Account Staff { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<OrderClientDetail> OrderClientDetails { get; set; } = new List<OrderClientDetail>();

        //public override string ToString()
        //{
        //    return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Description)}={Description}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(StaffId)}={StaffId.ToString()}, {nameof(OrderId)}={OrderId.ToString()}, {nameof(Staff)}={Staff}, {nameof(Order)}={Order}, {nameof(OrderClientDetails)}={OrderClientDetails}}}";
        //}
    }
}
