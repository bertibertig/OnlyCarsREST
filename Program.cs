using OnlyCarsREST.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

app.MapPost("/setOccupied", async (int[] parkingSpacesIndexes) => {
    await using (OnlyCarsContext db = new OnlyCarsContext()) {
        foreach(var index in parkingSpacesIndexes) {
            var parkingSpace = db.ParkingPlaces.FirstOrDefault(x =>x.Id == index);
            if(parkingSpace == null) {
                return Results.NotFound(index);
            }
            parkingSpace.Occupied = 1;
        }
        db.SaveChanges();
    }
    return Results.Ok(parkingSpacesIndexes);
}).WithName("SetOccupied");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}