// <copyright file="ResearchViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels
{
    using System.Collections.Generic;
    using Webzine.ViewModels.Base;

    /// <summary>
    /// Classe de type viewmodel pour une recherche dan sla barre prévue à cette effet.
    /// </summary>
    public class ResearchViewModel : BaseViewModel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ResearchViewModel"/>.
        /// </summary>
        public ResearchViewModel()
        {
            this.Titres = new List<TitreViewModel>();
            this.Artistes = new List<ArtisteViewModel>();
        }

        /// <summary>
        /// Obtient ou définit la chaine de caractères recherché.
        /// </summary>
        public string ResearchString { get; set; }

        /// <summary>
        /// Obtient ou définit la liste de titres correspondant à la recherche.
        /// </summary>
        public List<TitreViewModel> Titres { get; set; }

        /// <summary>
        /// Obtient ou définit la liste d'artistes correspondant à la recherche.
        /// </summary>
        public List<ArtisteViewModel> Artistes { get; set; }
    }
}
