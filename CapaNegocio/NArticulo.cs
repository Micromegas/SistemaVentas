﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        // metodo Insertar que llama al metodo Insertar de la clase DArticulo de la capa de datos
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Insertar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Editar que llama al metodo Editar de la clase DArticulo
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion,
            byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Editar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Eliminar que llama al metodo Eliminar de la clase DArticulo
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DArticulo
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar(); //creamos una instancia directa a DPresentacion y al metodo Mostrar
        }

        // metodo BuscarNombre que llama al metodo BuscarNombre de la clase DArticulo
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj); //retornamos todo el objeto Obj
        }
        // metodo Mostrar Stock que llama al metodo Mostrar de la clase DArticulo
        public static DataTable Stock_Articulos()
        {
            return new DArticulo().Stock_Articulos(); //creamos una instancia directa a DPresentacion y al metodo Mostrar
        }
    }
}
