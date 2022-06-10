// <copyright file="BaseService.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services.Base
{
    using System.Collections.Generic;
    using Webzine.Entities;
    using Webzine.Repositories.Contracts;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;

    /// <inheritdoc/>
    public class BaseService : IBaseServices
    {
        /// <inheritdoc/>
        public List<TitreViewModel> GetListOfTitlesIncludeArtist(List<Titre> titres, IArtisteRepository repository)
        {
            var titresVM = new List<TitreViewModel>();

            titres.ForEach(titre =>
            {
                var titreVM = new TitreViewModel(titre);
                titreVM.Artiste = new ArtisteRefViewModel(repository.Find(titreVM.Artiste.IdArtiste));
                titresVM.Add(titreVM);
            });

            return titresVM;
        }
    }
}
