using Juros.Domain.Model.DTO;

namespace Juros.Domain.Intefaces.Business
{
    public interface IJurosServices
    {
        double Calculajuros(decimal valorInicial, int meses);
    }
}
