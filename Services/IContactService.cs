using HumanResource.Entity;

namespace HumanResource.Services
{
    public interface  IContactService
    {
        Task RegisterOrUpdate(Contact contact);
    }
}
