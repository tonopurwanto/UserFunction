using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFunction.Models;

namespace UserFunction.Services
{
    public interface IProfileService
    {
        public Profile GetProfile(string user);
    }
}
