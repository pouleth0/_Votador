using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterdataVotador.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public UsuariosAcess Usuarios { get; set; }
        public ICollection<ModulosVotar>  NameModulos { get; set; }

    }
}
