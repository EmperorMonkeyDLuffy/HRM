namespace HumanResource.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

    }
}
