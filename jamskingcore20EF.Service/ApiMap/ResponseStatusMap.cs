using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.ApiModels;
namespace jamskingcore20EF.Service.ApiMap
{
    public class ResponseStatusMap
    {
        public ResponseStatusMap(EntityTypeBuilder<ResponseStatus> entityBuilder)
        {
            entityBuilder.HasKey(e => e.RSId);
            entityBuilder.Property(e => e.ApiCode).IsRequired();
            entityBuilder.Property(e => e.Errorcode).IsRequired();
            entityBuilder.Property(e => e.Infmation).IsRequired();
            entityBuilder.Property(e => e.Message).IsRequired();
            entityBuilder.Property(e => e.Position).IsRequired();
            entityBuilder.Property(e => e.Remark).IsRequired();
            entityBuilder.Property(e => e.Success).IsRequired();
            
            entityBuilder.Property(e => e.ApiFrom).IsRequired();
            

            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.IsLock).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            
        }
    }
}