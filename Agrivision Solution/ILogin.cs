using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriProject
{
    internal interface ILogin 
    {
        bool Login(string connectionString, out string errorMessage);
    }
}
