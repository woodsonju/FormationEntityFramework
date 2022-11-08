using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExo1.DAO
{
    public interface IBlogDAO
    {
        List<Blog> FindAll();
    }
}
