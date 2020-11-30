using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public class Person
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Όνομα")]
        public string FirstName { get; set; }
        [DisplayName("Επώνυμο")]
        public string LastName { get; set; }
    }
}
