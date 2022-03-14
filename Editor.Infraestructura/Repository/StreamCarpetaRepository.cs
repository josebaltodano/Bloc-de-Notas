using System;
using System.Collections.Generic;
using System.Text;
using Editor.Domain.Entities;
using Editor.Domain.Interfaces;
using System.IO;
using System.Windows.Forms;
//using BlocdeNotas.Forms;

namespace Editor.Infraestructura.Repository
{
    public class StreamCarpetaRepository : ICarpetaModel
    {
        private string ruta1="";
        public StreamCarpetaRepository()
        {

        }
        public void Add(Carpeta t)
        {
            if (t.Nombre == string.Empty)
            {
                return;
            }
            Directory.CreateDirectory(t.Ruta);
        }

        public void Create(Carpeta t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Carpeta t)
        {
            try
            {
                Directory.Delete(t.Ruta);
            }
            catch (IOException)
            {
                return;
            }
        }

    }
}
