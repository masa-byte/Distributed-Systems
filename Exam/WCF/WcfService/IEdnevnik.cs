using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IEdnevnikCallback), SessionMode = SessionMode.Required)]
    public interface IEdnevnik
    {
        // Professor part
        [OperationContract]
        void RegisterProfessor(Professor p);

        [OperationContract(IsOneWay = true)]
        void GradeStudent(Student s, int grade);

        [OperationContract]
        void AddStudent(Student s);

        [OperationContract]
        List<Student> GetProfessorStudents();

        // Parent part
        [OperationContract]
        void RegisterParent(Parent p);

        [OperationContract]
        Dictionary<string, List<int>> GetChildsGrades(Student s);

        [OperationContract]
        List<Student> GetParentChildren();

        [OperationContract]
        void AddChild(Student s);


        // Combined
        [OperationContract]
        List<Student> GetAllStudents();
    }

    public interface IEdnevnikCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyParent(string courseName, int grade);
    }

    [DataContract]
    public class Professor
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Course { get; set; }
    }

    [DataContract]
    public class Parent
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Surname { get; set; }
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int ParentId { get; set; }

        [DataMember]
        public List<int> ProfessorIds { get; set; }

        [DataMember]
        public Dictionary<string, List<int>> CourseGrades { get; set; }
    }
}
