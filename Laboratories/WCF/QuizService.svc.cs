using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class QuizService : IQuizService
    {
        static Dictionary<int, Question> questions = new Dictionary<int, Question>();
        static int questionId = 0;

        List<bool> answers = new List<bool>();

        public void AddQuestion(Question q)
        {
            q.Id = questionId;
            questionId++;
            questions.Add(q.Id, q);
        }

        public Dictionary<int, Question> GetQuestions()
        {
            return questions;
        }

        public void ModifyQuestionAnswer(int questionId, bool answer)
        {
            questions[questionId].Answer = answer;
        }

        public void ModifyQuestionText(int questionId, string text)
        {
            questions[questionId].Text = text;
        }
    }
}
