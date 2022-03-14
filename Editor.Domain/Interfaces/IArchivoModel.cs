using System;
using System.Collections.Generic;
using System.Text;
using Editor.Domain.Interfaces;
using Editor.Domain.Entities;

namespace Editor.Domain.Interfaces
{
    public interface IArchivoModel:IModel<ArchivoTexto>
    {
        void Open(ArchivoTexto t, ref string s);
        void GuardarComo(ArchivoTexto t);
        void DoubleClick(ArchivoTexto t, ref string s);
    }
}
