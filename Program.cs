using System.Text;
using Azure.Identity;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var cred = new DefaultAzureCredential();
var uri = new Uri("https://st2937424723.blob.core.windows.net/images");
var client = new BlobContainerClient(uri, cred);
app.MapGet("/", async () => {
    var sb = new StringBuilder();
    await foreach (var blob in client.GetBlobsAsync()) {
        sb.Append(blob.Name);
        sb.Append(',');
    }
    return sb.ToString();
});

app.Run();
