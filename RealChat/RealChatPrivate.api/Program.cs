using RealChatPrivate.api.SignalR.MessagePrivate;
using Repositery.Implemint.SignalR;
using Repositery.Interface.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//real By WebSocet
builder.Services.AddSignalR();

#region signlR

//builder.Services.AddTransient<IPrivateMessageRepository, PrivateMessageRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("chatHub");
});

app.Run();
