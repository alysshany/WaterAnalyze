using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace WaterAnalyze.Data
{
	public class PdfGenerator
	{
		public static void GeneratePdf(Source source, Analyze analyze, Direction direction)
		{
			//Create a new document
			Document document = new Document();

			//Create a PDF writer
			PdfWriter.GetInstance(document, new FileStream("C:\\Users\\Zilya\\source\\repos\\WaterAnalyze\\WaterAnalyze\\wwwroot\\files\\example.pdf", FileMode.Create));

			//Open the document
			document.Open();

			string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
			var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
			var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

			//Add a title
			Paragraph titleParagraph = new Paragraph(source.Title, font);
			titleParagraph.Alignment = Element.ALIGN_CENTER;
			document.Add(titleParagraph);

			//Add some text

			Paragraph bodyParagraph = new Paragraph($"Наименование: {source.Title}" + "\n" + $"Координаты: {source.CoordinatesX} {source.CoordinatesY} " +
				"\n" + "\n" + $"Направление: {direction.Title}" +
				"\n" + $"Информация по последнему анализу:" +
				"\n" + $"PH: {analyze.AcidityIndex}" +
				"\n" + $"Cl: {analyze.Сhloride}" +
				"\n" + $"HCO3: {analyze.Gidrocorbonat}" +
				"\n" + $"SO4: {analyze.Sulfate}" +
				"\n" + $"Ca: {analyze.Calcium}" +
				"\n" + $"Mg: {analyze.Magnesium}" +
				"\n" + $"Нефтепродукты: {analyze.Oil}", font);
			document.Add(bodyParagraph);

			//Close the document
			document.Close();
		}
	}
}
