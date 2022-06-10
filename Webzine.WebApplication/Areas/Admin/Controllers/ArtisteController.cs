// <copyright file="ArtisteController.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin
{
    using System.Web.Mvc;
    using Unity;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;
    using Webzine.WebApplication.Filters;

    /// <summary>
    /// Controlleur de l'espace d'administration des artistes.
    /// </summary>
    public class ArtisteController : Controller
    {
        /// <summary>
        /// .
        /// </summary>
        private ArtistesViewModel modelAdminArtistes;

        /// <summary>
        /// .
        /// </summary>
        private ArtisteViewModel modelArtiste;

        /// <summary>
        /// Obtient ou définit la dépendance à ITitreServices.
        /// </summary>
        [Dependency]
        public IArtisteServices ArtisteServices { get; set; }

        /// <summary>
        /// GET: Admin/Artiste.
        /// </summary>
        /// <returns>Vue Index.cshtml.</returns>
        public ActionResult Index()
        {
            this.modelAdminArtistes = this.ArtisteServices.GetArtistes();
            return this.View(this.modelAdminArtistes);
        }

        /// <summary>
        /// GET: Admin/Artiste/Create.
        /// </summary>
        /// <returns>Vue Create.cshtml.</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// POST: Admin/Artiste/Create.
        /// </summary>
        /// <param name="model">Modèle d'un artiste.</param>
        /// <returns>Vue Create.cshtml ou Index.cshtml.</returns>
        [HttpPost]
        [ValidateModelState]
        public ActionResult Create(ArtisteViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this.ArtisteServices.CreateArtiste(model);
                    return this.RedirectToAction("Index");
                }

                return this.View(model);
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// GET: Admin/Artiste/Edit/5.
        /// </summary>
        /// <param name="id">Identifiant d'un artiste.</param>
        /// <returns>Vue Edit.cshtml.</returns>
        public ActionResult Edit(int id)
        {
            this.modelArtiste = this.ArtisteServices.GetArtiste(id);
            return this.View(this.modelArtiste);
        }

        /// <summary>
        /// POST: Admin/Artiste/Edit/5.
        /// </summary>
        /// <param name="id">Identifiant d'un artiste.</param>
        /// <param name="model">Modèle d'un artiste.</param>
        /// <returns>Vue Edit.cshtml ou Index.cshtml.</returns>
        [HttpPost]
        public ActionResult Edit(int id, ArtisteViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this.ArtisteServices.UpdateArtiste(model);
                    return this.RedirectToAction("Index");
                }

                return this.View(model);
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// GET: Admin/Artiste/Delete/5.
        /// </summary>
        /// <param name="id">Identifiant d'un artiste.</param>
        /// <returns>Vue Edit.cshtml ou Index.cshtml.</returns>
        public ActionResult Delete(int id)
        {
            this.modelArtiste = this.ArtisteServices.GetArtiste(id);
            return this.View(this.modelArtiste);
        }

        /// <summary>
        /// POST: Admin/Artiste/Delete/5.
        /// </summary>
        /// <param name="id">Identifiant d'un artiste.</param>
        /// <param name="model">Modèle d'un artiste.</param>
        /// <returns>Vue Delete.cshtml ou Index.cshtml.</returns>
        [HttpPost]
        public ActionResult Delete(int id, ArtisteViewModel model)
        {
            try
            {
                this.ArtisteServices.DeleteArtiste(id);

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }
    }
}
