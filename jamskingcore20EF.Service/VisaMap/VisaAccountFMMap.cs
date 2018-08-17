using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaAccountFMMap
    {
        public VisaAccountFMMap(EntityTypeBuilder<DbVisaapiVisaAccountFM> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaAccountFMId);
            entityBuilder.Property(e => e.VisaAccountFMFirstName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountFMLastName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountFMFirstEnname).IsRequired();
            entityBuilder.Property(e => e.VisaAccountFMLastEnname).IsRequired();
            entityBuilder.Property(e => e.VisaAccountFMRel).IsRequired();
            entityBuilder.Property(e => e.VisaAccountFMJob).IsRequired();
            entityBuilder.Property(e => e.VisaAccountFMRel).IsRequired();
            
            entityBuilder.Property(e => e.VisaAccountFMBrithday).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIDNo).IsRequired();
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
        }
    }
}