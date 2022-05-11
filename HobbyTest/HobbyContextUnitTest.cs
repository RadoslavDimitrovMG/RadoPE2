using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using DBLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace NunitTest
{
    class HobbyContextUnitTest
    {
        private DatabaseContext dbContext;
        private HobbiesContext hobbiesContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new DatabaseContext(builder.Options);
            hobbiesContext = new HobbiesContext(dbContext);
        }

        [Test]
        public void TestCreateHobby()
        {
            int hobbiesBefore = hobbiesContext.ReadAll().Count();

            hobbiesContext.Create(new Hobby("Volleyball"));

            int hobbiesAfter = hobbiesContext.ReadAll().Count();

            Assert.IsTrue(hobbiesBefore != hobbiesAfter);
        }

        [Test]
        public void TestReadHobby()
        {
            hobbiesContext.Create(new Hobby("Volleyball"));

            Hobby hobby = hobbiesContext.Read(1);

            Assert.That(hobby != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateHobby()
        {
            hobbiesContext.Create(new Hobby("Volleyball"));

            Hobby hobby = hobbiesContext.Read(1);

            hobby.Name = "Football";

            hobbiesContext.Update(hobby);

            Hobby hobby1 = hobbiesContext.Read(1);

            Assert.IsTrue(hobby1.Name == "Football", "Hobby Update() does not change name!");
        }

        [Test]
        public void TestDeleteHobby()
        {
            hobbiesContext.Create(new Hobby("Delete hobby"));

            int hobbiesBeforeDeletion = hobbiesContext.ReadAll().Count();

            hobbiesContext.Delete(1);

            int hobbiesAfterDeletion = hobbiesContext.ReadAll().Count();

            Assert.AreNotEqual(hobbiesBeforeDeletion, hobbiesAfterDeletion);
        }

    }
}
