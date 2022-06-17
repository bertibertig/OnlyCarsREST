using OnlyCarsREST;
using OnlyCarsREST.Controller;
using OnlyCarsREST.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => {
    options.InputFormatters.Insert(0, OnlyCarsJPIF.GetJsonPatchInputFormatter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseHttpsRedirection();

app.MapGet("/cars", async () => {
    var cars = new List<Car>();
    await using (OnlyCarsContext db = new OnlyCarsContext()) {
        cars = db.Cars.ToList();
    }
    return cars;
}).WithName("GetCars");

app.MapGet("/parkingSpaces", async () => {
    var parkingSpaces = new List<ParkingPlace>();
    await using (OnlyCarsContext db = new OnlyCarsContext()) {
        parkingSpaces = db.ParkingPlaces.ToList();
    }
    return parkingSpaces;
}).WithName("GetParkingSpaces");

app.MapGet("/occupiedSpaces", async () => {
    var occSpaces = new List<ParkingPlace>();
    await using (OnlyCarsContext db = new OnlyCarsContext()) {
        occSpaces = db.ParkingPlaces.Where(x => x.Occupied == 1).ToList();
    }
    return occSpaces;
}).WithName("GetOccupiedParkingSpaces");

app.MapGet("/unoccupiedSpaces", async () => {
    var unOccSpaces = new List<ParkingPlace>();
    await using (OnlyCarsContext db = new OnlyCarsContext()) {
        unOccSpaces = db.ParkingPlaces.Where(x => x.Occupied == 0).ToList();
    }
    return unOccSpaces;
}).WithName("GetUnOccupiedParkingSpaces");

//MQTTController.CreateMQTTPublisher();

//MQTTController.CreateMQTTSubscriber();

app.Run();