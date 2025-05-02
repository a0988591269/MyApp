using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class PlayerWithCharactersDto : PlayerDto
    {
        public IEnumerable<CharacterDto> Characters { get; set; }
    }
}
