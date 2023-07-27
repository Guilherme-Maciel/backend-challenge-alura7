namespace JornadaMilhasAPI.Models
{
    public record DestinationModel
    {
        public int Id { get; set; }
        public string PictureURL { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
