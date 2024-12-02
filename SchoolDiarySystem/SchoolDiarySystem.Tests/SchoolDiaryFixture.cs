using System;
using System.Collections.Generic;
using System.Diagnostics;
using SchoolDiarySystem.Domain;

namespace SchoolDiarySystem.Tests
{
    public class SchoolFixture
    {
        public SchoolRepository Repository { get; private set; }

        public SchoolFixture()
        {
            Repository = new SchoolRepository();

            // Äîáàâëÿåì êëàññû
            var class1 = new SchoolClass { ClassId = 1, Number = 10, Letter = "À" };
            var class2 = new SchoolClass { ClassId = 2, Number = 10, Letter = "Á" };

            Repository.Classes.AddRange(new List<SchoolClass>
            {
                class1,
                class2
            });

            // Äîáàâëÿåì ó÷åíèêîâ è ñâÿçûâàåì èõ ñ îáúåêòàìè êëàññîâ
            Repository.Students.AddRange(new List<Student>
            {
                new Student { StudentId = 1, FullName = "Ivanov Ivan Ivanovich", Passport = "1234 567890", BirthDate = new DateTime(2005, 1, 15), ClassId = 1 },
                new Student { StudentId = 2, FullName = "Petrov Petr Petrovich", Passport = "2345 678901", BirthDate = new DateTime(2006, 2, 20), ClassId = 1 },
                new Student { StudentId = 3, FullName = "Sidorov Oleg Alexandrovich", Passport = "3456 789012", BirthDate = new DateTime(2005, 3, 10), ClassId = 1 },
                new Student { StudentId = 4, FullName = "Kuznetsov Alexey Sergeyevich", Passport = "4567 890123", BirthDate = new DateTime(2004, 4, 25), ClassId = 1 },
                new Student { StudentId = 5, FullName = "Smirnova Olga Andreevna", Passport = "5678 901234", BirthDate = new DateTime(2006, 5, 5), ClassId = 1 },
                new Student { StudentId = 6, FullName = "Fedorova Anna Mikhailovna", Passport = "6789 012345", BirthDate = new DateTime(2005, 6, 15), ClassId = 2 },
                new Student { StudentId = 7, FullName = "Morozov Artem Valeryevich", Passport = "7890 123456", BirthDate = new DateTime(2004, 7, 10), ClassId = 2 },
                new Student { StudentId = 8, FullName = "Vasiliev Nikolay Ivanovich", Passport = "8901 234567", BirthDate = new DateTime(2006, 8, 20), ClassId = 2 },
                new Student { StudentId = 9, FullName = "Mikhailova Tatyana Nikolaevna", Passport = "9012 345678", BirthDate = new DateTime(2005, 9, 30), ClassId = 2 },
                new Student { StudentId = 10, FullName = "Egorov Sergey Vladimirovich", Passport = "0123 456789", BirthDate = new DateTime(2004, 10, 15), ClassId = 2 },
                new Student { StudentId = 11, FullName = "Kovalenko Viktor Arkadyevich", Passport = "1234 567890", BirthDate = new DateTime(2006, 11, 5), ClassId = 2 }

});


            // Äîáàâëÿåì ïðåäìåòû
            Repository.Subjects.AddRange(new List<Subject>
            {
                new Subject { SubjectId = 1, Name = "Ìàòåìàòèêà", AcademicYear = 2024 },
                new Subject { SubjectId = 2, Name = "Ôèçèêà", AcademicYear = 2024 },
                new Subject { SubjectId = 3, Name = "Èñòîðèÿ", AcademicYear = 2024 },
                new Subject { SubjectId = 4, Name = "Èíôîðìàòèêà", AcademicYear = 2024 }
            });

            // Äîáàâëÿåì îöåíêè
            Repository.Grades.AddRange(new List<Grade>
            {
                // Îöåíêè ïî ìàòåìàòèêå
                new Grade { GradeId = 1, StudentId = 1, SubjectId = 1, Date = DateTime.Now, Value = 4 },
                new Grade { GradeId = 2, StudentId = 2, SubjectId = 1, Date = DateTime.Now.AddDays(-1), Value = 5 },
                new Grade { GradeId = 3, StudentId = 3, SubjectId = 1, Date = DateTime.Now, Value = 4 },
                new Grade { GradeId = 4, StudentId = 4, SubjectId = 1, Date = DateTime.Now.AddDays(-2), Value = 3 },
                new Grade { GradeId = 5, StudentId = 5, SubjectId = 1, Date = DateTime.Now.AddDays(-3), Value = 5 },

                // Îöåíêè ïî ôèçèêå
                new Grade { GradeId = 6, StudentId = 6, SubjectId = 2, Date = DateTime.Now, Value = 4 },
                new Grade { GradeId = 7, StudentId = 7, SubjectId = 2, Date = DateTime.Now, Value = 5 },
                new Grade { GradeId = 8, StudentId = 8, SubjectId = 2, Date = DateTime.Now.AddDays(-1), Value = 3 },
                new Grade { GradeId = 9, StudentId = 9, SubjectId = 2, Date = DateTime.Now.AddDays(-2), Value = 4 },
                new Grade { GradeId = 10, StudentId = 10, SubjectId = 2, Date = DateTime.Now, Value = 5 },

                // Îöåíêè ïî èñòîðèè
                new Grade { GradeId = 11, StudentId = 1, SubjectId = 3, Date = DateTime.Now, Value = 4 },
                new Grade { GradeId = 12, StudentId = 2, SubjectId = 3, Date = DateTime.Now.AddDays(-1), Value = 5 },
                new Grade { GradeId = 13, StudentId = 3, SubjectId = 3, Date = DateTime.Now.AddDays(-2), Value = 4 },
                new Grade { GradeId = 14, StudentId = 4, SubjectId = 3, Date = DateTime.Now.AddDays(-3), Value = 4 },
                new Grade { GradeId = 15, StudentId = 5, SubjectId = 3, Date = DateTime.Now, Value = 5 },

                // Îöåíêè ïî èíôîðìàòèêå
                new Grade { GradeId = 16, StudentId = 6, SubjectId = 4, Date = DateTime.Now, Value = 5 },
                new Grade { GradeId = 17, StudentId = 7, SubjectId = 4, Date = DateTime.Now.AddDays(-1), Value = 4 },
                new Grade { GradeId = 18, StudentId = 8, SubjectId = 4, Date = DateTime.Now.AddDays(-2), Value = 4 },
                new Grade { GradeId = 19, StudentId = 9, SubjectId = 4, Date = DateTime.Now, Value = 4 },
                new Grade { GradeId = 20, StudentId = 10, SubjectId = 4, Date = DateTime.Now, Value = 5 }
            });
        }
    }
}
