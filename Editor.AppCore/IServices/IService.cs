using System;
using System.Collections.Generic;
using System.Text;

namespace Editor.AppCore.IServices
{
    public interface IService<T>
    {
       // void Open(T t,ref string s);
        void Add(T t);
        void Delete(T t);
        void Create(T t);
    }
}
