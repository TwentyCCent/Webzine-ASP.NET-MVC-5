// <copyright file="IRechercheServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services.Contracts
{
    using Webzine.ViewModels;

    /// <summary>
    /// Abstraction ou contrat d'accès aux services métiers d'une recherche.
    /// </summary>
    public interface IRechercheServices
    {
        /// <summary>
        /// Méthode de recherche des différents titres et artistes
        /// dont le libellé ou le nom contient la chaîne de caractère passé en paramètre
        /// </summary>
        /// <param name="mot">Chaine de caractère recherchée.</param>
        /// <returns>Viewmodel contenant une liste de titres dont le "Libelle" contient "mot"
        /// et une liste d'artiste dont le "Nom" contient "mot".</returns>
        ResearchViewModel GetResult(string mot);
    }
}
