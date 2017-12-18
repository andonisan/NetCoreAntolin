using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPi.Atributtes;

namespace WebAPi.ViewModel.Project
{
    public class ProjectCreateDto
    {
        [Required]
        [MaxLength(10)]
        [Custom]
        public string Code { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Alias { get; set; }

        [Required]
        [Compare("Name")]
        public int ClientId { get; set; }

    }
}
