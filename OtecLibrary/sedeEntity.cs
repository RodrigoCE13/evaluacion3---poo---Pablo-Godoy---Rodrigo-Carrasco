using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class sedeEntity
    {
        private int id;
        private string nombre;
        private string direccion;
        private administradorEntity admin;

        public sedeEntity()
        {

        }

        public sedeEntity(int cod, string nom, string dir)
        {
            this.id = cod;
            this.nombre = nom;
            this.direccion = dir;
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
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
