// <copyright file="Seeder.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.RequestApiDeezer
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Webzine.DTO.Request;
    using Webzine.Entities;
    using Webzine.RequestApiDeezer.Helper;

    /// <summary>
    /// Classe de requetage de l'API Deezer.
    /// </summary>
    public static class Seeder
    {
        private static readonly DataTransferHelper DataTransferHelper = new DataTransferHelper();

        /// <summary>
        /// Requête une liste de 100 artistes en base de données.
        /// </summary>
        /// <returns>A <see cref="Task"/> represente une opération asynchrone.</returns>
        public static async Task<IList<Artiste>> GetRandomArtiste()
        {
            Random rnd = new Random();
            IList<Artiste> artistes = new List<Artiste>();

            for (var i = 0; i < 100; i++)
            {
                int artistId = rnd.Next(1, 10000);
                string route = $"https://api.deezer.com/artist/{artistId}";
                ArtisteDTO artisteDto = await DataTransferHelper.SendAsync<ArtisteDTO>(route, HttpMethod.Get);
                Artiste artiste = new Artiste(artisteDto);
                if (artiste.Nom != null && !artiste.Nom.Contains("?"))
                {
                    artiste.Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
                    artistes.Add(artiste);
                }
            }

            return artistes;
        }

        /// <summary>
        /// Requête les titres des artistes passé en paramètre.
        /// </summary>
        /// <param name="artistes">Liste d'artistes.</param>
        /// <returns>Collection de titres.</returns>
        public static IList<Titre> GetTitresOfArtistes(List<Artiste> artistes)
        {
            IList<Titre> titres = new List<Titre>();
            HttpClient httpClient = new HttpClient();

            artistes.ForEach(a =>
            {
                string route = $"https://api.deezer.com/search?q={a.Nom}";

                var response = httpClient.GetAsync(route).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                dynamic titresDto = JsonConvert.DeserializeObject<dynamic>(json);

                foreach (var item in titresDto.data)
                {
                    if (a.Nom == Convert.ToString(item.artist.name))
                    {
                        Titre titre = new Titre
                        {
                            IdTitre = item.id,
                            Libelle = item.title,
                            Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Duree = item.duration,
                            Lien = item.link,
                            IdArtiste = a.IdArtiste,
                            UrlJaquette = item.album.cover_big,
                            UrlEcoute = item.preview,
                            DateCreation = DateTime.Now,
                            DateSortie = DateTime.Now,
                            NbLectures = 0,
                            NbLikes = 0,
                        };

                        titres.Add(titre);
                    }
                }
            });

            return titres;
        }
    }
}
