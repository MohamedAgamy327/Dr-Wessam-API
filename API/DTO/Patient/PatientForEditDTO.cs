using System;

namespace API.DTO.Patient
{
    public class PatientForEditDTO
    {
        public int Code { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string MaritalStatus { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int? OccupationId { get; set; }
        public DateTime? Birthday { get; set; }
        public int? KnowingId { get; set; }
        public string Residence { get; set; }
        public string HusbandName { get; set; }
        public int? HusbandOccupationId { get; set; }
        public DateTime? HusbandBirthday { get; set; }
        public string HusbandPhone { get; set; }
        public string BloodGroup { get; set; }
        public string BMI { get; set; }
        public string Children { get; set; }
        public string Weight { get; set; }
        public string Smoking { get; set; }
    }
}
