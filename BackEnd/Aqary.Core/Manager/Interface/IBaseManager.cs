using Aqary.Core.Repository.Interface;
using Aqary.DataAccessLayer.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager.Interface
{
    public interface IBaseManager<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
        :
        IRepository<T, TCreateRequestDTO, TUpdateRequestDTO, TResponseDTO>
        where T : class, IBaseEntity, new()
    {
    }
}
