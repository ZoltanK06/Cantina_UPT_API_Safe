using Ardalis.Result;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
