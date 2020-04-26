using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities {
    class Curso:BusinessEntity{
        int anioCalendario, cupo, idComision, idMateria;
        String descripcion;

        public int AnioCalendario { get => anioCalendario; set => anioCalendario = value; }
        public int Cupo { get => cupo; set => cupo = value; }
        public int IdComision { get => idComision; set => idComision = value; }
        public int IdMateria { get => idMateria; set => idMateria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
