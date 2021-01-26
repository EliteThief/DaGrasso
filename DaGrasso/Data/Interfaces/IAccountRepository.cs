using DaGrasso.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DaGrasso.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel upModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
    }
}