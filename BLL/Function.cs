using DAL;
using ENTITIES;
namespace BLL
{
    public class Function
    {
        Database1 Database = new Database1();
        List<Student> StudentsList = new List<Student>();
        List<Teacher> TeachersList = new List<Teacher>();
        List<string> ClassList = new List<string>();

        public List<Student> LoadStudentsDetails()
        {
            var reader = Database.ReadFromDbStudents();
            while (reader.Read())
            {
                Student student = new Student
                {
                    Id = reader["Id"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    HomePhone = reader["HomePhone"].ToString(),
                    BirthdayYear = reader["BirthdayYear"].ToString(),
                    Class = reader["Class"].ToString(),
                    Address = reader["Address"].ToString()
                };
                StudentsList.Add(student);
            }
            reader.Close();
            return StudentsList;
        }
        public List<Teacher> LoadTeachersDetails()
        {
            var reader = Database.ReadFromDbTeachers();
            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    Id = (int)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    MailAddress = reader["MailAddress"].ToString(),
                };
                TeachersList.Add(teacher);
            }
            reader.Close();
            return TeachersList;
        }
    }
}