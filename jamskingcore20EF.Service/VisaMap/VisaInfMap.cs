using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaInfMap
    {
        public VisaInfMap(EntityTypeBuilder<DbVisaapiVisaInf> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaInfId);
            //entityBuilder.Property(e => e.dbVisaapiVisaCon).IsRequired();
            entityBuilder.Property(e => e.VisaEXP).IsRequired();
            entityBuilder.Property(e => e.VisaGOL).IsRequired();
            entityBuilder.Property(e => e.VisaName).IsRequired();
            entityBuilder.Property(e => e.VisaNat).IsRequired();
            entityBuilder.Property(e => e.VisaPrice).IsRequired();
            entityBuilder.Property(e => e.VisaSettlement).IsRequired();
            entityBuilder.Property(e => e.VisaSOM).IsRequired();
            entityBuilder.Property(e => e.VisaType).IsRequired();
            entityBuilder.Property(e => e.VisaYear).IsRequired();
           
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            
        }
    }
}