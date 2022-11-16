using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager
{
    public class CategoryManager :
        BaseManager<Category, Category, Category, Category>
        , ICategoryManager
    {
        public CategoryManager(AqaryDataBaseContext context, 
            IMapper mapper) : base(context, mapper)
        {
        }        
    }
}
