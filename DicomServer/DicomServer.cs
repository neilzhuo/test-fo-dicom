using FellowOakDicom.Network;

namespace DicomServer;

/// <summary>
/// Service Class Provider.
/// </summary>
public class DicomServer
{
    static void Main(string[] args)
    {
        //CEchoSCP.Execute();
        CStoreSCP.Execute();
    }
}
