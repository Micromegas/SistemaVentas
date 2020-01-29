using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        // metodo Insertar que llama al metodo Insertar de la clase DProveedor de la capa de datos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacieminto,
            string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacieminto;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;            
            return Obj.Insertar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Editar que llama al metodo Editar de la clase DCliente
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.IDcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Eliminar que llama al metodo Eliminar de la clase DProveedor
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.IDcliente = idcliente;
            return Obj.Eliminar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DProveedor
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar(); //creamos una instancia directa a DProveedor y al metodo Mostrar
        }

        // metodo BuscarApellido que llama al metodo BuscarApellido de la clase DProveedor
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj); //retornamos todo el objeto Obj
        }

        // metodo BuscarApellido que llama al metodo BuscarApellido de la clase DProveedor
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj); //retornamos todo el objeto Obj
        }
    }
}
