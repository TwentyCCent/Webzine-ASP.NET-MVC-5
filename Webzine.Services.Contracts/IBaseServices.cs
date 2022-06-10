// <copyright file="IBaseServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services.Contracts
{
    using System.Collections.Generic;
    using Webzine.Entities;
    using Webzine.Repositories.Contracts;
    using Webzine.ViewModels;

    /// <summary>
    /// Abstraction ou contrat d'accès aux services métiers génériques.
    /// </summary>
    public interface IBaseServices
    {
        /// <summary>
        /// Include à la mano. Je suis un dingue.
        /// </summary>
        /// <param name="titres">Liste de titres.</param>
        /// <param name="repository">Repository d'accès à la table artiste.</param>
        /// <returns>Liste de titres incluant leur artiste respectif.</returns>
        List<TitreViewModel> GetListOfTitlesIncludeArtist(List<Titre> titres, IArtisteRepository repository);
    }
}
