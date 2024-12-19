using SchoolDiarySystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы со студентами.
    /// </summary>
    public class IStudentRepository : IRepository<Student>
    {
        private readonly List<Student> _students;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IStudentRepository"/>.
        /// </summary>
        public IStudentRepository()
        {
            _students = new List<Student>();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IStudentRepository"/> с заданным списком студентов.
        /// </summary>
        /// <param name="students">Список студентов для инициализации.</param>
        public IStudentRepository(List<Student> students)
        {
            _students = students;
        }

        /// <summary>
        /// Получает всех студентов.
        /// </summary>
        /// <returns>Список всех студентов.</returns>
        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        /// <summary>
        /// Получает студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Студент с заданным идентификатором или null, если не найден.</returns>
        public Student? GetById(int id)
        {
            return _students.FirstOrDefault(s => s.StudentId == id);
        }

        /// <summary>
        /// Добавляет нового студента.
        /// </summary>
        /// <param name="student">Студент для добавления.</param>
        /// <returns>Идентификатор добавленного студента.</returns>
        public int Post(Student student)
        {
            var newId = _students.Count > 0 ? _students.Max(s => s.StudentId) + 1 : 1;
            student.StudentId = newId;
            _students.Add(student);
            return newId;
        }

        /// <summary>
        /// Обновляет существующего студента.
        /// </summary>
        /// <param name="student">Студент с обновленными данными.</param>
        /// <returns>True, если студент был успешно обновлен; иначе false.</returns>
        public bool Put(Student student)
        {
            var existingStudent = GetById(student.StudentId);
            if (existingStudent == null)
                return false;

            existingStudent.FullName = student.FullName;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Passport = student.Passport;
            existingStudent.ClassId = student.ClassId;

            return true;
        }

        /// <summary>
        /// Удаляет студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента для удаления.</param>
        /// <returns>True, если студент был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            var student = GetById(id);
            if (student == null)
                return false;

            _students.Remove(student);
            return true;
        }
    }
}