using System;
using System.Collections.Generic;

namespace LabWork
{
    public class House
    {
        private readonly List<string> _parts = new List<string>();
        public string HouseType { get; set; }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"--- {HouseType} ---");
            Console.WriteLine("Складові: " + string.Join(", ", _parts));
            Console.WriteLine();
        }
    }

    public interface IHouseBuilder
    {
        void Reset();
        void BuildFoundation();
        void BuildStructure();
        void BuildRoof();
        void BuildInterior();
        House GetResult();
    }

    public class PrivateHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public PrivateHouseBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _house = new House { HouseType = "Приватна забудова" };
        }

        public void BuildFoundation() => _house.AddPart("Бетонний фундамент");
        public void BuildStructure() => _house.AddPart("Цегляні стіни");
        public void BuildRoof() => _house.AddPart("Черепичний дах");
        public void BuildInterior() => _house.AddPart("Житлові кімнати");

        public House GetResult()
        {
            House product = _house;
            Reset();
            return product;
        }
    }

    public class OfficeBuildingBuilder : IHouseBuilder
    {
        private House _house = new House();

        public OfficeBuildingBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _house = new House { HouseType = "Офісна будівля" };
        }

        public void BuildFoundation() => _house.AddPart("Посилений фундамент");
        public void BuildStructure() => _house.AddPart("Скляний фасад");
        public void BuildRoof() => _house.AddPart("Плоский дах");
        public void BuildInterior() => _house.AddPart("Офіси та конференц-зали");

        public House GetResult()
        {
            House product = _house;
            Reset();
            return product;
        }
    }

    public class ApartmentBuildingBuilder : IHouseBuilder
    {
        private House _house = new House();

        public ApartmentBuildingBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _house = new House { HouseType = "Багатоквартирний будинок" };
        }

        public void BuildFoundation() => _house.AddPart("Пальовий фундамент");
        public void BuildStructure() => _house.AddPart("Залізобетонний каркас");
        public void BuildRoof() => _house.AddPart("Рулонна покрівля");
        public void BuildInterior() => _house.AddPart("Під'їзди та квартири");

        public House GetResult()
        {
            House product = _house;
            Reset();
            return product;
        }
    }

    public class ConstructionDirector
    {
        private IHouseBuilder _builder;

        public IHouseBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildFullComplex()
        {
            _builder.BuildFoundation();
            _builder.BuildStructure();
            _builder.BuildRoof();
            _builder.BuildInterior();
        }

        public void BuildBasicShell()
        {
            _builder.BuildFoundation();
            _builder.BuildStructure();
            _builder.BuildRoof();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var director = new ConstructionDirector();

            var privateBuilder = new PrivateHouseBuilder();
            director.Builder = privateBuilder;
            director.BuildFullComplex();
            privateBuilder.GetResult().ShowInfo();

            var officeBuilder = new OfficeBuildingBuilder();
            director.Builder = officeBuilder;
            director.BuildBasicShell();
            officeBuilder.GetResult().ShowInfo();

            var apartmentBuilder = new ApartmentBuildingBuilder();
            director.Builder = apartmentBuilder;
            director.BuildFullComplex();
            apartmentBuilder.GetResult().ShowInfo();
        }
    }
}