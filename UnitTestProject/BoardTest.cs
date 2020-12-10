using AspCoreOpenBBSMiddleware.Controllers;
using Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TestSupport.EfHelpers;

namespace UnitTestProject
{
    [TestClass]
    public class BoardTest
    {
        private MWDBContext _context;
        private BoardController _boardController;
        private BoardRepository _boardRepository;

        [TestInitialize]
        public void Init()
        {
            var options = EfInMemory.CreateOptions<MWDBContext>();
            _context = new MWDBContext(options);
            DbInitializer.Initialize(_context);
            _boardRepository = new BoardRepository(_context);

            _boardController = new BoardController(_boardRepository);
        }

        [TestCleanup]
        public void Clean()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void Board_GetAll()
        {
            var result = _boardController.GetAll(isPopular: true);
            if (null == result.Value) Assert.Fail("�^�ǵL���e");

            JObject jobject = JObject.FromObject(result.Value);

            string correctAnswer = @"{""list"":[{""bsn"":""sn-PttNewhand"",""bid"":""PttNewhand"",""title"":""����s��ȪA���ߡK ���Dtest�O"",""flag"":1,""boardType"":2,""cat"":""�s��"",""onlineCount"":100,""moderators"":[{""usn"":""sn-teemo"",""uid"":""teemo""},{""usn"":""sn-okcool"",""uid"":""okcool""}],""read"":false}],""nextBID"":""""}";
            string answer = jobject.ToString(Formatting.None);

            Assert.IsTrue(answer == correctAnswer, 
                $@"Expected:{correctAnswer}, 
got: {answer}");
        }
    }
}
