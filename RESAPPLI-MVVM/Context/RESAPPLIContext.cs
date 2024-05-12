using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.TestModels;

namespace RESAPPLI_MVVM.Context;

public partial class RESAPPLIContext : DbContext
{
    public RESAPPLIContext()
    {
    }

    public RESAPPLIContext(DbContextOptions<RESAPPLIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorieplanning> Categorieplannings { get; set; }

    public virtual DbSet<Categoriereservation> Categoriereservations { get; set; }

    public virtual DbSet<Entreprise> Entreprises { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<MisAJour> MisAJours { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Planning> Plannings { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Typecompte> Typecomptes { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=res;uid=RES;pwd=azerty123!!!", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>().ToTable("reservation");

        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categorieplanning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("categorieplanning")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdEntreprise, "ID_Entreprise");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdEntreprise).HasColumnName("ID_Entreprise");
            entity.Property(e => e.Nom).HasMaxLength(255);

            entity.HasOne(d => d.IdEntrepriseNavigation).WithMany(p => p.Categorieplannings)
                .HasForeignKey(d => d.IdEntreprise)
                .HasConstraintName("CategoriePlanning_ibfk_1");
        });

        modelBuilder.Entity<Categoriereservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("categoriereservation")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdEntreprise, "ID_Entreprise");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdEntreprise).HasColumnName("ID_Entreprise");
            entity.Property(e => e.Nom).HasMaxLength(255);

            entity.HasOne(d => d.IdEntrepriseNavigation).WithMany(p => p.Categoriereservations)
                .HasForeignKey(d => d.IdEntreprise)
                .HasConstraintName("CategorieReservation_ibfk_1");
        });

        modelBuilder.Entity<Entreprise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("entreprise")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom).HasMaxLength(255);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("logs")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.UtilisateurId, "Utilisateur_ID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .HasColumnName("ACTION");
            entity.Property(e => e.Contenu)
                .HasColumnType("text")
                .HasColumnName("CONTENU");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.UtilisateurId).HasColumnName("Utilisateur_ID");

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UtilisateurId)
                .HasConstraintName("LOGS_ibfk_1");
        });

        modelBuilder.Entity<MisAJour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("mis_a_jour")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Auteur)
                .HasMaxLength(255)
                .HasColumnName("AUTEUR");
            entity.Property(e => e.Contenu)
                .HasColumnType("text")
                .HasColumnName("CONTENU");
            entity.Property(e => e.DtCreate)
                .HasColumnType("datetime")
                .HasColumnName("DT_CREATE");
            entity.Property(e => e.Titre)
                .HasMaxLength(255)
                .HasColumnName("TITRE");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("permission")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Libelle).HasMaxLength(255);
        });

        modelBuilder.Entity<Planning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("planning")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdCategorie, "ID_Categorie");

            entity.HasIndex(e => e.IdEntreprise, "ID_Entreprise");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdCategorie).HasColumnName("ID_Categorie");
            entity.Property(e => e.IdEntreprise).HasColumnName("ID_Entreprise");
            entity.Property(e => e.Nom).HasMaxLength(255);

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Plannings)
                .HasForeignKey(d => d.IdCategorie)
                .HasConstraintName("Planning_ibfk_2");

            entity.HasOne(d => d.IdEntrepriseNavigation).WithMany(p => p.Plannings)
                .HasForeignKey(d => d.IdEntreprise)
                .HasConstraintName("Planning_ibfk_1");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reservation")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdCategorie, "ID_Categorie");

            entity.HasIndex(e => e.IdPlanning, "ID_Planning");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.HeureDebut).HasColumnType("time");
            entity.Property(e => e.HeureFin).HasColumnType("time");
            entity.Property(e => e.IdCategorie).HasColumnName("ID_Categorie");
            entity.Property(e => e.IdPlanning).HasColumnName("ID_Planning");

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdCategorie)
                .HasConstraintName("Reservation_ibfk_2");

            entity.HasOne(d => d.IdPlanningNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdPlanning)
                .HasConstraintName("Reservation_ibfk_1");

            entity.HasMany(d => d.IdUtilisateurs).WithMany(p => p.IdReservations)
                .UsingEntity<Dictionary<string, object>>(
                    "PossedeReservation",
                    r => r.HasOne<Utilisateur>().WithMany()
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("POSSEDE_RESERVATION_ibfk_2"),
                    l => l.HasOne<Reservation>().WithMany()
                        .HasForeignKey("IdReservation")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("POSSEDE_RESERVATION_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdReservation", "IdUtilisateur")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("possede_reservation")
                            .UseCollation("utf8mb4_unicode_ci");
                        j.HasIndex(new[] { "IdUtilisateur" }, "ID_Utilisateur");
                    });
        });

        modelBuilder.Entity<Typecompte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("typecompte")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Libelle).HasMaxLength(255);

            entity.HasMany(d => d.IdPermissions).WithMany(p => p.IdTypeComptes)
                .UsingEntity<Dictionary<string, object>>(
                    "PossedePermission",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("IdPermission")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("POSSEDE_PERMISSION_ibfk_2"),
                    l => l.HasOne<Typecompte>().WithMany()
                        .HasForeignKey("IdTypeCompte")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("POSSEDE_PERMISSION_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdTypeCompte", "IdPermission")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("possede_permission")
                            .UseCollation("utf8mb4_unicode_ci");
                        j.HasIndex(new[] { "IdPermission" }, "ID_Permission");
                    });
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("utilisateur")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdEntreprise, "ID_Entreprise");

            entity.HasIndex(e => e.IdTypeCompte, "ID_TypeCompte");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATE_AT");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.IdEntreprise).HasColumnName("ID_Entreprise");
            entity.Property(e => e.IdTypeCompte).HasColumnName("ID_TypeCompte");
            entity.Property(e => e.LastCo)
                .HasColumnType("datetime")
                .HasColumnName("LAST_CO");
            entity.Property(e => e.Nom).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Prenom).HasMaxLength(255);

            entity.HasOne(d => d.IdEntrepriseNavigation).WithMany(p => p.Utilisateurs)
                .HasForeignKey(d => d.IdEntreprise)
                .HasConstraintName("UTILISATEUR_ibfk_2");

            entity.HasOne(d => d.IdTypeCompteNavigation).WithMany(p => p.Utilisateurs)
                .HasForeignKey(d => d.IdTypeCompte)
                .HasConstraintName("UTILISATEUR_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
