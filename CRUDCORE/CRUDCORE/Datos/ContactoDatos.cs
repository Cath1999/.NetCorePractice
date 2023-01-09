
using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using CRUDCORE.Controllers.Models;

//esta clase permite conectarse a todos los procedimientos almacenados creados en la base de datos
namespace CRUDCORE.Datos
{


    public class ContactoDatos
    {
        //--------------------Metodos----------------------------------//
        public List<ContactoModel> Listar()
        {

            var oLista = new List<ContactoModel>();

            //instacia de la clase conexion
            var cn = new Conexion();


            //establece la cadena de conexion
            //retorna la cadena de sql
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //se abre la conexion
                conexion.Open();

                //estructura de los comandos a ejecutar

                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);

                //se indica que es de store procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //se lee el resultado de la ejecucion del procedimiento
                using (var dr = cmd.ExecuteReader())
                {

                    /*Dentro del bloque using, el objeto es de solo lectura y no se puede modificar 
                     * ni reasignar. Una variable declarada con una declaración using es de solo 
                     * lectura.*/
                    while (dr.Read())
                    {

                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }
        //--------------------------Obtener---------------------------//
        public ContactoModel Obtener( int IdContacto)
        {

            var oContacto = new ContactoModel();

            //instacia de la clase conexion
            var cn = new Conexion();


            //establece la cadena de conexion
            //retorna la cadena de sql
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //se abre la conexion
                conexion.Open();

                //estructura de los comandos a ejecutar

                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);

                //se indica que es de store procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //se lee el resultado de la ejecucion del procedimiento
                using (var dr = cmd.ExecuteReader())
                {

                    /*Dentro del bloque using, el objeto es de solo lectura y no se puede modificar 
                     * ni reasignar. Una variable declarada con una declaración using es de solo 
                     * lectura.*/
                    while (dr.Read())
                    {

                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();

                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {

            }
            catch
            {

            }



            return rpta;
        }




    }
}

