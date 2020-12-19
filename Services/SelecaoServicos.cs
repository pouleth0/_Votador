using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlterdataVotador.Data;
using AlterdataVotador.Models;

namespace AlterdataVotador.Services
{
    public class SelecaoServicos
    {
        private readonly AlterdataVotadorContext _context;

        public SelecaoServicos ( AlterdataVotadorContext context)
        {
            _context = context;
        }

        public List<MelhoriasVotar> FindAll()
        {
            return _context.MelhoriasVotar.ToList();
        }
        public void Insert(ModulosVotar obj)
        {
           // obj.Modulo = _context.ModulosVotar.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        internal void Insert(UsuariosAcess usuariosAcess)
        {
            throw new NotImplementedException();
        }
    }
}
