using Editor.Domain.Entities;
using Editor.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Editor.Infraestructura.Repository
{
    public class StreamArchivoRepository : IArchivoModel
    {
        private string ruta1 = "";
        public StreamArchivoRepository()
        {

        }
        StreamWriter streamWriter;
        StreamReader mylectura;
        public void Add(ArchivoTexto t)
        {
            try
            {

                if (ruta1 != string.Empty && ruta1 != null)
                {
                    using (FileStream fileStream = new FileStream(ruta1, FileMode.Truncate, FileAccess.Write))
                    {
                        streamWriter = new StreamWriter(fileStream);
                        streamWriter.Write(t.Texto);
                        streamWriter.Close();
                    }
                }

            }
            catch (IOException)
            {
                return;
            }
        }
        /*StreamWriter StreamWriter;
        public void OverWrite(ArchivoTexto t)
        {
            using (FileStream file=new FileStream(ruta1,FileMode.Append,FileAccess.Write))
            {
                StreamWriter = new StreamWriter(file);
                StreamWriter.Write(t.Texto);
                StreamWriter.Close();
                file.Close();
            }
        }*/
        public void Create(ArchivoTexto t)
        {
            using (FileStream fileStream = new FileStream(t.Ruta, FileMode.Append, FileAccess.Write))
            {
                streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(t.Texto);
                streamWriter.Close();
                ruta1 = t.Ruta;
            }
        }

        public void Delete(ArchivoTexto t)
        {
            File.Delete(t.Ruta);
            if (ruta1 == t.Ruta)
            {
                ruta1 = "";
            }
        }

        public void DoubleClick(ArchivoTexto t, ref string s)
        {
            try
            {
                StreamReader mylectura = null;
                using (FileStream fileStream = new FileStream(t.Ruta, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    mylectura = File.OpenText(t.Ruta);
                    ruta1 = t.Ruta;
                    s = mylectura.ReadToEnd();
                }
            }
            catch (IOException)
            {
                return;
            }
        }

        public void GuardarComo(ArchivoTexto t)
        {
            try
            {
                using (FileStream fileStream = new FileStream(t.Ruta, FileMode.Append, FileAccess.Write))
                {
                    streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(t.Texto);
                    ruta1 = t.Ruta;
                    streamWriter.Close();
                }
            }
            catch (IOException)
            {
                return;
            }
        }

        public void Open(ArchivoTexto t,ref string s)
        {
            try
            {
                using (FileStream fileStream = new FileStream(t.Ruta, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    ruta1 = t.Ruta;
                    mylectura = File.OpenText(t.Ruta);
                    s = mylectura.ReadToEnd();
                }
            }
            catch (IOException)
            {
                return;
            }
        }
    }
}
