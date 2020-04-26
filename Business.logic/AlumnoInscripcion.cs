using System;
using System.Collections.Generic;
using System.Text;

namespace Business.logic {
    class AlumnoInscripcion:BusinessEntity{
        String condicion;
        int idAlumno, idCurso, nota;
        public string Condicion { get => condicion; set => condicion = value; }
        public int IdAlumno { get => idAlumno; set => idAlumno = value; }
        public int IdCurso { get => idCurso; set => idCurso = value; }
        public int Nota { get => nota; set => nota = value; }
    }
}
