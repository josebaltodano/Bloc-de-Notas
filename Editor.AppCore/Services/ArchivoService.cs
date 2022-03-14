using System;
using System.Collections.Generic;
using System.Text;
using Editor.AppCore.IServices;
using Editor.Domain.Entities;
using Editor.Domain.Interfaces;

namespace Editor.AppCore.Services
{
    public class ArchivoService : BaseRepository<ArchivoTexto>, IArchivoService
    {
        IArchivoModel archivoModel;
        public ArchivoService(IArchivoModel archivo): base(archivo)
        {
            archivoModel = archivo;
        }

        public void DoubleClick(ArchivoTexto t, ref string s)
        {
            archivoModel.DoubleClick(t, ref s);
        }

        public void GuardarComo(ArchivoTexto t)
        {
            archivoModel.GuardarComo(t);
        }

        public void Open(ArchivoTexto t, ref string s)
        {
            archivoModel.Open(t,ref s);
        }
    }
}
