
using HumanResource.Entity;

namespace Hrm.Helpers
{
    public interface IMetaUpdate
    {
        void UpdateMedata<T>(T entity) where T : BaseEntity;
    }
}
