using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class GameContext : DbContext
    {
        public GameContext()
        {
        }

        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost;Database=Competitions;Uid=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.HasIndex(e => e.TeamId1, "team_id_1");

                entity.HasIndex(e => e.TeamId2, "team_id_2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.TeamId1)
                    .HasColumnType("int(11)")
                    .HasColumnName("team_id_1");

                entity.Property(e => e.TeamId2)
                    .HasColumnType("int(11)")
                    .HasColumnName("team_id_2");

                entity.HasOne(d => d.TeamId1Navigation)
                    .WithMany(p => p.GameTeamId1Navigations)
                    .HasForeignKey(d => d.TeamId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_ibfk_2");

                entity.HasOne(d => d.TeamId2Navigation)
                    .WithMany(p => p.GameTeamId2Navigations)
                    .HasForeignKey(d => d.TeamId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_ibfk_1");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("goals");

                entity.HasIndex(e => e.GameId, "game_id");

                entity.HasIndex(e => e.PlayerId, "player_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .HasColumnName("count");

                entity.Property(e => e.GameId)
                    .HasColumnType("int(11)")
                    .HasColumnName("game_id");

                entity.Property(e => e.PlayerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("player_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("goals_ibfk_3");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("goals_ibfk_2");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.CountryId, "country_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_ibfk_2");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player");

                entity.HasIndex(e => e.PersonId, "person_id");

                entity.HasIndex(e => e.TeamId, "team_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PersonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("person_id");

                entity.Property(e => e.PlayerNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("player_number");

                entity.Property(e => e.TeamId)
                    .HasColumnType("int(11)")
                    .HasColumnName("team_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("player_ibfk_2");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("player_ibfk_1");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CountryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
