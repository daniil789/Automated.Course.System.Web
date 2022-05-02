using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class ExternalLoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string ReturnUrl { get; set; }
    }
}
