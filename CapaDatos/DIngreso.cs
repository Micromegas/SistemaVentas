using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _IdProveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie,
            string correlativo, decimal igv, string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.IdProveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }

        //Metodo Insertar
        //recibe un parametro mas del tipo "Lista", el primero es "Ingreso", haciendo una instancia al objeto DDetalle_Ingreso "Detalle" en
        //donde recibe en esa lista a todos los detalles del ingreso
        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
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
                SqlCmd.CommandText = "spinsertar_ingreso";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                //@idingreso
                SqlParameter ParIdingreso = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdingreso);//lo insertamos a la BD
                //@idtrabajador
                SqlParameter ParIdtrabajador = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Ingreso.Idtrabajador;
                //ParIdtrabajador.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdtrabajador);//lo insertamos a la BD
                //@idproveedor
                SqlParameter ParIdproveedor = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Ingreso.IdProveedor;
                //ParIdproveedor.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdproveedor);//lo insertamos a la BD
                //@fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParFecha);
                //@tipo_comprobante
                SqlParameter ParTipo_Comprobante = new SqlParameter();
                ParTipo_Comprobante.ParameterName = "@tipo_comprobante";
                ParTipo_Comprobante.SqlDbType = SqlDbType.VarChar;
                ParTipo_Comprobante.Size = 20;
                ParTipo_Comprobante.Value = Ingreso.Tipo_Comprobante; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParTipo_Comprobante);
                //@serie
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Value = Ingreso.Serie;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParSerie);
                //@correlativo
                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParCorrelativo);
                //@igv
                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParIgv);
                //@estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParEstado);

                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro"; //condicional en una sola linea, el 1 equivale a True,
                       //si se ejecuto responde OK si no se ejecuto responde NO
                       //aca tenemos que armar para la tabla detalle ingreso
                if (rpta.Equals("OK"))
                {
                    //obtenemos el codigo de ingreso generado
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);//obtenemos el idingreso y lo almacenamos en Idingreso
                    //vamos a recorrer la lista que se recibe como parametro "List<DDetalle_Ingreso> Detalle"
                    //para ir insertandolo en la BD 
                    foreach(DDetalle_Ingreso det in Detalle)//en el foreach recorremos uno a uno "Detalle" almacenandolo
                    // en el objeto "det" que es de la clase "DDetalle"
                    {
                        det.Idingreso = this.Idingreso; //el primer "Idingreso es el que recien generamos arriba en el foreach                        
                        //y va a ser igual al "@Idingreso" que devolvio arriba en el convert
                        //llamamos al metodo insertar de la clase DDetalle_Ingreso que recibe varios parametros por referencia
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        //vamos a verificar que la respuesta haya sido OK, recorda que en la clase DDetalle_Ingreso
                        //devuelve la respuesta si fue OK o NO la insercion a la BD
                        if (!rpta.Equals("OK"))//la negamos, osea, si la respuesta no fue "OK"
                        {
                            break; //salimos del bucle foreach
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
        //Metodo Anular
        public string Anular(DIngreso Ingreso)
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
                SqlCmd.CommandText = "spanular_ingreso";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdingreso = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);//lo insertamos a la BD                               
                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se anulo el registro"; //condicional en una sola linea, el 1 equivale a True,
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

        //Metodo Mostrar 
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
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
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_ingreso";
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
    }
}
