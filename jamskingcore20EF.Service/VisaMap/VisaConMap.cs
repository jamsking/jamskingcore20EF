using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaConMap
    {
        public VisaConMap(EntityTypeBuilder<DbVisaapiVisaCon> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaConId);
            entityBuilder.Property(e => e.VisaConAgeLim).IsRequired();
            entityBuilder.Property(e => e.VisaConAtta).IsRequired();
            entityBuilder.Property(e => e.VisaConFitem).IsRequired();
            entityBuilder.Property(e => e.VisaConJobType).IsRequired();
            entityBuilder.Property(e => e.VisaConMst).IsRequired();
            entityBuilder.Property(e => e.VisaConName).IsRequired();
            entityBuilder.Property(e => e.VisaConNtext).IsRequired();
            entityBuilder.Property(e => e.VisaConOpt).IsRequired();
            entityBuilder.Property(e => e.VisaConSex).IsRequired();
            entityBuilder.Property(e => e.VisaConSign).IsRequired();
            entityBuilder.Property(e => e.VisaConType).IsRequired();
            entityBuilder.Property(e => e.VisaInfId).IsRequired();
            
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            
        }
    }
}