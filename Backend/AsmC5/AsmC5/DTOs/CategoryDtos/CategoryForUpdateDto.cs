﻿using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.CategoryDtos
{
    public class CategoryForUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
