using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.ApiModels;
namespace jamskingcore20EF.Service.ApiMap
{
    public class ApiAccountGroupMap
    {
        public ApiAccountGroupMap(EntityTypeBuilder<ApiAccountGroup> entityBuilder)
        {
            entityBuilder.HasKey(e => e.ApiAccountGroupId);
            entityBuilder.Property(e => e.ApiAccountGroupName).IsRequired();
            entityBuilder.Property(e => e.ApiAccountGroupCode).IsRequired();
            entityBuilder.Property(e => e.ApiAccountGroupLevel).IsRequired();
            
            
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.IsLock).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            
        }
    }
}