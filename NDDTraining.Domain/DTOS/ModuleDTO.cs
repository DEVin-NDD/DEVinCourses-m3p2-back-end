﻿using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.DTOS
{
    public class ModuleDTO
    {
        
        public int Id { get; set; }
        public string? TitleModule { get; set; }
        public string? Link { get; set; }
        public string? Image { get; set; }
        public string? DescriptionModule { get; set; }
        public string? StatusModule { get; set; }

        public ModuleDTO()
        {
        }
        public ModuleDTO(Module module)
        {
            TitleModule = module.TitleModule;
            Link = module.Link;
            Image = module.Image;
            DescriptionModule = module.DescriptionModule;
            StatusModule = module.StatusModule;
        }
       


    }
}