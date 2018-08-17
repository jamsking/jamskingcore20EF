using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaToDoMap
    {
        public VisaToDoMap(EntityTypeBuilder<DbVisaapiVisaToDo> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaToDoId);
            //entityBuilder.Property(e => e.DbVisaapiVisaAccount).IsRequired();
            //entityBuilder.Property(e => e.DbVisaapiVisaFile).IsRequired();

            entityBuilder.Property(e => e.VisaEXP).IsRequired();
            entityBuilder.Property(e => e.VisaGOL).IsRequired();
            entityBuilder.Property(e => e.VisaInfId).IsRequired();
            entityBuilder.Property(e => e.VisaName).IsRequired();
            entityBuilder.Property(e => e.VisaNat).IsRequired();
            
            entityBuilder.Property(e => e.VisaPrice).IsRequired();
            entityBuilder.Property(e => e.VisaSettlement).IsRequired();
            entityBuilder.Property(e => e.VisaSOM).IsRequired();
            //entityBuilder.Property(e => e.VisaToDoBatch).IsRequired();
            entityBuilder.Property(e => e.VisaToDoBatchCode).IsRequired();
            entityBuilder.Property(e => e.VisaToDoBatchId).IsRequired();
            entityBuilder.Property(e => e.VisaToDoCode).IsRequired();
            entityBuilder.Property(e => e.VisaToDoDIS).IsRequired();
            entityBuilder.Property(e => e.VisaToDoProfit).IsRequired();
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