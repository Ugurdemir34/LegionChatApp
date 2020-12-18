using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Utilities.Security.Jwt;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            

            builder.RegisterType<HobbyManager>().As<IHobbyService>();
            builder.RegisterType<EfHobbyDal>().As<IHobbyDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<LanguageManager>().As<ILanguageService>();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<UserLanguageManager>().As<IUserLanguageService>();
            builder.RegisterType<EfUserLanguageDal>().As<IUserLanguageDal>();

            builder.RegisterType<UserHobbyManager>().As<IUserHobbyService>();
            builder.RegisterType<EfUserHobbyDal>().As<IUserHobbyDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<RequestManager>().As<IRequestService>();
            builder.RegisterType<EfRequestDal>().As<IRequestDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

           

        }
    }
}
