using Juros.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juros.Domain.Intefaces.Business.Extern
{
    public interface ITaxaJurosService
    {
        ValueTask<JurosDTO> getTaxaJuros();
    }
}
