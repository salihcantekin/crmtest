using System;
using System.Collections.Generic;

namespace Crm.Data.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
