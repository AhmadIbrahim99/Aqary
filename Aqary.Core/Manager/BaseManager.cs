using Aqary.Core.Manager.Interface;
using Aqary.Core.Repository;
using Aqary.DataAccessLayer.Models;
using Aqary.DataAccessLayer.Models.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager
{
    public class BaseManager<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO> :
        Repository<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>,
        IBaseManager<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
        where T : class, IBaseEntity, new()

    {
        public BaseManager(AqaryDataBaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
