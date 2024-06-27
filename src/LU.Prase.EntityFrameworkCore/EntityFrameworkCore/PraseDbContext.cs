using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LU.Prase.Authorization.Roles;
using LU.Prase.Authorization.Users;
using LU.Prase.MultiTenancy;
using LU.Prase.Entities;

namespace LU.Prase.EntityFrameworkCore
{
    public class PraseDbContext : AbpZeroDbContext<Tenant, Role, User, PraseDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public PraseDbContext(DbContextOptions<PraseDbContext> options)
            : base(options)
        {
        }
    }
}
