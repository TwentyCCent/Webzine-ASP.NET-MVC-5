// <copyright file="TitreController.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin
{
    using System.Web.Mvc;
    using Unity;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;

    /// <summary>
    /// Controlleur de l'espace d'administration des titres.
    /// </summary>
    public class TitreController : Controller
    {
        private static SelectList choiceArtisteList;

        private TitresViewModel modelTitres;
        private TitreViewModel modelTitre;

        /// <summary>
        /// Obtient ou définit la dépendance à ITitreServices.
        /// </summary>
        [Dependency]
        public ITitreServices TitreServices { get; set; }

        /// <summary>
        /// Obtient ou définit la dépendance à ITitreServices.
        /// </summary>
        [Dependency]
        public IArtisteServices ArtisteServices { get; set; }

        /// <summary>
        /// GET: Admin/Titre.
        /// </summary>
        /// <returns>Vue Index.cshtml.</returns>
        public ActionResult Index()
        {
            this.modelTitres = new TitresViewModel
            {
                Titres = this.TitreServices.GetTitres(),
            };
            return this.View(this.modelTitres);
        }

        /// <summary>
        /// GET: Admin/Titre/Create.
        /// </summary>
        /// <returns>Vue Create.cshtml.</returns>
        public ActionResult Create()
        {
            this.modelTitre = new TitreViewModel();
            choiceArtisteList = this.modelTitre.SelectListArtistes = new SelectList(this.ArtisteServices.GetArtistes().Artistes, nameof(ArtisteViewModel.IdArtiste), nameof(ArtisteViewModel.Nom));
            return this.View(this.modelTitre);
        }

        /// <summary>
        /// POST: Admin/Titre/Create.
        /// </summary>
        /// <param name="model">Modèle d'un titre.</param>
        /// <returns>Vue Create.cshtml ou Index.cshtml.</returns>
        [HttpPost]
        public ActionResult Create(TitreViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this.TitreServices.CreateTitre(model);
                    return this.RedirectToAction("Index");
                }

                model.SelectListArtistes = choiceArtisteList;
                return this.View(model);
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// GET: Admin/Titre/Edit/5.
        /// </summary>
        /// <param name="id">Identifiant d'un titre.</param>
        /// <returns>Vue Edit.cshtml.</returns>
        public ActionResult Edit(int id)
        {
            this.modelTitre = this.TitreServices.GetTitre(id);
            return this.View(this.modelTitre);
        }

        /// <summary>
        /// POST: Admin/Titre/Edit/5.
        /// </summary>
        /// <param name="id">Identifiant d'un titre.</param>
        /// <param name="model">Modèle d'un titre.</param>
        /// <returns>Vue Edit.cshtml ou Index.cshtml.</returns>
        [HttpPost]
        public ActionResult Edit(int id, TitreViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this.TitreServices.UpdateTitre(model);
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
        /// GET: Admin/Titre/Delete/5.
        /// </summary>
        /// <param name="id">Identifiant d'un titre.</param>
        /// <returns>Vue Edit.cshtml ou Index.cshtml.</returns>
        public ActionResult Delete(int id)
        {
            this.modelTitre = this.TitreServices.GetTitre(id);
            return this.View(this.modelTitre);
        }

        /// <summary>
        /// POST: Admin/Titre/Delete/5.
        /// </summary>
        /// <param name="id">Identifiant d'un titre.</param>
        /// <param name="model">Modèle d'un titre.</param>
        /// <returns>Vue Delete.cshtml ou Index.cshtml.</returns>
        [HttpPost]
        public ActionResult Delete(int id, TitreViewModel model)
        {
            try
            {
                this.TitreServices.DeleteTitre(id);

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }
    }
}
