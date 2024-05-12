using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;

namespace WaterAnalyze.Data
{
    public class ExportService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ExportService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        //Export weather data to PDF document.
        public MemoryStream CreatePdf(Source source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Ошибка");
            }
            PdfDocument document = new PdfDocument();
            PdfPage currentPage = document.Pages.Add();
            SizeF clientSize = currentPage.GetClientSize();
            FileStream imageStream = new FileStream(_hostingEnvironment.WebRootPath + "//img//0.png", FileMode.Open, FileAccess.Read);
            PdfImage icon = new PdfBitmap(imageStream);
            SizeF iconSize = new SizeF(40, 40);
            PointF iconLocation = new PointF(14, 13);
            PdfGraphics graphics = currentPage.Graphics;
            graphics.DrawImage(icon, iconLocation, iconSize);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20, PdfFontStyle.Bold);
            var headerText = new PdfTextElement(source.Title, font, new PdfSolidBrush(Color.FromArgb(1, 53, 67, 16)));
            headerText.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            PdfLayoutResult result = headerText.Draw(currentPage, new PointF(clientSize.Width - 25, iconLocation.Y + 10));

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            stream.Position = 0;
            //Create a new PDF document.

            return stream;
        }
    }
}
