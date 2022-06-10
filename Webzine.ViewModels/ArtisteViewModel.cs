// <copyright file="ArtisteViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Webzine.Entities;

    /// <summary>
    /// Classe de type viewmodel pour un artiste.
    /// </summary>
    public class ArtisteViewModel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteViewModel"/>.
        /// </summary>
        public ArtisteViewModel()
        {
            this.Titres = new List<TitreViewModel>();
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ArtisteViewModel"/>.
        /// </summary>
        /// <param name="artiste">Entité artiste en base de données.</param>
        public ArtisteViewModel(Artiste artiste)
            : this()
        {
            this.IdArtiste = artiste.IdArtiste;
            this.Biographie = artiste.Biographie;
            this.Nom = artiste.Nom;
            this.Image = artiste.Image;
        }

        // Si le viewmodel contient les mêmes propriètés que l'entité
        // public Artiste Artiste { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required(ErrorMessage = "Veuillez saisir un nom d'artiste.")]
        [MinLength(1, ErrorMessage = "Veuillez saisir le nom de l'artiste (de 1 à 50 caractères).")]
        [MaxLength(50, ErrorMessage = "Veuillez saisir le nom de l'artiste (de 1 à 50 caractères).")]
        [Display(Name = "Nom de l'artiste")]
        public string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public string Biographie { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public List<TitreViewModel> Titres { get; set; }
    }
}
