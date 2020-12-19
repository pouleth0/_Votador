using AlterdataVotador.Models.Enums;
using System;
using System.Collections.Generic;

namespace AlterdataVotador.Models
{
    public class VotarHome
    {
        public int Id { get; set; }
        public DateTime DataVotar { get; set; }
        public ICollection<MelhoriasVotar> MelhoriasR { get; set; } = new List<MelhoriasVotar>();
        public MelhoriasCaceladas Status { get; set; }

        public VotarHome() { }

        public VotarHome(int id, DateTime dataVotar, MelhoriasCaceladas status)
        {
            Id = id;
            DataVotar = dataVotar;
            Status = status;
        }
    }
}
