using HumanResource.Entity;

namespace HumanResource.Services
{
    public interface IContactServiceRules
    {
        void ValidateContact(Contact contact);
        Task<bool> ExistingContact(Contact contact);
    }
}
