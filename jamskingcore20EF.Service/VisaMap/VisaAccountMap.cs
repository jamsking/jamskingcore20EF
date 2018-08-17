using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.VisaModels;
namespace jamskingcore20EF.Service.VisaMap
{
    public class VisaAccountMap
    {
        public VisaAccountMap(EntityTypeBuilder<DbVisaapiVisaAccount> entityBuilder)
        {
            entityBuilder.HasKey(e => e.VisaAccountId);
            entityBuilder.Property(e => e.VisaAccountFirstName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountEmail).IsRequired();
            entityBuilder.Property(e => e.VisaAccountId).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIdno).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIdtype).IsRequired();
            entityBuilder.Property(e => e.VisaAccountLastName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountUsedName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIdno).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIdtype).IsRequired();
            entityBuilder.Property(e => e.VisaAccountIdtype).IsRequired();
            entityBuilder.Property(e => e.VisaAccountBrithCo).IsRequired();
            entityBuilder.Property(e => e.VisaAccountBrithday).IsRequired();
            entityBuilder.Property(e => e.VisaAccountBrithC).IsRequired();
            entityBuilder.Property(e => e.VisaAccountBrithP).IsRequired();
            entityBuilder.Property(e => e.VisaAccountComAdd).IsRequired();
            entityBuilder.Property(e => e.VisaAccountComJob).IsRequired();
            entityBuilder.Property(e => e.VisaAccountComName).IsRequired();
            entityBuilder.Property(e => e.VisaAccountComTel).IsRequired();
            entityBuilder.Property(e => e.VisaAccountComSalary).IsRequired();
            entityBuilder.Property(e => e.VisaAccountComTax).IsRequired();
            entityBuilder.Property(e => e.VisaAccountMst).IsRequired();
            entityBuilder.Property(e => e.VisaAccountMob).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPradd).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPrc).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPrco).IsRequired();
            entityBuilder.Property(e => e.VisaAccountPrp).IsRequired();
            
            entityBuilder.Property(e => e.VisaAccountRadd).IsRequired();
            entityBuilder.Property(e => e.VisaAccountRc).IsRequired();
            entityBuilder.Property(e => e.VisaAccountRco).IsRequired();
            entityBuilder.Property(e => e.VisaAccountRp).IsRequired();
            entityBuilder.Property(e => e.VisaAccountSex).IsRequired();
            entityBuilder.Property(e => e.VisaAccountTel).IsRequired();
            entityBuilder.Property(e => e.VisaAccountZip).IsRequired();
            entityBuilder.Property(e => e.ModifiedUser).IsRequired();
            entityBuilder.Property(e => e.IsDel).IsRequired();
            entityBuilder.Property(e => e.ModifiedDate).IsRequired();
            entityBuilder.Property(e => e.CreatUser).IsRequired();
            entityBuilder.Property(e => e.CreatDate).IsRequired();
            entityBuilder.Property(e => e.VisaToDoCode).IsRequired();
            entityBuilder.Property(e => e.VisaToDoId).IsRequired();


            //entityBuilder.Property(e => e.DbVisaapiVisaAccountFM).IsRequired();
            //entityBuilder.Property(e => e.DbVisaapiVisaAccountPT).IsRequired();
            //entityBuilder.Property(e => e.DbVisaapiVisaAccountTrip).IsRequired();
        }
    }
}