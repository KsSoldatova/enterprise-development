using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с оценками.
    /// </summary>
    public class IGradeRepository : IRepository<Grade>
    {
        private readonly List<Grade> _grades;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IGradeRepository"/>.
        /// </summary>
        public IGradeRepository()
        {
            _grades = new List<Grade>();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IGradeRepository"/> с заданным списком оценок.
        /// </summary>
        /// <param name="grades">Список оценок для инициализации.</param>
        public IGradeRepository(List<Grade> grades)
        {
            _grades = grades;
        }

        /// <summary>
        /// Получает все оценки.
        /// </summary>
        /// <returns>Список всех оценок.</returns>
        public IEnumerable<Grade> GetAll()
        {
            return _grades;
        }

        /// <summary>
        /// Получает оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки.</param>
        /// <returns>Оценка с заданным идентификатором или null, если не найдена.</returns>
        public Grade? GetById(int id)
        {
            return _grades.FirstOrDefault(g => g.GradeId == id);
        }

        /// <summary>
        /// Добавляет новую оценку.
        /// </summary>
        /// <param name="grade">Оценка для добавления.</param>
        /// <returns>Идентификатор добавленной оценки.</returns>
        public int Post(Grade grade)
        {
            var newId = _grades.Count > 0 ? _grades.Max(g => g.GradeId) + 1 : 1;
            grade.GradeId = newId;
            _grades.Add(grade);
            return newId;
        }

        /// <summary>
        /// Обновляет существующую оценку.
        /// </summary>
        /// <param name="grade">Оценка с обновленными данными.</param>
        /// <returns>True, если оценка была успешно обновлена; иначе false.</returns>
        public bool Put(Grade grade)
        {
            var existingGrade = GetById(grade.GradeId);
            if (existingGrade == null)
                return false;

            existingGrade.Value = grade.Value;
            existingGrade.SubjectId = grade.SubjectId;
            existingGrade.StudentId = grade.StudentId;
            existingGrade.Date = grade.Date;
            return true;
        }

        /// <summary>
        /// Удаляет оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки для удаления.</param>
        /// <returns>True, если оценка была успешно удалена; иначе false.</returns>
        public bool Delete(int id)
        {
            var grade = GetById(id);
            if (grade == null)
                return false;

            _grades.Remove(grade);
            return true;
        }
    }
}