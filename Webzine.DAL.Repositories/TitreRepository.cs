// <copyright file="TitreRepository.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Repositories
{
    using System.Linq;
    using Webzine.Entities;
    using Webzine.Repositories.Contracts;

    /// <inheritdoc />
    public class TitreRepository : GenericRepository<Titre>, ITitreRepository
    {
        /// <inheritdoc />
        public IQueryable<Titre> Search(string mot)
        {
            return this.table.Where(t => t.Libelle.ToLower().Contains(mot.ToLower()));
        }

        /// <inheritdoc />
        public IQueryable<Titre> GetTitresByArtiste(int idArtiste)
        {
            return this.table.Where(t => t.IdArtiste == idArtiste);
        }

        /// <inheritdoc />
        public IQueryable<Titre> FindTitres(int offset, int limit)
        {
            var query = this.table.OrderByDescending(t => t.DateCreation).Skip(offset).Take(limit);
            return query;
        }

        /// <inheritdoc />
        public void IncrementNbLectures(Titre titre)
        {
            var nbLectures = this.table.FirstOrDefault(t => t == titre).NbLectures;
            titre.NbLectures = nbLectures++;
            this.Update(titre);
            this.Save();
        }

        /// <inheritdoc />
        public void DecrementNbLectures(Titre titre)
        {
            var nbLectures = this.table.FirstOrDefault(t => t == titre).NbLectures;
            if (nbLectures > 0)
            {
                titre.NbLectures = nbLectures - 1;
                this.Update(titre);
                this.Save();
            }
        }

        /// <inheritdoc />
        public void IncrementNbLikes(Titre titre)
        {
            var nbLikes = this.table.FirstOrDefault(t => t == titre).NbLikes;
            titre.NbLectures = nbLikes + 1;
            this.Update(titre);
            this.Save();
        }
    }
}
