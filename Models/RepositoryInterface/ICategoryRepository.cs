﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    interface ICategoryRepository
    {
        Category GetCategory(int Id);
        IEnumerable<Category> GetAllCategory();
        Category AddCategory(Category user);
        Category UpdateCategory(Category user);
        Category DeleteCategory(int id);
    }
}
