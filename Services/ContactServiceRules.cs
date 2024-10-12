using Hrm;
using HumanResource.Entity;

namespace HumanResource.Services
{
    public class ContactServiceRules : IContactServiceRules
    {
        private readonly IUserQueryExecutor _queryExecutor;


        public ContactServiceRules(IUserQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<bool> ExistingContact(Contact contact)
        {
            contact.Id = await _queryExecutor.ExecuteScalarAsync<int>("Select ContactId From Contacts Where Email=@Email", contact);
            return contact.Id > 0;
        }

        public void ValidateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact), "Contact cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(contact.FirstName))
            {
                throw new Exception("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(contact.LastName))
            {
                throw new Exception("Last name is required.");
            }
            if (string.IsNullOrWhiteSpace(contact.Email))
            {
                throw new Exception("Email Address is required.");
            }
            if (string.IsNullOrWhiteSpace(contact.Comments))
            {
                throw new Exception("Comment is required.");
            }

            if (!contact.Email.IsValidEmail())
            {
                throw new Exception("Invalid email format.");
            }

            if (!string.IsNullOrWhiteSpace(contact.PhoneNumber) && !contact.PhoneNumber.IsValidPhoneNumber())
            {
                throw new Exception("Invalid phone number format.");
            }
        }
    }

}
