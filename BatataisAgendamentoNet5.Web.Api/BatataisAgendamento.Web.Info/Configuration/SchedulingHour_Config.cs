using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BatataisAgendamento.Web.Info.Configuration
{
    public partial class SchedulingHour_Config : IEntityTypeConfiguration<SchedulingHourInfo>
    {
        public void Configure(EntityTypeBuilder<SchedulingHourInfo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
