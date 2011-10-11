using System;

namespace AbstractFactory
{
    class Program
    {
        public static void Main(string[] args)
        {
            Factory nissanFactory = new NissanFactory();

            CarDealership carDealership = new CarDealership(nissanFactory);
            carDealership.OrderVehicles();

            Factory fordFactory = new FordFactory();
            carDealership = new CarDealership(fordFactory);
            carDealership.OrderVehicles();

            Console.ReadKey();
        }


        abstract class Factory
        {
            public abstract Car CreateCar();
            public abstract Van CreateVan();
        }


        class NissanFactory : Factory
        {
            public override Car CreateCar()
            {
                return new Juke();
            }
            public override Van CreateVan()
            {
                return new Pathfinder();
            }
        }

        class FordFactory : Factory
        {
            public override Car CreateCar()
            {
                return new Mondeo();
            }
            public override Van CreateVan()
            {
                return new Transit();
            }
        }

        abstract class Car
        {
            public abstract void BuildVehicle();
        }

        abstract class Van
        {
            public abstract void BuildVehicle();
        }

        class Juke : Car
        {
            public override void BuildVehicle()
            {
                Console.WriteLine("Car Dealership ordered a " + GetType().Name + " Car");
            }
        }

        class Mondeo : Car
        {
            public override void BuildVehicle()
            {
                Console.WriteLine("Car Dealership ordered a " + GetType().Name + " Car");
            }
        }

        class Transit : Van
        {
            public override void BuildVehicle()
            {
                Console.WriteLine("Car Dealership ordered a " + GetType().Name + " Van");
            }
        }

        class Pathfinder : Van
        {
            public override void BuildVehicle()
            {
                Console.WriteLine("Car Dealership ordered a " + GetType().Name + " Van");
            }
        }

        class CarDealership
        {
            private Car _car;
            private Van _van;

            public CarDealership(Factory factory)
            {
                _van = factory.CreateVan();
                _car = factory.CreateCar();
            }

            public void OrderVehicles()
            {
                _van.BuildVehicle();
                _car.BuildVehicle();
            }
        }
    }
}
