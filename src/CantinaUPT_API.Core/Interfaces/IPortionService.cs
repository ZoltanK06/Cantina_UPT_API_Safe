using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface IPortionService
{
  Task<Portion> GetPortionById(int portionId);
  Task<List<Portion>> GetAllPortions();
}
