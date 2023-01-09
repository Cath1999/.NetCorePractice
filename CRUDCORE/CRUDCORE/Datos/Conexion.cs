
using System.Data.SqlClient;
namespace CRUDCORE.Datos
{

    public class Conexion
    {


        //declaracion de variable -- cadena vacia por default
       private string cadenaSQL = string.Empty;


        //creo que el constructor debe llmarse del mismo nombre de la clase
        public Conexion() {

            // var permite crear cualquier tipo de variable, no es necesario especificar de que tipo es
            

            //esto es para obtener la cadena de conexion que esta en appsettings
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        
            cadenaSQL =  builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        //Metodo que devuelve la cadena
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }




    }
}
