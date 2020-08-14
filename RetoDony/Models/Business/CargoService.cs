using RetoDony.Models.DAL;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Business
{
    public class CargoService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public List<Cargo> EncontrarTodosLosCargos()
        {
            try
            {
                return _context.Cargo.ToList();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public Cargo EncontrarCargo(int id)
        {
            try
            {
                return _context.Cargo.SingleOrDefault(c => c.Idcargo == id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void GuardarCargo(Cargo cargo)
        {
            try
            {
                _context.Cargo.Add(cargo);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EditarCargo(Cargo cargo)
        {
            try
            {
                _context.Entry(cargo).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EliminarCargo(int id)
        {
            try
            {
                _context.Cargo.Remove(EncontrarCargo(id) ?? throw new InvalidOperationException());
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}