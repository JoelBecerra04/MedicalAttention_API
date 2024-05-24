namespace MedicalAttention_API.Entities.DTO
{
    public class EncounterDTO
    {
        public Patient Patien { get; set; }
        public Facility Facility { get; set; }
        public Payer Payer { get; set; }
    }
}
