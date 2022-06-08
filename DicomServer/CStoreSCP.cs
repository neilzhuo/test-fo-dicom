using FellowOakDicom;
using FellowOakDicom.Log;
using FellowOakDicom.Network;
using System.Text;

namespace DicomServer;

/// <summary>
/// Service Class Provider.
/// </summary>
public class CStoreSCP
{
    public static void Execute()
    {
        var server = DicomServerFactory.Create<CStoreSCPProvider>(12345);
        Console.ReadLine();
    }
}

class CStoreSCPProvider : DicomService, IDicomServiceProvider, IDicomCStoreProvider
{
    private DicomTransferSyntax[] _acceptedImageTransferSyntaxes =
    {
        DicomTransferSyntax.ExplicitVRLittleEndian,
        DicomTransferSyntax.ExplicitVRBigEndian,
        DicomTransferSyntax.ImplicitVRLittleEndian
    };

    public CStoreSCPProvider(INetworkStream stream, Encoding fallbackEncoding, Logger log, DicomServiceDependencies dependencies)
        : base(stream, fallbackEncoding, log, dependencies)
    {
    }

    public Task<DicomCStoreResponse> OnCStoreRequestAsync(DicomCStoreRequest request) => Task.FromResult(new DicomCStoreResponse(request, DicomStatus.Success));

    public Task OnCStoreRequestExceptionAsync(string tempFileName, Exception e) => Task.CompletedTask;

    public Task OnReceiveAssociationRequestAsync(DicomAssociation association)
    {
        foreach (var pc in association.PresentationContexts)
        {
            pc.AcceptTransferSyntaxes(_acceptedImageTransferSyntaxes);
        }

        return SendAssociationAcceptAsync(association);
    }

    public Task OnReceiveAssociationReleaseRequestAsync()
    {
        return SendAssociationReleaseResponseAsync();
    }

    public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
    {
    }

    public void OnConnectionClosed(Exception exception)
    {
    }
}