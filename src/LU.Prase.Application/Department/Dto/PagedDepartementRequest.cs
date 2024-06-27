﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Department.Dto
{
    public class PagedDepartementRequest : IPagedResultRequest
    {
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
