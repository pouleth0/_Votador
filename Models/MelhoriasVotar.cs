using System;
namespace AlterdataVotador.Models
{
    public class MelhoriasVotar
    {
        public int Id {get;set;}
        public string NomeModulo { get; set; }
        public ModulosVotar Modulo { get; set; }
        public string MelhoriaArea { get; set; }
        public string QuantVotos { get; set; }
        public string DetalheDaMemoria_Votar { get; set; }
        public string DataVotacao_Votar { get; set; }
        public Boolean TrueFalse_Votar { get; set; }
        public MelhoriasVotar()
        {
        }
        public MelhoriasVotar(int id, string nomeModulo, string melhoriaArea, string quantVotos, string detalheDaMemoria_Votar, string dataVotacao_Votar, bool trueFalse_Votar)
        {
            Id = id;
            NomeModulo = nomeModulo;
            MelhoriaArea = melhoriaArea;
            QuantVotos = quantVotos;
            DetalheDaMemoria_Votar = detalheDaMemoria_Votar;
            DataVotacao_Votar = dataVotacao_Votar;
            TrueFalse_Votar = trueFalse_Votar;
        }
    }
}
