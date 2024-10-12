using Hrm;
using Hrm.Helpers;
using HumanResource.Entity;

namespace HumanResource.Services
{
    public class ContactService : IContactService
    {
        private readonly IUserQueryExecutor _queryExecutor;
        private readonly IContactServiceRules _contactServiceRule;
        private readonly IMetaUpdate _metaUpdate;
        public ContactService(IUserQueryExecutor queryExecutor, IContactServiceRules contactServiceRule, IMetaUpdate metaUpdate)
        {
            _queryExecutor = queryExecutor;
            _contactServiceRule = contactServiceRule;
            _metaUpdate = metaUpdate;
        }


        public async Task RegisterOrUpdate(Contact contact)
        {
            string Query = @"Insert Into Contacts(FirstName,LastName,PhoneNumber,Email,TimeInterval,LinkedIn,GitHub,Comments,CreatedOn,CreatedById,UpdatedOn,UpdatedById) OUTPUT INSERTED.ContactId VALUES (@FirstName,@LastName,@PhoneNumber,@Email,@TimeInterval,@LinkedIn,@GitHub,@Comments,@CreatedOn,@CreatedById,@UpdatedOn,@UpdatedById)";
            _contactServiceRule.ValidateContact(contact);
            if (await _contactServiceRule.ExistingContact(contact))
            {
                Query = @"Update Contacts SET FirstName=@FirstName,LastName=@LastName,PhoneNumber=@PhoneNumber,TimeInterval=@TimeInterval,LinkedIn=@LinkedIn,GitHub=@GitHub,Comments=@Comments,UpdatedById=@UpdatedById,UpdatedOn=@UpdatedOn Where ContactId=@Id";
            }
            _metaUpdate.UpdateMedata(contact);
            await _queryExecutor.ExecuteAsync(Query, contact);
        }
    }
}
