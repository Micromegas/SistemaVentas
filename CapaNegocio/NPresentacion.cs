using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NPresentacion
    {
        // metodo Insertar que llama al metodo Insertar de la clase DPresentacion de la capa de datos
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Editar que llama al metodo Editar de la clase DPresentacion
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Eliminar que llama al metodo Eliminar de la clase DPresentacion
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            return Obj.Eliminar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DPresentacion
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar(); //creamos una instancia directa a DPresentacion y al metodo Mostrar
        }

        // metodo BuscarNombre que llama al metodo BuscarNombre de la clase DPresentacion
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj); //retornamos todo el objeto Obj
        }
    }
}
