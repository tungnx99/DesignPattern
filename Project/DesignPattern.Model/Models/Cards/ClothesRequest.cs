namespace DesignPattern.Model.Models.Cards
{
    public class ClothesRequest
    {
        public ClothesRequest(string color, int size, string name)
        {
            Size = size;
            Name = name;
        }

        public ClothesRequest() { }

        public string Color { get; set; }

        public int Size { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
