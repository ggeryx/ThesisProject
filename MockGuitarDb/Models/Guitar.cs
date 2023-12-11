namespace MockGuitarDb.Models
{
    public enum BodyStyle
    {
        Stratocaster, SuperStrat, Telecaster, LesPaul, Offset, SG, FlyingV
    }
    public class Guitar
    {
        public int Id { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
