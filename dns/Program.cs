// Proxy to google's DNS
using DNS.Server;

MasterFile masterFile = new MasterFile();
DnsServer server = new DnsServer(masterFile, "8.8.8.8");

// Resolve these domain to localhost
masterFile.AddIPAddressResourceRecord("google.com", "127.0.0.1");
masterFile.AddIPAddressResourceRecord("github.com", "127.0.0.1");

// Log every request
server.Requested += (sender, e) => Console.WriteLine(e.Request);
// On every successful request log the request and the response
server.Responded += (sender, e) => Console.WriteLine("{0} => {1}", e.Request, e.Response);
// Log errors
server.Errored += (sender, e) => Console.WriteLine(e.Exception.Message);

// Start the server (by default it listens on port 53)
await server.Listen();