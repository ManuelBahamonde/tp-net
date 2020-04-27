using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Usuario:BusinessEntity
    {
        private string apellido;
        private string clave;
        private string email;
        private bool habilitado;
        private string nombre;
        private string nombreUsuario;

        public string Apellido { get => apellido; set => apellido = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Email { get => email; set => email = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    }
}
