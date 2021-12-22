using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtecLibrary
{
    public class cursoEntity
    {
        private int id;
        private string nombre;
        private cordinadorEntity cordinador;

        public cursoEntity()
        {

        }

        public cursoEntity(int cod, string nom)
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
    }
}
