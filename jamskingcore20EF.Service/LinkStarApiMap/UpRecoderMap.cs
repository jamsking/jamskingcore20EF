using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.LinkStarApiModels;
namespace jamskingcore20EF.Service.LinkStarApiMap
{
    public class UpRecoderMap
    {
        public UpRecoderMap(EntityTypeBuilder<UpRecoder> entityBuilder)
        {
            entityBuilder.HasKey(e => e.UpRecoderId);
            entityBuilder.Property(e => e.ApiAccountCode).IsRequired();
            entityBuilder.Property(e => e.ApiEchoToken).IsRequired();
            entityBuilder.Property(e => e.ApiFrom).IsRequired();
            entityBuilder.Property(e => e.ApiCon).IsRequired();
            entityBuilder.Property(e => e.ApiAccountId).IsRequired();
            entityBuilder.Property(e => e.ApiAccountUserName).IsRequired();
            entityBuilder.Property(e => e.ApiSysPassWord).IsRequired();
            entityBuilder.Property(e => e.ApiSysUserName).IsRequired();
            entityBuilder.Property(e => e.ApiUrl).IsRequired();
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