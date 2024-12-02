namespace SchoolDiarySystem.Domain;

/// <summary>
/// Класс, представляющий оценку.
/// </summary>
public class Grade
{
    /// <summary>
    /// Уникальный идентификатор оценки (первичный ключ).
    /// </summary>
    public int GradeId { get; set; }

    /// <summary>
    /// Значение оценки.
    /// </summary>
    public required int Value { get; set; }

    /// <summary>
    /// Идентификатор ученика, которому выставлена оценка.
    /// </summary>
    public int StudentId { get; set; }

    /// <summary>
    /// Идентификатор предмета, по которому выставлена оценка.
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// Ссылка на предмет.
    /// </summary>

    public required DateTime Date { get; set; }
}
