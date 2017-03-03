using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nancy.Owin;
using System;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Linq;
using System.Collections.Generic;
using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Infrastructure.Domain.Queries;

namespace Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            var QueryBuilder = new QueryBuilder(null);

            var builder = new ContainerBuilder();

            var assemblies = GetReferencingAssemblies("Cmas");
            
            foreach (var assembly in assemblies)
            {
                builder
                 .RegisterAssemblyTypes(assembly)
                 .AsClosedTypesOf(typeof(ICommand<>));

               /*builder
                .RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IQuery<,>));*/
            }

            builder.RegisterType<CommandBuilder>().As<ICommandBuilder>();
            builder.RegisterType<QueryBuilder>().As<IQueryBuilder>();
            builder.RegisterType<QueryFactory>().As<IQueryFactory>();

            builder.RegisterGeneric(typeof(QueryFor<>)).As(typeof(IQueryFor<>));
            
            builder.Register<Func<Type, object>>(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                return (t) => {
                    return componentContext.Resolve(t);
                };
            });

            builder.Populate(services);
            
            var container = builder.Build();
             

            return container.Resolve<IServiceProvider>();
        }

        public static IEnumerable<Assembly> GetReferencingAssemblies(string assemblyName)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateLibrary(library, assemblyName))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }

        private static bool IsCandidateLibrary(RuntimeLibrary library, string assemblyName)
        {
            return library.Name == (assemblyName)
                || library.Dependencies.Any(d => d.Name.StartsWith(assemblyName));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy(options =>
            {
                options.Bootstrapper = new Bootstrapper(app.ApplicationServices);
            }));

        }
    }
}
