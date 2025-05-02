using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class PlayerForUpdateDto
    {
        [Required(ErrorMessage = "帳號類型不能為空")]
        [StringLength(10, ErrorMessage = "帳號類型不能大於10")]
        public string AccountType { get; set; }
    }
}
