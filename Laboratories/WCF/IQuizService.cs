using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    [ServiceContract]
    public interface IQuizService
    {

        [OperationContract]
        void AddQuestion(Question q);

        [OperationContract]
        Dictionary<int, Question> GetQuestions();

        [OperationContract]
        void ModifyQuestionText(int questionId, string text);

        [OperationContract]
        void ModifyQuestionAnswer(int questionId, bool answer);
    }


    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public bool Answer { get; set; }
    }
}
