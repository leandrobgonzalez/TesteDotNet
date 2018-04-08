using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.Core.Models
{
    public class ItemModel
    {
        public int? Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string DataItem { get; set; }
    }
}
