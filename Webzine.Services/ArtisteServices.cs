// <copyright file="ArtisteServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services
{
    using System;
    using System.Linq;
    using Unity;
    using Webzine.Entities;
    using Webzine.Repositories.Contracts;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;

    /// <inheritdoc/>
    public class ArtisteServices : IArtisteServices
    {
        /// <summary>
        /// Obtient ou définit la dépendance à IArtisteRepository.
        /// </summary>
        [Dependency]
        public IArtisteRepository ArtisteRepository { get; set; }

        /// <summary>
        /// Obtient ou définit la dépendance à ITitreRepository.
        /// </summary>
        [Dependency]
        public ITitreRepository TitreRepository { get; set; }

        /// <inheritdoc/>
        public ArtistesViewModel GetArtistes()
        {
            var model = new ArtistesViewModel
            {
                Artistes = this.ArtisteRepository.FindAll()
                .Where(a => a.Biographie != null)
                .OrderBy(a => a.Nom)
                .Select(artiste => new ArtisteViewModel()
                {
                    IdArtiste = artiste.IdArtiste,
                    Nom = artiste.Nom,
                    Biographie = artiste.Biographie,
                })
                .ToList(),
            };
            return model;
        }

        /// <inheritdoc/>
        public SidebarViewModel GetArtistesForSidebar()
        {
            var model = new SidebarViewModel
            {
                ArtistesRefs = this.ArtisteRepository.FindAll()
                .Where(a => a.Biographie != null)
                .OrderBy(a => a.Nom)
                .Select(artiste => new ArtisteRefViewModel()
                {
                    IdArtiste = artiste.IdArtiste,
                    Nom = artiste.Nom,
                })
                .ToList(),
            };
            return model;
        }

        /// <inheritdoc/>
        public ArtisteViewModel GetArtiste(int id)
        {
            var model = new ArtisteViewModel(this.ArtisteRepository.Find(id))
            {
                Titres = this.TitreRepository.GetTitresByArtiste(id)
                .Select(titre => new TitreViewModel()
                {
                    IdTitre = titre.IdTitre,
                    Libelle = titre.Libelle,
                })
                .ToList(),
            };
            return model;
        }

        /// <inheritdoc/>
        public bool CreateArtiste(ArtisteViewModel artiste)
        {
            try
            {
                this.ArtisteRepository.Add(new Artiste
                {
                    Nom = artiste.Nom,
                    Biographie = artiste.Biographie,
                    Image = artiste.Image,
                });
                this.ArtisteRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateArtiste(ArtisteViewModel artiste)
        {
            try
            {
                this.ArtisteRepository.Update(new Artiste
                {
                    IdArtiste = artiste.IdArtiste,
                    Nom = artiste.Nom,
                    Biographie = artiste.Biographie,
                    Image = artiste.Image,
                });
                this.ArtisteRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteArtiste(int id)
        {
            try
            {
                this.ArtisteRepository.Delete(id);
                this.ArtisteRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
