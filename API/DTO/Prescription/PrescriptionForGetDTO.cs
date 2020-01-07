using System;

namespace API.DTO.Prescription
{
    public class PrescriptionForGetDTO
    {
        public int Id { get; set; }
        public string Diagonsis { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string VisitType { get; set; }
    }
}
