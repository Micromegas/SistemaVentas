using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        // metodo Insertar que llama al metodo Insertar de la clase DCategoria de la capa de datos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Editar que llama al metodo Editar de la clase DCategoria
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Eliminar que llama al metodo Eliminar de la clase DCategoria
        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DCategoria
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar(); //creamos una instancia directa a DCategoria y al metodo Mostrar
        }

        // metodo BuscarNombre que llama al metodo BuscarNombre de la clase DCategoria
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj); //retornamos todo el objeto Obj
        }

    }
}
