using housefunder.Helper;
using housefunder.Models;
using housefunder.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

/*app.Use(async (context, next) =>
{
    if (context.Request.RouteValues["controller"].Equals("Login") || context.Request.RouteValues["controller"].Equals("Register") || context.Request.RouteValues["controller"].Equals("FilterProjects") || context.Request.RouteValues["controller"].Equals("Partnerships") || context.Request.RouteValues["controller"].Equals("FinancersQuery"))
    {
        await next.Invoke();
    }
    else
    {
        string token = context.Request.Headers["Token"];
        using (var db = new DbHelper())
        {
            String email = TokenManager.ValidateToken(token);
            if (email != null)
            {
                foreach (Users user in db.users)
                {
                    if (user.email.Equals(email))
                    {
                        await next.Invoke();
                    }
                }
            }

        }
    }
});*/

app.MapControllers();

app.Run();
