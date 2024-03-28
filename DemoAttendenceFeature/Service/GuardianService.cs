using AutoMapper;
using DemoAttendenceFeature.Dtos.Guardian;
using DemoAttendenceFeature.Entities;
using DemoAttendenceFeature.Infrastructure.Interface;

namespace DemoAttendenceFeature.Service
{
    public class GuardianService
    {
        private readonly IGuardianRepository _guardianRepository;
        private readonly IMapper _mapper;
        public GuardianService(IGuardianRepository guardianRepository, IMapper mapper)
        {
            _guardianRepository = guardianRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateGuardian(AddRequestGuardianDto requestGuradianDto)
        {
            var guardian=_mapper.Map<Guardian>(requestGuradianDto);
            var guardianId = await _guardianRepository.CreateGuardian(guardian);
            return guardianId;
        }

        public async Task<GetResponseGuardianDto?> GetGuardian(int id)
        {
            var guardian = await _guardianRepository.GetGuardianById(id);
            if (guardian!=null)
            {
                var guardianDto=_mapper.Map<GetResponseGuardianDto>(guardian);
                return guardianDto;
            }
            return null;
        }

    }
}
