using Chatty.Api.Hubs;
using noam2.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ContactsService>(new ContactsService());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All",
    builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(x =>true);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Allow All");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/Hub/ChatHub");
app.Run();
