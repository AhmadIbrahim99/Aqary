using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Manager.Interface
{
    public interface IEstateManager : IBaseManager<Estate, CreateEstateDto, UpdateEstateDto, Estate>
    {
    }
}
