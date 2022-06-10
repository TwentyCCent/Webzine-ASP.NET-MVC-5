// <copyright file="ArtistesViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Classe de type viewmodel pour une liste d'artistes.
    /// </summary>
    public class ArtistesViewModel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtistesViewModel"/>.
        /// </summary>
        public ArtistesViewModel()
        {
            this.Artistes = new List<ArtisteViewModel>();
        }

        /// <summary>
        /// Obtient ou définit une liste d'artistes.
        /// </summary>
        public List<ArtisteViewModel> Artistes { get; set; }
    }
}
