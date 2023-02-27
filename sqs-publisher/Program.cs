using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;

var sqsClient = new AmazonSQSClient();
var newCustomer = new CustomerCreated{
    Id = 12,
    Name = "Customer 1"
};

var url = await sqsClient.GetQueueUrlAsync("Customers");
var request = new SendMessageRequest{
    QueueUrl = url.QueueUrl,
    MessageBody = JsonSerializer.Serialize(newCustomer)
};

var response = await sqsClient.SendMessageAsync(request); 