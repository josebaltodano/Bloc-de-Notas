using System;
using System.Collections.Generic;
using System.Text;
using Editor.AppCore.IServices;
using Editor.Domain.Entities;
using Editor.Domain.Interfaces;

namespace Editor.AppCore.Services
{
    public class BaseRepository<T> : IService<T>
    {
        private IModel<T> model;
        protected BaseRepository(IModel<T> modelo)
        {
            model = modelo;
        }
        public void Add(T t)
        {
            model.Add(t);
        }

        public void Create(T t)
        {
            model.Create(t);
        }

        public void Delete(T t)
        {
            model.Delete(t);
        }
    }
}
