namespace DogApi.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}