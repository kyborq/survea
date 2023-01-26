namespace Core.Entities
{
    public class ReferalCode : BaseEntity
    {
        public int ReferalCodeId { get; set; }
        public string Code { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
