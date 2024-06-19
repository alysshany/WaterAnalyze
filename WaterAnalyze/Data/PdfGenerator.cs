using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Charts.SVG.Models;
using Syncfusion.Drawing;
using System.IO;

namespace WaterAnalyze.Data
{
	public class PdfGenerator
	{
		public static void GeneratePdf(Source source, Analyze analyze, Direction direction)
		{
			Document document = new Document();

			PdfWriter.GetInstance(document, new FileStream("C:\\Users\\Zilya\\source\\repos\\WaterAnalyze\\WaterAnalyze\\wwwroot\\files\\example.pdf", FileMode.Create));

			document.Open();

			string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
			var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
			var baseColor = new BaseColor(77, 77, 255);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
			var fontBlue = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL, baseColor);

            Paragraph titleParagraph = new Paragraph(source.Title, font);
			titleParagraph.Alignment = Element.ALIGN_CENTER;
			document.Add(titleParagraph);

			Paragraph bodyParagraph = new Paragraph($"Наименование: {source.Title}" + "\n" + $"Координаты: {source.CoordinatesX} {source.CoordinatesY} " +
				"\n"  + "\n" + $"Направление: {direction.Title}" +
				"\n" + $"Информация по последнему анализу:" +
				"\n" + $"PH: {analyze.AcidityIndex}" +
				"\n" + $"Cl: {analyze.Сhloride}" +
				"\n" + $"HCO3: {analyze.Gidrocorbonat}" +
				"\n" + $"SO4: {analyze.Sulfate}" +
				"\n" + $"Ca: {analyze.Calcium}" +
				"\n" + $"Mg: {analyze.Magnesium}" +
				"\n" + $"Нефтепродукты: {analyze.Oil}", font);
			document.Add(bodyParagraph);

			document.Close();
		}


		public static void GenerateMany(WaterAnalyzeContext context, HashSet<Source> sources)
		{
            Document document = new Document();

            //Create a PDF writer
            PdfWriter.GetInstance(document, new FileStream("C:\\Users\\Zilya\\source\\repos\\WaterAnalyze\\WaterAnalyze\\wwwroot\\files\\example.pdf", FileMode.Create));

            //Open the document
            document.Open();

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(8);
            table.WidthPercentage = 100.0f;
            float[] widths = new float[] { 120f, 100f, 100f, 100f, 80f, 80f, 100f, 120f };
            table.SetWidths(widths);
            PdfPCell cell = new PdfPCell(new Phrase($"Наименование", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"PH", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"Хлорид", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"Гидрокарбонат", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"Сульфат", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"Кальций", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"Магний", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase($"Нефтепродукт", font));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
            table.AddCell(cell);
            //table.AddCell(new Phrase($"PH", font));
            //table.AddCell(new Phrase($"Хлорид", font));
            //table.AddCell(new Phrase($"Гидрокарбонат", font));
            //table.AddCell(new Phrase($"Сульфат", font));
            //table.AddCell(new Phrase($"Кальций", font));
            //table.AddCell(new Phrase($"Магний", font));
            //table.AddCell(new Phrase($"Нефтепродукт", font));

            foreach (Source source in sources)
			{

				//Add a title
				Paragraph titleParagraph = new Paragraph(source.Title, font);
				titleParagraph.Alignment = Element.ALIGN_CENTER;
				document.Add(titleParagraph);

                List<Analyze>  Elements = context.Analyzes.Where(x => x.SourceId == Convert.ToInt32(source.Id)).ToList();
                if (Elements.Count > 0)
                {
                    Elements.Reverse();

                    //Add some text

                    Paragraph bodyParagraph = new Paragraph($"Наименование: {source.Title}" + "\n" + $"Координаты: {source.CoordinatesX} {source.CoordinatesY} " +
                        "\n" +
                        "\n" + $"Информация по последнему анализу:" +
                        "\n" + $"PH: {Elements[0].AcidityIndex}" +
                        "\n" + $"Cl: {Elements[0].Сhloride}" +
                        "\n" + $"HCO3: {Elements[0].Gidrocorbonat}" +
                        "\n" + $"SO4: {Elements[0].Sulfate}" +
                        "\n" + $"Ca: {Elements[0].Calcium}" +
                        "\n" + $"Mg: {Elements[0].Magnesium}" +
                        "\n" + $"Нефтепродукты: {Elements[0].Oil}"
                        , font);
                    document.Add(bodyParagraph);

                    Paragraph paragraph = new Paragraph("\n");
                    document.Add(paragraph);

                    table.AddCell(new Phrase($"{source.Title}", font));
                    
                    PdfPCell cellChloride = new PdfPCell(new Phrase($"{Elements[0].Сhloride}", font));
                    PdfPCell cellMagnesium = new PdfPCell(new Phrase($"{Elements[0].Magnesium}", font));
                    PdfPCell cellCalciume = new PdfPCell(new Phrase($"{Elements[0].Calcium}", font));
                    PdfPCell cellOil = new PdfPCell(new Phrase($"{Elements[0].Oil}", font));
                    PdfPCell cellAcidityIndex = new PdfPCell(new Phrase($"{Elements[0].AcidityIndex}", font));

                    var sourceType = context.SourceTypes.Where(x => x.Id == source.SourceTypeId).First().Title;
                    if (sourceType == "Река" || sourceType == "Ручей")
                    {
                        List<Analyze> analyzeList = context.Analyzes.Where(x => x.SourceId == source.Id).ToList();
                        analyzeList.Reverse();
                        if (analyzeList.Count != 0)
                        {
                            var lastAnalyze = analyzeList[0];

                            if (lastAnalyze.Сhloride > 300)
                            {
                                cellChloride.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.Magnesium > 40)
                            {
                                cellMagnesium.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.Calcium > 180)
                            {
                                cellCalciume.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.Oil > 0.05)
                            {
                                cellOil.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.AcidityIndex > 9 || lastAnalyze.AcidityIndex < 6)
                            {
                                cellAcidityIndex.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                        }
                    }
                    else if (sourceType == "Родник" || sourceType == "Колонка" || sourceType == "Колодец" || sourceType == "Арт. Скважина")
                    {
                        List<Analyze> analyzeList = context.Analyzes.Where(x => x.SourceId == source.Id).ToList();
                        analyzeList.Reverse();
                        if (analyzeList.Count != 0)
                        {
                            var lastAnalyze = analyzeList[0];

                            if (lastAnalyze.Сhloride > 350)
                            {
                                cellChloride.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.Magnesium > 50)
                            {
                                cellMagnesium.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.Oil > 0.1)
                            {
                                cellOil.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                            if (lastAnalyze.AcidityIndex > 8.5 || lastAnalyze.AcidityIndex < 6.5)
                            {
                                cellAcidityIndex.BackgroundColor = new iTextSharp.text.BaseColor(250, 160, 160);
                            }
                        }
                    }
                    table.AddCell(cellAcidityIndex);
                    table.AddCell(cellChloride);
                    table.AddCell($"{Elements[0].Gidrocorbonat}");
                    table.AddCell($"{Elements[0].Sulfate}");
                    table.AddCell(cellCalciume);
                    table.AddCell(cellMagnesium);
                    table.AddCell(cellOil);
                }
                else
                {
                    Paragraph paragraph = new Paragraph("Анализов еще нет\n", font);
                    document.Add(paragraph);
                }
            }
            Paragraph paragraph2 = new Paragraph("Конечная таблица", font);
            paragraph2.Alignment = Element.ALIGN_CENTER;

            document.Add(paragraph2);
            Paragraph paragraph3 = new Paragraph("\n");
            document.Add(paragraph3);
            document.Add(table);

            //Close the document
            document.Close();
        }
	}
}
