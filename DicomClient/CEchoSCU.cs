using FellowOakDicom.Network;
using FellowOakDicom.Network.Client;

namespace DicomClient;

/// <summary>
/// Service Class User.
/// </summary>
public class CEchoSCU
{
    public static void Execute()
    {
        IDicomClient client = DicomClientFactory.Create("127.0.0.1", 12345, false, "SCU", "ANY-SCP");
        client.NegotiateAsyncOps();
        client.AddRequestAsync(new DicomCEchoRequest());
        client.SendAsync();
        Console.ReadLine();
    }
}
