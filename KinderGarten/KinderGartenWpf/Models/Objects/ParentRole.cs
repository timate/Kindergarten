﻿using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace KinderGartenWpf.Models.Objects
{
    public class ParentRole : ViewModelBase
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}