using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        // metodo Insertar
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie,
            string correlativo, decimal igv, string estado, DataTable dtDetalles)//en el parametro DataTable dtDetalle
            //recibimos todos los parametros
        {
            DIngreso Obj = new DIngreso();
            //Obj.Idingreso = idingreso;
            Obj.Idtrabajador = idtrabajador;
            Obj.IdProveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            // en una lista metemos todos los detalles del DataTable dtDetalles
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)//creamos un objeto DataRow de dtDetalles y recorremos todas las filas y le metemos en row
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles); //devolvemos el objeto con todos los atributos
        }
        // metodo Anular que llama al metodo Eliminar de la clase DCategoria
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj); //devolvemos el objeto con todos los atributos
        }

        // metodo Mostrar que llama al metodo Mostrar de la clase DCategoria
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar(); //creamos una instancia directa a DCategoria y al metodo Mostrar
        }

        // metodo BuscarFecha
        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();        
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        //metodo mostrar_detalles
        public static DataTable MostrarDetalles(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
