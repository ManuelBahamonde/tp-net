using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;
namespace Business.logic {
    public class UsuarioLogic:BusinessLogic {
        UsuarioAdapter usuarioData;

        public UsuarioLogic() {
            usuarioData = new UsuarioAdapter();
        }

        UsuarioAdapter UsuarioData {
            get { return usuarioData; }
            set { usuarioData = value; }
        }

        public Usuario getOne(int id) {
            return usuarioData.GetOne(id);
        }
        public List<Usuario> getAll() {
            return usuarioData.GetAll();
        }
        public void save(Usuario user) {
            usuarioData.Save(user);
        }
        public void delete(int id) {
            usuarioData.Delete(id);
        }
    }
}
