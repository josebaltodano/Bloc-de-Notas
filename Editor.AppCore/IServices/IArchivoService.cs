using Editor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Editor.AppCore.IServices
{
    public interface IArchivoService:IService<ArchivoTexto>
    {
        void Open(ArchivoTexto t, ref string s);
        void GuardarComo(ArchivoTexto t);
        void DoubleClick(ArchivoTexto t, ref string s);
    }
}
