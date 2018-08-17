using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.LinkStarApiModels;
namespace jamskingcore20EF.Service.LinkStarApiMap
{
    public class ReRecoderMap
    {
        public ReRecoderMap(EntityTypeBuilder<ReRecoder> entityBuilder)
        {
            entityBuilder.HasKey(e => e.ReRecoderId);
            entityBuilder.Property(e => e.ApiCorrelationID).IsRequired();
            entityBuilder.Property(e => e.ApiEchoToken).IsRequired();
            entityBuilder.Property(e => e.ApiFrom).IsRequired();
            entityBuilder.Property(e => e.ApiReCon).IsRequired();
            
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