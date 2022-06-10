// <copyright file="RechercheServices.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.Services
{
    using System.Linq;
    using Unity;
    using Webzine.Repositories.Contracts;
    using Webzine.Services.Base;
    using Webzine.Services.Contracts;
    using Webzine.ViewModels;

    /// <inheritdoc/>
    public class RechercheServices : BaseService, IRechercheServices
    {
        /// <summary>
        /// Obtient ou définit la dépendance à IArtisteRepository.
        /// </summary>
        [Dependency]
        public IArtisteRepository ArtisteRepository { get; set; }

        /// <summary>
        /// Obtient ou définit la dépendance à ITitreRepository.
        /// </summary>
        [Dependency]
        public ITitreRepository TitreRepository { get; set; }

        /// <inheritdoc />
        public ResearchViewModel GetResult(string mot)
        {
            var result = new ResearchViewModel();

            var titres = this.TitreRepository.Search(mot);
            var artistes = this.ArtisteRepository.Search(mot);

            result.ResearchString = mot;
            result.Titres = this.GetListOfTitlesIncludeArtist(titres.ToList(), this.ArtisteRepository);
            artistes.ToList().ForEach(a => result.Artistes.Add(new ArtisteViewModel(a)));

            return result;
        }
    }
}
