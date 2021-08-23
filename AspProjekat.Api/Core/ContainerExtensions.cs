using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.Emails;
using AspProjekat.Application.Queries;
using AspProjekat.DataAccess;
using AspProjekat.Implementation.Commands;
using AspProjekat.Implementation.Email;
using AspProjekat.Implementation.Logging;
using AspProjekat.Implementation.Queries;
using AspProjekat.Implementation.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Api.Core
{
	public static class ContainerExtensions
	{
		public static void AddUsesCases(this IServiceCollection services)
		{
			services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
			services.AddTransient<IGetCategoriesQuery, EfGetCategoryQuery>();
			services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
			services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
			services.AddTransient<IGetOneCategoriesQuery, EfGetOneCategoryQuery>();
			services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

			services.AddTransient<ICreateBlogCommand, EfCreateBlogCommand>();
			services.AddTransient<IDeleteBlogCommand, EfDeleteBlogCommand>();
			services.AddTransient<IUpdateBlogCommand, EfUpdateBlogCommand>();
			services.AddTransient<IGetOneBlogQuery, EfGetOneBlogQuery>();
			services.AddTransient<IGetBlogsQuery, EfGetBlogsQuery>();

			services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
			services.AddTransient<IEmailSender, SmtpEmailSender>();
			services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
			services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
			services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
			services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();

			services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
			services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
			services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
			services.AddTransient<IGetCommentQuery, EfGetCommentQuery>();

			services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();

			services.AddTransient<AspProjekatContext>();
			services.AddTransient<UseCaseExecutor>();
			services.AddTransient<CreateCategoryValidator>();
			services.AddTransient<CreateBlogValidator>();
			services.AddTransient<UpdateBlogValidator>();
			services.AddTransient<RegisterUserValidator>();
			services.AddTransient<UpdateUserValidator>();
			services.AddTransient<CreateCommentValidator>();
			services.AddTransient<JwtManager>();
			services.AddHttpContextAccessor();
		}

		public static void AddApplicationActor(this IServiceCollection services)
		{
			services.AddTransient<IApplicationActor>(x =>
			{
				var accessor = x.GetService<IHttpContextAccessor>();

				var user = accessor.HttpContext.User;

				if (user.FindFirst("ActorData") == null)
				{
					return new AnonymusActor();
				}

				var actorString = user.FindFirst("ActorData").Value;
				var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

				return actor;
			});
		}

		public static void AddJwt(this IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(cfg =>
			{
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = "asp_api",
					ValidateIssuer = true,
					ValidAudience = "Any",
					ValidateAudience = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
			});
		}
	}
}
