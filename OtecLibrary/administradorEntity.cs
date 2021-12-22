using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class administradorEntity
    {
        private int id;
        private string nombre;
        private string telefono;

        public administradorEntity()
        {

        }

        public administradorEntity(int cod, string nom, string tel)
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
    }
}
