using Autofac;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.Services;

namespace CantinaUPT_API.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
