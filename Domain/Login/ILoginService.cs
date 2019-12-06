using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Login
{
    public interface ILoginService
    {
        bool verificaLogin(string login, string senha);
    }
}
