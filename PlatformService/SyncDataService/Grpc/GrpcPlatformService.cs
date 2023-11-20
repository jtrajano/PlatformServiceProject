using AutoMapper;
using Grpc.Core;
using PlatformService.Core.Interfaces;

namespace PlatformService.SyncDataService.Grpc;

public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
{
        private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public GrpcPlatformService(IPlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override Task<PlatformResponse> GetAllPlatforms(GetAllRequest request, ServerCallContext context)
    {
        var response = new PlatformResponse();

        var platforms = _repository.ListAll();

        foreach (var item in platforms)
        {
            response.Platform.Add(_mapper.Map<GrpcPlatformModel>(item));
        }

        return Task.FromResult(response);

    }

}