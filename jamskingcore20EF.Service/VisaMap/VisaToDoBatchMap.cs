using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaToDoBatchMap
    {
        public VisaToDoBatchMap(EntityTypeBuilder<DbVisaapiVisaToDoBatch> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaToDoBatchId);
            //entityBuilder.Property(e => e.DbVisaapiVisaToDo).IsRequired();

            entityBuilder.Property(e => e.VisaToDoBatchAdd).IsRequired();

            entityBuilder.Property(e => e.VisaToDoBatchCO).IsRequired();
            entityBuilder.Property(e => e.VisaToDoBatchCode).IsRequired();
            entityBuilder.Property(e => e.VisaToDoBatchPredictTGdate).IsRequired();
            entityBuilder.Property(e => e.VisaToDoBatchToDate).IsRequired();
            entityBuilder.Property(e => e.VisaToDoBatchUser).IsRequired();
            
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
        }
    }
}