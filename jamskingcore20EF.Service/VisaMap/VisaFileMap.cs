using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaFileMap
    {
        public VisaFileMap(EntityTypeBuilder<DbVisaapiVisaFile> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaFileId);
            entityBuilder.Property(e => e.VisaConAgeLim).IsRequired();
            entityBuilder.Property(e => e.VisaFileAtta).IsRequired();
            entityBuilder.Property(e => e.VisaConFitem).IsRequired();
            entityBuilder.Property(e => e.VisaConJobType).IsRequired();
            entityBuilder.Property(e => e.VisaConMst).IsRequired();
            entityBuilder.Property(e => e.VisaConName).IsRequired();
            entityBuilder.Property(e => e.VisaConNtext).IsRequired();
            entityBuilder.Property(e => e.VisaConOpt).IsRequired();
            entityBuilder.Property(e => e.VisaConSex).IsRequired();
            entityBuilder.Property(e => e.VisaConSign).IsRequired();
            entityBuilder.Property(e => e.VisaConType).IsRequired();
            entityBuilder.Property(e => e.VisaFileAntext).IsRequired();
            entityBuilder.Property(e => e.VisaFileFitemAn).IsRequired();
            entityBuilder.Property(e => e.VisaFileName).IsRequired();
            entityBuilder.Property(e => e.VisaFileRe).IsRequired();
            entityBuilder.Property(e => e.VisaToDoCode).IsRequired();
            entityBuilder.Property(e => e.VisaToDoId).IsRequired();
            entityBuilder.Property(e => e.VisaInfId).IsRequired();
            
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            
        }
    }
}