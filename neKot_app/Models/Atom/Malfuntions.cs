namespace neKot_app.Models
{
    public class Malfuntions
    {
        public int Id { get; set; }
        public Machine Machine { get; set; }

        public string MalfunctionType { get; set; }

        public string ManualLink { get; set; }
    }
}
