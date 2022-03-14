using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Windows.Forms;

namespace Editor.Domain.Interfaces
{
    public interface IModel<T>
    {
       // void Open(T t, ref string s);
        void Add(T t);
        void Delete(T t);
        void Create(T t);
    }
}
