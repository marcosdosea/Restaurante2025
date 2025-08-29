using System.Collections.Generic;
using Core;

namespace RestauranteWeb.Models
{
    public class FuncionarioModel
    {
        public Funcionario Funcionario { get; set; }
        public IEnumerable<Tipofuncionario> TiposFuncionario { get; set; }
    }
}
