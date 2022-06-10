// <copyright file="BaseViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels.Base
{
    using Webzine.Entities;

    /// <summary>
    /// Classe viewmodel de méthode générique aux viewmodel spécifique.
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Méthode de formatage de la durée d'un titre.
        /// </summary>
        /// <param name="titre">Objet titre.</param>
        /// <returns>Durée d'un titre au format 0:00s en chaîne de caractère.</returns>
        public string FormatLength(Titre titre)
        {
            string output = ((titre.Duree - (titre.Duree % 60)) / 60) + ":";
            if (titre.Duree % 60 < 10)
            {
                output += "0";
            }

            output += (titre.Duree % 60).ToString();
            return output;
        }
    }
}
