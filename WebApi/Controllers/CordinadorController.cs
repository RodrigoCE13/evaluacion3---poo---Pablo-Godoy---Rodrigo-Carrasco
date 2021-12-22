using OtecLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CordinadorController : ApiController
    {

        [HttpGet]
        [Route("crud/cordinadores")]
        public respuesta listar(string nom = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<cordinador> listado = new List<cordinador>();
                cordinadorEntity cordinadorData = new cordinadorEntity();
                DataSet data = nom == "" ? cordinadorData.listCordinadores() : cordinadorData.buscarCordinador(nom);

                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    cordinador item = new cordinador();
                    item.id = int.Parse(data.Tables[0].Rows[i].ItemArray[0].ToString());
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    listado.Add(item);
                }
                
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else
                {
                    resp.data = "No se encontro el Cordinador...";
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error: " + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpPost]
        [Route("crud/cordinador")]

        public respuesta guardar(cordinador cord)
        {
            respuesta resp = new respuesta();
            try
            {
                cordinadorEntity cordE = new cordinadorEntity(cord.id, cord.nombre, cord.telefono);
                int estado = cordE.guardarCordinador();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Cordinador Ingresado";
                    resp.data = cord;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo el Ingreso";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error: " + e.Message;
                resp.data = null;
                return resp;
            }

        }

        [HttpDelete]
        [Route("crud/cordinador")]

        public respuesta eliminar(int id)
        {
            respuesta resp = new respuesta();
            try
            {
                cordinadorEntity cord = new cordinadorEntity();
                cord.Id = id;
                int estado = cord.eliminarCordinador();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Cordinador Eliminado";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo la eliminacion";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error: " + e.Message;
                resp.data = null;
                return resp;
            }
        }

        [HttpPut]
        [Route("crud/cordinador")]
        public respuesta actualizar(cordinador cord)
        {
            respuesta resp = new respuesta();
            try
            {
                cordinadorEntity cordE = new cordinadorEntity(cord.id, cord.nombre, cord.telefono);
                int estado = cordE.actualizarCordinador();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Cordinador Modificado";
                    resp.data = cord;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo la modificacion";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }

    }
}
