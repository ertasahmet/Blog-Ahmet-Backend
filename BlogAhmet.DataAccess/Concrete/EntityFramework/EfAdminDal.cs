using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAhmet.DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin>, IAdminDal
    {
        public string GetLatestPassword()
        {
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {

                return context.Admins.OrderByDescending(a => a.AdminId).FirstOrDefault().AdminPassword;
            }
        }

        public string GetLatestUsername()
        {
            using (BlogAhmetContext context = new BlogAhmetContext(BlogAhmetContext.ops.dbOptions))
            {

                return context.Admins.OrderByDescending(a => a.AdminId).FirstOrDefault().AdminUsername;
            }
        }
    }
}
