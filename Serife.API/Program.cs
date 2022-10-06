using Microsoft.AspNetCore.Identity;
using Serife.Business.Concrete;
using Serife.DataLayer;
using Serife.DataLayer.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ChatAppContext>();

builder.Services.AddScoped<DalUser>();
builder.Services.AddScoped<UserManager>();

builder.Services.AddScoped<DalMessage>();
builder.Services.AddScoped<MessageManager>();

builder.Services.AddScoped<DalFriend>();
builder.Services.AddScoped<FriendManager>();

builder.Services.AddScoped<DalComplain>();
builder.Services.AddScoped<ComplainManager>();

builder.Services.AddScoped<DalGroup>();
builder.Services.AddScoped<GroupManager>();

builder.Services.AddScoped<DalGroupMember>();
builder.Services.AddScoped<GroupMemberManager>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll",
        builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true);

        });
});

//    builder.Services.AddCors(options =>
//    {
//        options.AddDefaultPolicy(builder =>
//        builder.WithOrigins("http://www.localhost:34352")
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//    });

var app = builder.Build();
app.UseCors("CorsAllowAll");



app.UseRouting();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
