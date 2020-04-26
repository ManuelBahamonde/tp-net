using System;
using System.Collections.Generic;
using System.Text;

namespace Business.logic {
    public class Usuario:BusinessEntity {
        //Declaración de variables
        private String nombreUsuario,clave,nombre,apellido,email;
        private Boolean habilitado;
       
        //Properties
        public String NombreUsuario {
            get { return NombreUsuario1; }
            set { NombreUsuario1 = value; }
        }
        public String Clave {
            get { return Clave1; }
            set { Clave1 = value; }
        }
        public String Nombre {
            get { return Nombre1; }
            set { Nombre1 = value; }
        }
        public String Apellido {
            get { return Apellido1; }
            set { Apellido1 = value; }
        }
        public String Email {
            get { return Email1; }
            set { Email1 = value; }
        }
        public Boolean Habilitado {
            get { return Habilitado1; }
            set { Habilitado1 = value; }
        }

        public string NombreUsuario1 { get => nombreUsuario; set => nombreUsuario = value; }
        public string Clave1 { get => clave; set => clave = value; }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido; set => apellido = value; }
        public string Email1 { get => email; set => email = value; }
        public bool Habilitado1 { get => habilitado; set => habilitado = value; }
    }
}
