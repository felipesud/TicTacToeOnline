using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TicTacToeOnline
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração dos serviços necessários para a aplicação
            // Por exemplo, serviços do Entity Framework, injeção de dependências, etc.
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configuração do pipeline de solicitação
            // Por exemplo, uso de middlewares, configuração do roteamento, etc.
        }
    }
}
