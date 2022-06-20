using System;
using System.Net;
using System.Text;
using System.Text.Json;
using MQTTnet;
using MQTTnet.Server;
using OnlyCarsREST.Models;
using Serilog;

namespace OnlyCarsREST.MQTT {
    public class Broker {
        private static int MessageCounter = 0;

        public static void StartBroker() {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithDefaultEndpointPort(707)
                .WithConnectionValidator(OnNewConnection)
                .WithApplicationMessageInterceptor(OnNewMessage);


            IMqttServer mqttServer = new MqttFactory().CreateMqttServer();

            mqttServer.StartAsync(options.Build()).GetAwaiter().GetResult();
            Console.ReadLine();
        }

        public static void OnNewConnection(MqttConnectionValidatorContext context) {
            Log.Logger.Information(
                    "New connection: ClientId = {clientId}, Endpoint = {endpoint}, CleanSession = {cleanSession}",
                    context.ClientId,
                    context.Endpoint,
                    context.CleanSession);
        }

        public static void OnNewMessage(MqttApplicationMessageInterceptorContext context) {
            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);
            
            int id = -1;
            int occupationInfo = -1;

            if(payload != null) {
                var message = payload;
                var parkingInfo = message.Split(';');
                if(parkingInfo.Count() == 2) {
                    try {
                        id = Convert.ToInt32(parkingInfo[0]);
                        occupationInfo = Convert.ToInt32(parkingInfo[1]);
                    }
                    catch(FormatException e) {
                        Log.Logger.Error("Error converting the recieved Information to ints: " + e.Message);
                    }
                    Log.Logger.Information(message);
                    if (id != -1 && occupationInfo != -1) {
                        using (OnlyCarsContext db = new OnlyCarsContext()) {
                            if (db.ParkingPlaces.Any(x => x.Id == id)) {
                                db.ParkingPlaces.FirstOrDefault(x => x.Id == id).Occupied = occupationInfo;
                            }
                            db.SaveChanges();
                        }
                        if(occupationInfo == 1) {
                            Log.Logger.Information("Parked: Car parked at parking space with id: " + id);
                        }
                        else if(occupationInfo == 0) {
                            Log.Logger.Information("Left: Car left parking space with id: " + id);
                        }
                    }
                }
            }
        }
    }
}
