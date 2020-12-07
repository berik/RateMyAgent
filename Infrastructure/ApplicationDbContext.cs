using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.IServices;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService)
            : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<SoccerGame> SoccerGames { get; set; }
        public DbSet<SoccerEvent> SoccerEvents { get; set; }
        public DbSet<SoccerPlayer> SoccerPlayers { get; set; }
        public DbSet<SoccerTeam> SoccerTeams { get; set; }

        private readonly int ManchesterTeamId = 1;
        private readonly int BarcelonaTeamId = 2;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            const string adminId = "4ab306a9-ff4c-46ca-a6f9-c47383d928d8";
            const string roleId = "b43aaa03-ef03-4ec8-815b-5c79929361e9";

            // seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = roleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
            });

            // create admin user
            var adminUser = new ApplicationUser
            {
                Id = adminId,
                UserName = "berik.assylbekov@gmail.com",
                NormalizedUserName = "berik.assylbekov@gmail.com".ToUpper(),
                Email = "berik.assylbekov@gmail.com",
                NormalizedEmail = "berik.assylbekov@gmail.com".ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //set user password
            var ph = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "CCc76511!!");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<SoccerTeam>(ConfigureSoccerTeam);
            modelBuilder.Entity<SoccerPlayer>(ConfigureSoccerPlayer);
            modelBuilder.Entity<SoccerGame>(ConfigureSoccerGame);
            modelBuilder.Entity<SoccerEvent>(ConfigureSoccerEvent);
        }

        private void ConfigureSoccerTeam(EntityTypeBuilder<SoccerTeam> modelBuilder)
        {
            modelBuilder.Property(a => a.Name).IsRequired();
            modelBuilder
                .HasMany(a => a.Players)
                .WithOne(a => a.SoccerTeam)
                .OnDelete(DeleteBehavior.Cascade);

            // populate initial data
            modelBuilder.HasData(new List<SoccerTeam>()
            {
                new SoccerTeam()
                {
                    Id = ManchesterTeamId,
                    Name = "Manchester City"
                },
                new SoccerTeam()
                {
                    Id = BarcelonaTeamId,
                    Name = "Barcelona"
                }
            });
        }

        private void ConfigureSoccerPlayer(EntityTypeBuilder<SoccerPlayer> modelBuilder)
        {
            modelBuilder.Property(a => a.Name).IsRequired();

            // populate initial data
            modelBuilder.HasData(new List<SoccerPlayer>()
            {
                new SoccerPlayer()
                {
                    Id = 1,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Ederson",
                    SoccerPlayerType = SoccerPlayerType.Goalkeeper,
                },
                new SoccerPlayer()
                {
                    Id = 2,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Ake Nathan",
                    SoccerPlayerType = SoccerPlayerType.Defender,
                },
                new SoccerPlayer()
                {
                    Id = 3,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Cancelo Joao",
                    SoccerPlayerType = SoccerPlayerType.Defender
                },
                new SoccerPlayer()
                {
                    Id = 4,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Dias Ruben",
                    SoccerPlayerType = SoccerPlayerType.Defender,
                },
                new SoccerPlayer()
                {
                    Id = 5,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "De Bruyne Kevin",
                    SoccerPlayerType = SoccerPlayerType.Midfielder
                },
                new SoccerPlayer()
                {
                    Id = 6,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Foden Phil",
                    SoccerPlayerType = SoccerPlayerType.Midfielder,
                },
                new SoccerPlayer()
                {
                    Id = 7,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Aguero Sergio",
                    SoccerPlayerType = SoccerPlayerType.Forward
                },
                new SoccerPlayer()
                {
                    Id = 8,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Gabriel Jesus",
                    SoccerPlayerType = SoccerPlayerType.Forward
                },
                new SoccerPlayer()
                {
                    Id = 9,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Sterling Raheem",
                    SoccerPlayerType = SoccerPlayerType.Forward
                },
                new SoccerPlayer()
                {
                    Id = 10,
                    SoccerTeamId = ManchesterTeamId,
                    Name = "Guardiola Pep",
                    SoccerPlayerType = SoccerPlayerType.Coach
                },
                new SoccerPlayer()
                {
                    Id = 11,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Neto",
                    SoccerPlayerType = SoccerPlayerType.Goalkeeper
                },
                new SoccerPlayer()
                {
                    Id = 12,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Alba Jordi",
                    SoccerPlayerType = SoccerPlayerType.Defender,
                },
                new SoccerPlayer()
                {
                    Id = 13,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Firpo Junior",
                    SoccerPlayerType = SoccerPlayerType.Defender
                },
                new SoccerPlayer()
                {
                    Id = 14,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Mingueza Oscar",
                    SoccerPlayerType = SoccerPlayerType.Defender,
                },
                new SoccerPlayer()
                {
                    Id = 15,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Coutinho Philippe",
                    SoccerPlayerType = SoccerPlayerType.Midfielder
                },
                new SoccerPlayer()
                {
                    Id = 16,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Puig Ricard",
                    SoccerPlayerType = SoccerPlayerType.Midfielder,
                },
                new SoccerPlayer()
                {
                    Id = 17,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "de Jong Frenkie",
                    SoccerPlayerType = SoccerPlayerType.Forward
                },
                new SoccerPlayer()
                {
                    Id = 18,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Messi Lionel",
                    SoccerPlayerType = SoccerPlayerType.Forward
                },
                new SoccerPlayer()
                {
                    Id = 19,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Trincao",
                    SoccerPlayerType = SoccerPlayerType.Forward
                },
                new SoccerPlayer()
                {
                    Id = 20,
                    SoccerTeamId = BarcelonaTeamId,
                    Name = "Koeman Ronald",
                    SoccerPlayerType = SoccerPlayerType.Coach
                }
            });
        }

        private void ConfigureSoccerGame(EntityTypeBuilder<SoccerGame> modelBuilder)
        {
            modelBuilder.HasOne(a => a.HomeSoccerTeam).WithMany().HasForeignKey(a => a.HomeSoccerTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.HasOne(a => a.GuestSoccerTeam).WithMany().HasForeignKey(a => a.GuestSoccerTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // populate initial data
            modelBuilder.HasData(new List<SoccerGame>()
            {
                new SoccerGame()
                {
                    Id = 1,
                    Name = "Manchester City vs Barcelona",
                    GameStatus = GameStatus.NotStarted,
                    HomeSoccerTeamId = ManchesterTeamId,
                    GuestSoccerTeamId = BarcelonaTeamId
                }
            });
        }

        private void ConfigureSoccerEvent(EntityTypeBuilder<SoccerEvent> modelBuilder)
        {
            modelBuilder
                .HasOne(p => p.SoccerPlayer)
                .WithMany(b => b.SoccerEvents)
                .HasForeignKey(p => p.SoccerPlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(p => p.SoccerGame)
                .WithMany(b => b.SoccerEvents)
                .HasForeignKey(p => p.SoccerGameId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder
                .HasOne(p => p.SoccerTeam)
                .WithMany(b => b.SoccerEvents)
                .HasForeignKey(p => p.SoccerTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}