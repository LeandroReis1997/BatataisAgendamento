﻿using Microsoft.EntityFrameworkCore;

namespace BatataisAgendamento.Web.Info.SqlDbContext
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options) { }

        public DbSet<SchedulingDayInfo> SchedulingDay { get; set; }
        public DbSet<SchedulingHourInfo> SchedulingHour { get; set; }
    }
}
