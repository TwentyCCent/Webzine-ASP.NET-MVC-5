// <copyright file="RouteConfig.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Classe de gestion du routing hors area.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Méthode d'ajout des routes hors area dans "routes".
        /// </summary>
        /// <param name="routes">Collection de routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
