using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;

namespace Business.logic {
    public class Validar {
        public static bool IsMailValido(String mail) {
            //RegExp.IsMatch()

            return true;
        }

        public static bool Login(String user, String pass)
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            List<Usuario> usuarios = usuarioLogic.getAll();
            foreach(Usuario usuario in usuarios)
            {
                if(usuario.NombreUsuario == user && usuario.Clave == pass)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
