using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTraining.Domain.Models;


namespace NDDTraining.Infra.Data.Mappings
{
    public class TrainingActivityMap : IEntityTypeConfiguration<TrainingActivity>
    {
        public void Configure(EntityTypeBuilder<TrainingActivity> entity)
        {
            entity.ToTable("ACTIVITY");

            entity.HasKey(m => m.Id);

            entity.Property(m => m.Id)
                .HasColumnName("ID");

            entity.Property(m => m.Title)
                .HasColumnName("TITLE")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(m => m.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();
        }
    }


}
