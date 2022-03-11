using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BatataisAgendamento.Web.Info.Configuration
{
    public partial class SchedulingHour_Config
    {
        public class SchedulingDay_Config : IEntityTypeConfiguration<SchedulingDayInfo>
        {
            public void Configure(EntityTypeBuilder<SchedulingDayInfo> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();


                builder.HasMany(p => p.SchedulingHourInfoList)
                    .WithOne(b => b.DayInfo)
                    .HasForeignKey(p => p.IdDay);

            }
        }
    }
}
