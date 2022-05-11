using BussinessLayer;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class HobbiesContext : IDB<Hobby, int>
    {
        private DatabaseContext _context;
        public HobbiesContext(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(Hobby item)
        {
            try
            {
                /*List<User> users = new List<User>();

                foreach (var u in item.Users)
                {
                    User userFromDB = _context.Users.Find(u.ID);

                    if (userFromDB != null)
                    {
                        users.Add(userFromDB);
                    }
                    else
                    {
                        users.Add(u);
                    }
                }            
                item.Users = users;*/

                Field fieldFromDB = _context.Fields.Find(item.ID);

                if (fieldFromDB != null)
                {
                    item.Field = fieldFromDB;
                }

                _context.Hobbies.Add(item);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Hobbies.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Hobby Read(int key)
        {
            try
            {
                return _context.Hobbies.Find(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Hobby> ReadAll()
        {
            try
            {
                return _context.Hobbies.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Hobby item)
        {
            try
            {
                Hobby hobbyFromDB = Read(item.ID);

                _context.Entry(hobbyFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
