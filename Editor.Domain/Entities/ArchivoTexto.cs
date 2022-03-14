using System;
using System.Collections.Generic;
using System.Text;
using Editor.Domain.Entities;

namespace Editor.Domain.Entities
{
    public class ArchivoTexto:Carpeta
    {
        public string Texto { get; set; }
    }
}
