namespace Testing_general.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double? Price { get; set; }       // ✅ ubah ke nullable

        public string? Description { get; set; }
        public string? Slug { get; set; }
    }
}
