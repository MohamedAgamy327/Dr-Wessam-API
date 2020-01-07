using System.Collections.Generic;

namespace Domain.Entities
{
    public class Frequency
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
