using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;
using RadencyBooks.Infrastructure;

namespace RadencyBooks.WEB;

public static class StartupExtensions
{
    public static IApplicationBuilder AddSeedData(this IApplicationBuilder applicationBuilder)
    {
        var services = applicationBuilder.ApplicationServices;
        var lifetime = services.GetRequiredService<IHostApplicationLifetime>();
        lifetime.ApplicationStarted.Register(
            () =>
            {
                async Task SeedData()
                {
                    using var ser = applicationBuilder.ApplicationServices.CreateScope();
                    var repository = ser.ServiceProvider.GetRequiredService<IRepository<Book>>();
                    
                    await repository.AddRangeAsync(new List<Book>
                    {
                        new ()  {
                            Id = 1,
                            Author = "Троелсен",
                            Content = "Якісь контент",
                            Cover = "Тверда",
                            Genre = "IT",
                            Ratings = new List<Rating>
                            {
                                new()
                                {
                                    Id = 1,
                                    Score = 5
                                },
                                new()
                                {
                                    Id = 2,
                                    Score = 4
                                }
                            },
                            Reviews = new List<Review>
                            {
                                new()
                                {
                                    Id = 1,
                                    Message = "Крута книжка, но пітон всерівно краще!",
                                    Reviewer = "Андрій 7 клас"
                                },
                                new()
                                {
                                    Id = 2,
                                    Reviewer = "Дед",
                                    Message = "Перший раз читав коли був маслєнком, зараз я крутий!"
                                }
                            },
                            Title = "Мова програмування C#9 і платформа .NET 5"
                        },
                        new()
                        {
                            Id = 2,
                            Author = "Ріхтер",
                            Content = "Якісь контент 2",
                            Cover = "Тверда",
                            Genre = "IT",
                            Ratings = new List<Rating>
                            {
                                new()
                                {
                                    Id = 3,
                                    Score = 5
                                },
                                new()
                                {
                                    Id = 4,
                                    Score = 4
                                }
                            },
                            Reviews = new List<Review>
                            {
                                new()
                                {
                                    Id = 3,
                                    Message = "Круто но це не ЖВМ",
                                    Reviewer = "Сильний читач"
                                },
                                new()
                                {
                                    Id = 4,
                                    Reviewer = "Слабий",
                                    Message = "Ріхтер крут"
                                }
                            },
                            Title = ".NET Framework і CLR"
                        },
                        new()
                        {
                            Id = 3,
                            Author = "Тепляков",
                            Content = "Якісь контент 3",
                            Cover = "М'яка",
                            Genre = "IT",
                            Ratings = new List<Rating>
                            {
                                new()
                                {
                                    Id = 5,
                                    Score = 5
                                },
                                new()
                                {
                                    Id = 6,
                                    Score = 5
                                }
                            },
                            Reviews = new List<Review>
                            {
                                new()
                                {
                                    Id = 5,
                                    Message = "дякую тепер у мене патерн головного мозку",
                                    Reviewer = "якісь джун"
                                },
                                new()
                                {
                                    Id = 6,
                                    Reviewer = "якісь мідл",
                                    Message = "намальна но книжка маскальська"
                                }
                            },
                            Title = "Ну там патерни програміруванія"
                        }
                        
                    }
                    );
                }

                _ = SeedData();
            });
        return applicationBuilder;
    }
}