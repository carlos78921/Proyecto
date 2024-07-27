using BibliotecaLib.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLib.Controladores.Seguridad
{
    public class Verificaciones
    {
        private BibliotecaDataSet dataset;
        private VerificacionesTableAdapter verificacionesTableAdapter;

        public Verificaciones()
        {
            dataset = new BibliotecaDataSet();
            verificacionesTableAdapter = new VerificacionesTableAdapter();
        }

        public void InsertarVerificacion(Verificacion verificacion)
        {
            verificacionesTableAdapter.Insert(verificacion.Codigo, verificacion.Descripcion, verificacion.Estado);
        }

        public void ActualizarVerificacion(Verificacion updateTo, Verificacion updatedFrom)
        {
            verificacionesTableAdapter.Update(updateTo.Descripcion, updateTo.Estado, updatedFrom.Codigo, updatedFrom.Descripcion, updatedFrom.Estado);
        }

        public void EliminarVerificacion(Verificacion verificacion)
        {
            verificacionesTableAdapter.Delete(verificacion.Codigo, verificacion.Descripcion, verificacion.Estado);
        }

        public List<Verificacion> ObtenerVerificaciones()
        {
            List<Verificacion> verificaciones = new List<Verificacion>();
            foreach (var verificacion in verificacionesTableAdapter.GetData())
            {
                verificaciones.Add(new Verificacion(verificacion.verificacion, verificacion.name, verificacion.status));
            }
            return verificaciones;
        }

        public Verificacion? ObtenerVerificacion(string codigo)
        {
            var verificacion = verificacionesTableAdapter.GetDataBy1(codigo).FirstOrDefault();
            if (verificacion == null)
            {
                return null;
            }
            return new Verificacion(verificacion.verificacion, verificacion.name, verificacion.status);
        }

        public List<Verificacion> ObtenerVerificacionesAsignadasARol(string codigoRol)
        {
            List<Verificacion> verificaciones = new List<Verificacion>();
            foreach (var verificacion in verificacionesTableAdapter.GetDataByAssignToRol(codigoRol))
            {
                verificaciones.Add(new Verificacion(verificacion.verificacion, verificacion.name, verificacion.status));
            }
            return verificaciones;
        }

        public List<Verificacion> ObtenerVerificacionesNoAsignadasARol(string codigoRol)
        {
            List<Verificacion> verificaciones = new List<Verificacion>();
            foreach (var verificacion in verificacionesTableAdapter.GetDataByNotAssignToRol(codigoRol))
            {
                verificaciones.Add(new Verificacion(verificacion.verificacion, verificacion.name, verificacion.status));
            }
            return verificaciones;
        }

    }
}
