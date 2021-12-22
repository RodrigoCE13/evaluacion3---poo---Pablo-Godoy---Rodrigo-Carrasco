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
    public class AsignaturaController : ApiController
    {
        [HttpGet]
        [Route("crud/asignaturas")]
        public respuesta listar(string nom = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<asignatura> listado = new List<asignatura>();
                asignaturaEntity asignaturaData = new asignaturaEntity();
                DataSet data = nom == "" ? asignaturaData.listAsignaturas() : asignaturaData.buscarAsignatura(nom);

                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    asignatura item = new asignatura();
                    item.id = int.Parse(data.Tables[0].Rows[i].ItemArray[0].ToString());
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    listado.Add(item);
                }
                //operacion correcta
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else
                {
                    resp.data = "No se encontro la Asignatura...";
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
        [Route("crud/asignatura")]

        public respuesta guardar(asignatura asig)
        {
            respuesta resp = new respuesta();
            try
            {
                asignaturaEntity asgE = new asignaturaEntity(asig.id, asig.nombre);
                int estado = asgE.guardarAsignatura();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura Ingresada";
                    resp.data = asig;
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
        [Route("crud/asignatura")]

        public respuesta eliminar(int id)
        {
            respuesta resp = new respuesta();
            try
            {
                asignaturaEntity asg = new asignaturaEntity();
                asg.Id = id;
                int estado = asg.eliminarAsignatura();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura Eliminada";
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
        [Route("crud/asignatura")]
        public respuesta actualizar(asignatura asig)
        {
            respuesta resp = new respuesta();
            try
            {
                asignaturaEntity asgE = new asignaturaEntity(asig.id, asig.nombre);
                int estado = asgE.actualizarAsignatura();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura Modificado";
                    resp.data = asig;
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

