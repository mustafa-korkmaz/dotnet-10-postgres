using API.Requests.Account;
using Domain.Models;

namespace API.Mappings
{
    public static class AccountRequestMappings
    {
        public static User ToDomainModel(this RegisterRequest request, string passwordHash)
        {
            return User.Create(
                request.Email!,
                request.NameSurname,
                passwordHash);
        }
    }
}