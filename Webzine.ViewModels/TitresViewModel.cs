// <copyright file="TitresViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Classe de type viewmodel pour un titre.
    /// </summary>
    public class TitresViewModel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TitresViewModel"/>.
        /// </summary>
        public TitresViewModel()
        {
            this.Titres = new List<TitreViewModel>();
            this.TitresPlusChroniques = new List<TitreViewModel>();
            this.TitresPlusPopulaires = new List<TitreViewModel>();
        }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public List<TitreViewModel> Titres { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public List<TitreViewModel> TitresPlusChroniques { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public List<TitreViewModel> TitresPlusPopulaires { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int PageMax { get; set; }
    }
}
