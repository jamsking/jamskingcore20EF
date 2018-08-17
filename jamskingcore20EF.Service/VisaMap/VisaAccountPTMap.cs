using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaAccountPTMap
    {
        public VisaAccountPTMap(EntityTypeBuilder<DbVisaapiVisaAccountPT> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaAccountPTId);
            entityBuilder.Property(e => e.VisaAccountPTFirstENName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTLastENName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTType).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTIssueDay).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTIssueATP).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTIssueATCO).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTIssueATC).IsRequired();
            
            entityBuilder.Property(e => e.VisaAccountPTEXP).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPTCode).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIDNo).IsRequired();
            entityBuilder.Property(e => e.VisaAccountId).IsRequired();
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();

        }
    }
}