using RetoDony.Models.DAL;
using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RetoDony.Models.Business
{
    public class AreaService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public List<Area> EncontrarTodasLasAreas()
        {
            try
            {
                return _context.Area.ToList();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public Area EncontrarArea(int id)
        {
            try
            {
                return _context.Area.SingleOrDefault(a => a.Idarea == id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void GuardarArea(Area area)
        {
            try
            {
                _context.Area.Add(area);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EditarArea(Area area)
        {
            try
            {
                _context.Entry(area).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EliminarArea(int id)
        {
            try
            {
                _context.Area.Remove(EncontrarArea(id) ?? throw new InvalidOperationException());
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}