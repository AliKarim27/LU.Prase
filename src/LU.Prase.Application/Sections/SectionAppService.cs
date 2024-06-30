using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using LU.Prase.Authorization.Users;
using LU.Prase.Sections.Dto;
using LU.Prase.Entities;
using LU.Prase.Sections.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Sections
{
    public class SectionAppService : AsyncCrudAppService<Section, SectionDto, long, PagedSectionRequest, CreateSectionDto, UpdateSectionDto>, ISectionAppService
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<User, long> _responsiblesRepository;
        private readonly IRepository<Section, long> _repository;
        private readonly IRepository<Departement, long> _departementRepository;
        public SectionAppService(IRepository<Section, long> repository, IObjectMapper objectMapper, IRepository<User, long> responsiblesRepository, IRepository<Departement, long> departementRepository) : base(repository)
        {
            _objectMapper = objectMapper;
            _responsiblesRepository = responsiblesRepository;
            _repository = repository;
            _departementRepository = departementRepository;
        }
        protected override IQueryable<Section> CreateFilteredQuery(PagedSectionRequest input)
        {

            return base.CreateFilteredQuery(input).Include(x => x.Responsibles).Include(x=>x.Departement);
        }
        public async Task<List<ResponsibleDto>> GetAllResponsiblesAsync()
        {
            return _objectMapper.Map<List<ResponsibleDto>>(await _responsiblesRepository.GetAll().Where(x => !(x is Student)).ToListAsync());
        }


        public override async Task<SectionDto> UpdateAsync(UpdateSectionDto input)
        {
            //return base.UpdateAsync(input);
            var section = await _repository.GetAllIncluding(x => x.Responsibles).Include(x=>x.Departement).FirstOrDefaultAsync(x => x.Id == input.Id);
            section.Responsibles = [];
            section.Description = input.Description;
            section.Name = input.Name;
            foreach (var userid in input.Responsibles)
            {
                var user = await _responsiblesRepository.FirstOrDefaultAsync(userid.Id);

                if (user != null)
                {
                    section.Responsibles.Add(user);
                }
                else
                {
                    throw new UserFriendlyException("no user with this id");
                }
            }
            section.Departement = await _departementRepository.FirstOrDefaultAsync(x => x.Id == input.DepartementId);
            return _objectMapper.Map<SectionDto>(section);
        }
        public async Task<List<DepartementDto>> GetDepartementsAsync()
        {
            return _objectMapper.Map<List<DepartementDto>>(await _departementRepository.GetAllListAsync());
        }
        public override async Task<SectionDto> GetAsync(EntityDto<long> input)
        {
            return _objectMapper.Map<SectionDto>(await Repository.GetAll().Include(x => x.Responsibles).Include(x=>x.Departement).FirstOrDefaultAsync(x => x.Id == input.Id));
        }
        public override async Task<SectionDto> CreateAsync(CreateSectionDto input)
        {
            var section = _objectMapper.Map<Section>(input);
            section.Departement = await _departementRepository.FirstOrDefaultAsync(x=>x.Id  == input.DepartementId);
            section.Responsibles = [];
            foreach (var userId in input.Responsibles)
            {
                var user = await _responsiblesRepository.FirstOrDefaultAsync(userId.Id);

                if (user != null)
                {
                    section.Responsibles.Add(user);
                }
                else
                {
                    throw new UserFriendlyException("No User With This Id");
                }
            }
            return _objectMapper.Map<SectionDto>(await Repository.InsertAsync(section));
        }
    }
}
