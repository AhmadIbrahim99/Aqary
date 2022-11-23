using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.BaseEntity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager
{
    public class EstateManager :
        BaseManager<Estate, CreateEstateDto, UpdateEstateDto, Estate>
        , IEstateManager
    {
        public EstateManager(AqaryDataBaseContext context,
            IMapper mapper) : base(context, mapper)
        {
        }
    }
}
