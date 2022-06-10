// <copyright file="HomeController.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Controllers
{
    using System;
    using System.Web.Mvc;
    using Unity;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;

    /// <summary>
    /// Controlleur de l'espace d'accueil du site.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly TitresViewModel modelPage = new TitresViewModel();
        private ArtisteViewModel modelArtiste;
        private TitreViewModel modelTitre;
        private ResearchViewModel modelResearch;
        private SidebarViewModel modelSidebar;

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
        /// Obtient ou définit la dépendance à ITitreServices.
        /// </summary>
        [Dependency]
        public IRechercheServices RechercheServices { get; set; }

        /// <summary>
        /// Rendu de la liste d'artiste dans la sidebar.
        /// </summary>
        /// <returns>Vue partiel _Sidebar.cshtml.</returns>
        [ChildActionOnly]
        public ActionResult RenderSidebar()
        {
            this.modelSidebar = this.ArtisteServices.GetArtistesForSidebar();
            return this.PartialView("_Sidebar", this.modelSidebar);
        }

        /// <summary>
        /// GET "/" ou "/?pageNumber=1".
        /// </summary>
        /// <param name="pageNumber">Numéro de page.</param>
        /// <returns>Vue Index.cshtml.</returns>
        public ActionResult Index(int pageNumber = 1)
        {
            var nbCardChronic = 3;
            this.modelPage.Page = pageNumber;
            this.modelPage.PageMax = (int)Math.Floor((double)(this.TitreServices.Count() - 1) / nbCardChronic) + 1;
            this.modelPage.TitresPlusChroniques = this.TitreServices.GetTitresWithPagination((pageNumber - 1) * nbCardChronic, nbCardChronic);
            this.modelPage.TitresPlusPopulaires = this.TitreServices.GetTitresPopulaires();

            return this.View(this.modelPage);
        }

        /// <summary>
        /// GET "/Artiste/5".
        /// </summary>
        /// <param name="id">Identifiant de l'artiste.</param>
        /// <returns>Vue Artiste.cshtml.</returns>
        public ActionResult Artiste(int id)
        {
            this.modelArtiste = this.ArtisteServices.GetArtiste(id);
            return this.View(this.modelArtiste);
        }

        /// <summary>
        /// GET "/Titre/5".
        /// </summary>
        /// <param name="id">Identifiant du titre.</param>
        /// <returns>Vue Titre.cshtml.</returns>
        public ActionResult Titre(int id)
        {
            this.modelTitre = this.TitreServices.GetTitre(id);
            return this.View(this.modelTitre);
        }

        /// <summary>
        /// GET "/Recherche".
        /// </summary>
        /// <returns>Vue Recherche.cshtml.</returns>
        [HttpPost]
        public ActionResult Recherche()
        {
            var research = this.Request.Form["research"].ToString();
            this.modelResearch = this.RechercheServices.GetResult(research);
            return this.View(this.modelResearch);
        }

        /// <summary>
        /// GET "/Contact".
        /// </summary>
        /// <returns>Vue Contact.cshtml.</returns>
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Page de contact.";

            return this.View();
        }
    }
}