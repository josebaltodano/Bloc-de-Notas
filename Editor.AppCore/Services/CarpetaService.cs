using System;
using System.Collections.Generic;
using System.Text;
using Editor.AppCore.IServices;
using Editor.Domain.Entities;
using Editor.Domain.Interfaces;

namespace Editor.AppCore.Services
{
    public class CarpetaService : BaseRepository<Carpeta>, ICarpetaService
    {
        ICarpetaModel Carpeta;
        public CarpetaService(ICarpetaModel carpetaModel) : base(carpetaModel)
        {
            Carpeta = carpetaModel;
        }
    }
}
