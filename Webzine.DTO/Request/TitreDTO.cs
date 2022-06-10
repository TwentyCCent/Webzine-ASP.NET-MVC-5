// <copyright file="TitreDTO.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.DTO.Request
{
    using Newtonsoft.Json;

    /// <summary>
    /// Format titre provenant de l'API Deezer.
    /// </summary>
    public class TitreDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_short")]
        public string Title_short { get; set; }

        [JsonProperty("title_version")]
        public string Title_version { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("md5_image")]
        public string Md5_image { get; set; }

        [JsonProperty("artist")]
        public ArtisteDTO Artist { get; set; }

        public string Cover_big { get; set; }
    }
}
