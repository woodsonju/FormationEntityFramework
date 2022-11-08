using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExo1.DAO
{
    public class BlogDaoImpl : IBlogDAO
    {
        private Model1Container context;

        public BlogDaoImpl()
        {
            context = new Model1Container();
        }

        public List<Blog> FindAll()
        {
            return  context.Blogs.ToList();
        }
    }
}
