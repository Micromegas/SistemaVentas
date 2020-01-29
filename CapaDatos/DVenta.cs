using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        //private string _TextoBuscar;

        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }

        //constructores
        public DVenta()
        {

        }

        public DVenta(int idventa, int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante, string serie,
            string correlativo, decimal igv)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
        }

        //metodos
        public string DisminuirStock(int iddetalle_ingreso, int cantidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();//creamos una instancia a SqlConnection
            try
            {
                // codigo para insertar a la BD
                SqlCon.ConnectionString = Conexion.Cn; //nuestra conexion se llama SqlCon
                SqlCon.Open();// abrimos la conexion

                // Comando para insertar a la BD, en la tabla hay 3 @idcategoria, @nombre, @descripcion
                SqlCommand SqlCmd = new SqlCommand(); //SqlCmd nuestro comando para insertar
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdisminuir_stock";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                //@iddetalle_ingreso
                SqlParameter ParIddetalle_Ingreso = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Value = iddetalle_ingreso;//no lo recibimos de un objeto, sino del parametro del metodo arriba
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);//lo insertamos a la BD
                //@cantidad
                SqlParameter ParCantidad = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;//no lo recibimos de un objeto, sino del parametro del metodo arriba
                SqlCmd.Parameters.Add(ParCantidad);//lo insertamos a la BD
                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizo el stock"; //condicional en una sola linea, el 1 equivale a True,
                                                                                         //si se ejecuto responde OK si no se ejecuto responde NO

            }
            catch (Exception ex)// por si hay error
            {
                rpta = ex.Message;//mensaje de error

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close(); //si esta abierta la conexion que la cierre
                //SqlCon.Close();
            }
            return rpta; //regresa respuesta
        }

        //metodo insertar venta
        //Metodo Insertar
        //recibe un parametro mas del tipo "Lista", el primero es "Ingreso", haciendo una instancia al objeto DDetalle_Ingreso "Detalle" en
        //donde recibe en esa lista a todos los detalles del ingreso
        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();//creamos una instancia a SqlConnection            
            try
            {
                // codigo para insertar a la BD
                SqlCon.ConnectionString = Conexion.Cn; //nuestra conexion se llama SqlCon
                SqlCon.Open();// abrimos la conexion
                //establecemos una transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();//

                // Comando para insertar a la BD, en la tabla hay 3 @idcategoria, @nombre, @descripcion
                SqlCommand SqlCmd = new SqlCommand(); //SqlCmd nuestro comando para insertar
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                //@idventa
                SqlParameter ParIdventa = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdventa);//lo insertamos a la BD
                //@idcliente
                SqlParameter ParIdCliente = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);//lo insertamos a la BD
                //@idtrabajador
                SqlParameter ParIdtrabajador = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Venta.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);//lo insertamos a la BD                                
                //@fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParFecha);
                //@tipo_comprobante
                SqlParameter ParTipo_Comprobante = new SqlParameter();
                ParTipo_Comprobante.ParameterName = "@tipo_comprobante";
                ParTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_Comprobante.Size = 20;
                ParTipo_Comprobante.Value = Venta.Tipo_Comprobante; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParTipo_Comprobante);
                //@serie
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Value = Venta.Serie;
                ParSerie.Size = 4;
                ParSerie.Value = Venta.Serie; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParSerie);
                //@correlativo
                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Venta.Correlativo; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParCorrelativo);
                //@igv
                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Venta.Igv; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParIgv);               

                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro"; //condicional en una sola linea, el 1 equivale a True,
                                                                                           //si se ejecuto responde OK si no se ejecuto responde NO
                                                                                           //aca tenemos que armar para la tabla detalle ingreso
                if (rpta.Equals("OK"))
                {
                    //obtenemos el codigo de ingreso generado
                    this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);//obtenemos el idingreso y lo almacenamos en Idingreso
                    //vamos a recorrer la lista que se recibe como parametro "List<DDetalle_Ingreso> Detalle"
                    //para ir insertandolo en la BD 
                    foreach (DDetalle_Venta det in Detalle)//en el foreach recorremos uno a uno "Detalle" almacenandolo
                    // en el objeto "det" que es de la clase "DDetalle"
                    {
                        det.Idventa = this.Idventa; //el primer "Idingreso es el que recien generamos arriba en el foreach                        
                        //y va a ser igual al "@Idingreso" que devolvio arriba en el convert
                        //llamamos al metodo insertar de la clase DDetalle_Ingreso que recibe varios parametros por referencia
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        //vamos a verificar que la respuesta haya sido OK, recorda que en la clase DDetalle_Venta
                        //devuelve la respuesta si fue OK o NO la insercion a la BD
                        if (!rpta.Equals("OK"))//la negamos, osea, si la respuesta no fue "OK"
                        {
                            break; //salimos del bucle foreach
                        }
                        else //si la respuesta fue ok, se inserto a la BD
                        {
                            //actualizamos el stock
                            rpta = DisminuirStock(det.Iddetalle_ingreso, det.Cantidad);//llamamos al metodo Disminuir_Stock
                            if (!rpta.Equals("OK"))//si la respuesta es distinta a OK
                            {
                                break;//salimos del foreach
                            }
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();//confirmamos la transaccion
                }
                else
                {
                    SqlTra.Rollback();//vamos para atras con la transaccion
                }

            }
            catch (Exception ex)// por si hay error
            {
                rpta = ex.Message;//mensaje de error

            }
            finally
            { //si esta abierta la conexion que la cierre
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta; //regresa respuesta
        }

        //metodo eliminar venta
        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();//creamos una instancia a SqlConnection
            try
            {
                // codigo para insertar a la BD
                SqlCon.ConnectionString = Conexion.Cn; //nuestra conexion se llama SqlCon
                SqlCon.Open();// abrimos la conexion

                // Comando para insertar a la BD, en la tabla hay 3 @idcategoria, @nombre, @descripcion
                SqlCommand SqlCmd = new SqlCommand(); //SqlCmd nuestro comando para insertar
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spelininar_venta";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdventa = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);//lo insertamos a la BD                               
                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK"; //al haber un trigger se va a ejecutar si o si la transaccion

            }
            catch (Exception ex)// por si hay error
            {
                rpta = ex.Message;//mensaje de error

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close(); //si esta abierta la conexion que la cierre
                //SqlCon.Close();
            }
            return rpta; //regresa respuesta
        }

        //Metodo Mostrar 
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo BuscarFechas
        public DataTable BuscarFechas(string textobuscar, string TextoBuscar2)//va a recibir estos dos parametros desde la CapaNegocio
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_venta_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
                ParTextoBuscar2.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo MostrarDetalle
        public DataTable MostrarDetalle(string textobuscar)//va a recibir estos un parametro desde la CapaNegocio
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //Metodo mostrar articulos por su nombre        
        //public DataTable MostrarArticulo_Venta_Nombre(DVenta Venta)
        public DataTable MostrarArticulo_Venta_Nombre(string TextoBuscar)//va a recibir estos un parametro desde la CapaNegocio
        {
            DataTable DtResultado = new DataTable("articulos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscararticulo_venta_nombre";                
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //Metodo mostrar articulos por su codigo      
        public DataTable MostrarArticulo_Venta_Codigo(string TextoBuscar)//va a recibir estos un parametro desde la CapaNegocio
        {
            DataTable DtResultado = new DataTable("articulos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscararticulo_venta_codigo";                
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //este metodo es mio, es para mostrar todos los articulos 
        //Metodo Mostrar 
         public DataTable Mostrar_Carga_Vista()
         {
             DataTable DtResultado = new DataTable("articulo");
             SqlConnection SqlCon = new SqlConnection();
             try
             {
                 SqlCon.ConnectionString = Conexion.Cn;
                 SqlCommand SqlCmd = new SqlCommand();
                 SqlCmd.Connection = SqlCon;
                 SqlCmd.CommandText = "spmostrar_articulo_venta";
                 SqlCmd.CommandType = CommandType.StoredProcedure;
                 SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                 SqlDat.Fill(DtResultado);
             }
             catch (Exception ex)
             {
                 DtResultado = null;
             }
             return DtResultado;
         }

    }
}
