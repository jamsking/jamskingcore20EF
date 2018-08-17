using Microsoft.EntityFrameworkCore.Metadata.Builders;
using jamskingcore20EF.Model.Model;
namespace jamskingcore20EF.Service.Map
{
    public class BookMap
    {
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.ISBN).IsRequired();
            entityBuilder.Property(t => t.Author).IsRequired();
            entityBuilder.Property(t => t.Publisher).IsRequired();
        }
    }
}