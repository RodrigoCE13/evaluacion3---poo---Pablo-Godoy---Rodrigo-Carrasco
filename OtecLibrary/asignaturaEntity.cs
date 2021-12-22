using DatosLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class asignaturaEntity
    {
        private int id;
        private string nombre;
        datos data = new datos();

        public asignaturaEntity()
        {

        }

        public asignaturaEntity(int cod, string nom)
        {
            this.id = cod;
            this.nombre = nom;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DataSet listAsignaturas()
        {
            return data.listado("SELECT * FROM RC_PG_ASIGNATURA");
        }

        public DataSet buscarAsignatura(string nombre)
        {
            List<parametros> lst = new List<parametros>();
            lst.Add(new parametros("@NOMBRE", nombre));
            return data.listado("SP_BUSCAR_ASIGNATURA", lst);
        }

        public int guardarAsignatura()
        {
            return data.ejecutar("INSERT INTO RC_PG_ASIGNATURA(id, nombre) VALUES('" + this.id + "','" + this.nombre + "')");
        }

        public int eliminarAsignatura()
        {
            return data.ejecutar("DELETE FROM RC_PG_ASIGNATURA WHERE ID = '" + this.id + "'");
        }
        public int actualizarAsignatura()
        {
            return data.ejecutar("UPDATE RC_PG_ASIGNATURA SET nombre='" + this.nombre + "' WHERE ID='" + this.id + "'");
        }

    }
}
