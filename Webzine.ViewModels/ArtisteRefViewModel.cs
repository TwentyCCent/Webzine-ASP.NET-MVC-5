// <copyright file="ArtisteRefViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels
{
    using Webzine.Entities;

    /// <summary>
    /// .
    /// </summary>
    public class ArtisteRefViewModel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteRefViewModel"/>.
        /// </summary>
        public ArtisteRefViewModel()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteRefViewModel"/>.
        /// </summary>
        /// <param name="artiste">Entité artiste.</param>
        public ArtisteRefViewModel(Artiste artiste)
        {
            this.IdArtiste = artiste.IdArtiste;
            this.Nom = artiste.Nom;
        }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public string Nom { get; set; }
    }
}
