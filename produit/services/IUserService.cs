using produit.ModelAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace produit.services
{
   public interface IUserService
    {
        Task<IEnumerable<Register>> GetUser();
        Task<Register> EditUser(Register register, string id);
        Task<string> DeleteUser(string id);
    }
}
