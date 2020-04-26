using System;
using System.Collections.Generic;
using System.Text;

namespace Business.logic {
    class Especialidad:BusinessEntity{
        String descripcion;

        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
