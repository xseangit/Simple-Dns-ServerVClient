
using DNS.Client;
using DNS.Protocol;
using DNS.Protocol.ResourceRecords;
using System.Net;

ClientRequest request = new ClientRequest("65.109.211.154");

// Request an IPv6 record for the foo.com domain
request.Questions.Add(new Question(Domain.FromString("google.com")));
request.RecursionDesired = true;

IResponse response = await request.Resolve();

// Get all the IPs for the foo.com domain
IList<IPAddress> ips = response.AnswerRecords
    .Cast<IPAddressResourceRecord>()
    .Select(r => r.IPAddress)
    .ToList();

foreach (IPAddress ip in ips)
{
    Console.WriteLine(ip.ToString());
}