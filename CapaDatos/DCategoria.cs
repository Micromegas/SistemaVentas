using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private String _Descripcion;
        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        // Constructor vacio
        public DCategoria()
        {

        }
        // Constructor con parametros
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        //metodo insertar
        public string Insertar(DCategoria Categoria)
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
                SqlCmd.CommandText = "spinsertar_categoria";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdcategoria = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdcategoria);//lo insertamos a la BD
                //@nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParNombre);
                //@descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro"; //condicional en una sola linea, el 1 equivale a True,
                                                                                           //si se ejecuto responde OK si no se ejecuto responde NO

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

        // Metodo Editar
        public string Editar(DCategoria Categoria)
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
                SqlCmd.CommandText = "speditar_categoria";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdcategoria = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);//lo insertamos a la BD
                //@nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParNombre);
                //@descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizo el registro"; //condicional en una sola linea, el 1 equivale a True,
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

        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
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
                SqlCmd.CommandText = "speliminar_categoria";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdcategoria = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);//lo insertamos a la BD                               
                //ejecutamos el comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se elimino el registro"; //condicional en una sola linea, el 1 equivale a True,
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
            DataTable DtResultado = new DataTable("categoria");                        
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
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

        //Metodo BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar; //Categoria es una instancia de DCategoria ¡¡¡esta clase!!!
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

