using DogApi.Models;

namespace DogApi
{
    public static class DogRepository
    {
        private static List<Dog> Dogs = new();
        private static int nextId = 1;

        public static List<Dog> GetAll() => Dogs;

        public static Dog? Get(int id) => Dogs.FirstOrDefault(d => d.Id == id);

        public static Dog Add(Dog dog)
        {
            dog.Id = nextId++;
            Dogs.Add(dog);
            return dog;
        }

        public static bool Update(int id, Dog updatedDog)
        {
            var dog = Get(id);
            if (dog == null) return false;

            dog.Name = updatedDog.Name;
            dog.Breed = updatedDog.Breed;
            dog.Age = updatedDog.Age;
            return true;
        }

        public static bool Delete(int id)
        {
            var dog = Get(id);
            return dog != null && Dogs.Remove(dog);
        }
    }
}