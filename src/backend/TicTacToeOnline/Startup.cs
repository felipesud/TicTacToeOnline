using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TicTacToeOnline
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configura��o dos servi�os necess�rios para a aplica��o
            // Por exemplo, servi�os do Entity Framework, inje��o de depend�ncias, etc.
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configura��o do pipeline de solicita��o
            // Por exemplo, uso de middlewares, configura��o do roteamento, etc.
        }
    }
}
