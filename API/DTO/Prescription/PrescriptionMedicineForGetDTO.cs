namespace API.DTO.Prescription
{
    public class PrescriptionMedicineForGetDTO
    {
        public int MedicineId { get; set; }
        public string Medicine { get; set; }
        public string EnglishNotes { get; set; }
        public string ArabicNotes { get; set; }
        public int FrequencyId { get; set; }
        public string ArabicFrequency { get; set; }
        public string EnglishFrequency { get; set; }
        public int Duration { get; set; }
    }
}
