// <copyright file="ITitreServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services.Contracts
{
    using System.Collections.Generic;
    using Webzine.ViewModels;

    /// <summary>
    /// Abstraction ou contrat d'accès aux services métiers des titres.
    /// </summary>
    public interface ITitreServices
    {
        /// <summary>
        /// Service listant l'ensemble des titres en incluant leur artiste respectif pour l'affichage sur la page d'accueil.
        /// </summary>
        /// <returns>Liste de viewmodel de titre.</returns>
        List<TitreViewModel> GetTitres();

        /// <summary>
        /// Service listant les 3 titres les plus populaires en incluant leur artiste respectif pour l'affichage sur la page d'accueil.
        /// </summary>
        /// <returns>Liste de viewmodel de titre.</returns>
        List<TitreViewModel> GetTitresPopulaires();

        /// <summary>
        /// Méthode de pagination retournant les derniers titres chroniqués par trois.
        /// </summary>
        /// <param name="offset">Index de départ de construction de la liste.</param>
        /// <param name="limit">Nombre de titres.</param>
        /// <returns>Liste de viewmodel de titre.</returns>
        List<TitreViewModel> GetTitresWithPagination(int offset, int limit);

        /// <summary>
        /// Service retournant un titre en fonction de son identifiant.
        /// </summary>
        /// <param name="id">Identifiant du titre.</param>
        /// <returns>Un titre.</returns>
        TitreViewModel GetTitre(int id);

        /// <summary>
        /// Création d'un titre.
        /// </summary>
        /// <param name="titre">Viewmodel d'un titre.</param>
        /// <returns>Booléen.</returns>
        bool CreateTitre(TitreViewModel titre);

        /// <summary>
        /// Modification d'un titre.
        /// </summary>
        /// <param name="titre">Viewmodel d'un titre.</param>
        /// <returns>Booléen.</returns>
        bool UpdateTitre(TitreViewModel titre);

        /// <summary>
        /// Suppression d'un titre.
        /// </summary>
        /// <param name="id">Viewmodel d'un titre.</param>
        /// <returns>Booléen.</returns>
        bool DeleteTitre(int id);

        /// <summary>
        /// Obtient le nombre de titres total.
        /// </summary>
        /// <returns>Entier du nombre de titres.</returns>
        int Count();
    }
}
