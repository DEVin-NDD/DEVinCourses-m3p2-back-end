using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NDDTraining.Domain.Models;

namespace NDDTraining.Infra.Data.Mappings;

public class RegistrationMap : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> entity)
    {
        entity.ToTable("REGISTRATION");

        entity.HasKey(r => r.Id);

        entity.Property(r => r.Id)
            .HasColumnName("ID");

        entity.Property(m => m.UserId)
            .HasColumnName("USER_ID")
            .HasColumnType("INT")
            .IsRequired();

        entity.Property(m => m.TrainingId)
            .HasColumnName("TRAINING_ID")
            .HasColumnType("INT")
            .IsRequired();

        entity.Property(m => m.Status)
            .HasColumnName("STATUS")
            .HasColumnType("VARCHAR")
            .IsRequired();

        entity.Property(m => m.Status)
            .HasColumnName("STATUS")
            .HasColumnType("VARCHAR")
            .IsRequired();
        
        entity.HasOne<Training>(r => r.Training)
            .WithMany()
            .HasForeignKey(r => r.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne<User>(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}