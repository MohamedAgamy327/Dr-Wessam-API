namespace Domain.Entities
{
	public	class PrescriptionInstruction
	{
		public int	PrescriptionId { get; set; }
		public Prescription	Prescription { get; set; }
		public int InstructionId { get; set; }
		public Instruction Instruction { get; set; }
	}
}
