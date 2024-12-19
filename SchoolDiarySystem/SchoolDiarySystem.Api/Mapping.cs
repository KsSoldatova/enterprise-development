﻿using AutoMapper;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Api
{
    /// <summary>
    /// Настройка маппинга между моделями и DTO.
    /// </summary>
    public class Mapping : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Mapping"/>.
        /// </summary>
        public Mapping()
        {
            // Настройка маппинга для студентов
            CreateMap<Student, StudentGetDto>().ReverseMap();
            CreateMap<StudentPostDto, Student>();

            // Настройка маппинга для школьных классов
            CreateMap<SchoolClass, SchoolClassGetDto>().ReverseMap();
            CreateMap<StudentPostDto, SchoolClass>();

            // Настройка маппинга для оценок
            CreateMap<Grade, GradeGetDto>().ReverseMap();
            CreateMap<GradePostDto, Grade>();

            // Настройка маппинга для предметов
            CreateMap<Subject, SubjectGetDto>().ReverseMap();
            CreateMap<SubjectPostDto, Subject>();
        }
    }
}