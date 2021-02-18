using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int ISBN { get; set; }
        public int IdCliente { get; set; }
        public string FechaPedido { get; set; }
    }
}
