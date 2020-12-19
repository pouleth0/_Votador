using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlterdataVotador.Models;

namespace AlterdataVotador.Data
{
    public class SeedingService
    {
        private AlterdataVotadorContext _context;

        public SeedingService(AlterdataVotadorContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.MelhoriasVotar.Any() || 
                _context.ModulosVotar.Any() || 
                _context.UsuarioVotar.Any() || 
                _context.UsuariosAcess.Any())
            {
                //Console.WriteLine("Banco de dados já possue Tabelas, e Dados.");
                return;//Bando de dados com Dados, não pode ser populado.
            }

            MelhoriasVotar d1 = new MelhoriasVotar(1, "FISCAL","Gerar guia ICMS com COD barra do Estado","","Esta melhoria ira gerar todas Guias de ICMS, estaduais com COD Barra","00/00/0000", false);
            MelhoriasVotar d2 = new MelhoriasVotar(2, "FISCAL", "Gerar guia DARF COM COD barra do Estado", "", "Esta melhoria ira gerar todas Guias de DARF, estaduais com COD Barra", "00/00/0000", false);
            
            ModulosVotar c1 = new ModulosVotar(1, "FISCAL", "PACK");
            ModulosVotar c2 = new ModulosVotar(2, "CONTÁBIL", "PACK");
            ModulosVotar c3 = new ModulosVotar(3, "DEPARTAMENTO PESSOAL", "PACK");
            ModulosVotar c4 = new ModulosVotar(4, "WINSS (INSS)", "PACK");
            ModulosVotar c5 = new ModulosVotar(5, "ATIVO", "PACK");
            ModulosVotar c6 = new ModulosVotar(6, "CIAPE", "PACK");
            ModulosVotar c7 = new ModulosVotar(7, "FINANCEIRO", "PACK");

            UsuariosAcess u1 = new UsuariosAcess(1,"Alterdata", "3:00", "#abc123#");
            UsuariosAcess u2 = new UsuariosAcess(2, "SUPERVISOR", "3:00", "#abc123#");

        }
    }
}
