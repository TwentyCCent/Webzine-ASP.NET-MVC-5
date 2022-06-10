// <copyright file="FilterConfig.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication
{
    using System.Web;
    using System.Web.Mvc;
    using Webzine.WebApplication.Filters;

    /// <summary>
    /// Classe de gestion des filtres intergiciel.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Méthode d'ajout des filtres dans la collection filters.
        /// </summary>
        /// <param name="filters">Collection de filtre intergiciel.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValidateModelStateAttribute());
            filters.Add(new LoggerActionFilter());
        }
    }
}
