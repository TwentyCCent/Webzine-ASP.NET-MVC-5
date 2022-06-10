// <copyright file="TitreServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Unity;
    using Webzine.Entities;
    using Webzine.Repositories.Contracts;
    using Webzine.Services.Base;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;

    /// <inheritdoc />
    public class TitreServices : BaseService, ITitreServices
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

        private IQueryable<TitreViewModel> GetTitreViewModels(IQueryable<Titre> titres)
        {
            return titres.Select(titre => new TitreViewModel()
            {
                IdTitre = titre.IdTitre,
                Artiste = new ArtisteRefViewModel()
                {
                    IdArtiste = titre.IdArtiste,
                    Nom = titre.Artiste.Nom,
                },
                Libelle = titre.Libelle,
                Chronique = titre.Chronique,
                UrlJaquette = titre.UrlJaquette,
                UrlEcoute = titre.UrlEcoute,
                Lien = titre.Lien,
                DateCreation = titre.DateCreation,
                DateSortie = titre.DateSortie,
                Duree = titre.Duree,
                NbLectures = titre.NbLectures,
                NbLikes = titre.NbLikes,
            });
        }

        /// <inheritdoc />
        public List<TitreViewModel> GetTitres()
        {
            var titres = this.GetTitreViewModels(this.TitreRepository.FindAll()).ToList();

            return titres;
        }

        /// <inheritdoc />
        public List<TitreViewModel> GetTitresPopulaires()
        {
            var titres = this.GetTitreViewModels(this.TitreRepository.FindAll()).ToList()
                .OrderBy(t => t.NbLectures)
                .Take(3)
                .ToList();

            return titres;
        }

        /// <inheritdoc />
        public List<TitreViewModel> GetTitresWithPagination(int offset, int limit)
        {
            var titres = this.GetTitreViewModels(this.TitreRepository.FindTitres(offset, limit)).ToList();
            return titres;
        }

        /// <inheritdoc />
        public TitreViewModel GetTitre(int id)
        {
            var titre = new TitreViewModel(this.TitreRepository.Find(id));
            titre.Artiste = new ArtisteRefViewModel(this.ArtisteRepository.Find(titre.Artiste.IdArtiste));
            return titre;
        }

        /// <inheritdoc />
        public bool CreateTitre(TitreViewModel titre)
        {
            try
            {
                this.TitreRepository.Add(new Titre
                {
                    Libelle = titre.Libelle,
                    IdArtiste = titre.Artiste.IdArtiste,
                    Lien = titre.Lien,
                    UrlEcoute = titre.UrlEcoute,
                    UrlJaquette = titre.UrlJaquette,
                    Chronique = titre.Chronique,
                    Duree = titre.Duree,
                    DateSortie = titre.DateSortie,
                    DateCreation = DateTime.Now,
                    NbLectures = 0,
                    NbLikes = 0,
                });
                this.TitreRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <inheritdoc />
        public bool UpdateTitre(TitreViewModel titre)
        {
            try
            {
                this.TitreRepository.Update(new Titre
                {
                    IdTitre = titre.IdTitre,
                    Libelle = titre.Libelle,
                    IdArtiste = titre.Artiste.IdArtiste,
                    Lien = titre.Lien,
                    UrlEcoute = titre.UrlEcoute,
                    UrlJaquette = titre.UrlJaquette,
                    Chronique = titre.Chronique,
                    Duree = titre.Duree,
                    DateSortie = titre.DateSortie,
                    DateCreation = DateTime.Now,
                    NbLectures = titre.NbLectures,
                    NbLikes = titre.NbLikes,
                });
                this.TitreRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <inheritdoc />
        public bool DeleteTitre(int id)
        {
            try
            {
                this.TitreRepository.Delete(id);
                this.TitreRepository.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <inheritdoc />
        public int Count()
        {
            return this.TitreRepository.Count();
        }
    }
}
