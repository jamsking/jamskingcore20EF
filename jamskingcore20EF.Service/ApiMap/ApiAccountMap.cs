using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.ApiModels;
namespace jamskingcore20EF.Service.ApiMap
{
    public class ApiAccountMap
    {
        public ApiAccountMap(EntityTypeBuilder<ApiAccount> entityBuilder)
        {
            entityBuilder.HasKey(e => e.ApiAccountId);
            entityBuilder.Property(e => e.ApiAccountCode).IsRequired();
            entityBuilder.Property(e => e.ApiAccountUserName).IsRequired();
            entityBuilder.Property(e => e.ApiAccountPassWord).IsRequired();
            entityBuilder.Property(e => e.ApiAccountRealPassWord).IsRequired();
            entityBuilder.Property(e => e.ApiAccountRealName).IsRequired();
            entityBuilder.Property(e => e.ApiAccountComName).IsRequired();
            entityBuilder.Property(e => e.ApiAccountMob).IsRequired();
            entityBuilder.Property(e => e.ApiAccountTel).IsRequired();
            entityBuilder.Property(e => e.ApiAccountAddress).IsRequired();
            entityBuilder.Property(e => e.ApiAccountCity).IsRequired();
            entityBuilder.Property(e => e.ApiAccountNat).IsRequired();
            entityBuilder.Property(e => e.ApiUserGroup).IsRequired();
            entityBuilder.Property(e => e.ApiFrom).IsRequired();
            entityBuilder.Property(e => e.LoginTime).IsRequired();

            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.IsLock).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            
        }
    }
}