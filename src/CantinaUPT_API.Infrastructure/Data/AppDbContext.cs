﻿using System.Dynamic;
using System.Reflection;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.SharedKernel;
using CantinaUPT_API.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CantinaUPT_API.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
  public DbSet<Project> Projects => Set<Project>();

  public DbSet<Meal> Meals => Set<Meal>();
  public DbSet<Canteen> Canteens => Set<Canteen>(); 
  public DbSet<DailyMenu> DailyMenus => Set<DailyMenu>();
  public DbSet<OrderItem> OrderItems => Set<OrderItem>();
  public DbSet<User> Users => Set<User>();
  public DbSet<Order> Orders => Set<Order>();
  public DbSet<UserRoles> Roles => Set<UserRoles>();
  public DbSet<Category> Categories => Set<Category>();
  public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
  public DbSet<Portion> Portions => Set<Portion>();
  public DbSet<CategoryPictures> CategoryPictures => Set<CategoryPictures>();
  public DbSet<Card> Cards => Set<Card>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
