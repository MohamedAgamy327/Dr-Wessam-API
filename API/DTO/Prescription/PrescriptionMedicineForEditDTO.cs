using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Prescription
{
    public class PrescriptionMedicineForEditDTO
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public string EnglishNotes { get; set; }
        public string ArabicNotes { get; set; }
        public int FrequencyId { get; set; }
        public int Duration { get; set; }
    }
}
