namespace CallCenter.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public bool? Status { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? RefreshPasswordTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<OrderClient> OrderClients { get; set; } = new List<OrderClient>();

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Username)}={Username}, {nameof(Password)}={Password}, {nameof(Email)}={Email}, {nameof(Phone)}={Phone}, {nameof(Role)}={Role}, {nameof(Status)}={Status.ToString()}, {nameof(Token)}={Token}, {nameof(RefreshToken)}={RefreshToken}, {nameof(RefreshTokenExpireTime)}={RefreshTokenExpireTime.ToString()}, {nameof(ResetPasswordToken)}={ResetPasswordToken}, {nameof(RefreshPasswordTime)}={RefreshPasswordTime.ToString()}, {nameof(CreatedAt)}={CreatedAt.ToString()}, {nameof(UpdatedAt)}={UpdatedAt.ToString()}, {nameof(DeletedAt)}={DeletedAt.ToString()}, {nameof(DepartmentId)}={DepartmentId.ToString()}, {nameof(Department)}={Department}, {nameof(Complaints)}={Complaints}, {nameof(Clients)}={Clients}, {nameof(Products)}={Products}, {nameof(OrderClients)}={OrderClients}}}";
        }
    }
}
