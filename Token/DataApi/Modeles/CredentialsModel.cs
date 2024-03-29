﻿using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DataApi.Modeles
{
    public class CredentialsModel
    {
        [Required(ErrorMessage ="CustomerName cannot be null.")]
        public string? CustomerName { get; set; }

        public string? Password { get; set; }
        public string? Pin { get; set; }
    }
}
