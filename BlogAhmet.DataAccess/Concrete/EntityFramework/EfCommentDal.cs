using BlogAhmet.DataAccess.Abstract;
using BlogAhmet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment>, ICommentDal
    {
    }
}
