using Azure.Core;
using ChatbotNinja.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatbotNinja.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }
        public ApplicationDbContext()
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=ChatbotNinja;Connection Timeout=300;MultipleActiveResultSets=True; TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>(character =>
            {
                character.ToTable("Characters");

                character.Property(l => l.DeletedAt).HasColumnType("date");
                character.Property(l => l.CreatedAt).HasColumnType("date");
                character.Property(l => l.ModifiedAt).HasColumnType("date");

                character.HasOne(c => c.BasePersonality);
                character.HasMany(c => c.TemplatesRoles);
            });

            modelBuilder.Entity<Personality>(perso =>
            {
                perso.ToTable("Personalities");

                perso.Property(l => l.DeletedAt).HasColumnType("date");
                perso.Property(l => l.CreatedAt).HasColumnType("date");
                perso.Property(l => l.ModifiedAt).HasColumnType("date");

                //perso.HasOne(p => p.Character);

                perso.HasMany(p => p.PersonalityTrails);
                perso.HasMany(p => p.PersonalityInstructions);
            });

            modelBuilder.Entity<PersonalityTrail>(perso =>
            {
                perso.ToTable("PersonalitiesTrails");

                perso.Property(l => l.DeletedAt).HasColumnType("date");
                perso.Property(l => l.CreatedAt).HasColumnType("date");
                perso.Property(l => l.ModifiedAt).HasColumnType("date");

                //perso.HasOne(p => p.Character);
            });

            modelBuilder.Entity<TemplateRole>(role =>
            {
                role.ToTable("TemplateRoles");

                role.Property(l => l.DeletedAt).HasColumnType("date");
                role.Property(l => l.CreatedAt).HasColumnType("date");
                role.Property(l => l.ModifiedAt).HasColumnType("date");

                role.HasMany(r => r.Characters);
                role.HasMany(r => r.PersonalityInstructions);
            });

            modelBuilder.Entity<Instruction>(instruction =>
            {
                instruction.ToTable("Instructions");

                instruction.HasOne(i => i.Personality)
                            .WithMany(p => p.PersonalityInstructions)
                            .HasForeignKey(i => i.PersonalityId);

                instruction.HasOne(i => i.TemplateRole)
                            .WithMany(r => r.PersonalityInstructions)
                            .HasForeignKey(i => i.TemplateRoleId);
            });


        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Personality> Personalities { get; set; }
        public DbSet<PersonalityTrail> PersonalitiesTrails { get; set; }

        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<TemplateRole> TemplatesRoles { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
