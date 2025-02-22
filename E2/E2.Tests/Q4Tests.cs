using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E2.Q4.Tests
{
    [TestClass()]
    public class CountryTests
    {

        [TestMethod()]
        public void SmallCityTest()
        {
            Person.ResetRndGen();
            var ali =  new Person(name: "ali", id: 4233211212);
            var golnaz = new Person(name: "golnaz", id:2343218383);
            var sadegh = new Person(name: "sadegh", id:534321238);
            var hooshang = new Person(name: "hooshang", id:5343328);
            var zhila = new Person(name: "zhila", id:934113328);
            Person[] mardom = new Person[] {ali, golnaz, sadegh, hooshang, zhila};

            var vrlist = mardom.Select(p => p.Vote("Constitution")).ToList();

            Assert.AreEqual(5, vrlist.Sum(vr => vr.Total));
            Assert.AreEqual(5, vrlist.SelectMany(vr => new int[]{vr.NoCount, vr.YesCount, vr.WhiteCount}).Sum());

            Assert.AreEqual(vrlist[0].YesCount, 1);
            Assert.AreEqual(vrlist[1].WhiteCount, 1);
            Assert.AreEqual(vrlist[2].WhiteCount, 1);
            Assert.AreEqual(vrlist[3].NoCount, 1);
            Assert.AreEqual(vrlist[4].WhiteCount, 1);

            Person.ResetRndGen();
            City behesht = new City("Behesht", mardom);
            var vr = behesht.Vote("Constitution");
            Assert.AreEqual(3, vr.WhiteCount);
            Assert.AreEqual(1, vr.YesCount);
            Assert.AreEqual(1, vr.NoCount);
            Assert.AreEqual(5, vr.Total);
        }

        [TestMethod()]
        public void CityTest()
        {
            Person.ResetRndGen();
            City karaj = new City("Karaj", GeneratePeople(10_000));
            var result = karaj.Vote("Constitution");
            Assert.AreEqual(result.NoCount, 2969);
            Assert.AreEqual(result.YesCount, 2997);
            Assert.AreEqual(result.WhiteCount, 4034);
        }

        [TestMethod()]
        public void StateTest()
        {
            Person.ResetRndGen();
            City eslamshahr = new City("eslamshahr", GeneratePeople(450_000));
            City rey = new City("eslamshahr", GeneratePeople(150_000));
            City varamin = new City("eslamshahr", GeneratePeople(250_000));
            State tehran = new State("Tehran", new City[]{ eslamshahr, rey, varamin});
            var result = tehran.Vote("Constitution");
            Assert.AreEqual(result.NoCount, 255484);
            Assert.AreEqual(result.YesCount, 255368);
            Assert.AreEqual(result.WhiteCount, 339148);
            Assert.AreEqual(result.Total, 850_000);
        }

        [TestMethod()]
        public void VoteTest()
        {
            Person.ResetRndGen();
            Country c = new Country("Iran", GenerateStates(31));
            var result = c.Vote("Constitution");
            Assert.AreEqual(result.NoCount, 92955);
            Assert.AreEqual(result.YesCount, 93086);
            Assert.AreEqual(result.WhiteCount, 123959);
            Assert.AreEqual(result.Total, 310_000);
        }


        static uint UniquePersonNumber = 0;
        static uint UniqueCityNumber = 0;


        private State[] GenerateStates(int count)
        {
            State[] states = new State[count];
            for (int i = 0; i < states.Length; i++)
                states[i] = new State(UniqueCityNumber.ToString(), GenerateCities(10));

            return states;
        }

        private City[] GenerateCities(int count)
        {
            City[] cities = new City[count];
            for (int i = 0; i < cities.Length; i++)
                cities[i] = new City(UniqueCityNumber.ToString(), GeneratePeople(1000));

            return cities;

        }

        private Person[] GeneratePeople(int count)
        {
            Person[] people = new Person[count];
            for (int i = 0; i < people.Length; i++)
                people[i] = new Person(UniquePersonNumber.ToString(), UniquePersonNumber++);

            return people;
        }
    }
}