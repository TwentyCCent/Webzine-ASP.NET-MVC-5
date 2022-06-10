// <copyright file="UnityConfig.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication
{
    using System.Web.Mvc;
    using Unity;
    using Unity.Mvc5;
    using Webzine.Repositories;
    using Webzine.Repositories.Contracts;
    using Webzine.Services;
    using Webzine.Services.Base;
    using Webzine.Services.Contracts;

    /// <summary>
    /// Configuration de la librairie Unity pour la gestion de l'injection de dépendances.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Enregistrement des composants de dépendances.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Enregistrements de tous les composants dans le conteneur
            container.RegisterType<IArtisteRepository, ArtisteRepository>();
            container.RegisterType<ITitreRepository, TitreRepository>();

            container.RegisterType<IArtisteServices, ArtisteServices>();
            container.RegisterType<ITitreServices, TitreServices>();
            container.RegisterType<IRechercheServices, RechercheServices>();
            container.RegisterType<IBaseServices, BaseService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}