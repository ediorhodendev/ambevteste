﻿using System;

namespace Ambev.DeveloperEvaluation.Application.Branches.Dtos
{
    public class BranchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
       
    }
}
