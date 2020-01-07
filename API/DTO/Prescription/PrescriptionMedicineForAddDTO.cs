namespace API.DTO.Prescription
{
    public class PrescriptionMedicineForAddDTO
    {
        public int MedicineId { get; set; }
        public string EnglishNotes { get; set; }
        public string ArabicNotes { get; set; }
        public int FrequencyId { get; set; }
        public int Duration { get; set; }
    }
}
