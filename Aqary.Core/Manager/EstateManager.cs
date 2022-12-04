using Aqary.Core.Manager.Interface;
using Aqary.DataAccessLayer.Models;
using Aqary.DTO.Dtos.BaseEntity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aqary.Common.Extensions;
using Aqary.DTO.Dtos.User;
using Aqary.DTO.Dtos;
using examBaraaDb.Common.Helpers;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Aqary.Core.Manager
{
    public class EstateManager :
        BaseManager<Estate, CreateEstateDto, UpdateEstateDto, Estate>
        , IEstateManager
    {
        private readonly AqaryDataBaseContext _context;
        private readonly IMapper _mapper;
        public EstateManager(AqaryDataBaseContext context,
            IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResponseEstateDto GetAllFilterAsync(int page = 1, int pageSize = 10, string searchText = "", string sortColumn = "", string sortDirection = "ascending")
        {
            var queryRes = _context.Estates.
                Include(x=> x.IdCategoryNavigation).
                Include(c=> c.Attachments)
               .Where(a => string.IsNullOrWhiteSpace(searchText)
               || (a.Name.Contains(searchText) ||
               a.Description.Contains(searchText)||
               a.IdCategoryNavigation.Name.Contains(searchText)));

            if (!string.IsNullOrWhiteSpace(sortColumn) && sortDirection.ToLower().Equals("ascending"))
            {
                queryRes = queryRes.OrderBy(sortColumn);
            }
            else if (!string.IsNullOrWhiteSpace(sortColumn) && sortDirection.ToLower().Equals("descending"))
            {
                queryRes = queryRes.OrderByDescending(sortColumn);
            }

            var res = queryRes.GetPaged(page, pageSize);

            var userids = res.Data
                .Select(a => a.IdUser)
                .Distinct()
                .ToList();

            var users = _context.ApplicationUsers
                .Where(a => userids.Contains(a.Id))
                .ToDictionary(a => a.Id, x => _mapper.Map<ResponseUserDto>(x));
            ResponseEstateDto data = new ResponseEstateDto
            {
                Estates = _mapper.Map<PagedResult<EstateDto>>(res),
                Users = users
            };
            data.Estates.Sortable.Add("Id", "Id");
            data.Estates.Sortable.Add("Salary", "Salary");

            return data;
        }

        public override async Task<Estate> CeateAsync(CreateEstateDto entity)
        {
            var result = await base.CeateAsync(entity);
            if (entity.AttachmentsString != null)
            {
                foreach(var current in entity.AttachmentsString)
                {
                    var attachment = new Attachment();
                    attachment.IdEstate = result.Id;
                    var baseUrl = "https://localhost:44344";
                    var url = Helper.SaveImage(current, "profileImages");
                    attachment.ImageString = $@"{baseUrl}/{url}";
                    //attachment.ImageString = $@"{baseUrl}/api/estate/fileretrive/attachment?filename={url}";
                    await _context.Attachments.AddAsync(attachment);
                    await _context.SaveChangesAsync();
                    result.Attachments.Add(attachment);
                }
            }
            return result;
        }

        public byte[] Retrive(string fileName)
        {
            var folderPath = Directory.GetCurrentDirectory();
            folderPath = $@"{folderPath}\{fileName}";
            var byteArray = File.ReadAllBytes(folderPath);
            return byteArray;
        }
    }
}
