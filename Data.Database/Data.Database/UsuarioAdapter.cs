using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
      
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read()) {
                    Usuario usr = new Usuario();

                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (String)drUsuarios["nombre_usuario"];
                    usr.Clave = (String)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (String)drUsuarios["nombre"];
                    usr.Apellido = (String)drUsuarios["apellido"];
                    usr.Email = (String)drUsuarios["email"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];

                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch(Exception exc) {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios" + exc.Message);
                throw ExcepcionManejada;
            }
            finally {
                this.CloseConnection();
            }

            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id",sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read()) {
                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.Nombre = (String)drUsuarios["nombre"];
                    usr.Apellido = (String)drUsuarios["apellido"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.NombreUsuario = (String)drUsuarios["nombre_usuario"];
                    usr.Clave = (String)drUsuarios["clave"];
                    usr.Email = (String)drUsuarios["email"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                }

                drUsuarios.Close();
            }catch(Exception exc) {
                throw new Exception("Error al recuperar datos de usuario: ",exc);
            }
            finally {
                this.CloseConnection();
            }

            return usr;
        }

        public void Delete(int ID){
            try {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE FROM usuarios WHERE id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception exc) {
                throw new Exception("Error al eliminar el usuario: ", exc);
            }
            finally {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario) {
            if (usuario.State == BusinessEntity.States.Deleted) {
                this.Delete(usuario.Id);
            }
            else if (usuario.State == BusinessEntity.States.Modified) {
                this.Update(usuario);
            }
            else if (usuario.State == BusinessEntity.States.New) {
                this.Insert(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Usuario usuario) {
            try {
                this.OpenConnection();

                SqlCommand cmdUpdate = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario,clave = @clave,habilitado = @habilitado" +
                    ",nombre = @nombre,apellido = @apellido,id_persona = @id_persona,email = @email WHERE id_usuario = @id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                cmdUpdate.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.NombreUsuario;
                cmdUpdate.Parameters.Add("@clave", SqlDbType.VarChar,50).Value = usuario.Clave;
                cmdUpdate.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = usuario.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar,50).Value = usuario.Apellido;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar,50).Value = usuario.Email;
                cmdUpdate.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception exc) {
                throw new Exception("Error al modificar datos del usuario: ", exc);
            }
            finally {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario) {
            try {
                this.OpenConnection();

                SqlCommand cmdInsert = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email) VALUES(@nombre_usuario" +
                    ",@clave,@habilitado,@nombre,@apellido,@email) SELECT @@identity", sqlConn);
                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;

                usuario.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception exc) {
                throw new Exception("Error al crear usuario: ", exc);
            }
            finally {
                this.CloseConnection();
            }
        }
    }
}