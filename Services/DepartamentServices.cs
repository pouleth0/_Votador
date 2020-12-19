using AlterdataVotador.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlterdataVotador.Models;

namespace AlterdataVotador.Services
{
    public class DepartamentServices
    {
        private readonly AlterdataVotadorContext _context;

        public DepartamentServices(AlterdataVotadorContext context)
        {
            _context = context;
        }
        public List<ModulosVotar> FindAll()
        {
            return _context.ModulosVotar.OrderBy(x => x.NameModulos).ToList();
        }
    }
}
