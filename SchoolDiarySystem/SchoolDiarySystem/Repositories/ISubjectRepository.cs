using SchoolDiarySystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с предметами.
    /// </summary>
    public class ISubjectRepository(List<Subject> _subjects) : IRepository<Subject>
    {
        /// <summary>
        /// Получает все предметы.
        /// </summary>
        /// <returns>Список всех предметов.</returns>
        public IEnumerable<Subject> GetAll()
        {
            return _subjects;
        }

        /// <summary>
        /// Получает предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета.</param>
        /// <returns>Предмет с заданным идентификатором или null, если не найден.</returns>
        public Subject? GetById(int id)
        {
            return _subjects.FirstOrDefault(sub => sub.SubjectId == id);
        }

        /// <summary>
        /// Добавляет новый предмет.
        /// </summary>
        /// <param name="subject">Предмет для добавления.</param>
        /// <returns>Идентификатор добавленного предмета.</returns>
        public int Post(Subject subject)
        {
            var newId = _subjects.Count > 0 ? _subjects.Max(sub => sub.SubjectId) + 1 : 1;
            subject.SubjectId = newId;
            _subjects.Add(subject);
            return newId;
        }

        /// <summary>
        /// Обновляет существующий предмет.
        /// </summary>
        /// <param name="subject">Предмет с обновленными данными.</param>
        /// <returns>True, если предмет был успешно обновлен; иначе false.</returns>
        public bool Put(Subject subject)
        {
            var existingSubject = GetById(subject.SubjectId);
            if (existingSubject == null)
                return false;

            existingSubject.Name = subject.Name;
            existingSubject.AcademicYear = subject.AcademicYear;
            return true;
        }

        /// <summary>
        /// Удаляет предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета для удаления.</param>
        /// <returns>True, если предмет был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            var subject = GetById(id);
            if (subject == null)
                return false;

            _subjects.Remove(subject);
            return true;
        }
    }
}