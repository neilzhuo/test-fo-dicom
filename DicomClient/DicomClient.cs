using FellowOakDicom.Network;
using FellowOakDicom.Network.Client;

namespace DicomClient;

/// <summary>
/// Service Class User.
/// </summary>
public class DicomClient
{
    static void Main(string[] args)
    {
        //CEchoSCU.Execute();
        CStoreSCU.Execute();
    }
}
