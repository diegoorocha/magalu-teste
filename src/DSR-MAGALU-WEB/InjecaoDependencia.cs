using AutoMapper;
using DSR_MAGALU_BUSINESS.AutoMapper;
using DSR_MAGALU_BUSINESS.Services;
using DSR_MAGALU_BUSINESS.Services.Interface;
using DSR_MAGALU_DATA.Repositories;
using DSR_MAGALU_DATA.Repositories.Interface;
using DSR_MAGALU_WEB.NotificationToaster;
using DSR_MAGALU_WEB.NotificationToaster.Interface;

namespace DSR_MAGALU_WEB
{
    public static class InjecaoDependencia
    {
        public static void Injetar(IServiceCollection services)
        {
            Repositorios(services);
            Servicos(services);
        }

        private static void Repositorios(IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }

        private static void Servicos(IServiceCollection services)
        {
            #region Auto Mapper

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion Auto Mapper
            services.AddScoped<IToasterService, ToasterService>();
            services.AddTransient<IClienteService, ClienteService>();
        }
    }
}
