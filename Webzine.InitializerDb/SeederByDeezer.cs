namespace Webzine.InitializerDb
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Webzine.DAL.EntitiesContext;
    using Webzine.DTO.Request;
    using Webzine.Entities;
    using Webzine.InitializerDb.Helper;

    public class SeederByDeezer<T, ArtisteDbSet, TitreDbSet> : DropCreateDatabaseAlways<DbContext> 
        where T : DbContext
        where ArtisteDbSet : DbSet<Artiste>
        where TitreDbSet : DbSet<Titre>
    {
        private readonly DataTransferHelper dataTransferHelper = new DataTransferHelper();



        /// <inheritdoc/>
        protected override void Seed(DbContext context)
        {
            var task = this.GetRandomArtiste();
            task.Wait();
            var taskTitle = this.GetRandomTitre();
            taskTitle.Wait();

            base.Seed(context);
        }

        /// <summary>
        /// Enregistre une liste de 100 artistes en base de données.
        /// </summary>
        /// <param name="context">DbContext.</param>
        private async Task GetRandomArtiste()
        {
            Random rnd = new Random();
            List<Artiste> artistes = new List<Artiste>();

            for (var i = 0; i < 100; i++)
            {
                int artistId = rnd.Next(1, 10000);
                string route = $"https://api.deezer.com/artist/{artistId}";
                ArtisteDTO artisteDto = await this.dataTransferHelper.SendAsync<ArtisteDTO>(route, HttpMethod.Get);
                Artiste artiste = new Artiste(artisteDto);
                if (artiste.Nom != null && !artiste.Nom.Contains("?"))
                {
                    artiste.Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
                    artistes.Add(artiste);
                }
            }

            using (var context = new T())
            {
                context.ArtisteDbSet.AddRange(artistes);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Enregistre une liste de 100 artistes en base de données.
        /// </summary>
        /// <param name="context">DbContext.</param>
        private Task GetRandomTitre()
        {
            List<Artiste> artistes;
            using (var context = new WebzineDbContext())
            {
                artistes = context.Artistes.ToList();
            }

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

            using (var context = new T())
            {
                context.Titres.AddRange(titres);
                context.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}

