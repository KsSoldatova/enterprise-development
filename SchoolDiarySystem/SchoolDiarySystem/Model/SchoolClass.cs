namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Класс, представляющий класс учащихся.
/// </summary>
public class SchoolClass
{
    /// <summary>
    /// Уникальный идентификатор класса (первичный ключ).
    /// </summary>
    public required int ClassId { get; set; }

    /// <summary>
    /// Номер класса (например, 10).
    /// </summary>
    public required int Number { get; set; }

    /// <summary>
    /// Литера класса (например, "А").
    /// </summary>
    public required string Letter { get; set; }

    /// <summary>
    /// Список учеников в классе.
    /// </summary>
    public List<Student> Students { get; set; } = new();
}
