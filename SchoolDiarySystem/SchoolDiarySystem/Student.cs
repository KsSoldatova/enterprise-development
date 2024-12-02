namespace SchoolDiarySystem.Domain;

/// <summary>
/// Класс, представляющий ученика.
/// </summary>
public class Student
{
    /// <summary>
    /// Уникальный идентификатор ученика (первичный ключ).
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Паспортные данные ученика.
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// ФИО ученика.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Дата рождения ученика.
    /// </summary>
    public required DateTime BirthDate { get; set; }

    /// <summary>
    /// Идентификатор класса ученика.
    /// </summary>
    public int ClassId { get; set; }
}
