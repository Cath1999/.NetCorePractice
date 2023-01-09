using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using APICore.Controllers.models;
using Microsoft.AspNetCore.Cors;

namespace APICore.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        //llamada del servidor a travez del controlador

        private readonly string cadenaSQL;
        
        //constructor del controlador
        public ProductoController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQl");

        }

        //paquete que permite poder utilizar todas las clases y elementos para conectarse a la bd a traves de sql

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_productos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(rd["IdProducto"]),
                                CodigoBarra = rd["CodigoBarra"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Marca = rd["Marca"].ToString(),
                                Categoria = rd["Categoria"].ToString(),
                                Precio = Convert.ToDecimal(rd["Precio"])
                            

                            });
                        }
                    }

                }

                return StatusCode(StatusCodes.Status200OK, new{
                    mensaje = "ok",
                    response = lista

                });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = error.Message,
                    response = lista

                });

            }
        }

        //------------------------------------------------------------------------------//

        [HttpGet]
        [Route("Obtener/{idProducto:int}")]
        public IActionResult Obtener(int IdProducto)
        {
            List<Producto> lista = new List<Producto>();
            Producto producto = new Producto();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_productos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(rd["IdProducto"]),
                                CodigoBarra = rd["CodigoBarra"].ToString(),
                                Nombre = rd["Nombre"].ToString(),
                                Marca = rd["Marca"].ToString(),
                                Categoria = rd["Categoria"].ToString(),
                                Precio = Convert.ToDecimal(rd["Precio"])


                            });
                        }
                    }

                }

                producto = lista.Where(item => IdProducto == IdProducto).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ok",
                    response = producto

                });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = error.Message,
                    response = producto

                });

            }
        }


        //--------------------------------------------------------------------------//

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody]Producto objeto)
        {
          
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_guardar_producto", conexion);
                    cmd.Parameters.AddWithValue("codigoBarra", objeto.CodigoBarra);
                    cmd.Parameters.AddWithValue("nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("marca", objeto.Marca);
                    cmd.Parameters.AddWithValue("categoria", objeto.Categoria);
                    cmd.Parameters.AddWithValue("precio", objeto.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }


                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "ok"
                  

                });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = error.Message
                 

                });

            }
        }
        //--------------------------------------------------------------------------//

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Producto objeto)
        {

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_editar_producto", conexion);
                    cmd.Parameters.AddWithValue("idproducto", objeto.IdProducto == 0 ? DBNull.Value : objeto.IdProducto);
                    cmd.Parameters.AddWithValue("codigoBarra", objeto.CodigoBarra  is null ? DBNull.Value : objeto.CodigoBarra);
                    cmd.Parameters.AddWithValue("nombre", objeto.Nombre is null ? DBNull.Value : objeto.Nombre);
                    cmd.Parameters.AddWithValue("marca", objeto.Marca is null ? DBNull.Value : objeto.Marca);
                    cmd.Parameters.AddWithValue("categoria", objeto.Categoria is null ? DBNull.Value : objeto.Categoria);
                    cmd.Parameters.AddWithValue("precio", objeto.Precio  == 0  ? DBNull.Value : objeto.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }


                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "editado"


                });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = error.Message


                });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{idProducto:int}")]
        public IActionResult Eliminar(int idProducto)
        {

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_eliminar_producto", conexion);
                    cmd.Parameters.AddWithValue("idproducto", idProducto );
                       cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }


                return StatusCode(StatusCodes.Status200OK, new
                {
                    mensaje = "eliminado"


                });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = error.Message


                });

            }
        }


    }
}
