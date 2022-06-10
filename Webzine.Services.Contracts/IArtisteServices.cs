// <copyright file="IArtisteServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services.Contracts
{
    using Webzine.ViewModels;

    /// <summary>
    /// Abstraction ou contrat d'accès aux services métiers des artistes.
    /// </summary>
    public interface IArtisteServices
    {
        /// <summary>
        /// Obtient un viewmodel d'une liste d'artistes pour l'affichage dans l'index de l'administration des artistes.
        /// </summary>
        /// <returns>ViewModel.</returns>
        ArtistesViewModel GetArtistes();

        /// <summary>
        /// Obtient un viewmodel d'une liste d'artistes pour l'affichage dans la sidebar.
        /// </summary>
        /// <returns>ViewModel.</returns>
        SidebarViewModel GetArtistesForSidebar();

        /// <summary>
        /// Obtient un viewmodel d'un artiste.
        /// </summary>
        /// <param name="id">Identifiant d'un artiste.</param>
        /// <returns>ViewModel.</returns>
        ArtisteViewModel GetArtiste(int id);

        /// <summary>
        /// Création d'un artiste.
        /// </summary>
        /// <param name="artiste">Viewmodel d'un artiste.</param>
        /// <returns>Booléen.</returns>
        bool CreateArtiste(ArtisteViewModel artiste);

        /// <summary>
        /// Modification d'un artiste.
        /// </summary>
        /// <param name="artiste">Viewmodel d'un artiste.</param>
        /// <returns>Booléen.</returns>
        bool UpdateArtiste(ArtisteViewModel artiste);

        /// <summary>
        /// Suppression d'un artiste.
        /// </summary>
        /// <param name="id">identifiant d'un artiste.</param>
        /// <returns>Booléen.</returns>
        bool DeleteArtiste(int id);
    }
}
