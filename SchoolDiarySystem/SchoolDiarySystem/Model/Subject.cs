namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Класс, представляющий предмет.
/// </summary>
public class Subject
{
    /// <summary>
    /// Уникальный идентификатор предмета (первичный ключ).
    /// </summary>
    public required int SubjectId { get; set; }

    /// <summary>
    /// Название предмета.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Год обучения, в котором преподается предмет.
    /// </summary>
    public required int AcademicYear { get; set; }
}
