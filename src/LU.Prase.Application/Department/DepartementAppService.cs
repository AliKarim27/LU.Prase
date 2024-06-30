using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using LU.Prase.Authorization.Users;
using LU.Prase.Department.Dto;
using LU.Prase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LU.Prase.Department
{
    public class DepartementAppService : AsyncCrudAppService<Departement, DepartementDto, long, PagedDepartementRequest, CreateDepartementDto, UpdateDepartementDto>, IDepartementAppService
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<User, long> _responsiblesRepository;
        private readonly IRepository<Departement, long> _repository;

        public DepartementAppService(IRepository<Departement, long> repository, IObjectMapper objectMapper, IRepository<User, long> responsiblesRepository) : base(repository)
        {
            _objectMapper = objectMapper;
            _responsiblesRepository = responsiblesRepository;
            _repository = repository;
        }

        protected override IQueryable<Departement> CreateFilteredQuery(PagedDepartementRequest input)
        {

            return base.CreateFilteredQuery(input).Include(x => x.Responsibles);
        }
        public async Task<List<ResponsibleDto>> GetAllResponsiblesAsync()
        {
            return _objectMapper.Map<List<ResponsibleDto>>(await _responsiblesRepository.GetAll().Where(x => !(x is Student)).ToListAsync());
        }


        public override async Task<DepartementDto> UpdateAsync(UpdateDepartementDto input)
        {
            //return base.UpdateAsync(input);
            var departement = await _repository.GetAllIncluding(x => x.Responsibles).FirstOrDefaultAsync(x => x.Id == input.Id);
            departement.Name = input.Name;
            departement.Address = input.Address;
            departement.Description = input.Description;
            departement.Responsibles = [];
            foreach (var userid in input.Responsibles)
            {
                var user = await _responsiblesRepository.FirstOrDefaultAsync(userid.Id);

                if (user != null)
                {
                    departement.Responsibles.Add(user);
                }
                else
                {
                    throw new UserFriendlyException("no user with this id");
                }
            }
            return _objectMapper.Map<DepartementDto>(departement);
        }
        public override async Task<DepartementDto> GetAsync(EntityDto<long> input)
        {
            return _objectMapper.Map<DepartementDto>(await Repository.GetAll().Include(x => x.Responsibles).FirstOrDefaultAsync(x => x.Id == input.Id));
        }

        public override async Task<DepartementDto> CreateAsync(CreateDepartementDto input)
        {
            var departement = _objectMapper.Map<Departement>(input);
            departement.Responsibles = [];
            foreach (var userId in input.Responsibles)
            {
                var user = await _responsiblesRepository.FirstOrDefaultAsync(userId.Id);

                if (user != null)
                {
                    departement.Responsibles.Add(user);
                }
                else
                {
                    throw new UserFriendlyException("No User With This Id");
                }
            }
            return _objectMapper.Map<DepartementDto>(await Repository.InsertAsync(departement));
        }
    }
}
