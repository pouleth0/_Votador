using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterdataVotador.Models
{
    public class UsuarioVota
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Id_MelhoriaVotada { get; set; }
        public string TimeZone { get; set; }
        public UsuarioVota()
        {

        }

        public UsuarioVota(int id, string nomeUsuario, string id_MelhoriaVotada, string timeZone)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            Id_MelhoriaVotada = id_MelhoriaVotada;
            TimeZone = timeZone;
        }
    }
}
