// <copyright file="Titre.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Webzine.DTO.Request;

    /// <summary>
    /// Classe définnissant une entité Titre.
    /// </summary>
    public class Titre
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Titre"/>.
        /// </summary>
        public Titre()
        {
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Titre"/>.
        /// </summary>
        /// <param name="titre">Objet provenant de l'API Deezer.</param>
        public Titre(TitreDTO titre)
            : this()
        {
            this.IdTitre = titre.Id;
            this.IdArtiste = Convert.ToInt32(titre.Artist.Id);
            this.Artiste = new Artiste(titre.Artist);
            this.Libelle = titre.Title;
            this.Lien = titre.Link;
            this.UrlJaquette = titre.Cover_big;
            this.UrlEcoute = titre.Preview;
            this.DateCreation = DateTime.Now;
            this.DateSortie = DateTime.Now;
            this.Duree = titre.Duration;
            this.NbLectures = 0;
            this.NbLikes = 0;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du Titre.
        /// </summary>
        [Key]
        public int IdTitre { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'artiste rattaché Titre.
        /// </summary>
        [Required]
        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit artiste ayant créé le Titre.
        /// </summary>
        public Artiste Artiste { get; set; }

        /// <summary>
        /// Obtient ou définit libellé/Nom du Titre.
        /// </summary>
        [Required]
        public string Libelle { get; set; }

        /// <summary>
        /// Obtient ou définit lien vers Deezer.
        /// </summary>
        public string Lien { get; set; }

        /// <summary>
        /// Obtient ou définit chronique liée au Titre.
        /// </summary>
        public string Chronique { get; set; }

        /// <summary>
        /// Obtient ou définit Url de la Jaquette de l'Album lié au Titre.
        /// </summary>
        [Required]
        public string UrlJaquette { get; set; }

        /// <summary>
        /// Obtient ou définit lien pour écouter au Titre.
        /// </summary>
        public string UrlEcoute { get; set; }

        /// <summary>
        /// Obtient ou définit date de création de la chronique du Titre.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Obtient ou définit date de la sortie du Titre.
        /// </summary>
        [Required]
        public DateTime DateSortie { get; set; }

        /// <summary>
        /// Obtient ou définit durée du titre. En Secondes.
        /// </summary>
        [Required]
        public int Duree { get; set; }

        /// <summary>
        /// Obtient ou définit nombre de Lectures de la chronique du Titre.
        /// </summary>
        public int NbLectures { get; set; }

        /// <summary>
        /// Obtient ou définit nombre de Likes du titre.
        /// </summary>
        public int NbLikes { get; set; }
    }
}
