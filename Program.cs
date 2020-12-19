using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlterdataVotador
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
/*wwwroot: estão os estilos CSS - gerenciador JS - Imagesn - libs. 
css
images
js
lib

Controllers: os controladores que irão interagir com os botões e marcações no front.
HomeController---frontEnd principal

Views: Telas da aplicação, organizada pelas subPasta. cada pasta está definida com suas relações com base.
Home-- Contorlador da Tela principal Home
Share- paginas compartilhadas por todo projeto. estarei deixando dentro por padrão Home

 */