using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Editor.AppCore.IServices;
using Editor.AppCore.Services;
using Editor.Domain.Interfaces;
using Editor.Infraestructura.Repository;


namespace BlocdeNotas
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StreamArchivoRepository>().As<IArchivoModel>();
            builder.RegisterType<ArchivoService>().As<IArchivoService>();
            builder.RegisterType<StreamCarpetaRepository>().As<ICarpetaModel>();
            builder.RegisterType<CarpetaService>().As<ICarpetaService>();
            var container = builder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBloc(container.Resolve<IArchivoService>(),container.Resolve<ICarpetaService>()));
            /*var builder = new ContainerBuilder();
            builder.RegisterType<StreamActivoRepository>().As<IActivoModel>();
            builder.RegisterType<ActivoServices>().As<IActivoServices>();*/
            //Application.Run(new Form1(container.Resolve<IActivoServices>()));
        }
    }
}
