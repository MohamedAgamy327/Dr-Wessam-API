using System.Collections.Generic;

namespace Domain.Entities
{
    public class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; }

        public ICollection<Patient> HusbandsPatients { get; set; }

    }
}
