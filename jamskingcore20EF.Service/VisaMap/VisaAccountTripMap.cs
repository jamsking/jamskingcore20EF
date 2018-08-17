using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaAccountTripMap
    {
        public VisaAccountTripMap(EntityTypeBuilder<DbVisaapiVisaAccountTrip> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaAccountTripId);
            entityBuilder.Property(e => e.VisaAccountTripAdd).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripC).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripCO).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripFDate).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripP).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripPur).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripSDate).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTripTRName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIDNo).IsRequired();
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();

        }
    }
}