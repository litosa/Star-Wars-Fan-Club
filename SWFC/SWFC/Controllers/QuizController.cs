using PagedList;
using SWFC.QuizServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SWFC.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        // GET: Quiz
        [HttpGet]
        public ActionResult Index()
        {
            QuizInterfaceClient qic = new QuizInterfaceClient();
            List<string> questions = qic.GetTenRandomQuestions().ToList();
            return View(questions);
        }

        [HttpPost]
        public ActionResult Index(List<string> Question, List<string> Answer)
        {
            QuizData[] qd = new QuizData[10];
            string name = "";
            
            QuizInterfaceClient qic = new QuizInterfaceClient();
            for (int i = 0; i < Question.Count(); i++)
            {
                QuizData newRow = new QuizData();
                newRow.question = Question[i];
                newRow.answer = Answer[i];
                qd[i] = newRow;
            }
            qic.CheckAnswersAddScore(qd, name = User.Identity.Name);

            List<string> questions = qic.GetTenRandomQuestions().ToList();
            return View(questions);            
        }

        [HttpGet]
        public ActionResult HighScore(int page = 1, int pageSize = 10)
        {
            QuizInterfaceClient qic = new QuizInterfaceClient();
            List<QuizHighscore> highscore = qic.GetHighscore().ToList();

            PagedList<QuizHighscore> highscorePagedList = new PagedList<QuizHighscore>(highscore, page, pageSize);

            return View(highscorePagedList);
        }
    }
}