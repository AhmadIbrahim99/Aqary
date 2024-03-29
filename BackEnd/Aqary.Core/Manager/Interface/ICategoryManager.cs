﻿using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager.Interface
{
    public interface ICategoryManager : IBaseManager<Category, CreateCategoryDto, UpdateCategoryDto, Category>
    {
    }
}
