using System;
using System.Collections.Generic;
using System.Text;

namespace Business.logic {
    public class Modulo:BusinessEntity {
        //Declaración de variables
        String descripcion;

        //Properties
        public String Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
