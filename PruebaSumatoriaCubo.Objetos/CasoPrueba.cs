using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSumatoriaCubo.Objetos
{
    public class CasoPrueba
    {
        public CasoPrueba()
        {
            this.Operaciones = new List<string>();
        }
        public int N { get; set; }
        public int M { get; set; }

        public List<string> Operaciones { get; set; }
    }
}
