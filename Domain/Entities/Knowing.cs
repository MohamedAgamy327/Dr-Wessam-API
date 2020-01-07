using System.Collections.Generic;

namespace Domain.Entities
{
    public class Knowing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
