using Microsoft.Extensions.DependencyInjection;
using MediatR.NotificationPublishers;
using System;

namespace CA.EShop_SQL.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection SerCollectionI)
        {
            SerCollectionI.AddMediatR(mSerConfig =>
            {
                mSerConfig.RegisterServicesFromAssemblyContaining<AssRef_Application>();
                mSerConfig.NotificationPublisher = new TaskWhenAllPublisher();
            });

            return SerCollectionI;
        }
    }
}
