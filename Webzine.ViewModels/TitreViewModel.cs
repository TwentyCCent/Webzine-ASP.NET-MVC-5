// <copyright file="TitreViewModel.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Webzine.Entities;

    /// <summary>
    /// .
    /// </summary>
    public class TitreViewModel
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TitreViewModel"/>.
        /// </summary>
        public TitreViewModel()
        {
            this.Artiste = new ArtisteRefViewModel();
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TitreViewModel"/>.
        /// </summary>
        /// <param name="titre">à partir d'un objet de type Titre.</param>
        public TitreViewModel(Titre titre)
            : this()
        {
            this.IdTitre = titre.IdTitre;
            this.Artiste.IdArtiste = titre.IdArtiste;
            this.Libelle = titre.Libelle;
            this.Chronique = titre.Chronique;
            this.UrlJaquette = titre.UrlJaquette;
            this.UrlEcoute = titre.UrlEcoute;
            this.Lien = titre.Lien;
            this.DateCreation = titre.DateCreation;
            this.Duree = titre.Duree;
            this.NbLectures = titre.NbLectures;
            this.NbLikes = titre.NbLikes;
        }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int IdTitre { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public ArtisteRefViewModel Artiste { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required(ErrorMessage = "Veuillez saisir un libellé pour votre titre (de 1 à 200 caractères).")]
        [MinLength(1, ErrorMessage = "Veuillez saisir un libellé pour votre titre (de 1 à 200 caractères).")]
        [MaxLength(200, ErrorMessage = "Veuillez saisir un libellé pour votre titre (de 1 à 200 caractères).")]
        public string Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public string Lien { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required(ErrorMessage = "Veuillez saisir votre chronique (de 10 à 4000 caractères).")]
        [MinLength(10, ErrorMessage = "Veuillez saisir votre chronique (de 10 à 4000 caractères).")]
        [MaxLength(4000, ErrorMessage = "Veuillez saisir votre chronique (de 10 à 4000 caractères).")]
        public string Chronique { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required(ErrorMessage = "Veuillez saisir un lien pour la jaquette de votre titre.")]
        [MaxLength(250, ErrorMessage = "Maximum 250 caractères")]
        public string UrlJaquette { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [MinLength(13, ErrorMessage = "Minimum 13 caractères pour l'url d'écoute")]
        [MaxLength(250, ErrorMessage = "Maximum 250 caractères pour l'url d'écoute")]
        public string UrlEcoute { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required(ErrorMessage = "Veuillez sélectioner une date de sortie pour votre titre.")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez sélectioner une date de sortie pour votre titre.")]
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        [Required(ErrorMessage = "Entrez la durée de votre titre en secondes.")]
        public int Duree { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int NbLectures { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public int NbLikes { get; set; }

        /// <summary>
        /// Obtient ou définit .
        /// </summary>
        public SelectList SelectListArtistes { get; set; }
    }
}
