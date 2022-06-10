// <copyright file="Global.asax.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Webzine.EntitiesContext;

    /// <summary>
    /// Classe de gestion du démarrage de l'application.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Méthode de démarrage.
        /// </summary>
        protected void Application_Start()
        {
            using (var db = new WebzineDbContext())
            {
                db.Database.Initialize(true);
            }

            AreaRegistration.RegisterAllAreas();

            UnityConfig.RegisterComponents();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
