using System.Collections.Generic;

namespace Domain.Entities
{
    public class Instruction
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public ICollection<PrescriptionInstruction> PrescriptionInstructions { get; set; }
    }
}
