using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Zoo
{
    enum AnimalFood
    {
        Carrots,
        Apples,
        Grass,
        Barley
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo1 = new Zoo("Bronx Zoo");

            zoo1.ShowAnimals();

            var pig1 = new Pig("pig1", AnimalFood.Apples);
            zoo1.AddAnimal(pig1);
            zoo1.ShowAnimals();

            zoo1.AddAnimal(new Cow("cow1", AnimalFood.Grass));
            zoo1.ShowAnimals();

            zoo1.FeedAnimals();

            zoo1.RemoveAnimal(pig1);
            zoo1.ShowAnimals();

            zoo1.FeedAnimals();

        }
        // Model a ZOO keeping in mind that:
        // A zoo has a name and a list of animals
        // At a zoo they can bring new animals and transfer animals to new zoos
        // At a zoo the animals are daily fed with their favorite food, and each animal eats what it loves to eat.
        // Each animal knows to eat by itself, and not all animals of the same type prefer the same type of food.Eg; a horse prefers carrots, and another horse prefers apples

        public class Zoo
        {
            private List<Animal> animals = new List<Animal>();
            private string name;

            public Zoo(string name)
            {
                this.name = name;
            }

            public void FeedAnimals()
            {
                Console.WriteLine("Daily feeding has begun.");

                foreach (var animal in animals)
                {
                    animal.Eat();
                }

                Console.WriteLine("Daily feeding has ended.");
            }

            public string Name => name;

            public void AddAnimal(Animal animal)
            {
                animals.Add(animal);
                Console.WriteLine($"{animal.GetType().Name} '{animal.Name}' has been added.");
            }

            public void RemoveAnimal(Animal animal)
            {
                animals.Remove(animal);
                Console.WriteLine($"{animal.GetType().Name} '{animal.Name}' has been removed.");
            }

            public void ShowAnimals()
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine($"There are no animals in the zoo '{name}'.");

                    return;
                }

                StringBuilder listOfAnimals = new StringBuilder();

                foreach (var animal in animals)
                {
                    listOfAnimals.Append(animal.Name + ", ");
                }

                string listOfAnimalsTemp = listOfAnimals.ToString().Substring(0, listOfAnimals.Length - 2);

                Console.WriteLine($"The zoo '{name}' has the following animals: {listOfAnimalsTemp}.");
            }
        }

        public abstract class Animal
        {
            private string name;
            private AnimalFood preferredFood;

            public Animal(string name, AnimalFood animalFood)
            {
                this.name = name;
                this.preferredFood = animalFood;
            }

            public string Name => name;

            public void Eat()
            {
                Console.WriteLine($"{GetType().Name} {name} eats {preferredFood}.");
            }
        }

        public class Pig : Animal
        {
            public Pig(string name, AnimalFood animalFood) : base(name, animalFood)
            {
            }
        }

        public class Cow : Animal
        {
            public Cow(string name, AnimalFood animalFood) : base(name, animalFood)
            {
            }
        }
    }
}
