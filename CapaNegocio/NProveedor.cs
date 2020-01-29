using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NProveedor
    {
        // metodo Insertar que llama al metodo Insertar de la clase DProveedor de la capa de datos
        public static string Insertar(string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento, string direccion,
            string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Insertar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Editar que llama al metodo Editar de la clase DProveedor
        public static string Editar(int idproveedor, string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento, string direccion,
            string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Eliminar que llama al metodo Eliminar de la clase DProveedor
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DProveedor
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar(); //creamos una instancia directa a DProveedor y al metodo Mostrar
        }

        // metodo BuscarRazon_Social que llama al metodo BuscarRazon_Social de la clase DProveedor
        public static DataTable BuscarRazon_Social(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj); //retornamos todo el objeto Obj
        }

        // metodo BuscarRazon_Social que llama al metodo BuscarRazon_Social de la clase DProveedor
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj); //retornamos todo el objeto Obj
        }
    }
}
