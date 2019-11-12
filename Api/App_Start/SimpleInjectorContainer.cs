using Domain.Comentario;
using Domain.DadosTrello;
using Domain.Membro;
using Repository.RepositoriesApiTrello;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Api.App_Start
{
    public static class SimpleInjectorContainer
    {
        private static readonly Container container = new Container();

        public static Container Build()
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            RegisterRepositories();
            RegisterServices();

            container.Verify();
            return container;
        }

        private static void RegisterRepositories()
        {
            container.Register<IDadosTrelloService, DadosTrelloService>(); 
        }

        private static void RegisterServices()
        {
            container.Register<IDadosQuadroDesenvRepository, DadosQuadroDesenvRepository>();
            container.Register<IMembroRepository, MembroRepository>(); 
            container.Register<IComentarioRepository, ComentarioRepository>();
        }
    }
}
