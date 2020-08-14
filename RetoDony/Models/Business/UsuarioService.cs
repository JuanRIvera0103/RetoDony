using RetoDony.Models.DAL;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Business
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public List<Usuario> EncontrarTodosLosUsuarios()
        {
            try
            {
                return _context.Usuario.ToList();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public Usuario EncontrarUsuario(int id)
        {
            try
            {
                return _context.Usuario.SingleOrDefault(us => us.Idusuario == id);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public void GuardarUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                _context.Usuario.Remove(EncontrarUsuario(id) ?? throw new InvalidOperationException());
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception();
            }            
        }
    }
}