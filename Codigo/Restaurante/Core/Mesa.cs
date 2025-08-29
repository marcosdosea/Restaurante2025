using System;
using System.Collections.Generic;

namespace Core;

public partial class Mesa
{
    public int Id { get; set; }

    public string Identificacao { get; set; } = null!;

    public uint IdRestaurante { get; set; }

    public virtual ICollection<Atendimento> Atendimentos { get; set; } = new List<Atendimento>();

    public virtual Restaurante IdRestauranteNavigation { get; set; } = null!;
    public int Numero { get; set; }
    public int Capacidade { get; set; }
}
