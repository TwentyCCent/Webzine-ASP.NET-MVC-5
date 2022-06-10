// <copyright file="IGenericRepository.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Classe de méthode générique pour la manipulation de la base de données.
    /// </summary>
    /// <typeparam name="T">Type d'objet manipulé.</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Retourne une entité de type T en fonction de son Id.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>L'objet de type T identifié.</returns>
        T Find(object id);

        /// <summary>
        /// Retourne toutes les entités de type T.
        /// </summary>
        /// <returns>Tous les objets de la table de type T.</returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Persiste une entité de type T en BDD.
        /// </summary>
        /// <param name="value">Objet de type T.</param>
        void Add(T value);

        /// <summary>
        /// Persiste une liste d'entité de type T en BDD.
        /// </summary>
        /// <param name="value">Objet de type T.</param>
        void AddRange(List<T> value);

        /// <summary>
        /// Modifie une entité de type T.
        /// </summary>
        /// <param name="value">Objet de type T.</param>
        void Update(T value);

        /// <summary>
        /// Supprime une entité de type T.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        void Delete(object id);

        /// <summary>
        /// Retourne le nombre d'entité en BDD.
        /// </summary>
        /// <returns>Le nombre de ligne de la table des entités de type T.</returns>
        int Count();

        /// <summary>
        /// Sauvegarde des changements en BDD.
        /// </summary>
        void Save();
    }
}
