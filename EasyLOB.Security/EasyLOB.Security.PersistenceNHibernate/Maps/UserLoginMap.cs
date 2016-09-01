using FluentNHibernate.Mapping;
using EasyLOB.Security.Data;

namespace EasyLOB.Security.Persistence
{
    public class UserLoginMap : ClassMap<UserLogin>
    {
        public UserLoginMap()
        {
            #region Class

            Table("AspNetUserLogins");

            CompositeId()
                .KeyProperty(x => x.LoginProvider, "LoginProvider")
                .KeyProperty(x => x.ProviderKey, "ProviderKey")
                .KeyProperty(x => x.UserId, "UserId");

            #endregion Class

            #region Associations (FK)

            References(x => x.User)
                .Column("UserId");

            #endregion Associations (FK)
        }
    }
}