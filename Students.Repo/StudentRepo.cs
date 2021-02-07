using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.Repo
{
    public class StudentRepo : IStudent
    {
        private readonly StudentDbContext _db;
        public StudentRepo(StudentDbContext db)
        {
            _db = db;
        }
        public IQueryable<Student> GetStudents => _db.Students;

        public void Delete(int? Id)
        {
            Student student = _db.Students.Find(Id);
            _db.Students.Remove(student);
            _db.SaveChanges();
        }

        public Student GetStudent(int? Id)
        {
            Student student=_db.Students.Find(Id);
            return student;
        }

        public void Save(Student student)
        {
            if (student.Id == 0)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
            }
            else if (student.Id != 0)
            {
                Student _student = _db.Students.Find(student.Id);
                _student.FirstName = student.FirstName;
                _student.LastName = student.LastName;
                _student.Gender = student.Gender;
                _db.SaveChanges();
            }
        }
    }
}
