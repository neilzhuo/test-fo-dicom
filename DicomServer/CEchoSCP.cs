using FellowOakDicom.Network;

namespace DicomServer;

/// <summary>
/// Service Class Provider.
/// </summary>
public class CEchoSCP
{
    public static void Execute()
    {
        var server = DicomServerFactory.Create<DicomCEchoProvider>(12345);
        Console.ReadLine();
    }
}
