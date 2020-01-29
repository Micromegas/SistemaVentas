using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador
    {
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        //Propiedades
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public DTrabajador()
        {

        }
        public DTrabajador(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password,
            string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;
        }

        //Metodos
        //Metodos para la BD
        //metodo insertar
        public string Insertar(DTrabajador Trabajador)
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
                SqlCmd.CommandText = "spinsertar_trabajador";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdtrabajador = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Direction = ParameterDirection.Output;  //es autoicremental
                SqlCmd.Parameters.Add(ParIdtrabajador);//lo insertamos a la BD

                //@Parnombre
                SqlParameter Parnombre = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Trabajador.Nombre;
                SqlCmd.Parameters.Add(Parnombre);//lo insertamos a la BD

                //@apellido
                SqlParameter Parapellidos = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parapellidos.ParameterName = "@apellidos";
                Parapellidos.SqlDbType = SqlDbType.VarChar;
                Parapellidos.Size = 40;
                Parapellidos.Value = Trabajador.Apellidos;
                SqlCmd.Parameters.Add(Parapellidos);//lo insertamos a la BD

                //@sexo
                SqlParameter Parsexo = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parsexo.ParameterName = "@sexo";
                Parsexo.SqlDbType = SqlDbType.VarChar;
                Parsexo.Size = 1;
                Parsexo.Value = Trabajador.Sexo;
                SqlCmd.Parameters.Add(Parsexo);//lo insertamos a la BD

                //fecha_nacimiento
                SqlParameter Parfecha_nacimiento = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parfecha_nacimiento.ParameterName = "@fecha_nacimiento";
                Parfecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                Parfecha_nacimiento.Size = 50;
                Parfecha_nacimiento.Value = Trabajador.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(Parfecha_nacimiento);//lo insertamos a la BD                

                //num_documento
                SqlParameter ParNum_Documento = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Trabajador.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);//lo insertamos a la BD

                //direccion
                SqlParameter ParDireccion = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);//lo insertamos a la BD

                //telefono
                SqlParameter ParTelefono = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Trabajador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);//lo insertamos a la BD

                //email
                SqlParameter ParEmail = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                SqlCmd.Parameters.Add(ParEmail);//lo insertamos a la BD

                //acceso
                SqlParameter ParAcceso = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Trabajador.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);//lo insertamos a la BD

                //usuario
                SqlParameter ParUsuario = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);//lo insertamos a la BD

                //password
                SqlParameter ParPassword = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);//lo insertamos a la BD

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
        public string Editar(DTrabajador Trabajador)
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
                SqlCmd.CommandText = "speditar_trabajador";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdcliente = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdcliente.ParameterName = "@idtrabajador";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdcliente);//lo insertamos a la BD

                //@Parnombre
                SqlParameter Parnombre = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Trabajador.Nombre;
                SqlCmd.Parameters.Add(Parnombre);//lo insertamos a la BD

                //@apellido
                SqlParameter Parapellidos = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parapellidos.ParameterName = "@apellidos";
                Parapellidos.SqlDbType = SqlDbType.VarChar;
                Parapellidos.Size = 40;
                Parapellidos.Value = Trabajador.Apellidos;
                SqlCmd.Parameters.Add(Parapellidos);//lo insertamos a la BD

                //@sexo
                SqlParameter Parsexo = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parsexo.ParameterName = "@sexo";
                Parsexo.SqlDbType = SqlDbType.VarChar;
                Parsexo.Size = 1;
                Parsexo.Value = Trabajador.Sexo;
                SqlCmd.Parameters.Add(Parsexo);//lo insertamos a la BD

                //fecha_nacimiento
                SqlParameter Parfecha_nacimiento = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                Parfecha_nacimiento.ParameterName = "@fecha_nacimiento";
                Parfecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                Parfecha_nacimiento.Size = 50;
                Parfecha_nacimiento.Value = Trabajador.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(Parfecha_nacimiento);//lo insertamos a la BD                

                //num_documento
                SqlParameter ParNum_Documento = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Trabajador.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);//lo insertamos a la BD

                //direccion
                SqlParameter ParDireccion = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);//lo insertamos a la BD

                //telefono
                SqlParameter ParTelefono = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Trabajador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);//lo insertamos a la BD

                //email
                SqlParameter ParEmail = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                SqlCmd.Parameters.Add(ParEmail);//lo insertamos a la BD

                //acceso
                SqlParameter ParAcceso = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Trabajador.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);//lo insertamos a la BD

                //usuario
                SqlParameter ParUsuario = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);//lo insertamos a la BD

                //password
                SqlParameter ParPassword = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);//lo insertamos a la BD

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
        public string Eliminar(DTrabajador Trabajador)
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
                SqlCmd.CommandText = "speliminar_trabajador";//Que tipo de comando es? store procedure
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //declaramos los parametros que va a recibir el store procedure
                SqlParameter ParIdtrabajador = new SqlParameter(); //instanciamos para tener nuestra objeto ParIdcategoria
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);//lo insertamos a la BD                               
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
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_trabajador";
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

        //Metodo Buscar Apellido
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_apellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar; //Categoria es una instancia de DCategoria ¡¡¡esta clase!!!
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
        //Metodo Numero Documento
        public DataTable BuscarNum_Documento(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar; //Categoria es una instancia de DCategoria ¡¡¡esta clase!!!
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

        //Metodo Login
        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario; //Categoria es una instancia de DCategoria ¡¡¡esta clase!!!
                SqlCmd.Parameters.Add(ParUsuario);
                //password
                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajador.Password; //Categoria es una instancia de DCategoria ¡¡¡esta clase!!!
                SqlCmd.Parameters.Add(ParPassword);

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
