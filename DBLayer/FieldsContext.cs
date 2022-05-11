using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class FieldsContext: IDB<Field, int>
    {
        private DatabaseContext _context;
        public FieldsContext(DatabaseContext context)
        {
            _context = context;
        }
        public void Create(Field item)
        {
            try
            {
                List<User> users = new List<User>();

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

                item.Users = users;
                

                _context.Fields.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Fields.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Field Read(int key)
        {
            try
            {
                return _context.Fields.Find(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Field> ReadAll()
        {
            try
            {
                return _context.Fields.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Field item)
        {
            try
            {
                Field fieldFromDB = Read(item.ID);

                _context.Entry(fieldFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
