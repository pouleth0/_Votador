using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterdataVotador.Models
{
    public class UsuariosAcess
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string TimeZoneUSuario { get; set; }
        public string PassWord { get; set; }

        public string Email { get; set; }

        public string DatNass { get; set; }
        public ModulosVotar Modulos { get; set; }
        public int ModulosVotarId { get; set; }

        public UsuariosAcess()
        {

        }

        public UsuariosAcess(int id, string nomeUsuario, string timeZoneUSuario, string passWord)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            TimeZoneUSuario = timeZoneUSuario;
            PassWord = passWord;
        }
      
    }
}
