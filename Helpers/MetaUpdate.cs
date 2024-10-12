

using HumanResource.Entity;

namespace Hrm.Helpers
{
    public class MetaUpdate : IMetaUpdate
    {

        public MetaUpdate()
        {
        }


        public void UpdateMedata<T>(T entity) where T : BaseEntity
        {
            entity.CreatedById = 55017;
            entity.UpdatedById = 55017;
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;

        }
    }
}
