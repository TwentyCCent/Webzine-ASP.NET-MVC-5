// <copyright file="adminAreaRegistration.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Areas.Admin
{
    using System.Web.Mvc;

    /// <summary>
    /// Classe de gestion du routing de l'area Admin.
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        /// <inheritdoc/>
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        /// <inheritdoc/>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}