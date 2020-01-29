using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        // metodo Insertar
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante, string serie,
            string correlativo, decimal igv, DataTable dtDetalles)//en el parametro DataTable dtDetalle
                                                                                 //recibimos todos los parametros
        {
            DVenta Obj = new DVenta();
            //Obj.Idingreso = idingreso;
            Obj.Idcliente = idcliente;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            // en una lista metemos todos los detalles del DataTable dtDetalles
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)//creamos un objeto DataRow de dtDetalles y recorremos todas las filas y le metemos en row
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["Iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles); //devolvemos el objeto con todos los atributos
        }
        // metodo Anular que llama al metodo Eliminar de la clase DCategoria
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;
            return Obj.Eliminar(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DCategoria
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar(); //creamos una instancia directa a DCategoria y al metodo Mostrar
        }

        // metodo BuscarFecha
        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        //metodo mostrar_detalles
        public static DataTable MostrarDetalles(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        //metodo MostrarArticulo_Venta_Nombre
        
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }
        //metodo MostrarArticulo_Venta_Codigo
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);            
        }
        //este metodo es mio        
         public static DataTable Mostrar_Carga_Vista()
         {
             DVenta Obj = new DVenta();
             //Obj.TextoBuscar = textobuscar;             
             return new DVenta().Mostrar_Carga_Vista();
         }
    }
}
