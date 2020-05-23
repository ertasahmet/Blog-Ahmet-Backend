using BlogAhmet.Business.Abstract;
using BlogAhmet.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAhmet.Business.Concrete
{
    public class AdminManager : IAdminService
    {

        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public string GetPassword()
        {
            return _adminDal.GetLatestPassword();
        }

        public string GetUsername()
        {
            return _adminDal.GetLatestUsername();
        }
    }
}
