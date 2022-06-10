// <copyright file="WebzineDbContext.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.EntitiesContext
{
    using System.Data.Entity;
    using Webzine.Entities;

    /// <summary>
    /// Classe définissant le contexte de la base de données.
    /// </summary>
    public class WebzineDbContext : DbContext
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="WebzineDbContext"/>.
        /// </summary>
        public WebzineDbContext()
            : base("WebzineDbContext")
        {
            // Initialisation de la base de données avec amorçage
            // Database.SetInitializer(new WebzineDbInitializer());

            // Log des requêtes SQL
            this.Database.Log = (sql) => System.Diagnostics.Debug.WriteLine(sql);
        }

        /// <summary>
        /// Obtient ou définit sur ensemble d'artistes persistants.
        /// </summary>
        public DbSet<Artiste> Artistes { get; set; }

        /// <summary>
        /// Obtient ou définit sur ensemble des titres persistants.
        /// </summary>
        public DbSet<Titre> Titres { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new WebzineConfigurations());

            // Conventions de nommage des tables au pluriel ou singulier
            modelBuilder.Conventions.Remove();

            modelBuilder.Entity<Titre>()
                .HasRequired(t => t.Artiste)
                .WithMany(a => a.Titres)
                .HasForeignKey(t => t.IdArtiste);

            base.OnModelCreating(modelBuilder);
        }
    }
}
