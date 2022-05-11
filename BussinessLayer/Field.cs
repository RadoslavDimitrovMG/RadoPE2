using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BussinessLayer
{
    public class Field
    {
        [Key]
        public int ID { get; private set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }

        private Field()
        {

        }

        public Field(string name)
        {
            Name = name;
        }
    }
}