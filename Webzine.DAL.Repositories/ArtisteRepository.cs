// <copyright file="ArtisteRepository.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Repositories
{
    using System.Linq;
    using Webzine.Entities;
    using Webzine.Repositories.Contracts;

    /// <inheritdoc />
    public class ArtisteRepository : GenericRepository<Artiste>, IArtisteRepository
    {
        /// <inheritdoc />
        public IQueryable<Artiste> Search(string mot)
        {
            return this.table
                .Where(a => a.Nom.ToLower().Contains(mot.ToLower()));
        }
    }
}
