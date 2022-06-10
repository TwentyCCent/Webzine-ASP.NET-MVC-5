// <copyright file="IArtisteRepository.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Webzine.Entities;

    /// <summary>
    /// Repository de la table Artistes.
    /// </summary>
    public interface IArtisteRepository : IGenericRepository<Artiste>
    {
        /// <summary>
        /// Recherche d'artistes dont l'attribut "Nom" contient la chaine de caratères "mot".
        /// </summary>
        /// <param name="mot">Chaîne de caractère précisant la recherche.</param>
        /// <returns>Liste d'artistes.</returns>
        IQueryable<Artiste> Search(string mot);
    }
}
