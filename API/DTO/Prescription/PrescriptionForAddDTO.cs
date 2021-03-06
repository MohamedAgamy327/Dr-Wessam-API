﻿using System;
using System.Collections.Generic;

namespace API.DTO.Prescription
{
    public class PrescriptionForAddDTO
    {
        public string Diagonsis { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string VisitType { get; set; }
        public int PatientId { get; set; }
        public ICollection<PrescriptionInstructionForAddDTO> PrescriptionInstructions { get; set; }
        public ICollection<PrescriptionMedicineForAddDTO> PrescriptionMedicines { get; set; }
    }
}
