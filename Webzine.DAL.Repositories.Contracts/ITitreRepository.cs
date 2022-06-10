// <copyright file="ITitreRepository.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Repositories.Contracts
{
    using System.Linq;
    using Webzine.Entities;

    /// <summary>
    /// Repository de la table Titres.
    /// </summary>
    public interface ITitreRepository : IGenericRepository<Titre>
    {
        /// <summary>
        /// Recherche de titres dont l'attribut "Libelle" contient la chaine de caratères "mot".
        /// </summary>
        /// <param name="mot">Chaîne de caractère précisant la recherche.</param>
        /// <returns>Liste de titres.</returns>
        IQueryable<Titre> Search(string mot);

        /// <summary>
        /// Obtenir la liste des titres d'un artiste.
        /// </summary>
        /// <param name="idArtiste">Identifiant.</param>
        /// <returns>Liste de titres d'un artistes.</returns>
        IQueryable<Titre> GetTitresByArtiste(int idArtiste);

        /// <summary>
        /// Obtenir une liste de titres à partir de l'index "offset" et contenant un nombre de titres "limit".
        /// </summary>
        /// <param name="offset">Index du titre à partir du quel on construit la liste.</param>
        /// <param name="limit">Nombre de titres.</param>
        /// <returns>Liste de titres.</returns>
        IQueryable<Titre> FindTitres(int offset, int limit);

        /// <summary>
        /// Incrémenter le nombre de lecture d'un titre.
        /// </summary>
        /// <param name="titre">Objet titre.</param>
        void IncrementNbLectures(Titre titre);

        /// <summary>
        /// Décrémenter le nombre de lecture d'un titre.
        /// </summary>
        /// <param name="titre">Objet titre.</param>
        void DecrementNbLectures(Titre titre);

        /// <summary>
        /// Incrémenter le nombre de likes d'un titre.
        /// </summary>
        /// <param name="titre">Objet titre.</param>
        void IncrementNbLikes(Titre titre);
    }
}
