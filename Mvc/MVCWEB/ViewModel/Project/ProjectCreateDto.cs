using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPi.ViewModel.Project
{
    public class ProjectCreateDto
    {
        [Required]
        [MaxLength(10)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Alias { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public int ClientId { get; set; }

    }
}
