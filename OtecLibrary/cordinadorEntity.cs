using DatosLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class cordinadorEntity
    {
        private int id;
        private string nombre;
        private string telefono;

        datos data = new datos();

        public cordinadorEntity()
        {

        }

        public cordinadorEntity(int cod, string nom, string tel)
        {
            this.id = cod;
            this.nombre = nom;
            this.telefono = tel;
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
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

        public DataSet listCordinadores()
        {
            return data.listado("SELECT * FROM RC_PG_CORDINADOR");
        }

        public DataSet buscarCordinador(string nombre)
        {
            List<parametros> lst = new List<parametros>();
            lst.Add(new parametros("@NOMBRE", nombre));
            return data.listado("SP_BUSCAR_CORDINADOR", lst);
        }

        public int guardarCordinador()
        {
            return data.ejecutar("INSERT INTO RC_PG_CORDINADOR(id, nombre, telefono) VALUES('" + this.id + "','" + this.nombre + "','" + this.telefono + "')");
        }

        public int eliminarCordinador()
        {
            return data.ejecutar("DELETE FROM RC_PG_CORDINADOR WHERE ID = '" + this.id + "'");
        }
        public int actualizarCordinador()
        {
            return data.ejecutar("UPDATE RC_PG_CORDINADOR SET nombre='" + this.nombre + "', telefono='" + this.telefono + "' WHERE ID='" + this.id + "'");
        }
    }
}
