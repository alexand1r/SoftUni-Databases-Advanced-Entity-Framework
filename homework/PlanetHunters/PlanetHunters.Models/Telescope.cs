namespace PlanetHunters.Models
{
    public class Telescope
    {
        private decimal diameter;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public decimal MirrorDiameter
        {
            get { return diameter; }
            set
            {
                if (value > 0.0M) diameter = value;
            }
        }
    }
}
