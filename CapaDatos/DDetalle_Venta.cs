using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_venta;
        private decimal _Descuento;

        public int Iddetalle_venta { get => _Iddetalle_venta; set => _Iddetalle_venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }

        //constructores
        public DDetalle_Venta()
        {

        }
        public DDetalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso,
            int cantidad, decimal precio_venta, decimal descuento)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_venta = precio_venta;
            this.Descuento = descuento;
        }
        //metodo insertar
        //el metodo recibe dos parametros por referencia, uno SqlConnection es la conexion DIngreso (asi no abrimos otra
        //y la segunada refencia es SqlTransaction  para recibir la transaccion asi se lleva a cabo de una sola vez
        public string Insertar(DDetalle_Venta Detalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            //la conexion la eliminamos porque ya estamos recibiendo la conexion por referencia "SqlCon"
            //SqlConnection SqlCon = new SqlConnection();//creamos una instancia a SqlConnection            
            try
            {
                // codigo para insertar a la BD
                //SqlCon.ConnectionString = Conexion.Cn; //nuestra conexion se llama SqlCon
                //SqlCon.Open();// abrimos la conexion

                // Comando para insertar a la BD, en la tabla hay 3 @idcategoria, @nombre, @descripcion
                SqlCommand SqlCmd = new SqlCommand(); //SqlCmd nuestro comando para insertar
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                //@Iddetalle_venta
                SqlParameter ParIiddetalle_Venta = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIiddetalle_Venta.ParameterName = "@iddetalle_venta";
                ParIiddetalle_Venta.SqlDbType = SqlDbType.Int;
                ParIiddetalle_Venta.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIiddetalle_Venta);//lo insertamos a la BD 
                //@Idventa
                SqlParameter ParIdVenta = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdVenta.ParameterName = "@idventa";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Detalle_Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdVenta);//lo insertamos a la BD
                //@iddetalle_Ingreso
                SqlParameter ParIiddetalle_Ingreso = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIiddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIiddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIiddetalle_Ingreso.Value = Detalle_Venta.Iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIiddetalle_Ingreso);//lo insertamos a la BD
                //@cantidad
                SqlParameter ParCantidad = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);//lo insertamos a la BD
                //@precio_venta
                SqlParameter ParPrecioVenta = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = Detalle_Venta.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecioVenta);//lo insertamos a la BD
                //@desuento
                SqlParameter ParDescuento = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_Venta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);//lo insertamos a la BD

                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro"; //condicional en una sola linea, el 1 equivale a True,
                                                                                           //si se ejecuto responde OK si no se ejecuto responde NO

            }
            catch (Exception ex)// por si hay error
            {
                rpta = ex.Message;//mensaje de error

            }
            return rpta; //regresa respuesta
        }

    }
}
