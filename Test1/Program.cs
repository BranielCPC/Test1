
using FluentNHibernate.Automapping;
using Test1;
using static FluentNHibernate.Automapping.AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Test1.Data;
using Test1.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig)); //Automates the mapping
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// All of the engineers    
app.MapGet("/api/EngineerList", (ILogger<Program> _logger) => {
    _logger.Log(LogLevel.Information, "Generating the Calender");
    return Results.Ok(ListEngine.engineers);

}).WithName("All Engineer").Produces<Engineer>(200);

//Adding to find single engineer
app.MapGet("/api/EngineerList/{ID:int}", (ILogger<Program> _logger, int Id) =>
{
    return Results.Ok(ListEngine.engineers.FirstOrDefault(u => u.Id == Id));
}).WithName("Single Engineer").Produces<Engineer>(200);

//Endpoint
app.MapPost("/api/EngineerList", async (IMapper _mapper, [FromBody] EngineCreateDTO engineer_E_DTO) => {

    if (string.IsNullOrEmpty(engineer_E_DTO.Fname))
    {
        return Results.BadRequest("Invalid Id or Name");
    }
    if (ListEngine.engineers.FirstOrDefault(u => u.Fname.ToLower() == engineer_E_DTO.Fname.ToLower()) != null)
    {
        return Results.BadRequest("Name already exisit");
    }
    //This was manual not auto
    Engineer engineer = _mapper.Map<Engineer>(engineer_E_DTO);
    //this was manual not auto
    engineer.Id = ListEngine.engineers.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
    ListEngine.engineers.Add(engineer);
    EngineerDTO engineerDTO = _mapper.Map<EngineerDTO>(engineer);

    return Results.CreatedAtRoute("Create Engineer", new { id = engineer.Id }, engineerDTO);
    // return Results.Created($"/api/EngineerList/{engineer.Id}", engineer);
}).WithName("Create Engineer").Accepts<EngineCreateDTO>("application/json").Produces<EngineerDTO>(201).Produces(400);

//add more status 
app.MapPut("/api/EngineerList", () => {

});

app.MapDelete("/api/EngineerList/Delete", (int Id) => {

}).WithName("Delete Engineer");


app.UseHttpsRedirection();

app.Run();