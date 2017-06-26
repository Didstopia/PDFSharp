using System;
using System.IO;
using Didstopia.PDFSharp.Drawing;
using Didstopia.PDFSharp.Fonts;
using Didstopia.PDFSharp.Pdf;
using Didstopia.PDFSharp.Pdf.IO;
using Xunit;

namespace Didstopia.PDFSharp.Tests
{
    public class PDFSharpTests
    {
        // TODO: Implement more tests, since these are VERY barebones
        //       and not in any way reliable as is

        private const string TitleString = "Unit Test PDF";
        private const string FontName = "Tinos";
        private const int FontSize = 16;

        private const string PasswordSamplePath = "Samples/pdf_sample_password.pdf";

        [Fact]
        public void TestBasicFunctionality()
        {
            // Create a new PDF
            var pdfDocument = new PdfDocument();
            Assert.True(pdfDocument != null, "PDF should not be null");

            // Set the PDF title
            pdfDocument.Info.Title = TitleString;
            Assert.True(pdfDocument.Info.Title.Equals(TitleString), $"PDF title should equal { TitleString }");

            // Add a new page to the PDF
            PdfPage pdfPage = pdfDocument.AddPage();
            Assert.True(pdfPage != null, "PDF page should not be null");

            // Draw text on the newly created page
            GlobalFontSettings.FontResolver = new FontResolver();
            XGraphics pdfGraphics = XGraphics.FromPdfPage(pdfPage);
            XFont pdfFont = new XFont(FontName, FontSize, XFontStyle.Regular);
            pdfGraphics.DrawString(TitleString, pdfFont, XBrushes.Black, new XRect(0, 0, pdfPage.Width, pdfPage.Height), XStringFormats.Center);

            // Save the PDF to a temporary path
            var tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");
            Assert.False(File.Exists(tempFilePath), "Temporary file should not exist before saving");
            Assert.True(pdfDocument.CanSave(ref tempFilePath), $"PDF should be able to be saved to path: { tempFilePath }");
            pdfDocument.Save(tempFilePath);
            Assert.True(File.Exists(tempFilePath), "Temporary file should exist after saving");
            var tempFileLength = new FileInfo(tempFilePath).Length;
            Assert.True(tempFileLength > 0, $"Temporary file length should be greater than 0 after saving, but was { tempFileLength } instead");

            // Close and dispose of the saved PDF
            pdfDocument.Close();
            pdfDocument.Dispose();

            // Load the PDF from the temporary path
            var loadedPdfDocument = PdfReader.Open(tempFilePath, PdfDocumentOpenMode.ReadOnly);
            Assert.True(loadedPdfDocument != null, "PDF should not be null");
            Assert.True(loadedPdfDocument.Info != null, "PDF info should not be null");
            Assert.True(loadedPdfDocument.Info.Title.Equals(TitleString), $"PDF title should equal { TitleString }");

            // Close and dispose of the loaded PDF
            loadedPdfDocument.Close();
            loadedPdfDocument.Dispose();
        }

        [Fact]
        public void TestEncryption()
        {
            // FIXME: This is still breaking due to an NRE being thrown in the security classes/methods

            // Opening a document will fail with an invalid password.
            try
            {
                //var document = PdfReader.Open(PasswordSamplePath, "invalid password");
                var document = PdfReader.Open(PasswordSamplePath, PdfDocumentOpenMode.ReadOnly, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Load the PDF
            var pdfDocument = PdfReader.Open(PasswordSamplePath, "password", PdfDocumentOpenMode.ReadOnly);
            Assert.True(pdfDocument != null, "PDF should not be null");
            Assert.True(pdfDocument.Info != null, "PDF info should not be null");
            Assert.True(pdfDocument.Info.Title.Equals(TitleString), $"PDF title should equal { TitleString }");

            // Close and dispose of the loaded PDF
            pdfDocument.Close();
            pdfDocument.Dispose();
        }
    }
}
