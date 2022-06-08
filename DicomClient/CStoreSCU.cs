using FellowOakDicom.Network;
using FellowOakDicom.Network.Client;

namespace DicomClient;

/// <summary>
/// Service Class User.
/// </summary>
public class CStoreSCU
{
    public static void Execute()
    {
        IDicomClient client = DicomClientFactory.Create("127.0.0.1", 12345, false, "SCU", "ANY-SCP");
        client.NegotiateAsyncOps();
        client.AddRequestAsync(new DicomCStoreRequest(@"test.dcm"));
        client.SendAsync();
        Console.ReadLine();

        // After that, check file in C:\Users\admin\AppData\Local\Temp. The file name is changed, check the size of the latest file.
    }
}
