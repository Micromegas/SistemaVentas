using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DArticulo
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        public DArticulo()
        {

        }
        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen,
            int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
        }
        //Metodo Insertar
        public string Insertar(DArticulo Articulo)
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
                SqlCmd.CommandText = "spinsertar_articulo";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdarticulo = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdarticulo);//lo insertamos a la BD
                //@codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParCodigo);                
                //@nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParNombre);
                //@descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParDescripcion);
                //Imagen
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParImagen);
                //idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Articulo.Idcategoria; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParIdcategoria);
                //idpresentacion
                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Articulo.Idpresentacion; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParIdpresentacion);

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
        public string Editar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speditar_articulo";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdarticulo = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);//lo insertamos a la BD
                //@codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Value = Articulo.Codigo; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParCodigo);
                //@nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParNombre);
                //@descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParDescripcion);
                //Imagen
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParImagen);
                //idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Articulo.Idcategoria; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParIdcategoria);
                //idpresentacion
                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Articulo.Idpresentacion; // recordar, Categoria es una instancia de la clase DCategoria - Nombre hace referencia al metodo Get
                SqlCmd.Parameters.Add(ParIdpresentacion);


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
        public string Eliminar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speliminar_articulo";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdarticulo = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);//lo insertamos a la BD                               
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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar; 
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
        //Metodo MostrarStock  
        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
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
