using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с школьными классами.
    /// </summary>
    public class ISchoolClassRepository : IRepository<SchoolClass>
    {
        private readonly List<SchoolClass> _classes;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ISchoolClassRepository"/>.
        /// </summary>
        public ISchoolClassRepository()
        {
            _classes = new List<SchoolClass>();
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ISchoolClassRepository"/> с заданным списком классов.
        /// </summary>
        /// <param name="classes">Список классов для инициализации.</param>
        public ISchoolClassRepository(List<SchoolClass> classes)
        {
            _classes = classes;
        }

        /// <summary>
        /// Получает все школьные классы.
        /// </summary>
        /// <returns>Список всех школьных классов.</returns>
        public IEnumerable<SchoolClass> GetAll()
        {
            return _classes;
        }

        /// <summary>
        /// Получает школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса.</param>
        /// <returns>Школьный класс с заданным идентификатором или null, если не найден.</returns>
        public SchoolClass? GetById(int id)
        {
            return _classes.FirstOrDefault(c => c.ClassId == id);
        }

        /// <summary>
        /// Добавляет новый школьный класс.
        /// </summary>
        /// <param name="schoolClass">Школьный класс для добавления.</param>
        /// <returns>Идентификатор добавленного школьного класса.</returns>
        public int Post(SchoolClass schoolClass)
        {
            var newId = _classes.Count > 0 ? _classes.Max(c => c.ClassId) + 1 : 1;
            schoolClass.ClassId = newId;
            _classes.Add(schoolClass);
            return newId;
        }

        /// <summary>
        /// Обновляет существующий школьный класс.
        /// </summary>
        /// <param name="schoolClass">Школьный класс с обновленными данными.</param>
        /// <returns>True, если класс был успешно обновлен; иначе false.</returns>
        public bool Put(SchoolClass schoolClass)
        {
            var existingClass = GetById(schoolClass.ClassId);
            if (existingClass == null)
                return false;

            existingClass.Letter = schoolClass.Letter;
            existingClass.Number = schoolClass.Number;
            existingClass.Students = schoolClass.Students;
            return true;
        }

        /// <summary>
        /// Удаляет школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса для удаления.</param>
        /// <returns>True, если класс был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            var schoolClass = GetById(id);
            if (schoolClass == null)
                return false;

            _classes.Remove(schoolClass);
            return true;
        }
    }
}