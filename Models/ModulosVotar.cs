using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterdataVotador.Models
{
    public class ModulosVotar
    {
        public int Id { get; set; }
        public string NameModulos { get; set; }
        public string LinhaDoModulo {get; set; }

        public ModulosVotar()
        {
        }

        public ModulosVotar(int id, string nameModulos, string linhaDoModulo)
        {
            Id = id;
            NameModulos = nameModulos;
            LinhaDoModulo = linhaDoModulo;
        }
    }
}
