using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Login
{
   public class LoginService : ILoginService
   {
       public bool verificaLogin(string login, string senha) => login == "smn" && senha == "123";
   }
}   
