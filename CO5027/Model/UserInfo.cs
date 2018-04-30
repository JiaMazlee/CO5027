using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CO5027.Model
{
    public class UserInfo
    {
        public UserDetail GetUserDetail(string guId)
        {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
            UserDetail info = (from x in db.UserDetails
                        where x.GUID == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserInfo(UserDetail userDetail)
        {
            db_1722759_co5027_asgEntities db = new db_1722759_co5027_asgEntities();
            db.UserDetails.Add(userDetail);
            db.SaveChanges();
        }

    }
}