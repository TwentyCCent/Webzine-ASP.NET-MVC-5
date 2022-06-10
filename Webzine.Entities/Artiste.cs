// <copyright file="Artiste.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Webzine.DTO.Request;

    /// <summary>
    /// Classe définnissant une entité Artiste.
    /// </summary>
    public class Artiste
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Artiste"/>.
        /// </summary>
        public Artiste()
        {
            this.Titres = new List<Titre>();
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Artiste"/>.
        /// </summary>
        /// <param name="artiste">Objet provenant de l'API Deezer.</param>
        public Artiste(ArtisteDTO artiste)
            : this()
        {
            this.IdArtiste = Convert.ToInt32(artiste.Id);
            this.Nom = artiste.Name;
            this.Image = artiste.Picture_small;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'artiste.
        /// </summary>
        [Key]
        public int IdArtiste { get; set; }

        /// <summary>
        /// Obtient ou définit nom de l'artiste.
        /// </summary>
        [Required]
        public string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit biographie de l'artiste.
        /// </summary>
        public string Biographie { get; set; }

        /// <summary>
        /// Obtient ou définit image de l'artiste.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Obtient ou définit liste des Titres créés par l'artiste.
        /// </summary>
        public ICollection<Titre> Titres { get; set; }
    }
}
