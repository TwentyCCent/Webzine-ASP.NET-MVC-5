// <copyright file="WebzineDbInitializer.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>
namespace Webzine.EntitiesContext
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Webzine.Entities;
    using Webzine.RequestApiDeezer;

    /// <summary>
    /// Classe d'amorçage de la base de données.
    /// </summary>
    public class WebzineDbInitializer : DropCreateDatabaseAlways<WebzineDbContext>
    {
        /// <inheritdoc/>
        protected override void Seed(WebzineDbContext context)
        {
            // Amorçage de la base de données
            var task = this.GetRandomArtiste();
            task.Wait();
            var taskTitle = this.GetRandomTitre();
            taskTitle.Wait();

            base.Seed(context);
        }

        /// <summary>
        /// Enregistre une liste de 100 artistes en base de données.
        /// </summary>
        /// <param name="context">DbContext.</param>
        private async Task GetRandomArtiste()
        {
            IList<Artiste> artistes = await Seeder.GetRandomArtiste();

            using (var context = new WebzineDbContext())
            {
                context.Artistes.AddRange(artistes);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Enregistre une liste de 100 artistes en base de données.
        /// </summary>
        /// <param name="context">DbContext.</param>
        private Task GetRandomTitre()
        {
            List<Artiste> artistes;
            using (var context = new WebzineDbContext())
            {
                artistes = context.Artistes.ToList();
            }

            IList<Titre> titres = Seeder.GetTitresOfArtistes(artistes);

            using (var context = new WebzineDbContext())
            {
                context.Titres.AddRange(titres);
                context.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}
