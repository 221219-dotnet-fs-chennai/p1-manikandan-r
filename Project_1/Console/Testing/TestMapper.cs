using Bussiness_Logic;
using Models;
using TEF = Trainer_EF_Layer.Entities;


namespace Testing
{
    [TestFixture]
    public class TestMapper
    {
        Mapper map = new Mapper();

        // Entity to Model Mapper Testing
        [Test]
        public void testmapTrainer()
        {
            TEF.TrainerDetail trainer = new TEF.TrainerDetail();
            var model = map.MapTrainer(trainer);
            Assert.AreEqual(model.GetType(), typeof(TrainerDetail));
        }

        [Test]
        public void testmapEducation()
        {
            TEF.Education trainer = new TEF.Education();
            var model = map.MapEducation(trainer);
            Assert.AreEqual(model.GetType(), typeof(TrainerEducation));
        }

        [Test]
        public void testmapSkill()
        {
            TEF.Skill trainer = new TEF.Skill();
            var model = map.MapSkill(trainer);
            Assert.AreEqual(model.GetType(), typeof(TrainerSkill));
        }

        [Test]
        public void testmapCompany()
        {
            TEF.Company trainer = new TEF.Company();
            var model = map.MapCompany(trainer);
            Assert.AreEqual(model.GetType(), typeof(TrainerCompany));
        }


        // Model to Entity Mapper Testing
        [Test]
        public void TestMapTrainer()
        {
            TrainerDetail trainer = new TrainerDetail();
            var entity = map.mapTrainer(trainer);
            Assert.AreEqual(entity.GetType(), typeof(TEF.TrainerDetail));
        }

        [Test]
        public void TestMapEducation()
        {
            TrainerEducation trainer = new TrainerEducation();
            var entity = map.mapEducation(trainer);
            Assert.AreEqual(entity.GetType(), typeof(TEF.Education));
        }

        [Test]
        public void TestMapSkill()
        {
            TrainerSkill trainer = new TrainerSkill();
            var entity = map.mapSkill(trainer);
            Assert.AreEqual(entity.GetType(), typeof(TEF.Skill));
        }

        [Test]
        public void TestMapCompany()
        {
            TrainerCompany trainer = new TrainerCompany();
            var entity = map.mapCompany(trainer);
            Assert.AreEqual(entity.GetType(), typeof(TEF.Company));
        }
    }
}
