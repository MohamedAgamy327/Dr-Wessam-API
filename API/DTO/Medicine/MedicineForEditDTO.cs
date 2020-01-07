namespace API.DTO.Medicine
{
    public class MedicineForEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArabicNotes { get; set; }
        public string EnglishNotes { get; set; }
        public int MedicineTypeId { get; set; }
        public int FrequencyId { get; set; }
        public int Duration { get; set; }
    }
}
