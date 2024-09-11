namespace Applications.Model.Models.Cards
{
    public class ClothesDTO
    {
        public ClothesDTO(string color, int size, string type, string name, int count)
        {
            Color = color;
            Size = size;
            Type = type;
            Name = name;
            Count = count;
        }

        public string Color { get; set; }

        public int Size { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public ClothesDTO Clone(int count) => new ClothesDTO(Color, Size, Type, Name, count);
    }
}
