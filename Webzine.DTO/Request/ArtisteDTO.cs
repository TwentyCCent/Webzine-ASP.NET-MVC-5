// <copyright file="ArtisteDTO.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.DTO.Request
{
    using Newtonsoft.Json;

    /// <summary>
    /// Format artiste provenant de l'API Deezer.
    /// </summary>
    public class ArtisteDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("share")]
        public string Share { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("picture_small")]
        public string Picture_small { get; set; }

        [JsonProperty("picture_medium")]
        public string Picture_medium { get; set; }

        [JsonProperty("picture_big")]
        public string Picture_big { get; set; }

        [JsonProperty("picture_xl")]
        public string Picture_xl { get; set; }

        [JsonProperty("nb_album")]
        public int Nb_album { get; set; }

        [JsonProperty("nb_fan")]
        public int Nb_fan { get; set; }

        [JsonProperty("radio")]
        public bool Radio { get; set; }

        [JsonProperty("tracklist")]
        public string Tracklist { get; set; }
    }
}
