namespace MedicalAttention_API.Entities
{
    public class Encounter
    {
        public int Id { get; set; }
        public Patient Patien { get; set; }
        public Facility Facility { get; set; }
        public Payer Payer { get; set; }

    }
}
