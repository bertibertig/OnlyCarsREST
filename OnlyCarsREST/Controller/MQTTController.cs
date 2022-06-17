using MQTTnet;
using MQTTnet.Client;
using System.Text;

namespace OnlyCarsREST.Controller {
    public class MQTTController {
        public static async void CreateMQTTPublisher() {
            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder().WithClientId(Guid.NewGuid().ToString()).WithTcpServer("broker.hivemq.com", 1883).WithCleanSession().Build();
            
            await client.ConnectAsync(options);
            client.ConnectedAsync += Client_ConnectedAsync;
            client.DisconnectedAsync += Client_DisconnectedAsync;

            Console.WriteLine("Press a key to publish the message");
            Console.ReadLine();

            await PublishMessageAsync(client);

            await client.DisconnectAsync();
        }

        private static Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg) {
            return new Task(() => { Console.WriteLine("Disconnected"); });
        }

        private static Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg) {
            return new Task(() => { Console.WriteLine("Connected"); });
        }

        private static async Task PublishMessageAsync(IMqttClient client) {
            string messagePayload = "Test";
            var message = new MqttApplicationMessageBuilder().WithTopic("MQTTTEsting12345").WithPayload(messagePayload).WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).Build();
            if(client.IsConnected) {
                await client.PublishAsync(message);
            }
        }

        public static async void CreateMQTTSubscriber() {
            var mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder().WithClientId(Guid.NewGuid().ToString()).WithTcpServer("broker.hivemq.com", 1883).WithCleanSession().Build();
            await client.ConnectAsync(options);
            client.ConnectedAsync += Client_ConnectedAsync1; ;
            client.DisconnectedAsync += Client_DisconnectedAsync;

            

            await client.ConnectAsync(options);
            Console.ReadLine();

            await client.DisconnectAsync();
        }

        private static Task Client_ConnectedAsync1(MqttClientConnectedEventArgs arg) {
            throw new NotImplementedException();
        }

        private static Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg) {
            return new Task(() => {
                Console.WriteLine("Message: " + Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
            });
        }
    }
}
