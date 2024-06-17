using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
    public class Ednevik : IEdnevnik
    {
        static Dictionary<int, IEdnevnikCallback> callbacks = new Dictionary<int, IEdnevnikCallback>();

        static Dictionary<int, Parent> parents = new Dictionary<int, Parent>();
        static Dictionary<int, Professor> professors = new Dictionary<int, Professor>();
        static Dictionary<int, Student> students = new Dictionary<int, Student>();

        // for user for session
        int id;

        public void AddChild(Student s)
        {
            students[s.Id].ParentId = this.id;
        }

        public void AddStudent(Student s)
        {
            if (!students.ContainsKey(s.Id))
            {
                students[s.Id] = s;
                students[s.Id].CourseGrades = new Dictionary<string, List<int>>();
                students[s.Id].ProfessorIds = new List<int>();
            }

            if (students[s.Id].ProfessorIds.Contains(this.id) == false)
            {
                students[s.Id].ProfessorIds.Add(this.id);
            }
        }

        public List<Student> GetAllStudents()
        {
            return students.Values.ToList();
        }

        public Dictionary<string, List<int>> GetChildsGrades(Student s)
        {
            return students[s.Id].CourseGrades;
        }

        public List<Student> GetParentChildren()
        {
            return students.Values.Where(s => s.ParentId == this.id).ToList();
        }

        public List<Student> GetProfessorStudents()
        {
            return students.Values.Where(s => s.ProfessorIds.Contains(this.id)).ToList();
        }

        public void GradeStudent(Student s, int grade)
        {
            string courseName = professors[this.id].Course;

            if (!students[s.Id].CourseGrades.ContainsKey(courseName))
            {
                students[s.Id].CourseGrades[courseName] = new List<int>();
            }
            students[s.Id].CourseGrades[courseName].Add(grade);

            int parentId = students[s.Id].ParentId;
            callbacks[parentId].NotifyParent(courseName, grade);
        }

        public void RegisterParent(Parent p)
        {
            if (!parents.ContainsKey(p.Id))
            {
                parents.Add(p.Id, p);
            }

            callbacks[p.Id] = OperationContext.Current.GetCallbackChannel<IEdnevnikCallback>();
            this.id = p.Id;
        }

        public void RegisterProfessor(Professor p)
        {
            if (!professors.ContainsKey(p.Id))
            {
                professors[p.Id] = p;
            }
            this.id = p.Id;
        }
    }
}
