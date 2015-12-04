using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Framework.Common
{
    public interface ISignInPage
    {
        void Action_SignIn(string userName, string password, string churchCode);
    }
}
