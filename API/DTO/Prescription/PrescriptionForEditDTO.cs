using System;
using System.Collections.Generic;

namespace API.DTO.Prescription
{
    public class PrescriptionForEditDTO
    {
        public int Id { get; set; }
        public string Diagonsis { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string VisitType { get; set; }
        public int PatientId { get; set; }
        public ICollection<PrescriptionInstructionForEditDTO> PrescriptionInstructions { get; set; }
        public ICollection<PrescriptionMedicineForEditDTO> PrescriptionMedicines { get; set; }
    }
}
