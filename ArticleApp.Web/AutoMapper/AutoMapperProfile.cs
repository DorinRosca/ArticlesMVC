using ArticleApp.Web.UI.Article.MediatR.Commands.Create;
using ArticleApp.Web.UI.Article.MediatR.Commands.Update;
using ArticleApp.Web.UI.Article.Models;
using ArticleApp.Web.UI.Payment.MediatR.Commands.Create;
using AutoMapper;
namespace ArticleApp.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateArticleCommand, EntityFramework.Entities.Article>().ReverseMap();
            CreateMap<UpdateArticleCommand, EntityFramework.Entities.Article>().ReverseMap();
            CreateMap<EntityFramework.Entities.Article, ArticleViewModel>().ReverseMap();
            CreateMap<CreatePaymentCommand, EntityFramework.Entities.Payment>().ReverseMap();

        }
    }
}
