using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using LU.Prase.Entities;
using LU.Prase.Machines.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LU.Prase.Machines
{
    public class MachineAppService : AsyncCrudAppService<Machine, MachineDto, long, PagedMachineRequest, CreateMachineDto, UpdateMachineDto, EntityDto<long>>
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IRepository<Section, long> _sectionRepository;
        private readonly IRepository<Machine, long> _machineRepository;
        public MachineAppService(IRepository<Machine, long> repository, IObjectMapper objectMapper, IRepository<Section, long> sectionRepository) : base(repository)
        {
            _objectMapper = objectMapper;
            _sectionRepository = sectionRepository;
            _machineRepository = repository;
        }

        public async Task<List<SectionDto>> GetSectionsAsync()
        {
            return _objectMapper.Map<List<SectionDto>>(await _sectionRepository.GetAllListAsync());
        }
        protected override IQueryable<Machine> CreateFilteredQuery(PagedMachineRequest input)
        {
            return base.CreateFilteredQuery(input).Include(x=>x.Section);
        }

        public override async Task<MachineDto> UpdateAsync(UpdateMachineDto input)
        {
            var machine = await _machineRepository.GetAllIncluding(x => x.Section).FirstOrDefaultAsync(x => x.Id == input.Id);
            machine.Notes = input.Notes;
            machine.Name = input.Name;
            machine.Section = await _sectionRepository.FirstOrDefaultAsync(x => x.Id == input.SectionId);
            return _objectMapper.Map<MachineDto>(machine);
        }
        public override async Task<MachineDto> GetAsync(EntityDto<long> input)
        {
            return _objectMapper.Map<MachineDto>(await Repository.GetAll().Include(x => x.Section).FirstOrDefaultAsync(x => x.Id == input.Id));

        }
        public override async Task<MachineDto> CreateAsync(CreateMachineDto input)
        {
            //return base.CreateAsync(input);
            var machine = _objectMapper.Map<Machine>(input);
            machine.Section = await _sectionRepository.FirstOrDefaultAsync(x => x.Id == input.SectionId);
            return _objectMapper.Map<MachineDto>(await Repository.InsertAsync(machine));
        }
    }
}
