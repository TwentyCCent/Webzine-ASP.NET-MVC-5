// <copyright file="BundleConfig.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication
{
    using System.Web.Optimization;

    /// <summary>
    /// Enregistrement des bundles pour accès fichiers statiques via tag helpers.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Méthode d'ajout des fichiers statiques dans bundles.
        /// </summary>
        /// <param name="bundles">Collection de fichiers statiques.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/js/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-extra.css"));

            bundles.Add(new ScriptBundle("~/bundles/font-awesome").Include(
                "~/lib/font-awesome/js/all.js"));
        }
    }
}
