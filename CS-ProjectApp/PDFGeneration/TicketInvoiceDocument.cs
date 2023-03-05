using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using CS_ProjectApp.Models;
using QRCoder;

namespace CS_ProjectApp.PDFGeneration
{


    public class TicketInvoiceDocument : IDocument
    {
        public TicketSchema Invoice { get; }

        public TicketInvoiceDocument(TicketSchema invoice)
        {
            this.Invoice = invoice;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;



        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);


                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

            container.Row(row =>
            {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"Invoice #{Invoice.ticketId}").Style(titleStyle);

                column.Item().Text(text =>
                {
                    text.Span("Issue date: ").SemiBold();
                    text.Span($"{Invoice.orderTime:d}");
                });

            });

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"{Invoice.ticketId}, {Invoice.eventInfo.eventName}", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            qrCode.GetGraphic(10).Save($"./qrcodes/qrc-{Invoice.ticketId}.png");



            row.ConstantItem(100).Height(100).Image($"./qrcodes/qrc-{Invoice.ticketId}.png", ImageScaling.FitArea);
            });

            // container.Image("qrc.png");
        }

        void ComposeContent(IContainer container)
        {
            container
                .PaddingVertical(40)
                .Height(250)
                .Background(Colors.Grey.Lighten3)
                .AlignCenter()
                .AlignMiddle()
                .Text($"Event: {Invoice.eventInfo.eventName}\nDate: {Invoice.eventInfo.eventStart}").FontSize(16);
        }
    }
}
