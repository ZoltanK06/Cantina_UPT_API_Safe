using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class PortionService: IPortionService
{
  public readonly IReadRepository<Portion> _portionRepo;

  public PortionService(IReadRepository<Portion> portionRepo)
  {
    _portionRepo = portionRepo;
  }

  public async Task<Portion> GetPortionById(int portionId)
  {
    return await _portionRepo.GetByIdAsync(portionId);
  }

  public async Task<List<Portion>> GetAllPortions()
  {
    return await _portionRepo.ListAsync();
  }
}
