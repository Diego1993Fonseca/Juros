using Juros.Domain.Intefaces.Business;
using Juros.Domain.Intefaces.Business.Extern;
using Juros.Domain.Model.DTO;
using System;

namespace Juros.Business.Services
{
    public class JurosService : IJurosServices
    {
        readonly ITaxaJurosService _TaxaJurosService;
        const double _taxa = 0.01;

        public JurosService(ITaxaJurosService TaxaJurosService) 
        {
            _TaxaJurosService = TaxaJurosService;
        }

        public double Calculajuros(decimal valorInicial, int meses )
        {
            var taxaJuros = _TaxaJurosService.getTaxaJuros().Result;

            if (taxaJuros == null) 
                return 0;

            return decimal.ToDouble(valorInicial) * Potencia(1 + taxaJuros.taxa, meses);
        }

        public double Potencia(double valor, int potencia)
        {
            var result = valor;
            potencia--;

            while (potencia > 0) 
            {
                result = result * valor;
                potencia--;
            }

            return result;
        }
    }
}
