using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Wps = DocumentFormat.OpenXml.Office2010.Word.DrawingShape;
using Wp14 = DocumentFormat.OpenXml.Office2010.Word.Drawing;
using V = DocumentFormat.OpenXml.Vml;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using Wvml = DocumentFormat.OpenXml.Vml.Wordprocessing;
using M = DocumentFormat.OpenXml.Math;
using W15 = DocumentFormat.OpenXml.Office2013.Word;

namespace ChordEditor.Core
{
	public class WordFile
	{
		// Creates a WordprocessingDocument.
		public void CreatePackage(string filePath)
		{
			using (WordprocessingDocument package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
			{
				CreateParts(package);
			}
		}

		// Adds child parts and generates content of the specified part.
		private void CreateParts(WordprocessingDocument document)
		{
			ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
			GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

			MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
			GenerateMainDocumentPart1Content(mainDocumentPart1);

			WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId3");
			GenerateWebSettingsPart1Content(webSettingsPart1);

			DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId2");
			GenerateDocumentSettingsPart1Content(documentSettingsPart1);

			documentSettingsPart1.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate", new System.Uri("file:///D:\\PJ\\GITHUB\\ChordWiki\\ChordEditor\\bin\\Debug\\Template\\chordbook.dotx", System.UriKind.Absolute), "rId1");
			StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId1");
			GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

			ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId5");
			GenerateThemePart1Content(themePart1);

			FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId4");
			GenerateFontTablePart1Content(fontTablePart1);

			SetPackageProperties(document);
		}

		// Generates content of extendedFilePropertiesPart1.
		private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
		{
			Ap.Properties properties1 = new Ap.Properties();
			properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
			Ap.Template template1 = new Ap.Template();
			template1.Text = "chordbook.dotx";
			Ap.TotalTime totalTime1 = new Ap.TotalTime();
			totalTime1.Text = "7";
			Ap.Pages pages1 = new Ap.Pages();
			pages1.Text = "1";
			Ap.Words words1 = new Ap.Words();
			words1.Text = "30";
			Ap.Characters characters1 = new Ap.Characters();
			characters1.Text = "177";
			Ap.Application application1 = new Ap.Application();
			application1.Text = "Microsoft Office Word";
			Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
			documentSecurity1.Text = "0";
			Ap.Lines lines1 = new Ap.Lines();
			lines1.Text = "1";
			Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
			paragraphs1.Text = "1";
			Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
			scaleCrop1.Text = "false";

			Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

			Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

			Vt.Variant variant1 = new Vt.Variant();
			Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
			vTLPSTR1.Text = "Titolo";

			variant1.Append(vTLPSTR1);

			Vt.Variant variant2 = new Vt.Variant();
			Vt.VTInt32 vTInt321 = new Vt.VTInt32();
			vTInt321.Text = "1";

			variant2.Append(vTInt321);

			vTVector1.Append(variant1);
			vTVector1.Append(variant2);

			headingPairs1.Append(vTVector1);

			Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

			Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
			Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
			vTLPSTR2.Text = "";

			vTVector2.Append(vTLPSTR2);

			titlesOfParts1.Append(vTVector2);
			Ap.Company company1 = new Ap.Company();
			company1.Text = "Microsoft";
			Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
			linksUpToDate1.Text = "false";
			Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
			charactersWithSpaces1.Text = "206";
			Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
			sharedDocument1.Text = "false";
			Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
			hyperlinksChanged1.Text = "false";
			Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
			applicationVersion1.Text = "15.0000";

			properties1.Append(template1);
			properties1.Append(totalTime1);
			properties1.Append(pages1);
			properties1.Append(words1);
			properties1.Append(characters1);
			properties1.Append(application1);
			properties1.Append(documentSecurity1);
			properties1.Append(lines1);
			properties1.Append(paragraphs1);
			properties1.Append(scaleCrop1);
			properties1.Append(headingPairs1);
			properties1.Append(titlesOfParts1);
			properties1.Append(company1);
			properties1.Append(linksUpToDate1);
			properties1.Append(charactersWithSpaces1);
			properties1.Append(sharedDocument1);
			properties1.Append(hyperlinksChanged1);
			properties1.Append(applicationVersion1);

			extendedFilePropertiesPart1.Properties = properties1;
		}

		// Generates content of mainDocumentPart1.
		private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1)
		{
			Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 wp14" } };
			document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
			document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
			document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
			document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
			document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
			document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
			document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
			document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			document1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
			document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
			document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
			document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
			document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

			Body body1 = new Body();

			Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "00D30EB8", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties1 = new ParagraphProperties();
			ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "SongTitle" };

			paragraphProperties1.Append(paragraphStyleId1);

			Run run1 = new Run();
			Text text1 = new Text();
			text1.Text = "La canzone del Sole";

			run1.Append(text1);

			paragraph1.Append(paragraphProperties1);
			paragraph1.Append(run1);

			Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties2 = new ParagraphProperties();
			ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "SongArtist" };

			paragraphProperties2.Append(paragraphStyleId2);

			Run run2 = new Run();
			Text text2 = new Text();
			text2.Text = "Lucio Battisti";

			run2.Append(text2);

			paragraph2.Append(paragraphProperties2);
			paragraph2.Append(run2);

			Paragraph paragraph3 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties3 = new ParagraphProperties();
			ParagraphStyleId paragraphStyleId3 = new ParagraphStyleId() { Val = "StropheWC" };

			paragraphProperties3.Append(paragraphStyleId3);

			Run run3 = new Run();

			RunProperties runProperties1 = new RunProperties();
			NoProof noProof1 = new NoProof();

			runProperties1.Append(noProof1);

			AlternateContent alternateContent1 = new AlternateContent();

			AlternateContentChoice alternateContentChoice1 = new AlternateContentChoice() { Requires = "wps" };

			Drawing drawing1 = new Drawing();

			Wp.Anchor anchor1 = new Wp.Anchor() { DistanceFromTop = (UInt32Value)45720U, DistanceFromBottom = (UInt32Value)45720U, DistanceFromLeft = (UInt32Value)114300U, DistanceFromRight = (UInt32Value)114300U, SimplePos = false, RelativeHeight = (UInt32Value)251659264U, BehindDoc = false, Locked = false, LayoutInCell = true, AllowOverlap = true };
			Wp.SimplePosition simplePosition1 = new Wp.SimplePosition() { X = 0L, Y = 0L };

			Wp.HorizontalPosition horizontalPosition1 = new Wp.HorizontalPosition() { RelativeFrom = Wp.HorizontalRelativePositionValues.Character };
			Wp.PositionOffset positionOffset1 = new Wp.PositionOffset();
			positionOffset1.Text = "0";

			horizontalPosition1.Append(positionOffset1);

			Wp.VerticalPosition verticalPosition1 = new Wp.VerticalPosition() { RelativeFrom = Wp.VerticalRelativePositionValues.Line };
			Wp.PositionOffset positionOffset2 = new Wp.PositionOffset();
			positionOffset2.Text = "-90170";

			verticalPosition1.Append(positionOffset2);
			Wp.Extent extent1 = new Wp.Extent() { Cx = 161925L, Cy = 153035L };
			Wp.EffectExtent effectExtent1 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 9525L, BottomEdge = 0L };
			Wp.WrapNone wrapNone1 = new Wp.WrapNone();
			Wp.DocProperties docProperties1 = new Wp.DocProperties() { Id = (UInt32Value)217U, Name = "Casella di testo 2" };

			Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new Wp.NonVisualGraphicFrameDrawingProperties();

			A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks();
			graphicFrameLocks1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

			A.Graphic graphic1 = new A.Graphic();
			graphic1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			A.GraphicData graphicData1 = new A.GraphicData() { Uri = "http://schemas.microsoft.com/office/word/2010/wordprocessingShape" };

			Wps.WordprocessingShape wordprocessingShape1 = new Wps.WordprocessingShape();

			Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties1 = new Wps.NonVisualDrawingShapeProperties() { TextBox = true };
			A.ShapeLocks shapeLocks1 = new A.ShapeLocks() { NoChangeArrowheads = true };

			nonVisualDrawingShapeProperties1.Append(shapeLocks1);

			Wps.ShapeProperties shapeProperties1 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

			A.Transform2D transform2D1 = new A.Transform2D();
			A.Offset offset1 = new A.Offset() { X = 0L, Y = 0L };
			A.Extents extents1 = new A.Extents() { Cx = 161925L, Cy = 153035L };

			transform2D1.Append(offset1);
			transform2D1.Append(extents1);

			A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
			A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

			presetGeometry1.Append(adjustValueList1);
			A.NoFill noFill1 = new A.NoFill();

			A.Outline outline1 = new A.Outline() { Width = 9525 };
			A.NoFill noFill2 = new A.NoFill();
			A.Miter miter1 = new A.Miter() { Limit = 800000 };
			A.HeadEnd headEnd1 = new A.HeadEnd();
			A.TailEnd tailEnd1 = new A.TailEnd();

			outline1.Append(noFill2);
			outline1.Append(miter1);
			outline1.Append(headEnd1);
			outline1.Append(tailEnd1);

			shapeProperties1.Append(transform2D1);
			shapeProperties1.Append(presetGeometry1);
			shapeProperties1.Append(noFill1);
			shapeProperties1.Append(outline1);

			Wps.TextBoxInfo2 textBoxInfo21 = new Wps.TextBoxInfo2();

			TextBoxContent textBoxContent1 = new TextBoxContent();

			Paragraph paragraph4 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties4 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
			RunFonts runFonts1 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold1 = new Bold();

			paragraphMarkRunProperties1.Append(runFonts1);
			paragraphMarkRunProperties1.Append(bold1);

			paragraphProperties4.Append(paragraphMarkRunProperties1);

			Run run4 = new Run() { RsidRunProperties = "00496A6D" };

			RunProperties runProperties2 = new RunProperties();
			RunFonts runFonts2 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold2 = new Bold();

			runProperties2.Append(runFonts2);
			runProperties2.Append(bold2);
			Text text3 = new Text();
			text3.Text = "LA";

			run4.Append(runProperties2);
			run4.Append(text3);

			paragraph4.Append(paragraphProperties4);
			paragraph4.Append(run4);

			textBoxContent1.Append(paragraph4);

			textBoxInfo21.Append(textBoxContent1);

			Wps.TextBodyProperties textBodyProperties1 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.None, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
			A.ShapeAutoFit shapeAutoFit1 = new A.ShapeAutoFit();

			textBodyProperties1.Append(shapeAutoFit1);

			wordprocessingShape1.Append(nonVisualDrawingShapeProperties1);
			wordprocessingShape1.Append(shapeProperties1);
			wordprocessingShape1.Append(textBoxInfo21);
			wordprocessingShape1.Append(textBodyProperties1);

			graphicData1.Append(wordprocessingShape1);

			graphic1.Append(graphicData1);

			Wp14.RelativeWidth relativeWidth1 = new Wp14.RelativeWidth() { ObjectId = Wp14.SizeRelativeHorizontallyValues.Margin };
			Wp14.PercentageWidth percentageWidth1 = new Wp14.PercentageWidth();
			percentageWidth1.Text = "40000";

			relativeWidth1.Append(percentageWidth1);

			Wp14.RelativeHeight relativeHeight1 = new Wp14.RelativeHeight() { RelativeFrom = Wp14.SizeRelativeVerticallyValues.Margin };
			Wp14.PercentageHeight percentageHeight1 = new Wp14.PercentageHeight();
			percentageHeight1.Text = "20000";

			relativeHeight1.Append(percentageHeight1);

			anchor1.Append(simplePosition1);
			anchor1.Append(horizontalPosition1);
			anchor1.Append(verticalPosition1);
			anchor1.Append(extent1);
			anchor1.Append(effectExtent1);
			anchor1.Append(wrapNone1);
			anchor1.Append(docProperties1);
			anchor1.Append(nonVisualGraphicFrameDrawingProperties1);
			anchor1.Append(graphic1);
			anchor1.Append(relativeWidth1);
			anchor1.Append(relativeHeight1);

			drawing1.Append(anchor1);

			alternateContentChoice1.Append(drawing1);

			AlternateContentFallback alternateContentFallback1 = new AlternateContentFallback();

			Picture picture1 = new Picture();

			V.Shapetype shapetype1 = new V.Shapetype() { Id = "_x0000_t202", CoordinateSize = "21600,21600", OptionalNumber = 202, EdgePath = "m,l,21600r21600,l21600,xe" };
			V.Stroke stroke1 = new V.Stroke() { JoinStyle = V.StrokeJoinStyleValues.Miter };
			V.Path path1 = new V.Path() { AllowGradientShape = true, ConnectionPointType = Ovml.ConnectValues.Rectangle };

			shapetype1.Append(stroke1);
			shapetype1.Append(path1);

			V.Shape shape1 = new V.Shape() { Id = "Casella di testo 2", Style = "position:absolute;margin-left:0;margin-top:-7.1pt;width:12.75pt;height:12.05pt;z-index:251659264;visibility:visible;mso-wrap-style:none;mso-width-percent:400;mso-height-percent:200;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:char;mso-position-vertical:absolute;mso-position-vertical-relative:line;mso-width-percent:400;mso-height-percent:200;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top", OptionalString = "_x0000_s1026", Filled = false, Stroked = false, Type = "#_x0000_t202", EncodedPackage = "UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF\n90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA\n0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD\nOlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893\nSUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y\nJsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl\nbHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR\nJVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY\n22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i\nOWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA\nIQByyGlFBQIAAOkDAAAOAAAAZHJzL2Uyb0RvYy54bWysU8tu2zAQvBfoPxC815IcOE0Ey0Hq1EWB\n9AGk/YA1RVlESS5BMpbcr++Ssp0gvQXRgVhqubM7w+HyZjSa7aUPCm3Dq1nJmbQCW2V3Df/9a/Ph\nirMQwbag0cqGH2TgN6v375aDq+Uce9St9IxAbKgH1/A+RlcXRRC9NBBm6KSlZIfeQKSt3xWth4HQ\njS7mZXlZDOhb51HIEOjv3ZTkq4zfdVLEH10XZGS64TRbzKvP6zatxWoJ9c6D65U4jgGvmMKAstT0\nDHUHEdijV/9BGSU8BuziTKApsOuUkJkDsanKF2weenAycyFxgjvLFN4OVnzf//RMtQ2fVx85s2Do\nktYQpNbAWsWiDBHZPOk0uFDT8QdHBXH8hCPdd+Yc3D2KP4FZXPdgd/LWexx6CS3NWaXK4lnphBMS\nyHb4hi21g8eIGWjsvEkikiyM0Om+Duc7kmNkIrW8rK7nC84EparFRXmxyB2gPhU7H+IXiYaloOGe\nLJDBYX8fYhoG6tOR1MviRmmdbaAtGxp+vSD4FxmjIrlUK9PwqzJ9k28Sx8+2zcURlJ5iaqDtkXTi\nOTGO43akg0mJLbYHou9xciO9Hgp69H85G8iJDbf0VDjTXy0JmEx7Cvwp2J4CsIIKGx45m8J1zOZO\n8wd3S8JuVCb91Pc4Gfkpa3H0fjLs830+9fRCV/8AAAD//wMAUEsDBBQABgAIAAAAIQBQx11V3gAA\nAAUBAAAPAAAAZHJzL2Rvd25yZXYueG1sTI9BS8NAFITvgv9heYIXaTcNrdg0L6UURBCF2tpDb5vs\nMxvMvg3ZbZr+e9eTHocZZr7J16NtxUC9bxwjzKYJCOLK6YZrhM/D8+QJhA+KtWodE8KVPKyL25tc\nZdpd+IOGfahFLGGfKQQTQpdJ6StDVvmp64ij9+V6q0KUfS11ry6x3LYyTZJHaVXDccGojraGqu/9\n2SKU7+GQzjcvp6updtvu7eE4vPIR8f5u3KxABBrDXxh+8SM6FJGpdGfWXrQI8UhAmMzmKYhop4sF\niBJhuQRZ5PI/ffEDAAD//wMAUEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAA\nAAAAAAAAAFtDb250ZW50X1R5cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAA\nAAAAAAAAAAAAAAAvAQAAX3JlbHMvLnJlbHNQSwECLQAUAAYACAAAACEAcshpRQUCAADpAwAADgAA\nAAAAAAAAAAAAAAAuAgAAZHJzL2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAUMddVd4AAAAFAQAA\nDwAAAAAAAAAAAAAAAABfBAAAZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAGoFAAAAAA==\n" };

			V.TextBox textBox1 = new V.TextBox() { Style = "mso-fit-shape-to-text:t", Inset = "0,0,0,0" };

			TextBoxContent textBoxContent2 = new TextBoxContent();

			Paragraph paragraph5 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties5 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
			RunFonts runFonts3 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold3 = new Bold();

			paragraphMarkRunProperties2.Append(runFonts3);
			paragraphMarkRunProperties2.Append(bold3);

			paragraphProperties5.Append(paragraphMarkRunProperties2);

			Run run5 = new Run() { RsidRunProperties = "00496A6D" };

			RunProperties runProperties3 = new RunProperties();
			RunFonts runFonts4 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold4 = new Bold();

			runProperties3.Append(runFonts4);
			runProperties3.Append(bold4);
			Text text4 = new Text();
			text4.Text = "LA";

			run5.Append(runProperties3);
			run5.Append(text4);

			paragraph5.Append(paragraphProperties5);
			paragraph5.Append(run5);

			textBoxContent2.Append(paragraph5);

			textBox1.Append(textBoxContent2);
			Wvml.TextWrap textWrap1 = new Wvml.TextWrap() { AnchorY = new EnumValue<DocumentFormat.OpenXml.Vml.Wordprocessing.VerticalAnchorValues>() { InnerText = "line" } };

			shape1.Append(textBox1);
			shape1.Append(textWrap1);

			picture1.Append(shapetype1);
			picture1.Append(shape1);

			alternateContentFallback1.Append(picture1);

			alternateContent1.Append(alternateContentChoice1);
			alternateContent1.Append(alternateContentFallback1);

			run3.Append(runProperties1);
			run3.Append(alternateContent1);

			Run run6 = new Run();
			Text text5 = new Text() { Space = SpaceProcessingModeValues.Preserve };
			text5.Text = "Le bionde treccie gli ";

			run6.Append(text5);

			Run run7 = new Run();

			RunProperties runProperties4 = new RunProperties();
			NoProof noProof2 = new NoProof();

			runProperties4.Append(noProof2);

			AlternateContent alternateContent2 = new AlternateContent();

			AlternateContentChoice alternateContentChoice2 = new AlternateContentChoice() { Requires = "wps" };

			Drawing drawing2 = new Drawing();

			Wp.Anchor anchor2 = new Wp.Anchor() { DistanceFromTop = (UInt32Value)45720U, DistanceFromBottom = (UInt32Value)45720U, DistanceFromLeft = (UInt32Value)114300U, DistanceFromRight = (UInt32Value)114300U, SimplePos = false, RelativeHeight = (UInt32Value)251661312U, BehindDoc = false, Locked = false, LayoutInCell = true, AllowOverlap = true, EditId = "36FE597C", AnchorId = "08E0E6AE" };
			Wp.SimplePosition simplePosition2 = new Wp.SimplePosition() { X = 0L, Y = 0L };

			Wp.HorizontalPosition horizontalPosition2 = new Wp.HorizontalPosition() { RelativeFrom = Wp.HorizontalRelativePositionValues.Character };
			Wp.PositionOffset positionOffset3 = new Wp.PositionOffset();
			positionOffset3.Text = "0";

			horizontalPosition2.Append(positionOffset3);

			Wp.VerticalPosition verticalPosition2 = new Wp.VerticalPosition() { RelativeFrom = Wp.VerticalRelativePositionValues.Line };
			Wp.PositionOffset positionOffset4 = new Wp.PositionOffset();
			positionOffset4.Text = "-90170";

			verticalPosition2.Append(positionOffset4);
			Wp.Extent extent2 = new Wp.Extent() { Cx = 161925L, Cy = 153035L };
			Wp.EffectExtent effectExtent2 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 9525L, BottomEdge = 0L };
			Wp.WrapNone wrapNone2 = new Wp.WrapNone();
			Wp.DocProperties docProperties2 = new Wp.DocProperties() { Id = (UInt32Value)1U, Name = "Casella di testo 2" };

			Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties2 = new Wp.NonVisualGraphicFrameDrawingProperties();

			A.GraphicFrameLocks graphicFrameLocks2 = new A.GraphicFrameLocks();
			graphicFrameLocks2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			nonVisualGraphicFrameDrawingProperties2.Append(graphicFrameLocks2);

			A.Graphic graphic2 = new A.Graphic();
			graphic2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			A.GraphicData graphicData2 = new A.GraphicData() { Uri = "http://schemas.microsoft.com/office/word/2010/wordprocessingShape" };

			Wps.WordprocessingShape wordprocessingShape2 = new Wps.WordprocessingShape();

			Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties2 = new Wps.NonVisualDrawingShapeProperties() { TextBox = true };
			A.ShapeLocks shapeLocks2 = new A.ShapeLocks() { NoChangeArrowheads = true };

			nonVisualDrawingShapeProperties2.Append(shapeLocks2);

			Wps.ShapeProperties shapeProperties2 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

			A.Transform2D transform2D2 = new A.Transform2D();
			A.Offset offset2 = new A.Offset() { X = 0L, Y = 0L };
			A.Extents extents2 = new A.Extents() { Cx = 161925L, Cy = 153035L };

			transform2D2.Append(offset2);
			transform2D2.Append(extents2);

			A.PresetGeometry presetGeometry2 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
			A.AdjustValueList adjustValueList2 = new A.AdjustValueList();

			presetGeometry2.Append(adjustValueList2);
			A.NoFill noFill3 = new A.NoFill();

			A.Outline outline2 = new A.Outline() { Width = 9525 };
			A.NoFill noFill4 = new A.NoFill();
			A.Miter miter2 = new A.Miter() { Limit = 800000 };
			A.HeadEnd headEnd2 = new A.HeadEnd();
			A.TailEnd tailEnd2 = new A.TailEnd();

			outline2.Append(noFill4);
			outline2.Append(miter2);
			outline2.Append(headEnd2);
			outline2.Append(tailEnd2);

			shapeProperties2.Append(transform2D2);
			shapeProperties2.Append(presetGeometry2);
			shapeProperties2.Append(noFill3);
			shapeProperties2.Append(outline2);

			Wps.TextBoxInfo2 textBoxInfo22 = new Wps.TextBoxInfo2();

			TextBoxContent textBoxContent3 = new TextBoxContent();

			Paragraph paragraph6 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties6 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
			RunFonts runFonts5 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold5 = new Bold();

			paragraphMarkRunProperties3.Append(runFonts5);
			paragraphMarkRunProperties3.Append(bold5);

			paragraphProperties6.Append(paragraphMarkRunProperties3);

			Run run8 = new Run();

			RunProperties runProperties5 = new RunProperties();
			RunFonts runFonts6 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold6 = new Bold();

			runProperties5.Append(runFonts6);
			runProperties5.Append(bold6);
			Text text6 = new Text();
			text6.Text = "MI";

			run8.Append(runProperties5);
			run8.Append(text6);

			paragraph6.Append(paragraphProperties6);
			paragraph6.Append(run8);

			textBoxContent3.Append(paragraph6);

			textBoxInfo22.Append(textBoxContent3);

			Wps.TextBodyProperties textBodyProperties2 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.None, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
			A.ShapeAutoFit shapeAutoFit2 = new A.ShapeAutoFit();

			textBodyProperties2.Append(shapeAutoFit2);

			wordprocessingShape2.Append(nonVisualDrawingShapeProperties2);
			wordprocessingShape2.Append(shapeProperties2);
			wordprocessingShape2.Append(textBoxInfo22);
			wordprocessingShape2.Append(textBodyProperties2);

			graphicData2.Append(wordprocessingShape2);

			graphic2.Append(graphicData2);

			Wp14.RelativeWidth relativeWidth2 = new Wp14.RelativeWidth() { ObjectId = Wp14.SizeRelativeHorizontallyValues.Margin };
			Wp14.PercentageWidth percentageWidth2 = new Wp14.PercentageWidth();
			percentageWidth2.Text = "40000";

			relativeWidth2.Append(percentageWidth2);

			Wp14.RelativeHeight relativeHeight2 = new Wp14.RelativeHeight() { RelativeFrom = Wp14.SizeRelativeVerticallyValues.Margin };
			Wp14.PercentageHeight percentageHeight2 = new Wp14.PercentageHeight();
			percentageHeight2.Text = "20000";

			relativeHeight2.Append(percentageHeight2);

			anchor2.Append(simplePosition2);
			anchor2.Append(horizontalPosition2);
			anchor2.Append(verticalPosition2);
			anchor2.Append(extent2);
			anchor2.Append(effectExtent2);
			anchor2.Append(wrapNone2);
			anchor2.Append(docProperties2);
			anchor2.Append(nonVisualGraphicFrameDrawingProperties2);
			anchor2.Append(graphic2);
			anchor2.Append(relativeWidth2);
			anchor2.Append(relativeHeight2);

			drawing2.Append(anchor2);

			alternateContentChoice2.Append(drawing2);

			AlternateContentFallback alternateContentFallback2 = new AlternateContentFallback();

			Picture picture2 = new Picture();

			V.Shape shape2 = new V.Shape() { Id = "_x0000_s1027", Style = "position:absolute;margin-left:0;margin-top:-7.1pt;width:12.75pt;height:12.05pt;z-index:251661312;visibility:visible;mso-wrap-style:none;mso-width-percent:400;mso-height-percent:200;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:char;mso-position-vertical:absolute;mso-position-vertical-relative:line;mso-width-percent:400;mso-height-percent:200;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top", Filled = false, Stroked = false, Type = "#_x0000_t202", EncodedPackage = "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\n" };
			shape2.SetAttribute(new OpenXmlAttribute("w14", "anchorId", "http://schemas.microsoft.com/office/word/2010/wordml", "08E0E6AE"));

			V.TextBox textBox2 = new V.TextBox() { Style = "mso-fit-shape-to-text:t", Inset = "0,0,0,0" };

			TextBoxContent textBoxContent4 = new TextBoxContent();

			Paragraph paragraph7 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties7 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
			RunFonts runFonts7 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold7 = new Bold();

			paragraphMarkRunProperties4.Append(runFonts7);
			paragraphMarkRunProperties4.Append(bold7);

			paragraphProperties7.Append(paragraphMarkRunProperties4);

			Run run9 = new Run();

			RunProperties runProperties6 = new RunProperties();
			RunFonts runFonts8 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold8 = new Bold();

			runProperties6.Append(runFonts8);
			runProperties6.Append(bold8);
			Text text7 = new Text();
			text7.Text = "MI";

			run9.Append(runProperties6);
			run9.Append(text7);

			paragraph7.Append(paragraphProperties7);
			paragraph7.Append(run9);

			textBoxContent4.Append(paragraph7);

			textBox2.Append(textBoxContent4);
			Wvml.TextWrap textWrap2 = new Wvml.TextWrap() { AnchorY = new EnumValue<DocumentFormat.OpenXml.Vml.Wordprocessing.VerticalAnchorValues>() { InnerText = "line" } };

			shape2.Append(textBox2);
			shape2.Append(textWrap2);

			picture2.Append(shape2);

			alternateContentFallback2.Append(picture2);

			alternateContent2.Append(alternateContentChoice2);
			alternateContent2.Append(alternateContentFallback2);

			run7.Append(runProperties4);
			run7.Append(alternateContent2);

			Run run10 = new Run();
			Text text8 = new Text() { Space = SpaceProcessingModeValues.Preserve };
			text8.Text = "occhi azzurri e poi le tue ";

			run10.Append(text8);

			Run run11 = new Run();

			RunProperties runProperties7 = new RunProperties();
			NoProof noProof3 = new NoProof();

			runProperties7.Append(noProof3);

			AlternateContent alternateContent3 = new AlternateContent();

			AlternateContentChoice alternateContentChoice3 = new AlternateContentChoice() { Requires = "wps" };

			Drawing drawing3 = new Drawing();

			Wp.Anchor anchor3 = new Wp.Anchor() { DistanceFromTop = (UInt32Value)45720U, DistanceFromBottom = (UInt32Value)45720U, DistanceFromLeft = (UInt32Value)114300U, DistanceFromRight = (UInt32Value)114300U, SimplePos = false, RelativeHeight = (UInt32Value)251663360U, BehindDoc = false, Locked = false, LayoutInCell = true, AllowOverlap = true, EditId = "1323F4B0", AnchorId = "341B3744" };
			Wp.SimplePosition simplePosition3 = new Wp.SimplePosition() { X = 0L, Y = 0L };

			Wp.HorizontalPosition horizontalPosition3 = new Wp.HorizontalPosition() { RelativeFrom = Wp.HorizontalRelativePositionValues.Character };
			Wp.PositionOffset positionOffset5 = new Wp.PositionOffset();
			positionOffset5.Text = "0";

			horizontalPosition3.Append(positionOffset5);

			Wp.VerticalPosition verticalPosition3 = new Wp.VerticalPosition() { RelativeFrom = Wp.VerticalRelativePositionValues.Line };
			Wp.PositionOffset positionOffset6 = new Wp.PositionOffset();
			positionOffset6.Text = "-90170";

			verticalPosition3.Append(positionOffset6);
			Wp.Extent extent3 = new Wp.Extent() { Cx = 161925L, Cy = 153035L };
			Wp.EffectExtent effectExtent3 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 9525L, BottomEdge = 0L };
			Wp.WrapNone wrapNone3 = new Wp.WrapNone();
			Wp.DocProperties docProperties3 = new Wp.DocProperties() { Id = (UInt32Value)2U, Name = "Casella di testo 2" };

			Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties3 = new Wp.NonVisualGraphicFrameDrawingProperties();

			A.GraphicFrameLocks graphicFrameLocks3 = new A.GraphicFrameLocks();
			graphicFrameLocks3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			nonVisualGraphicFrameDrawingProperties3.Append(graphicFrameLocks3);

			A.Graphic graphic3 = new A.Graphic();
			graphic3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			A.GraphicData graphicData3 = new A.GraphicData() { Uri = "http://schemas.microsoft.com/office/word/2010/wordprocessingShape" };

			Wps.WordprocessingShape wordprocessingShape3 = new Wps.WordprocessingShape();

			Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties3 = new Wps.NonVisualDrawingShapeProperties() { TextBox = true };
			A.ShapeLocks shapeLocks3 = new A.ShapeLocks() { NoChangeArrowheads = true };

			nonVisualDrawingShapeProperties3.Append(shapeLocks3);

			Wps.ShapeProperties shapeProperties3 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

			A.Transform2D transform2D3 = new A.Transform2D();
			A.Offset offset3 = new A.Offset() { X = 0L, Y = 0L };
			A.Extents extents3 = new A.Extents() { Cx = 161925L, Cy = 153035L };

			transform2D3.Append(offset3);
			transform2D3.Append(extents3);

			A.PresetGeometry presetGeometry3 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
			A.AdjustValueList adjustValueList3 = new A.AdjustValueList();

			presetGeometry3.Append(adjustValueList3);
			A.NoFill noFill5 = new A.NoFill();

			A.Outline outline3 = new A.Outline() { Width = 9525 };
			A.NoFill noFill6 = new A.NoFill();
			A.Miter miter3 = new A.Miter() { Limit = 800000 };
			A.HeadEnd headEnd3 = new A.HeadEnd();
			A.TailEnd tailEnd3 = new A.TailEnd();

			outline3.Append(noFill6);
			outline3.Append(miter3);
			outline3.Append(headEnd3);
			outline3.Append(tailEnd3);

			shapeProperties3.Append(transform2D3);
			shapeProperties3.Append(presetGeometry3);
			shapeProperties3.Append(noFill5);
			shapeProperties3.Append(outline3);

			Wps.TextBoxInfo2 textBoxInfo23 = new Wps.TextBoxInfo2();

			TextBoxContent textBoxContent5 = new TextBoxContent();

			Paragraph paragraph8 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties8 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
			RunFonts runFonts9 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold9 = new Bold();

			paragraphMarkRunProperties5.Append(runFonts9);
			paragraphMarkRunProperties5.Append(bold9);

			paragraphProperties8.Append(paragraphMarkRunProperties5);

			Run run12 = new Run();

			RunProperties runProperties8 = new RunProperties();
			RunFonts runFonts10 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold10 = new Bold();

			runProperties8.Append(runFonts10);
			runProperties8.Append(bold10);
			Text text9 = new Text();
			text9.Text = "RE";

			run12.Append(runProperties8);
			run12.Append(text9);

			paragraph8.Append(paragraphProperties8);
			paragraph8.Append(run12);

			textBoxContent5.Append(paragraph8);

			textBoxInfo23.Append(textBoxContent5);

			Wps.TextBodyProperties textBodyProperties3 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.None, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
			A.ShapeAutoFit shapeAutoFit3 = new A.ShapeAutoFit();

			textBodyProperties3.Append(shapeAutoFit3);

			wordprocessingShape3.Append(nonVisualDrawingShapeProperties3);
			wordprocessingShape3.Append(shapeProperties3);
			wordprocessingShape3.Append(textBoxInfo23);
			wordprocessingShape3.Append(textBodyProperties3);

			graphicData3.Append(wordprocessingShape3);

			graphic3.Append(graphicData3);

			Wp14.RelativeWidth relativeWidth3 = new Wp14.RelativeWidth() { ObjectId = Wp14.SizeRelativeHorizontallyValues.Margin };
			Wp14.PercentageWidth percentageWidth3 = new Wp14.PercentageWidth();
			percentageWidth3.Text = "40000";

			relativeWidth3.Append(percentageWidth3);

			Wp14.RelativeHeight relativeHeight3 = new Wp14.RelativeHeight() { RelativeFrom = Wp14.SizeRelativeVerticallyValues.Margin };
			Wp14.PercentageHeight percentageHeight3 = new Wp14.PercentageHeight();
			percentageHeight3.Text = "20000";

			relativeHeight3.Append(percentageHeight3);

			anchor3.Append(simplePosition3);
			anchor3.Append(horizontalPosition3);
			anchor3.Append(verticalPosition3);
			anchor3.Append(extent3);
			anchor3.Append(effectExtent3);
			anchor3.Append(wrapNone3);
			anchor3.Append(docProperties3);
			anchor3.Append(nonVisualGraphicFrameDrawingProperties3);
			anchor3.Append(graphic3);
			anchor3.Append(relativeWidth3);
			anchor3.Append(relativeHeight3);

			drawing3.Append(anchor3);

			alternateContentChoice3.Append(drawing3);

			AlternateContentFallback alternateContentFallback3 = new AlternateContentFallback();

			Picture picture3 = new Picture();

			V.Shape shape3 = new V.Shape() { Id = "_x0000_s1028", Style = "position:absolute;margin-left:0;margin-top:-7.1pt;width:12.75pt;height:12.05pt;z-index:251663360;visibility:visible;mso-wrap-style:none;mso-width-percent:400;mso-height-percent:200;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:char;mso-position-vertical:absolute;mso-position-vertical-relative:line;mso-width-percent:400;mso-height-percent:200;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top", Filled = false, Stroked = false, Type = "#_x0000_t202", EncodedPackage = "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\n" };
			shape3.SetAttribute(new OpenXmlAttribute("w14", "anchorId", "http://schemas.microsoft.com/office/word/2010/wordml", "341B3744"));

			V.TextBox textBox3 = new V.TextBox() { Style = "mso-fit-shape-to-text:t", Inset = "0,0,0,0" };

			TextBoxContent textBoxContent6 = new TextBoxContent();

			Paragraph paragraph9 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties9 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
			RunFonts runFonts11 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold11 = new Bold();

			paragraphMarkRunProperties6.Append(runFonts11);
			paragraphMarkRunProperties6.Append(bold11);

			paragraphProperties9.Append(paragraphMarkRunProperties6);

			Run run13 = new Run();

			RunProperties runProperties9 = new RunProperties();
			RunFonts runFonts12 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold12 = new Bold();

			runProperties9.Append(runFonts12);
			runProperties9.Append(bold12);
			Text text10 = new Text();
			text10.Text = "RE";

			run13.Append(runProperties9);
			run13.Append(text10);

			paragraph9.Append(paragraphProperties9);
			paragraph9.Append(run13);

			textBoxContent6.Append(paragraph9);

			textBox3.Append(textBoxContent6);
			Wvml.TextWrap textWrap3 = new Wvml.TextWrap() { AnchorY = new EnumValue<DocumentFormat.OpenXml.Vml.Wordprocessing.VerticalAnchorValues>() { InnerText = "line" } };

			shape3.Append(textBox3);
			shape3.Append(textWrap3);

			picture3.Append(shape3);

			alternateContentFallback3.Append(picture3);

			alternateContent3.Append(alternateContentChoice3);
			alternateContent3.Append(alternateContentFallback3);

			run11.Append(runProperties7);
			run11.Append(alternateContent3);

			Run run14 = new Run();
			Text text11 = new Text();
			text11.Text = "calzette rosse";

			run14.Append(text11);

			Run run15 = new Run();
			Break break1 = new Break();

			run15.Append(break1);

			Run run16 = new Run();

			RunProperties runProperties10 = new RunProperties();
			NoProof noProof4 = new NoProof();

			runProperties10.Append(noProof4);

			AlternateContent alternateContent4 = new AlternateContent();

			AlternateContentChoice alternateContentChoice4 = new AlternateContentChoice() { Requires = "wps" };

			Drawing drawing4 = new Drawing();

			Wp.Anchor anchor4 = new Wp.Anchor() { DistanceFromTop = (UInt32Value)45720U, DistanceFromBottom = (UInt32Value)45720U, DistanceFromLeft = (UInt32Value)114300U, DistanceFromRight = (UInt32Value)114300U, SimplePos = false, RelativeHeight = (UInt32Value)251665408U, BehindDoc = false, Locked = false, LayoutInCell = true, AllowOverlap = true, EditId = "19538B1D", AnchorId = "46D2A011" };
			Wp.SimplePosition simplePosition4 = new Wp.SimplePosition() { X = 0L, Y = 0L };

			Wp.HorizontalPosition horizontalPosition4 = new Wp.HorizontalPosition() { RelativeFrom = Wp.HorizontalRelativePositionValues.Character };
			Wp.PositionOffset positionOffset7 = new Wp.PositionOffset();
			positionOffset7.Text = "0";

			horizontalPosition4.Append(positionOffset7);

			Wp.VerticalPosition verticalPosition4 = new Wp.VerticalPosition() { RelativeFrom = Wp.VerticalRelativePositionValues.Line };
			Wp.PositionOffset positionOffset8 = new Wp.PositionOffset();
			positionOffset8.Text = "-90170";

			verticalPosition4.Append(positionOffset8);
			Wp.Extent extent4 = new Wp.Extent() { Cx = 161925L, Cy = 153035L };
			Wp.EffectExtent effectExtent4 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 9525L, BottomEdge = 0L };
			Wp.WrapNone wrapNone4 = new Wp.WrapNone();
			Wp.DocProperties docProperties4 = new Wp.DocProperties() { Id = (UInt32Value)3U, Name = "Casella di testo 3" };

			Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties4 = new Wp.NonVisualGraphicFrameDrawingProperties();

			A.GraphicFrameLocks graphicFrameLocks4 = new A.GraphicFrameLocks();
			graphicFrameLocks4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			nonVisualGraphicFrameDrawingProperties4.Append(graphicFrameLocks4);

			A.Graphic graphic4 = new A.Graphic();
			graphic4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			A.GraphicData graphicData4 = new A.GraphicData() { Uri = "http://schemas.microsoft.com/office/word/2010/wordprocessingShape" };

			Wps.WordprocessingShape wordprocessingShape4 = new Wps.WordprocessingShape();

			Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties4 = new Wps.NonVisualDrawingShapeProperties() { TextBox = true };
			A.ShapeLocks shapeLocks4 = new A.ShapeLocks() { NoChangeArrowheads = true };

			nonVisualDrawingShapeProperties4.Append(shapeLocks4);

			Wps.ShapeProperties shapeProperties4 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

			A.Transform2D transform2D4 = new A.Transform2D();
			A.Offset offset4 = new A.Offset() { X = 0L, Y = 0L };
			A.Extents extents4 = new A.Extents() { Cx = 161925L, Cy = 153035L };

			transform2D4.Append(offset4);
			transform2D4.Append(extents4);

			A.PresetGeometry presetGeometry4 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
			A.AdjustValueList adjustValueList4 = new A.AdjustValueList();

			presetGeometry4.Append(adjustValueList4);
			A.NoFill noFill7 = new A.NoFill();

			A.Outline outline4 = new A.Outline() { Width = 9525 };
			A.NoFill noFill8 = new A.NoFill();
			A.Miter miter4 = new A.Miter() { Limit = 800000 };
			A.HeadEnd headEnd4 = new A.HeadEnd();
			A.TailEnd tailEnd4 = new A.TailEnd();

			outline4.Append(noFill8);
			outline4.Append(miter4);
			outline4.Append(headEnd4);
			outline4.Append(tailEnd4);

			shapeProperties4.Append(transform2D4);
			shapeProperties4.Append(presetGeometry4);
			shapeProperties4.Append(noFill7);
			shapeProperties4.Append(outline4);

			Wps.TextBoxInfo2 textBoxInfo24 = new Wps.TextBoxInfo2();

			TextBoxContent textBoxContent7 = new TextBoxContent();

			Paragraph paragraph10 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties10 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
			RunFonts runFonts13 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold13 = new Bold();

			paragraphMarkRunProperties7.Append(runFonts13);
			paragraphMarkRunProperties7.Append(bold13);

			paragraphProperties10.Append(paragraphMarkRunProperties7);

			Run run17 = new Run();

			RunProperties runProperties11 = new RunProperties();
			RunFonts runFonts14 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold14 = new Bold();

			runProperties11.Append(runFonts14);
			runProperties11.Append(bold14);
			Text text12 = new Text();
			text12.Text = "LA";

			run17.Append(runProperties11);
			run17.Append(text12);

			paragraph10.Append(paragraphProperties10);
			paragraph10.Append(run17);

			textBoxContent7.Append(paragraph10);

			textBoxInfo24.Append(textBoxContent7);

			Wps.TextBodyProperties textBodyProperties4 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.None, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
			A.ShapeAutoFit shapeAutoFit4 = new A.ShapeAutoFit();

			textBodyProperties4.Append(shapeAutoFit4);

			wordprocessingShape4.Append(nonVisualDrawingShapeProperties4);
			wordprocessingShape4.Append(shapeProperties4);
			wordprocessingShape4.Append(textBoxInfo24);
			wordprocessingShape4.Append(textBodyProperties4);

			graphicData4.Append(wordprocessingShape4);

			graphic4.Append(graphicData4);

			Wp14.RelativeWidth relativeWidth4 = new Wp14.RelativeWidth() { ObjectId = Wp14.SizeRelativeHorizontallyValues.Margin };
			Wp14.PercentageWidth percentageWidth4 = new Wp14.PercentageWidth();
			percentageWidth4.Text = "40000";

			relativeWidth4.Append(percentageWidth4);

			Wp14.RelativeHeight relativeHeight4 = new Wp14.RelativeHeight() { RelativeFrom = Wp14.SizeRelativeVerticallyValues.Margin };
			Wp14.PercentageHeight percentageHeight4 = new Wp14.PercentageHeight();
			percentageHeight4.Text = "20000";

			relativeHeight4.Append(percentageHeight4);

			anchor4.Append(simplePosition4);
			anchor4.Append(horizontalPosition4);
			anchor4.Append(verticalPosition4);
			anchor4.Append(extent4);
			anchor4.Append(effectExtent4);
			anchor4.Append(wrapNone4);
			anchor4.Append(docProperties4);
			anchor4.Append(nonVisualGraphicFrameDrawingProperties4);
			anchor4.Append(graphic4);
			anchor4.Append(relativeWidth4);
			anchor4.Append(relativeHeight4);

			drawing4.Append(anchor4);

			alternateContentChoice4.Append(drawing4);

			AlternateContentFallback alternateContentFallback4 = new AlternateContentFallback();

			Picture picture4 = new Picture();

			V.Shape shape4 = new V.Shape() { Id = "Casella di testo 3", Style = "position:absolute;margin-left:0;margin-top:-7.1pt;width:12.75pt;height:12.05pt;z-index:251665408;visibility:visible;mso-wrap-style:none;mso-width-percent:400;mso-height-percent:200;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:char;mso-position-vertical:absolute;mso-position-vertical-relative:line;mso-width-percent:400;mso-height-percent:200;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top", OptionalString = "_x0000_s1029", Filled = false, Stroked = false, Type = "#_x0000_t202", EncodedPackage = "UEsDBBQABgAIAAAAIQC2gziS/gAAAOEBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbJSRQU7DMBBF\n90jcwfIWJU67QAgl6YK0S0CoHGBkTxKLZGx5TGhvj5O2G0SRWNoz/78nu9wcxkFMGNg6quQqL6RA\n0s5Y6ir5vt9lD1JwBDIwOMJKHpHlpr69KfdHjyxSmriSfYz+USnWPY7AufNIadK6MEJMx9ApD/oD\nOlTrorhX2lFEilmcO2RdNtjC5xDF9pCuTyYBB5bi6bQ4syoJ3g9WQ0ymaiLzg5KdCXlKLjvcW893\nSUOqXwnz5DrgnHtJTxOsQfEKIT7DmDSUCaxw7Rqn8787ZsmRM9e2VmPeBN4uqYvTtW7jvijg9N/y\nJsXecLq0q+WD6m8AAAD//wMAUEsDBBQABgAIAAAAIQA4/SH/1gAAAJQBAAALAAAAX3JlbHMvLnJl\nbHOkkMFqwzAMhu+DvYPRfXGawxijTi+j0GvpHsDYimMaW0Yy2fr2M4PBMnrbUb/Q94l/f/hMi1qR\nJVI2sOt6UJgd+ZiDgffL8ekFlFSbvV0oo4EbChzGx4f9GRdb25HMsYhqlCwG5lrLq9biZkxWOiqY\n22YiTra2kYMu1l1tQD30/bPm3wwYN0x18gb45AdQl1tp5j/sFB2T0FQ7R0nTNEV3j6o9feQzro1i\nOWA14Fm+Q8a1a8+Bvu/d/dMb2JY5uiPbhG/ktn4cqGU/er3pcvwCAAD//wMAUEsDBBQABgAIAAAA\nIQBltTkBBQIAAO4DAAAOAAAAZHJzL2Uyb0RvYy54bWysU8Fu2zAMvQ/YPwi6L3YSpGiNOEWXLsOA\nbh3Q7QMYWY6FSaIgqbGzrx8lx2nR3Yb5IFAW+cj39LS+HYxmR+mDQlvz+azkTFqBjbKHmv/8sftw\nzVmIYBvQaGXNTzLw2837d+veVXKBHepGekYgNlS9q3kXo6uKIohOGggzdNLSYYveQKStPxSNh57Q\njS4WZXlV9Ogb51HIEOjv/XjINxm/baWIj20bZGS65jRbzKvP6z6txWYN1cGD65Q4jwH/MIUBZanp\nBeoeIrBnr/6CMkp4DNjGmUBTYNsqITMHYjMv37B56sDJzIXECe4iU/h/sOLb8btnqqn5kjMLhq5o\nC0FqDaxRLMoQkS2TSr0LFSU/OUqPw0cc6LYz4+AeUPwKzOK2A3uQd95j30loaMp5qixelY44IYHs\n+6/YUDt4jpiBhtabJCGJwgidbut0uSE5RCZSy6v5zWLFmaCj+WpZLle5A1RTsfMhfpZoWApq7skA\nGRyODyGmYaCaUlIvizuldTaBtqyv+c2K4N+cGBXJo1qZml+X6Rtdkzh+sk0ujqD0GFMDbc+kE8+R\ncRz2w1llyk+C7LE5kQoeR0vSE6KgQ/+bs57sWHNL74Uz/cWSjsm5U+CnYD8FYAUV1jxyNobbmB2e\naAR3R/ruVOb+0vc8IJkqS3J+AMm1r/c56+WZbv4AAAD//wMAUEsDBBQABgAIAAAAIQBQx11V3gAA\nAAUBAAAPAAAAZHJzL2Rvd25yZXYueG1sTI9BS8NAFITvgv9heYIXaTcNrdg0L6UURBCF2tpDb5vs\nMxvMvg3ZbZr+e9eTHocZZr7J16NtxUC9bxwjzKYJCOLK6YZrhM/D8+QJhA+KtWodE8KVPKyL25tc\nZdpd+IOGfahFLGGfKQQTQpdJ6StDVvmp64ij9+V6q0KUfS11ry6x3LYyTZJHaVXDccGojraGqu/9\n2SKU7+GQzjcvp6updtvu7eE4vPIR8f5u3KxABBrDXxh+8SM6FJGpdGfWXrQI8UhAmMzmKYhop4sF\niBJhuQRZ5PI/ffEDAAD//wMAUEsBAi0AFAAGAAgAAAAhALaDOJL+AAAA4QEAABMAAAAAAAAAAAAA\nAAAAAAAAAFtDb250ZW50X1R5cGVzXS54bWxQSwECLQAUAAYACAAAACEAOP0h/9YAAACUAQAACwAA\nAAAAAAAAAAAAAAAvAQAAX3JlbHMvLnJlbHNQSwECLQAUAAYACAAAACEAZbU5AQUCAADuAwAADgAA\nAAAAAAAAAAAAAAAuAgAAZHJzL2Uyb0RvYy54bWxQSwECLQAUAAYACAAAACEAUMddVd4AAAAFAQAA\nDwAAAAAAAAAAAAAAAABfBAAAZHJzL2Rvd25yZXYueG1sUEsFBgAAAAAEAAQA8wAAAGoFAAAAAA==\n" };
			shape4.SetAttribute(new OpenXmlAttribute("w14", "anchorId", "http://schemas.microsoft.com/office/word/2010/wordml", "46D2A011"));

			V.TextBox textBox4 = new V.TextBox() { Style = "mso-fit-shape-to-text:t", Inset = "0,0,0,0" };

			TextBoxContent textBoxContent8 = new TextBoxContent();

			Paragraph paragraph11 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties11 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
			RunFonts runFonts15 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold15 = new Bold();

			paragraphMarkRunProperties8.Append(runFonts15);
			paragraphMarkRunProperties8.Append(bold15);

			paragraphProperties11.Append(paragraphMarkRunProperties8);

			Run run18 = new Run();

			RunProperties runProperties12 = new RunProperties();
			RunFonts runFonts16 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold16 = new Bold();

			runProperties12.Append(runFonts16);
			runProperties12.Append(bold16);
			Text text13 = new Text();
			text13.Text = "LA";

			run18.Append(runProperties12);
			run18.Append(text13);

			paragraph11.Append(paragraphProperties11);
			paragraph11.Append(run18);

			textBoxContent8.Append(paragraph11);

			textBox4.Append(textBoxContent8);
			Wvml.TextWrap textWrap4 = new Wvml.TextWrap() { AnchorY = new EnumValue<DocumentFormat.OpenXml.Vml.Wordprocessing.VerticalAnchorValues>() { InnerText = "line" } };

			shape4.Append(textBox4);
			shape4.Append(textWrap4);

			picture4.Append(shape4);

			alternateContentFallback4.Append(picture4);

			alternateContent4.Append(alternateContentChoice4);
			alternateContent4.Append(alternateContentFallback4);

			run16.Append(runProperties10);
			run16.Append(alternateContent4);

			Run run19 = new Run();
			Text text14 = new Text();
			text14.Text = "e l’innocenza sulle g";

			run19.Append(text14);

			Run run20 = new Run();

			RunProperties runProperties13 = new RunProperties();
			NoProof noProof5 = new NoProof();

			runProperties13.Append(noProof5);

			AlternateContent alternateContent5 = new AlternateContent();

			AlternateContentChoice alternateContentChoice5 = new AlternateContentChoice() { Requires = "wps" };

			Drawing drawing5 = new Drawing();

			Wp.Anchor anchor5 = new Wp.Anchor() { DistanceFromTop = (UInt32Value)45720U, DistanceFromBottom = (UInt32Value)45720U, DistanceFromLeft = (UInt32Value)114300U, DistanceFromRight = (UInt32Value)114300U, SimplePos = false, RelativeHeight = (UInt32Value)251667456U, BehindDoc = false, Locked = false, LayoutInCell = true, AllowOverlap = true, EditId = "4A4F5694", AnchorId = "03756925" };
			Wp.SimplePosition simplePosition5 = new Wp.SimplePosition() { X = 0L, Y = 0L };

			Wp.HorizontalPosition horizontalPosition5 = new Wp.HorizontalPosition() { RelativeFrom = Wp.HorizontalRelativePositionValues.Character };
			Wp.PositionOffset positionOffset9 = new Wp.PositionOffset();
			positionOffset9.Text = "0";

			horizontalPosition5.Append(positionOffset9);

			Wp.VerticalPosition verticalPosition5 = new Wp.VerticalPosition() { RelativeFrom = Wp.VerticalRelativePositionValues.Line };
			Wp.PositionOffset positionOffset10 = new Wp.PositionOffset();
			positionOffset10.Text = "-90170";

			verticalPosition5.Append(positionOffset10);
			Wp.Extent extent5 = new Wp.Extent() { Cx = 161925L, Cy = 153035L };
			Wp.EffectExtent effectExtent5 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 9525L, BottomEdge = 0L };
			Wp.WrapNone wrapNone5 = new Wp.WrapNone();
			Wp.DocProperties docProperties5 = new Wp.DocProperties() { Id = (UInt32Value)4U, Name = "Casella di testo 4" };

			Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties5 = new Wp.NonVisualGraphicFrameDrawingProperties();

			A.GraphicFrameLocks graphicFrameLocks5 = new A.GraphicFrameLocks();
			graphicFrameLocks5.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			nonVisualGraphicFrameDrawingProperties5.Append(graphicFrameLocks5);

			A.Graphic graphic5 = new A.Graphic();
			graphic5.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			A.GraphicData graphicData5 = new A.GraphicData() { Uri = "http://schemas.microsoft.com/office/word/2010/wordprocessingShape" };

			Wps.WordprocessingShape wordprocessingShape5 = new Wps.WordprocessingShape();

			Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties5 = new Wps.NonVisualDrawingShapeProperties() { TextBox = true };
			A.ShapeLocks shapeLocks5 = new A.ShapeLocks() { NoChangeArrowheads = true };

			nonVisualDrawingShapeProperties5.Append(shapeLocks5);

			Wps.ShapeProperties shapeProperties5 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

			A.Transform2D transform2D5 = new A.Transform2D();
			A.Offset offset5 = new A.Offset() { X = 0L, Y = 0L };
			A.Extents extents5 = new A.Extents() { Cx = 161925L, Cy = 153035L };

			transform2D5.Append(offset5);
			transform2D5.Append(extents5);

			A.PresetGeometry presetGeometry5 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
			A.AdjustValueList adjustValueList5 = new A.AdjustValueList();

			presetGeometry5.Append(adjustValueList5);
			A.NoFill noFill9 = new A.NoFill();

			A.Outline outline5 = new A.Outline() { Width = 9525 };
			A.NoFill noFill10 = new A.NoFill();
			A.Miter miter5 = new A.Miter() { Limit = 800000 };
			A.HeadEnd headEnd5 = new A.HeadEnd();
			A.TailEnd tailEnd5 = new A.TailEnd();

			outline5.Append(noFill10);
			outline5.Append(miter5);
			outline5.Append(headEnd5);
			outline5.Append(tailEnd5);

			shapeProperties5.Append(transform2D5);
			shapeProperties5.Append(presetGeometry5);
			shapeProperties5.Append(noFill9);
			shapeProperties5.Append(outline5);

			Wps.TextBoxInfo2 textBoxInfo25 = new Wps.TextBoxInfo2();

			TextBoxContent textBoxContent9 = new TextBoxContent();

			Paragraph paragraph12 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties12 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
			RunFonts runFonts17 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold17 = new Bold();

			paragraphMarkRunProperties9.Append(runFonts17);
			paragraphMarkRunProperties9.Append(bold17);

			paragraphProperties12.Append(paragraphMarkRunProperties9);

			Run run21 = new Run();

			RunProperties runProperties14 = new RunProperties();
			RunFonts runFonts18 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold18 = new Bold();

			runProperties14.Append(runFonts18);
			runProperties14.Append(bold18);
			Text text15 = new Text();
			text15.Text = "MI";

			run21.Append(runProperties14);
			run21.Append(text15);

			paragraph12.Append(paragraphProperties12);
			paragraph12.Append(run21);

			textBoxContent9.Append(paragraph12);

			textBoxInfo25.Append(textBoxContent9);

			Wps.TextBodyProperties textBodyProperties5 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.None, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
			A.ShapeAutoFit shapeAutoFit5 = new A.ShapeAutoFit();

			textBodyProperties5.Append(shapeAutoFit5);

			wordprocessingShape5.Append(nonVisualDrawingShapeProperties5);
			wordprocessingShape5.Append(shapeProperties5);
			wordprocessingShape5.Append(textBoxInfo25);
			wordprocessingShape5.Append(textBodyProperties5);

			graphicData5.Append(wordprocessingShape5);

			graphic5.Append(graphicData5);

			Wp14.RelativeWidth relativeWidth5 = new Wp14.RelativeWidth() { ObjectId = Wp14.SizeRelativeHorizontallyValues.Margin };
			Wp14.PercentageWidth percentageWidth5 = new Wp14.PercentageWidth();
			percentageWidth5.Text = "40000";

			relativeWidth5.Append(percentageWidth5);

			Wp14.RelativeHeight relativeHeight5 = new Wp14.RelativeHeight() { RelativeFrom = Wp14.SizeRelativeVerticallyValues.Margin };
			Wp14.PercentageHeight percentageHeight5 = new Wp14.PercentageHeight();
			percentageHeight5.Text = "20000";

			relativeHeight5.Append(percentageHeight5);

			anchor5.Append(simplePosition5);
			anchor5.Append(horizontalPosition5);
			anchor5.Append(verticalPosition5);
			anchor5.Append(extent5);
			anchor5.Append(effectExtent5);
			anchor5.Append(wrapNone5);
			anchor5.Append(docProperties5);
			anchor5.Append(nonVisualGraphicFrameDrawingProperties5);
			anchor5.Append(graphic5);
			anchor5.Append(relativeWidth5);
			anchor5.Append(relativeHeight5);

			drawing5.Append(anchor5);

			alternateContentChoice5.Append(drawing5);

			AlternateContentFallback alternateContentFallback5 = new AlternateContentFallback();

			Picture picture5 = new Picture();

			V.Shape shape5 = new V.Shape() { Id = "Casella di testo 4", Style = "position:absolute;margin-left:0;margin-top:-7.1pt;width:12.75pt;height:12.05pt;z-index:251667456;visibility:visible;mso-wrap-style:none;mso-width-percent:400;mso-height-percent:200;mso-wrap-distance-left:9pt;mso-wrap-distance-top:3.6pt;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:3.6pt;mso-position-horizontal:absolute;mso-position-horizontal-relative:char;mso-position-vertical:absolute;mso-position-vertical-relative:line;mso-width-percent:400;mso-height-percent:200;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top", OptionalString = "_x0000_s1030", Filled = false, Stroked = false, Type = "#_x0000_t202", EncodedPackage = "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\n" };
			shape5.SetAttribute(new OpenXmlAttribute("w14", "anchorId", "http://schemas.microsoft.com/office/word/2010/wordml", "03756925"));

			V.TextBox textBox5 = new V.TextBox() { Style = "mso-fit-shape-to-text:t", Inset = "0,0,0,0" };

			TextBoxContent textBoxContent10 = new TextBoxContent();

			Paragraph paragraph13 = new Paragraph() { RsidParagraphMarkRevision = "00496A6D", RsidParagraphAddition = "00496A6D", RsidParagraphProperties = "00496A6D", RsidRunAdditionDefault = "00496A6D" };

			ParagraphProperties paragraphProperties13 = new ParagraphProperties();

			ParagraphMarkRunProperties paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
			RunFonts runFonts19 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold19 = new Bold();

			paragraphMarkRunProperties10.Append(runFonts19);
			paragraphMarkRunProperties10.Append(bold19);

			paragraphProperties13.Append(paragraphMarkRunProperties10);

			Run run22 = new Run();

			RunProperties runProperties15 = new RunProperties();
			RunFonts runFonts20 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold20 = new Bold();

			runProperties15.Append(runFonts20);
			runProperties15.Append(bold20);
			Text text16 = new Text();
			text16.Text = "MI";

			run22.Append(runProperties15);
			run22.Append(text16);

			paragraph13.Append(paragraphProperties13);
			paragraph13.Append(run22);

			textBoxContent10.Append(paragraph13);

			textBox5.Append(textBoxContent10);
			Wvml.TextWrap textWrap5 = new Wvml.TextWrap() { AnchorY = new EnumValue<DocumentFormat.OpenXml.Vml.Wordprocessing.VerticalAnchorValues>() { InnerText = "line" } };

			shape5.Append(textBox5);
			shape5.Append(textWrap5);

			picture5.Append(shape5);

			alternateContentFallback5.Append(picture5);

			alternateContent5.Append(alternateContentChoice5);
			alternateContent5.Append(alternateContentFallback5);

			run20.Append(runProperties13);
			run20.Append(alternateContent5);

			Run run23 = new Run();
			Text text17 = new Text();
			text17.Text = "ote tue, due arance ancor più rosse";

			run23.Append(text17);

			Run run24 = new Run();
			Break break2 = new Break();
			Text text18 = new Text();
			text18.Text = "e la cantina buia do";

			run24.Append(break2);
			run24.Append(text18);
			BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
			BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

			Run run25 = new Run();
			Text text19 = new Text();
			text19.Text = "ve noi, respiravamo piano";

			run25.Append(text19);

			paragraph3.Append(paragraphProperties3);
			paragraph3.Append(run3);
			paragraph3.Append(run6);
			paragraph3.Append(run7);
			paragraph3.Append(run10);
			paragraph3.Append(run11);
			paragraph3.Append(run14);
			paragraph3.Append(run15);
			paragraph3.Append(run16);
			paragraph3.Append(run19);
			paragraph3.Append(run20);
			paragraph3.Append(run23);
			paragraph3.Append(run24);
			paragraph3.Append(bookmarkStart1);
			paragraph3.Append(bookmarkEnd1);
			paragraph3.Append(run25);

			SectionProperties sectionProperties1 = new SectionProperties() { RsidRPr = "00496A6D", RsidR = "00496A6D", RsidSect = "00937B3B" };
			PageSize pageSize1 = new PageSize() { Width = (UInt32Value)8391U, Height = (UInt32Value)11907U, Code = (UInt16Value)11U };
			PageMargin pageMargin1 = new PageMargin() { Top = 284, Right = (UInt32Value)284U, Bottom = 284, Left = (UInt32Value)1134U, Header = (UInt32Value)709U, Footer = (UInt32Value)709U, Gutter = (UInt32Value)0U };
			Columns columns1 = new Columns() { Space = "708" };
			DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };

			sectionProperties1.Append(pageSize1);
			sectionProperties1.Append(pageMargin1);
			sectionProperties1.Append(columns1);
			sectionProperties1.Append(docGrid1);

			body1.Append(paragraph1);
			body1.Append(paragraph2);
			body1.Append(paragraph3);
			body1.Append(sectionProperties1);

			document1.Append(body1);

			mainDocumentPart1.Document = document1;
		}

		// Generates content of webSettingsPart1.
		private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
		{
			WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15" } };
			webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			webSettings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");

			Divs divs1 = new Divs();

			Div div1 = new Div() { Id = "1276405551" };
			BodyDiv bodyDiv1 = new BodyDiv() { Val = true };
			LeftMarginDiv leftMarginDiv1 = new LeftMarginDiv() { Val = "0" };
			RightMarginDiv rightMarginDiv1 = new RightMarginDiv() { Val = "0" };
			TopMarginDiv topMarginDiv1 = new TopMarginDiv() { Val = "0" };
			BottomMarginDiv bottomMarginDiv1 = new BottomMarginDiv() { Val = "0" };

			DivBorder divBorder1 = new DivBorder();
			TopBorder topBorder1 = new TopBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

			divBorder1.Append(topBorder1);
			divBorder1.Append(leftBorder1);
			divBorder1.Append(bottomBorder1);
			divBorder1.Append(rightBorder1);

			div1.Append(bodyDiv1);
			div1.Append(leftMarginDiv1);
			div1.Append(rightMarginDiv1);
			div1.Append(topMarginDiv1);
			div1.Append(bottomMarginDiv1);
			div1.Append(divBorder1);

			Div div2 = new Div() { Id = "1765148426" };
			BodyDiv bodyDiv2 = new BodyDiv() { Val = true };
			LeftMarginDiv leftMarginDiv2 = new LeftMarginDiv() { Val = "0" };
			RightMarginDiv rightMarginDiv2 = new RightMarginDiv() { Val = "0" };
			TopMarginDiv topMarginDiv2 = new TopMarginDiv() { Val = "0" };
			BottomMarginDiv bottomMarginDiv2 = new BottomMarginDiv() { Val = "0" };

			DivBorder divBorder2 = new DivBorder();
			TopBorder topBorder2 = new TopBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

			divBorder2.Append(topBorder2);
			divBorder2.Append(leftBorder2);
			divBorder2.Append(bottomBorder2);
			divBorder2.Append(rightBorder2);

			div2.Append(bodyDiv2);
			div2.Append(leftMarginDiv2);
			div2.Append(rightMarginDiv2);
			div2.Append(topMarginDiv2);
			div2.Append(bottomMarginDiv2);
			div2.Append(divBorder2);

			Div div3 = new Div() { Id = "1917475967" };
			BodyDiv bodyDiv3 = new BodyDiv() { Val = true };
			LeftMarginDiv leftMarginDiv3 = new LeftMarginDiv() { Val = "0" };
			RightMarginDiv rightMarginDiv3 = new RightMarginDiv() { Val = "0" };
			TopMarginDiv topMarginDiv3 = new TopMarginDiv() { Val = "0" };
			BottomMarginDiv bottomMarginDiv3 = new BottomMarginDiv() { Val = "0" };

			DivBorder divBorder3 = new DivBorder();
			TopBorder topBorder3 = new TopBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

			divBorder3.Append(topBorder3);
			divBorder3.Append(leftBorder3);
			divBorder3.Append(bottomBorder3);
			divBorder3.Append(rightBorder3);

			div3.Append(bodyDiv3);
			div3.Append(leftMarginDiv3);
			div3.Append(rightMarginDiv3);
			div3.Append(topMarginDiv3);
			div3.Append(bottomMarginDiv3);
			div3.Append(divBorder3);

			Div div4 = new Div() { Id = "2030908765" };
			BodyDiv bodyDiv4 = new BodyDiv() { Val = true };
			LeftMarginDiv leftMarginDiv4 = new LeftMarginDiv() { Val = "0" };
			RightMarginDiv rightMarginDiv4 = new RightMarginDiv() { Val = "0" };
			TopMarginDiv topMarginDiv4 = new TopMarginDiv() { Val = "0" };
			BottomMarginDiv bottomMarginDiv4 = new BottomMarginDiv() { Val = "0" };

			DivBorder divBorder4 = new DivBorder();
			TopBorder topBorder4 = new TopBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
			RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

			divBorder4.Append(topBorder4);
			divBorder4.Append(leftBorder4);
			divBorder4.Append(bottomBorder4);
			divBorder4.Append(rightBorder4);

			div4.Append(bodyDiv4);
			div4.Append(leftMarginDiv4);
			div4.Append(rightMarginDiv4);
			div4.Append(topMarginDiv4);
			div4.Append(bottomMarginDiv4);
			div4.Append(divBorder4);

			divs1.Append(div1);
			divs1.Append(div2);
			divs1.Append(div3);
			divs1.Append(div4);
			OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();

			webSettings1.Append(divs1);
			webSettings1.Append(optimizeForBrowser1);

			webSettingsPart1.WebSettings = webSettings1;
		}

		// Generates content of documentSettingsPart1.
		private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
		{
			DocumentFormat.OpenXml.Wordprocessing.Settings settings1 = new DocumentFormat.OpenXml.Wordprocessing.Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15" } };
			settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
			settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
			settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
			settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
			settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			settings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
			settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
			Zoom zoom1 = new Zoom() { Percent = "120" };
			MirrorMargins mirrorMargins1 = new MirrorMargins();
			ProofState proofState1 = new ProofState() { Grammar = ProofingStateValues.Clean };
			AttachedTemplate attachedTemplate1 = new AttachedTemplate() { Id = "rId1" };
			StylePaneFormatFilter stylePaneFormatFilter1 = new StylePaneFormatFilter() { Val = "1024", AllStyles = false, CustomStyles = false, LatentStyles = true, StylesInUse = false, HeadingStyles = true, NumberingStyles = false, TableStyles = false, DirectFormattingOnRuns = false, DirectFormattingOnParagraphs = false, DirectFormattingOnNumbering = false, DirectFormattingOnTables = false, ClearFormatting = true, Top3HeadingStyles = false, VisibleStyles = false, AlternateStyleNames = false };
			DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 720 };
			HyphenationZone hyphenationZone1 = new HyphenationZone() { Val = "283" };
			DrawingGridHorizontalSpacing drawingGridHorizontalSpacing1 = new DrawingGridHorizontalSpacing() { Val = "110" };
			DisplayHorizontalDrawingGrid displayHorizontalDrawingGrid1 = new DisplayHorizontalDrawingGrid() { Val = 2 };
			CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

			Compatibility compatibility1 = new Compatibility();
			CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "15" };
			CompatibilitySetting compatibilitySetting2 = new CompatibilitySetting() { Name = CompatSettingNameValues.OverrideTableStyleFontSizeAndJustification, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
			CompatibilitySetting compatibilitySetting3 = new CompatibilitySetting() { Name = CompatSettingNameValues.EnableOpenTypeFeatures, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
			CompatibilitySetting compatibilitySetting4 = new CompatibilitySetting() { Name = CompatSettingNameValues.DoNotFlipMirrorIndents, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
			CompatibilitySetting compatibilitySetting5 = new CompatibilitySetting() { Name = CompatSettingNameValues.DifferentiateMultirowTableHeaders, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };

			compatibility1.Append(compatibilitySetting1);
			compatibility1.Append(compatibilitySetting2);
			compatibility1.Append(compatibilitySetting3);
			compatibility1.Append(compatibilitySetting4);
			compatibility1.Append(compatibilitySetting5);

			Rsids rsids1 = new Rsids();
			RsidRoot rsidRoot1 = new RsidRoot() { Val = "00496A6D" };
			Rsid rsid1 = new Rsid() { Val = "000F4940" };
			Rsid rsid2 = new Rsid() { Val = "00133575" };
			Rsid rsid3 = new Rsid() { Val = "00136951" };
			Rsid rsid4 = new Rsid() { Val = "00162DC9" };
			Rsid rsid5 = new Rsid() { Val = "0020187D" };
			Rsid rsid6 = new Rsid() { Val = "0024134E" };
			Rsid rsid7 = new Rsid() { Val = "002A50C0" };
			Rsid rsid8 = new Rsid() { Val = "002D6866" };
			Rsid rsid9 = new Rsid() { Val = "00496A6D" };
			Rsid rsid10 = new Rsid() { Val = "00522591" };
			Rsid rsid11 = new Rsid() { Val = "00531640" };
			Rsid rsid12 = new Rsid() { Val = "005610C4" };
			Rsid rsid13 = new Rsid() { Val = "00621C55" };
			Rsid rsid14 = new Rsid() { Val = "00826D15" };
			Rsid rsid15 = new Rsid() { Val = "00850FBC" };
			Rsid rsid16 = new Rsid() { Val = "008A008A" };
			Rsid rsid17 = new Rsid() { Val = "008B204D" };
			Rsid rsid18 = new Rsid() { Val = "008C3ACC" };
			Rsid rsid19 = new Rsid() { Val = "00937B3B" };
			Rsid rsid20 = new Rsid() { Val = "00966BD8" };
			Rsid rsid21 = new Rsid() { Val = "009847DA" };
			Rsid rsid22 = new Rsid() { Val = "009D5441" };
			Rsid rsid23 = new Rsid() { Val = "00A66A01" };
			Rsid rsid24 = new Rsid() { Val = "00B05C9A" };
			Rsid rsid25 = new Rsid() { Val = "00B47D61" };
			Rsid rsid26 = new Rsid() { Val = "00BD1D5D" };
			Rsid rsid27 = new Rsid() { Val = "00BE6E7C" };
			Rsid rsid28 = new Rsid() { Val = "00D30EB8" };
			Rsid rsid29 = new Rsid() { Val = "00D43385" };
			Rsid rsid30 = new Rsid() { Val = "00D5138A" };
			Rsid rsid31 = new Rsid() { Val = "00D734F4" };
			Rsid rsid32 = new Rsid() { Val = "00DE53E8" };
			Rsid rsid33 = new Rsid() { Val = "00E62C1A" };
			Rsid rsid34 = new Rsid() { Val = "00F22791" };
			Rsid rsid35 = new Rsid() { Val = "00F36B82" };

			rsids1.Append(rsidRoot1);
			rsids1.Append(rsid1);
			rsids1.Append(rsid2);
			rsids1.Append(rsid3);
			rsids1.Append(rsid4);
			rsids1.Append(rsid5);
			rsids1.Append(rsid6);
			rsids1.Append(rsid7);
			rsids1.Append(rsid8);
			rsids1.Append(rsid9);
			rsids1.Append(rsid10);
			rsids1.Append(rsid11);
			rsids1.Append(rsid12);
			rsids1.Append(rsid13);
			rsids1.Append(rsid14);
			rsids1.Append(rsid15);
			rsids1.Append(rsid16);
			rsids1.Append(rsid17);
			rsids1.Append(rsid18);
			rsids1.Append(rsid19);
			rsids1.Append(rsid20);
			rsids1.Append(rsid21);
			rsids1.Append(rsid22);
			rsids1.Append(rsid23);
			rsids1.Append(rsid24);
			rsids1.Append(rsid25);
			rsids1.Append(rsid26);
			rsids1.Append(rsid27);
			rsids1.Append(rsid28);
			rsids1.Append(rsid29);
			rsids1.Append(rsid30);
			rsids1.Append(rsid31);
			rsids1.Append(rsid32);
			rsids1.Append(rsid33);
			rsids1.Append(rsid34);
			rsids1.Append(rsid35);

			M.MathProperties mathProperties1 = new M.MathProperties();
			M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
			M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
			M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
			M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
			M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
			M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
			M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
			M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
			M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
			M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
			M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

			mathProperties1.Append(mathFont1);
			mathProperties1.Append(breakBinary1);
			mathProperties1.Append(breakBinarySubtraction1);
			mathProperties1.Append(smallFraction1);
			mathProperties1.Append(displayDefaults1);
			mathProperties1.Append(leftMargin1);
			mathProperties1.Append(rightMargin1);
			mathProperties1.Append(defaultJustification1);
			mathProperties1.Append(wrapIndent1);
			mathProperties1.Append(integralLimitLocation1);
			mathProperties1.Append(naryLimitLocation1);
			ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "en-GB" };
			ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };

			ShapeDefaults shapeDefaults1 = new ShapeDefaults();
			Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

			Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
			Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

			shapeLayout1.Append(shapeIdMap1);

			shapeDefaults1.Append(shapeDefaults2);
			shapeDefaults1.Append(shapeLayout1);
			DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
			ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };
			W15.PersistentDocumentId persistentDocumentId1 = new W15.PersistentDocumentId() { Val = "{64F8E4E7-82BA-4610-A18F-4D77F4E49470}" };

			settings1.Append(zoom1);
			settings1.Append(mirrorMargins1);
			settings1.Append(proofState1);
			settings1.Append(attachedTemplate1);
			settings1.Append(stylePaneFormatFilter1);
			settings1.Append(defaultTabStop1);
			settings1.Append(hyphenationZone1);
			settings1.Append(drawingGridHorizontalSpacing1);
			settings1.Append(displayHorizontalDrawingGrid1);
			settings1.Append(characterSpacingControl1);
			settings1.Append(compatibility1);
			settings1.Append(rsids1);
			settings1.Append(mathProperties1);
			settings1.Append(themeFontLanguages1);
			settings1.Append(colorSchemeMapping1);
			settings1.Append(shapeDefaults1);
			settings1.Append(decimalSymbol1);
			settings1.Append(listSeparator1);
			settings1.Append(persistentDocumentId1);

			documentSettingsPart1.Settings = settings1;
		}

		// Generates content of styleDefinitionsPart1.
		private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
		{
			Styles styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15" } };
			styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			styles1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");

			DocDefaults docDefaults1 = new DocDefaults();

			RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

			RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
			RunFonts runFonts21 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
			FontSize fontSize1 = new FontSize() { Val = "22" };
			FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "22" };
			Languages languages1 = new Languages() { Val = "en-GB", EastAsia = "en-US", Bidi = "ar-SA" };

			runPropertiesBaseStyle1.Append(runFonts21);
			runPropertiesBaseStyle1.Append(fontSize1);
			runPropertiesBaseStyle1.Append(fontSizeComplexScript1);
			runPropertiesBaseStyle1.Append(languages1);

			runPropertiesDefault1.Append(runPropertiesBaseStyle1);

			ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

			ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
			SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

			paragraphPropertiesBaseStyle1.Append(spacingBetweenLines1);

			paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

			docDefaults1.Append(runPropertiesDefault1);
			docDefaults1.Append(paragraphPropertiesDefault1);

			LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = false, DefaultUnhideWhenUsed = false, DefaultPrimaryStyle = false, Count = 371 };
			LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0 };
			LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9 };
			LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "index 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "index 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "index 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "index 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "index 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "index 6", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "index 7", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "index 8", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "index 9", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Normal Indent", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "footnote text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "annotation text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "header", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "footer", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "index heading", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "table of figures", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "envelope address", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "envelope return", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "footnote reference", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "annotation reference", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "line number", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "page number", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "endnote reference", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "endnote text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "table of authorities", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "macro", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "toa heading", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "List", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "List Bullet", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "List Number", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "List 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "List 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "List 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "List 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "List Bullet 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "List Bullet 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "List Bullet 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "List Bullet 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "List Number 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "List Number 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "List Number 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "List Number 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10 };
			LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Closing", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Signature", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Body Text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Body Text Indent", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "List Continue", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "List Continue 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "List Continue 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "List Continue 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "List Continue 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Message Header", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11 };
			LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Salutation", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Date", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Body Text First Indent", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Body Text First Indent 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Note Heading", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Body Text 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Body Text 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Body Text Indent 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Body Text Indent 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Block Text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Hyperlink", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "FollowedHyperlink", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22 };
			LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20 };
			LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Document Map", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Plain Text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "E-mail Signature", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "HTML Top of Form", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "HTML Bottom of Form", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Normal (Web)", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "HTML Acronym", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "HTML Address", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "HTML Cite", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "HTML Code", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "HTML Definition", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "HTML Keyboard", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "HTML Preformatted", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "HTML Sample", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "HTML Typewriter", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "HTML Variable", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Normal Table", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "annotation subject", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "No List", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Outline List 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Outline List 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Outline List 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Table Simple 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Table Simple 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Table Simple 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Table Classic 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Table Classic 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Table Classic 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Table Classic 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Table Colorful 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Table Colorful 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Table Colorful 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Table Columns 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Table Columns 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Table Columns 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Table Columns 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Table Columns 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Table Grid 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Table Grid 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Table Grid 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Table Grid 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Table Grid 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Table Grid 6", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Table Grid 7", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Table Grid 8", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Table List 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Table List 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "Table List 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Table List 4", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "Table List 5", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "Table List 6", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "Table List 7", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "Table List 8", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "Table Contemporary", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "Table Elegant", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "Table Professional", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "Table Subtle 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "Table Subtle 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "Table Web 1", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "Table Web 2", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "Table Web 3", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "Balloon Text", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59 };
			LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "Table Theme", SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", SemiHidden = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1 };
			LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Revision", SemiHidden = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34 };
			LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29 };
			LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30 };
			LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60 };
			LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61 };
			LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62 };
			LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63 };
			LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64 };
			LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65 };
			LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66 };
			LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67 };
			LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68 };
			LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69 };
			LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70 };
			LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71 };
			LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72 };
			LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73 };
			LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19 };
			LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21 };
			LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31 };
			LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32 };
			LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33 };
			LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37, SemiHidden = true, UnhideWhenUsed = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
			LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Plain Table 1", UiPriority = 41 };
			LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Plain Table 2", UiPriority = 42 };
			LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Plain Table 3", UiPriority = 43 };
			LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Plain Table 4", UiPriority = 44 };
			LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Plain Table 5", UiPriority = 45 };
			LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Grid Table Light", UiPriority = 40 };
			LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo275 = new LatentStyleExceptionInfo() { Name = "Grid Table 2", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo276 = new LatentStyleExceptionInfo() { Name = "Grid Table 3", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo277 = new LatentStyleExceptionInfo() { Name = "Grid Table 4", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo278 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo279 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo280 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo281 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 1", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo282 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 1", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo283 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 1", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo284 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 1", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo285 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 1", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo286 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 1", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo287 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 1", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo288 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 2", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo289 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 2", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo290 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 2", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo291 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 2", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo292 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 2", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo293 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 2", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo294 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 2", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo295 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 3", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo296 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 3", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo297 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 3", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo298 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 3", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo299 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 3", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo300 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 3", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo301 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 3", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo302 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 4", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo303 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 4", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo304 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 4", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo305 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 4", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo306 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 4", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo307 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 4", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo308 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 4", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo309 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 5", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo310 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 5", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo311 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 5", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo312 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 5", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo313 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 5", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo314 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 5", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo315 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 5", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo316 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 6", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo317 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 6", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo318 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 6", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo319 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 6", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo320 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 6", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo321 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 6", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo322 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 6", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo323 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo324 = new LatentStyleExceptionInfo() { Name = "List Table 2", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo325 = new LatentStyleExceptionInfo() { Name = "List Table 3", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo326 = new LatentStyleExceptionInfo() { Name = "List Table 4", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo327 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo328 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo329 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo330 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 1", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo331 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 1", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo332 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 1", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo333 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 1", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo334 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 1", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo335 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 1", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo336 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 1", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo337 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 2", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo338 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 2", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo339 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 2", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo340 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 2", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo341 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 2", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo342 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 2", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo343 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 2", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo344 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 3", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo345 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 3", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo346 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 3", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo347 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 3", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo348 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 3", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo349 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 3", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo350 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 3", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo351 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 4", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo352 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 4", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo353 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 4", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo354 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 4", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo355 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 4", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo356 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 4", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo357 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 4", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo358 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 5", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo359 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 5", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo360 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 5", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo361 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 5", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo362 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 5", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo363 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 5", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo364 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 5", UiPriority = 52 };
			LatentStyleExceptionInfo latentStyleExceptionInfo365 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 6", UiPriority = 46 };
			LatentStyleExceptionInfo latentStyleExceptionInfo366 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 6", UiPriority = 47 };
			LatentStyleExceptionInfo latentStyleExceptionInfo367 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 6", UiPriority = 48 };
			LatentStyleExceptionInfo latentStyleExceptionInfo368 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 6", UiPriority = 49 };
			LatentStyleExceptionInfo latentStyleExceptionInfo369 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 6", UiPriority = 50 };
			LatentStyleExceptionInfo latentStyleExceptionInfo370 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 6", UiPriority = 51 };
			LatentStyleExceptionInfo latentStyleExceptionInfo371 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 6", UiPriority = 52 };

			latentStyles1.Append(latentStyleExceptionInfo1);
			latentStyles1.Append(latentStyleExceptionInfo2);
			latentStyles1.Append(latentStyleExceptionInfo3);
			latentStyles1.Append(latentStyleExceptionInfo4);
			latentStyles1.Append(latentStyleExceptionInfo5);
			latentStyles1.Append(latentStyleExceptionInfo6);
			latentStyles1.Append(latentStyleExceptionInfo7);
			latentStyles1.Append(latentStyleExceptionInfo8);
			latentStyles1.Append(latentStyleExceptionInfo9);
			latentStyles1.Append(latentStyleExceptionInfo10);
			latentStyles1.Append(latentStyleExceptionInfo11);
			latentStyles1.Append(latentStyleExceptionInfo12);
			latentStyles1.Append(latentStyleExceptionInfo13);
			latentStyles1.Append(latentStyleExceptionInfo14);
			latentStyles1.Append(latentStyleExceptionInfo15);
			latentStyles1.Append(latentStyleExceptionInfo16);
			latentStyles1.Append(latentStyleExceptionInfo17);
			latentStyles1.Append(latentStyleExceptionInfo18);
			latentStyles1.Append(latentStyleExceptionInfo19);
			latentStyles1.Append(latentStyleExceptionInfo20);
			latentStyles1.Append(latentStyleExceptionInfo21);
			latentStyles1.Append(latentStyleExceptionInfo22);
			latentStyles1.Append(latentStyleExceptionInfo23);
			latentStyles1.Append(latentStyleExceptionInfo24);
			latentStyles1.Append(latentStyleExceptionInfo25);
			latentStyles1.Append(latentStyleExceptionInfo26);
			latentStyles1.Append(latentStyleExceptionInfo27);
			latentStyles1.Append(latentStyleExceptionInfo28);
			latentStyles1.Append(latentStyleExceptionInfo29);
			latentStyles1.Append(latentStyleExceptionInfo30);
			latentStyles1.Append(latentStyleExceptionInfo31);
			latentStyles1.Append(latentStyleExceptionInfo32);
			latentStyles1.Append(latentStyleExceptionInfo33);
			latentStyles1.Append(latentStyleExceptionInfo34);
			latentStyles1.Append(latentStyleExceptionInfo35);
			latentStyles1.Append(latentStyleExceptionInfo36);
			latentStyles1.Append(latentStyleExceptionInfo37);
			latentStyles1.Append(latentStyleExceptionInfo38);
			latentStyles1.Append(latentStyleExceptionInfo39);
			latentStyles1.Append(latentStyleExceptionInfo40);
			latentStyles1.Append(latentStyleExceptionInfo41);
			latentStyles1.Append(latentStyleExceptionInfo42);
			latentStyles1.Append(latentStyleExceptionInfo43);
			latentStyles1.Append(latentStyleExceptionInfo44);
			latentStyles1.Append(latentStyleExceptionInfo45);
			latentStyles1.Append(latentStyleExceptionInfo46);
			latentStyles1.Append(latentStyleExceptionInfo47);
			latentStyles1.Append(latentStyleExceptionInfo48);
			latentStyles1.Append(latentStyleExceptionInfo49);
			latentStyles1.Append(latentStyleExceptionInfo50);
			latentStyles1.Append(latentStyleExceptionInfo51);
			latentStyles1.Append(latentStyleExceptionInfo52);
			latentStyles1.Append(latentStyleExceptionInfo53);
			latentStyles1.Append(latentStyleExceptionInfo54);
			latentStyles1.Append(latentStyleExceptionInfo55);
			latentStyles1.Append(latentStyleExceptionInfo56);
			latentStyles1.Append(latentStyleExceptionInfo57);
			latentStyles1.Append(latentStyleExceptionInfo58);
			latentStyles1.Append(latentStyleExceptionInfo59);
			latentStyles1.Append(latentStyleExceptionInfo60);
			latentStyles1.Append(latentStyleExceptionInfo61);
			latentStyles1.Append(latentStyleExceptionInfo62);
			latentStyles1.Append(latentStyleExceptionInfo63);
			latentStyles1.Append(latentStyleExceptionInfo64);
			latentStyles1.Append(latentStyleExceptionInfo65);
			latentStyles1.Append(latentStyleExceptionInfo66);
			latentStyles1.Append(latentStyleExceptionInfo67);
			latentStyles1.Append(latentStyleExceptionInfo68);
			latentStyles1.Append(latentStyleExceptionInfo69);
			latentStyles1.Append(latentStyleExceptionInfo70);
			latentStyles1.Append(latentStyleExceptionInfo71);
			latentStyles1.Append(latentStyleExceptionInfo72);
			latentStyles1.Append(latentStyleExceptionInfo73);
			latentStyles1.Append(latentStyleExceptionInfo74);
			latentStyles1.Append(latentStyleExceptionInfo75);
			latentStyles1.Append(latentStyleExceptionInfo76);
			latentStyles1.Append(latentStyleExceptionInfo77);
			latentStyles1.Append(latentStyleExceptionInfo78);
			latentStyles1.Append(latentStyleExceptionInfo79);
			latentStyles1.Append(latentStyleExceptionInfo80);
			latentStyles1.Append(latentStyleExceptionInfo81);
			latentStyles1.Append(latentStyleExceptionInfo82);
			latentStyles1.Append(latentStyleExceptionInfo83);
			latentStyles1.Append(latentStyleExceptionInfo84);
			latentStyles1.Append(latentStyleExceptionInfo85);
			latentStyles1.Append(latentStyleExceptionInfo86);
			latentStyles1.Append(latentStyleExceptionInfo87);
			latentStyles1.Append(latentStyleExceptionInfo88);
			latentStyles1.Append(latentStyleExceptionInfo89);
			latentStyles1.Append(latentStyleExceptionInfo90);
			latentStyles1.Append(latentStyleExceptionInfo91);
			latentStyles1.Append(latentStyleExceptionInfo92);
			latentStyles1.Append(latentStyleExceptionInfo93);
			latentStyles1.Append(latentStyleExceptionInfo94);
			latentStyles1.Append(latentStyleExceptionInfo95);
			latentStyles1.Append(latentStyleExceptionInfo96);
			latentStyles1.Append(latentStyleExceptionInfo97);
			latentStyles1.Append(latentStyleExceptionInfo98);
			latentStyles1.Append(latentStyleExceptionInfo99);
			latentStyles1.Append(latentStyleExceptionInfo100);
			latentStyles1.Append(latentStyleExceptionInfo101);
			latentStyles1.Append(latentStyleExceptionInfo102);
			latentStyles1.Append(latentStyleExceptionInfo103);
			latentStyles1.Append(latentStyleExceptionInfo104);
			latentStyles1.Append(latentStyleExceptionInfo105);
			latentStyles1.Append(latentStyleExceptionInfo106);
			latentStyles1.Append(latentStyleExceptionInfo107);
			latentStyles1.Append(latentStyleExceptionInfo108);
			latentStyles1.Append(latentStyleExceptionInfo109);
			latentStyles1.Append(latentStyleExceptionInfo110);
			latentStyles1.Append(latentStyleExceptionInfo111);
			latentStyles1.Append(latentStyleExceptionInfo112);
			latentStyles1.Append(latentStyleExceptionInfo113);
			latentStyles1.Append(latentStyleExceptionInfo114);
			latentStyles1.Append(latentStyleExceptionInfo115);
			latentStyles1.Append(latentStyleExceptionInfo116);
			latentStyles1.Append(latentStyleExceptionInfo117);
			latentStyles1.Append(latentStyleExceptionInfo118);
			latentStyles1.Append(latentStyleExceptionInfo119);
			latentStyles1.Append(latentStyleExceptionInfo120);
			latentStyles1.Append(latentStyleExceptionInfo121);
			latentStyles1.Append(latentStyleExceptionInfo122);
			latentStyles1.Append(latentStyleExceptionInfo123);
			latentStyles1.Append(latentStyleExceptionInfo124);
			latentStyles1.Append(latentStyleExceptionInfo125);
			latentStyles1.Append(latentStyleExceptionInfo126);
			latentStyles1.Append(latentStyleExceptionInfo127);
			latentStyles1.Append(latentStyleExceptionInfo128);
			latentStyles1.Append(latentStyleExceptionInfo129);
			latentStyles1.Append(latentStyleExceptionInfo130);
			latentStyles1.Append(latentStyleExceptionInfo131);
			latentStyles1.Append(latentStyleExceptionInfo132);
			latentStyles1.Append(latentStyleExceptionInfo133);
			latentStyles1.Append(latentStyleExceptionInfo134);
			latentStyles1.Append(latentStyleExceptionInfo135);
			latentStyles1.Append(latentStyleExceptionInfo136);
			latentStyles1.Append(latentStyleExceptionInfo137);
			latentStyles1.Append(latentStyleExceptionInfo138);
			latentStyles1.Append(latentStyleExceptionInfo139);
			latentStyles1.Append(latentStyleExceptionInfo140);
			latentStyles1.Append(latentStyleExceptionInfo141);
			latentStyles1.Append(latentStyleExceptionInfo142);
			latentStyles1.Append(latentStyleExceptionInfo143);
			latentStyles1.Append(latentStyleExceptionInfo144);
			latentStyles1.Append(latentStyleExceptionInfo145);
			latentStyles1.Append(latentStyleExceptionInfo146);
			latentStyles1.Append(latentStyleExceptionInfo147);
			latentStyles1.Append(latentStyleExceptionInfo148);
			latentStyles1.Append(latentStyleExceptionInfo149);
			latentStyles1.Append(latentStyleExceptionInfo150);
			latentStyles1.Append(latentStyleExceptionInfo151);
			latentStyles1.Append(latentStyleExceptionInfo152);
			latentStyles1.Append(latentStyleExceptionInfo153);
			latentStyles1.Append(latentStyleExceptionInfo154);
			latentStyles1.Append(latentStyleExceptionInfo155);
			latentStyles1.Append(latentStyleExceptionInfo156);
			latentStyles1.Append(latentStyleExceptionInfo157);
			latentStyles1.Append(latentStyleExceptionInfo158);
			latentStyles1.Append(latentStyleExceptionInfo159);
			latentStyles1.Append(latentStyleExceptionInfo160);
			latentStyles1.Append(latentStyleExceptionInfo161);
			latentStyles1.Append(latentStyleExceptionInfo162);
			latentStyles1.Append(latentStyleExceptionInfo163);
			latentStyles1.Append(latentStyleExceptionInfo164);
			latentStyles1.Append(latentStyleExceptionInfo165);
			latentStyles1.Append(latentStyleExceptionInfo166);
			latentStyles1.Append(latentStyleExceptionInfo167);
			latentStyles1.Append(latentStyleExceptionInfo168);
			latentStyles1.Append(latentStyleExceptionInfo169);
			latentStyles1.Append(latentStyleExceptionInfo170);
			latentStyles1.Append(latentStyleExceptionInfo171);
			latentStyles1.Append(latentStyleExceptionInfo172);
			latentStyles1.Append(latentStyleExceptionInfo173);
			latentStyles1.Append(latentStyleExceptionInfo174);
			latentStyles1.Append(latentStyleExceptionInfo175);
			latentStyles1.Append(latentStyleExceptionInfo176);
			latentStyles1.Append(latentStyleExceptionInfo177);
			latentStyles1.Append(latentStyleExceptionInfo178);
			latentStyles1.Append(latentStyleExceptionInfo179);
			latentStyles1.Append(latentStyleExceptionInfo180);
			latentStyles1.Append(latentStyleExceptionInfo181);
			latentStyles1.Append(latentStyleExceptionInfo182);
			latentStyles1.Append(latentStyleExceptionInfo183);
			latentStyles1.Append(latentStyleExceptionInfo184);
			latentStyles1.Append(latentStyleExceptionInfo185);
			latentStyles1.Append(latentStyleExceptionInfo186);
			latentStyles1.Append(latentStyleExceptionInfo187);
			latentStyles1.Append(latentStyleExceptionInfo188);
			latentStyles1.Append(latentStyleExceptionInfo189);
			latentStyles1.Append(latentStyleExceptionInfo190);
			latentStyles1.Append(latentStyleExceptionInfo191);
			latentStyles1.Append(latentStyleExceptionInfo192);
			latentStyles1.Append(latentStyleExceptionInfo193);
			latentStyles1.Append(latentStyleExceptionInfo194);
			latentStyles1.Append(latentStyleExceptionInfo195);
			latentStyles1.Append(latentStyleExceptionInfo196);
			latentStyles1.Append(latentStyleExceptionInfo197);
			latentStyles1.Append(latentStyleExceptionInfo198);
			latentStyles1.Append(latentStyleExceptionInfo199);
			latentStyles1.Append(latentStyleExceptionInfo200);
			latentStyles1.Append(latentStyleExceptionInfo201);
			latentStyles1.Append(latentStyleExceptionInfo202);
			latentStyles1.Append(latentStyleExceptionInfo203);
			latentStyles1.Append(latentStyleExceptionInfo204);
			latentStyles1.Append(latentStyleExceptionInfo205);
			latentStyles1.Append(latentStyleExceptionInfo206);
			latentStyles1.Append(latentStyleExceptionInfo207);
			latentStyles1.Append(latentStyleExceptionInfo208);
			latentStyles1.Append(latentStyleExceptionInfo209);
			latentStyles1.Append(latentStyleExceptionInfo210);
			latentStyles1.Append(latentStyleExceptionInfo211);
			latentStyles1.Append(latentStyleExceptionInfo212);
			latentStyles1.Append(latentStyleExceptionInfo213);
			latentStyles1.Append(latentStyleExceptionInfo214);
			latentStyles1.Append(latentStyleExceptionInfo215);
			latentStyles1.Append(latentStyleExceptionInfo216);
			latentStyles1.Append(latentStyleExceptionInfo217);
			latentStyles1.Append(latentStyleExceptionInfo218);
			latentStyles1.Append(latentStyleExceptionInfo219);
			latentStyles1.Append(latentStyleExceptionInfo220);
			latentStyles1.Append(latentStyleExceptionInfo221);
			latentStyles1.Append(latentStyleExceptionInfo222);
			latentStyles1.Append(latentStyleExceptionInfo223);
			latentStyles1.Append(latentStyleExceptionInfo224);
			latentStyles1.Append(latentStyleExceptionInfo225);
			latentStyles1.Append(latentStyleExceptionInfo226);
			latentStyles1.Append(latentStyleExceptionInfo227);
			latentStyles1.Append(latentStyleExceptionInfo228);
			latentStyles1.Append(latentStyleExceptionInfo229);
			latentStyles1.Append(latentStyleExceptionInfo230);
			latentStyles1.Append(latentStyleExceptionInfo231);
			latentStyles1.Append(latentStyleExceptionInfo232);
			latentStyles1.Append(latentStyleExceptionInfo233);
			latentStyles1.Append(latentStyleExceptionInfo234);
			latentStyles1.Append(latentStyleExceptionInfo235);
			latentStyles1.Append(latentStyleExceptionInfo236);
			latentStyles1.Append(latentStyleExceptionInfo237);
			latentStyles1.Append(latentStyleExceptionInfo238);
			latentStyles1.Append(latentStyleExceptionInfo239);
			latentStyles1.Append(latentStyleExceptionInfo240);
			latentStyles1.Append(latentStyleExceptionInfo241);
			latentStyles1.Append(latentStyleExceptionInfo242);
			latentStyles1.Append(latentStyleExceptionInfo243);
			latentStyles1.Append(latentStyleExceptionInfo244);
			latentStyles1.Append(latentStyleExceptionInfo245);
			latentStyles1.Append(latentStyleExceptionInfo246);
			latentStyles1.Append(latentStyleExceptionInfo247);
			latentStyles1.Append(latentStyleExceptionInfo248);
			latentStyles1.Append(latentStyleExceptionInfo249);
			latentStyles1.Append(latentStyleExceptionInfo250);
			latentStyles1.Append(latentStyleExceptionInfo251);
			latentStyles1.Append(latentStyleExceptionInfo252);
			latentStyles1.Append(latentStyleExceptionInfo253);
			latentStyles1.Append(latentStyleExceptionInfo254);
			latentStyles1.Append(latentStyleExceptionInfo255);
			latentStyles1.Append(latentStyleExceptionInfo256);
			latentStyles1.Append(latentStyleExceptionInfo257);
			latentStyles1.Append(latentStyleExceptionInfo258);
			latentStyles1.Append(latentStyleExceptionInfo259);
			latentStyles1.Append(latentStyleExceptionInfo260);
			latentStyles1.Append(latentStyleExceptionInfo261);
			latentStyles1.Append(latentStyleExceptionInfo262);
			latentStyles1.Append(latentStyleExceptionInfo263);
			latentStyles1.Append(latentStyleExceptionInfo264);
			latentStyles1.Append(latentStyleExceptionInfo265);
			latentStyles1.Append(latentStyleExceptionInfo266);
			latentStyles1.Append(latentStyleExceptionInfo267);
			latentStyles1.Append(latentStyleExceptionInfo268);
			latentStyles1.Append(latentStyleExceptionInfo269);
			latentStyles1.Append(latentStyleExceptionInfo270);
			latentStyles1.Append(latentStyleExceptionInfo271);
			latentStyles1.Append(latentStyleExceptionInfo272);
			latentStyles1.Append(latentStyleExceptionInfo273);
			latentStyles1.Append(latentStyleExceptionInfo274);
			latentStyles1.Append(latentStyleExceptionInfo275);
			latentStyles1.Append(latentStyleExceptionInfo276);
			latentStyles1.Append(latentStyleExceptionInfo277);
			latentStyles1.Append(latentStyleExceptionInfo278);
			latentStyles1.Append(latentStyleExceptionInfo279);
			latentStyles1.Append(latentStyleExceptionInfo280);
			latentStyles1.Append(latentStyleExceptionInfo281);
			latentStyles1.Append(latentStyleExceptionInfo282);
			latentStyles1.Append(latentStyleExceptionInfo283);
			latentStyles1.Append(latentStyleExceptionInfo284);
			latentStyles1.Append(latentStyleExceptionInfo285);
			latentStyles1.Append(latentStyleExceptionInfo286);
			latentStyles1.Append(latentStyleExceptionInfo287);
			latentStyles1.Append(latentStyleExceptionInfo288);
			latentStyles1.Append(latentStyleExceptionInfo289);
			latentStyles1.Append(latentStyleExceptionInfo290);
			latentStyles1.Append(latentStyleExceptionInfo291);
			latentStyles1.Append(latentStyleExceptionInfo292);
			latentStyles1.Append(latentStyleExceptionInfo293);
			latentStyles1.Append(latentStyleExceptionInfo294);
			latentStyles1.Append(latentStyleExceptionInfo295);
			latentStyles1.Append(latentStyleExceptionInfo296);
			latentStyles1.Append(latentStyleExceptionInfo297);
			latentStyles1.Append(latentStyleExceptionInfo298);
			latentStyles1.Append(latentStyleExceptionInfo299);
			latentStyles1.Append(latentStyleExceptionInfo300);
			latentStyles1.Append(latentStyleExceptionInfo301);
			latentStyles1.Append(latentStyleExceptionInfo302);
			latentStyles1.Append(latentStyleExceptionInfo303);
			latentStyles1.Append(latentStyleExceptionInfo304);
			latentStyles1.Append(latentStyleExceptionInfo305);
			latentStyles1.Append(latentStyleExceptionInfo306);
			latentStyles1.Append(latentStyleExceptionInfo307);
			latentStyles1.Append(latentStyleExceptionInfo308);
			latentStyles1.Append(latentStyleExceptionInfo309);
			latentStyles1.Append(latentStyleExceptionInfo310);
			latentStyles1.Append(latentStyleExceptionInfo311);
			latentStyles1.Append(latentStyleExceptionInfo312);
			latentStyles1.Append(latentStyleExceptionInfo313);
			latentStyles1.Append(latentStyleExceptionInfo314);
			latentStyles1.Append(latentStyleExceptionInfo315);
			latentStyles1.Append(latentStyleExceptionInfo316);
			latentStyles1.Append(latentStyleExceptionInfo317);
			latentStyles1.Append(latentStyleExceptionInfo318);
			latentStyles1.Append(latentStyleExceptionInfo319);
			latentStyles1.Append(latentStyleExceptionInfo320);
			latentStyles1.Append(latentStyleExceptionInfo321);
			latentStyles1.Append(latentStyleExceptionInfo322);
			latentStyles1.Append(latentStyleExceptionInfo323);
			latentStyles1.Append(latentStyleExceptionInfo324);
			latentStyles1.Append(latentStyleExceptionInfo325);
			latentStyles1.Append(latentStyleExceptionInfo326);
			latentStyles1.Append(latentStyleExceptionInfo327);
			latentStyles1.Append(latentStyleExceptionInfo328);
			latentStyles1.Append(latentStyleExceptionInfo329);
			latentStyles1.Append(latentStyleExceptionInfo330);
			latentStyles1.Append(latentStyleExceptionInfo331);
			latentStyles1.Append(latentStyleExceptionInfo332);
			latentStyles1.Append(latentStyleExceptionInfo333);
			latentStyles1.Append(latentStyleExceptionInfo334);
			latentStyles1.Append(latentStyleExceptionInfo335);
			latentStyles1.Append(latentStyleExceptionInfo336);
			latentStyles1.Append(latentStyleExceptionInfo337);
			latentStyles1.Append(latentStyleExceptionInfo338);
			latentStyles1.Append(latentStyleExceptionInfo339);
			latentStyles1.Append(latentStyleExceptionInfo340);
			latentStyles1.Append(latentStyleExceptionInfo341);
			latentStyles1.Append(latentStyleExceptionInfo342);
			latentStyles1.Append(latentStyleExceptionInfo343);
			latentStyles1.Append(latentStyleExceptionInfo344);
			latentStyles1.Append(latentStyleExceptionInfo345);
			latentStyles1.Append(latentStyleExceptionInfo346);
			latentStyles1.Append(latentStyleExceptionInfo347);
			latentStyles1.Append(latentStyleExceptionInfo348);
			latentStyles1.Append(latentStyleExceptionInfo349);
			latentStyles1.Append(latentStyleExceptionInfo350);
			latentStyles1.Append(latentStyleExceptionInfo351);
			latentStyles1.Append(latentStyleExceptionInfo352);
			latentStyles1.Append(latentStyleExceptionInfo353);
			latentStyles1.Append(latentStyleExceptionInfo354);
			latentStyles1.Append(latentStyleExceptionInfo355);
			latentStyles1.Append(latentStyleExceptionInfo356);
			latentStyles1.Append(latentStyleExceptionInfo357);
			latentStyles1.Append(latentStyleExceptionInfo358);
			latentStyles1.Append(latentStyleExceptionInfo359);
			latentStyles1.Append(latentStyleExceptionInfo360);
			latentStyles1.Append(latentStyleExceptionInfo361);
			latentStyles1.Append(latentStyleExceptionInfo362);
			latentStyles1.Append(latentStyleExceptionInfo363);
			latentStyles1.Append(latentStyleExceptionInfo364);
			latentStyles1.Append(latentStyleExceptionInfo365);
			latentStyles1.Append(latentStyleExceptionInfo366);
			latentStyles1.Append(latentStyleExceptionInfo367);
			latentStyles1.Append(latentStyleExceptionInfo368);
			latentStyles1.Append(latentStyleExceptionInfo369);
			latentStyles1.Append(latentStyleExceptionInfo370);
			latentStyles1.Append(latentStyleExceptionInfo371);

			Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "Normale", Default = true };
			StyleName styleName1 = new StyleName() { Val = "Normal" };
			Rsid rsid36 = new Rsid() { Val = "00496A6D" };

			StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();

			Tabs tabs1 = new Tabs();
			TabStop tabStop1 = new TabStop() { Val = TabStopValues.Left, Position = 916 };
			TabStop tabStop2 = new TabStop() { Val = TabStopValues.Left, Position = 1832 };
			TabStop tabStop3 = new TabStop() { Val = TabStopValues.Left, Position = 2748 };
			TabStop tabStop4 = new TabStop() { Val = TabStopValues.Left, Position = 3664 };
			TabStop tabStop5 = new TabStop() { Val = TabStopValues.Left, Position = 4580 };
			TabStop tabStop6 = new TabStop() { Val = TabStopValues.Left, Position = 5496 };
			TabStop tabStop7 = new TabStop() { Val = TabStopValues.Left, Position = 6412 };
			TabStop tabStop8 = new TabStop() { Val = TabStopValues.Left, Position = 7328 };
			TabStop tabStop9 = new TabStop() { Val = TabStopValues.Left, Position = 8244 };
			TabStop tabStop10 = new TabStop() { Val = TabStopValues.Left, Position = 9160 };
			TabStop tabStop11 = new TabStop() { Val = TabStopValues.Left, Position = 10076 };
			TabStop tabStop12 = new TabStop() { Val = TabStopValues.Left, Position = 10992 };
			TabStop tabStop13 = new TabStop() { Val = TabStopValues.Left, Position = 11908 };
			TabStop tabStop14 = new TabStop() { Val = TabStopValues.Left, Position = 12824 };
			TabStop tabStop15 = new TabStop() { Val = TabStopValues.Left, Position = 13740 };
			TabStop tabStop16 = new TabStop() { Val = TabStopValues.Left, Position = 14656 };

			tabs1.Append(tabStop1);
			tabs1.Append(tabStop2);
			tabs1.Append(tabStop3);
			tabs1.Append(tabStop4);
			tabs1.Append(tabStop5);
			tabs1.Append(tabStop6);
			tabs1.Append(tabStop7);
			tabs1.Append(tabStop8);
			tabs1.Append(tabStop9);
			tabs1.Append(tabStop10);
			tabs1.Append(tabStop11);
			tabs1.Append(tabStop12);
			tabs1.Append(tabStop13);
			tabs1.Append(tabStop14);
			tabs1.Append(tabStop15);
			tabs1.Append(tabStop16);
			SpacingBetweenLines spacingBetweenLines2 = new SpacingBetweenLines() { After = "0", Line = "120", LineRule = LineSpacingRuleValues.AtLeast };

			styleParagraphProperties1.Append(tabs1);
			styleParagraphProperties1.Append(spacingBetweenLines2);

			StyleRunProperties styleRunProperties1 = new StyleRunProperties();
			RunFonts runFonts22 = new RunFonts() { Ascii = "Candara", HighAnsi = "Candara", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Color color1 = new Color() { Val = "000000" };
			FontSize fontSize2 = new FontSize() { Val = "20" };
			FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "20" };
			Languages languages2 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties1.Append(runFonts22);
			styleRunProperties1.Append(color1);
			styleRunProperties1.Append(fontSize2);
			styleRunProperties1.Append(fontSizeComplexScript2);
			styleRunProperties1.Append(languages2);

			style1.Append(styleName1);
			style1.Append(rsid36);
			style1.Append(styleParagraphProperties1);
			style1.Append(styleRunProperties1);

			Style style2 = new Style() { Type = StyleValues.Paragraph, StyleId = "Titolo2" };
			StyleName styleName2 = new StyleName() { Val = "heading 2" };
			BasedOn basedOn1 = new BasedOn() { Val = "Normale" };
			NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normale" };
			LinkedStyle linkedStyle1 = new LinkedStyle() { Val = "Titolo2Carattere" };
			UIPriority uIPriority1 = new UIPriority() { Val = 9 };
			UnhideWhenUsed unhideWhenUsed1 = new UnhideWhenUsed();
			Rsid rsid37 = new Rsid() { Val = "00BD1D5D" };

			StyleParagraphProperties styleParagraphProperties2 = new StyleParagraphProperties();
			KeepNext keepNext1 = new KeepNext();
			KeepLines keepLines1 = new KeepLines();
			SpacingBetweenLines spacingBetweenLines3 = new SpacingBetweenLines() { Before = "40" };
			OutlineLevel outlineLevel1 = new OutlineLevel() { Val = 1 };

			styleParagraphProperties2.Append(keepNext1);
			styleParagraphProperties2.Append(keepLines1);
			styleParagraphProperties2.Append(spacingBetweenLines3);
			styleParagraphProperties2.Append(outlineLevel1);

			StyleRunProperties styleRunProperties2 = new StyleRunProperties();
			RunFonts runFonts23 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Color color2 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
			FontSize fontSize3 = new FontSize() { Val = "26" };
			FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "26" };

			styleRunProperties2.Append(runFonts23);
			styleRunProperties2.Append(color2);
			styleRunProperties2.Append(fontSize3);
			styleRunProperties2.Append(fontSizeComplexScript3);

			style2.Append(styleName2);
			style2.Append(basedOn1);
			style2.Append(nextParagraphStyle1);
			style2.Append(linkedStyle1);
			style2.Append(uIPriority1);
			style2.Append(unhideWhenUsed1);
			style2.Append(rsid37);
			style2.Append(styleParagraphProperties2);
			style2.Append(styleRunProperties2);

			Style style3 = new Style() { Type = StyleValues.Paragraph, StyleId = "Titolo3" };
			StyleName styleName3 = new StyleName() { Val = "heading 3" };
			BasedOn basedOn2 = new BasedOn() { Val = "Normale" };
			NextParagraphStyle nextParagraphStyle2 = new NextParagraphStyle() { Val = "Normale" };
			LinkedStyle linkedStyle2 = new LinkedStyle() { Val = "Titolo3Carattere" };
			UIPriority uIPriority2 = new UIPriority() { Val = 9 };
			UnhideWhenUsed unhideWhenUsed2 = new UnhideWhenUsed();
			Rsid rsid38 = new Rsid() { Val = "00BD1D5D" };

			StyleParagraphProperties styleParagraphProperties3 = new StyleParagraphProperties();
			KeepNext keepNext2 = new KeepNext();
			KeepLines keepLines2 = new KeepLines();
			SpacingBetweenLines spacingBetweenLines4 = new SpacingBetweenLines() { Before = "40" };
			OutlineLevel outlineLevel2 = new OutlineLevel() { Val = 2 };

			styleParagraphProperties3.Append(keepNext2);
			styleParagraphProperties3.Append(keepLines2);
			styleParagraphProperties3.Append(spacingBetweenLines4);
			styleParagraphProperties3.Append(outlineLevel2);

			StyleRunProperties styleRunProperties3 = new StyleRunProperties();
			RunFonts runFonts24 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Color color3 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };
			FontSize fontSize4 = new FontSize() { Val = "24" };
			FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "24" };

			styleRunProperties3.Append(runFonts24);
			styleRunProperties3.Append(color3);
			styleRunProperties3.Append(fontSize4);
			styleRunProperties3.Append(fontSizeComplexScript4);

			style3.Append(styleName3);
			style3.Append(basedOn2);
			style3.Append(nextParagraphStyle2);
			style3.Append(linkedStyle2);
			style3.Append(uIPriority2);
			style3.Append(unhideWhenUsed2);
			style3.Append(rsid38);
			style3.Append(styleParagraphProperties3);
			style3.Append(styleRunProperties3);

			Style style4 = new Style() { Type = StyleValues.Paragraph, StyleId = "Titolo4" };
			StyleName styleName4 = new StyleName() { Val = "heading 4" };
			NextParagraphStyle nextParagraphStyle3 = new NextParagraphStyle() { Val = "Normale" };
			LinkedStyle linkedStyle3 = new LinkedStyle() { Val = "Titolo4Carattere" };
			UIPriority uIPriority3 = new UIPriority() { Val = 9 };
			UnhideWhenUsed unhideWhenUsed3 = new UnhideWhenUsed();
			Rsid rsid39 = new Rsid() { Val = "00D30EB8" };

			StyleParagraphProperties styleParagraphProperties4 = new StyleParagraphProperties();
			KeepNext keepNext3 = new KeepNext();
			KeepLines keepLines3 = new KeepLines();
			SpacingBetweenLines spacingBetweenLines5 = new SpacingBetweenLines() { Before = "40", After = "120", Line = "240", LineRule = LineSpacingRuleValues.Auto };
			ContextualSpacing contextualSpacing1 = new ContextualSpacing();
			OutlineLevel outlineLevel3 = new OutlineLevel() { Val = 3 };

			styleParagraphProperties4.Append(keepNext3);
			styleParagraphProperties4.Append(keepLines3);
			styleParagraphProperties4.Append(spacingBetweenLines5);
			styleParagraphProperties4.Append(contextualSpacing1);
			styleParagraphProperties4.Append(outlineLevel3);

			StyleRunProperties styleRunProperties4 = new StyleRunProperties();
			RunFonts runFonts25 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Italic italic1 = new Italic();
			ItalicComplexScript italicComplexScript1 = new ItalicComplexScript();
			Color color4 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
			FontSize fontSize5 = new FontSize() { Val = "28" };
			FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "20" };
			Languages languages3 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties4.Append(runFonts25);
			styleRunProperties4.Append(italic1);
			styleRunProperties4.Append(italicComplexScript1);
			styleRunProperties4.Append(color4);
			styleRunProperties4.Append(fontSize5);
			styleRunProperties4.Append(fontSizeComplexScript5);
			styleRunProperties4.Append(languages3);

			style4.Append(styleName4);
			style4.Append(nextParagraphStyle3);
			style4.Append(linkedStyle3);
			style4.Append(uIPriority3);
			style4.Append(unhideWhenUsed3);
			style4.Append(rsid39);
			style4.Append(styleParagraphProperties4);
			style4.Append(styleRunProperties4);

			Style style5 = new Style() { Type = StyleValues.Character, StyleId = "Carpredefinitoparagrafo", Default = true };
			StyleName styleName5 = new StyleName() { Val = "Default Paragraph Font" };
			UIPriority uIPriority4 = new UIPriority() { Val = 1 };
			SemiHidden semiHidden1 = new SemiHidden();
			UnhideWhenUsed unhideWhenUsed4 = new UnhideWhenUsed();

			style5.Append(styleName5);
			style5.Append(uIPriority4);
			style5.Append(semiHidden1);
			style5.Append(unhideWhenUsed4);

			Style style6 = new Style() { Type = StyleValues.Table, StyleId = "Tabellanormale", Default = true };
			StyleName styleName6 = new StyleName() { Val = "Normal Table" };
			UIPriority uIPriority5 = new UIPriority() { Val = 99 };
			SemiHidden semiHidden2 = new SemiHidden();
			UnhideWhenUsed unhideWhenUsed5 = new UnhideWhenUsed();

			StyleTableProperties styleTableProperties1 = new StyleTableProperties();
			TableIndentation tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

			TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
			TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
			TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
			BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
			TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

			tableCellMarginDefault1.Append(topMargin1);
			tableCellMarginDefault1.Append(tableCellLeftMargin1);
			tableCellMarginDefault1.Append(bottomMargin1);
			tableCellMarginDefault1.Append(tableCellRightMargin1);

			styleTableProperties1.Append(tableIndentation1);
			styleTableProperties1.Append(tableCellMarginDefault1);

			style6.Append(styleName6);
			style6.Append(uIPriority5);
			style6.Append(semiHidden2);
			style6.Append(unhideWhenUsed5);
			style6.Append(styleTableProperties1);

			Style style7 = new Style() { Type = StyleValues.Numbering, StyleId = "Nessunelenco", Default = true };
			StyleName styleName7 = new StyleName() { Val = "No List" };
			UIPriority uIPriority6 = new UIPriority() { Val = 99 };
			SemiHidden semiHidden3 = new SemiHidden();
			UnhideWhenUsed unhideWhenUsed6 = new UnhideWhenUsed();

			style7.Append(styleName7);
			style7.Append(uIPriority6);
			style7.Append(semiHidden3);
			style7.Append(unhideWhenUsed6);

			Style style8 = new Style() { Type = StyleValues.Paragraph, StyleId = "Sottotitolo" };
			StyleName styleName8 = new StyleName() { Val = "Subtitle" };
			BasedOn basedOn3 = new BasedOn() { Val = "Normale" };
			NextParagraphStyle nextParagraphStyle4 = new NextParagraphStyle() { Val = "Normale" };
			LinkedStyle linkedStyle4 = new LinkedStyle() { Val = "SottotitoloCarattere" };
			UIPriority uIPriority7 = new UIPriority() { Val = 11 };
			Rsid rsid40 = new Rsid() { Val = "00966BD8" };

			StyleParagraphProperties styleParagraphProperties5 = new StyleParagraphProperties();

			NumberingProperties numberingProperties1 = new NumberingProperties();
			NumberingLevelReference numberingLevelReference1 = new NumberingLevelReference() { Val = 1 };

			numberingProperties1.Append(numberingLevelReference1);
			SpacingBetweenLines spacingBetweenLines6 = new SpacingBetweenLines() { After = "80" };

			styleParagraphProperties5.Append(numberingProperties1);
			styleParagraphProperties5.Append(spacingBetweenLines6);

			StyleRunProperties styleRunProperties5 = new StyleRunProperties();
			RunFonts runFonts26 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Italic italic2 = new Italic();
			ItalicComplexScript italicComplexScript2 = new ItalicComplexScript();
			Color color5 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
			Spacing spacing1 = new Spacing() { Val = 15 };
			FontSize fontSize6 = new FontSize() { Val = "24" };
			FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "24" };

			styleRunProperties5.Append(runFonts26);
			styleRunProperties5.Append(italic2);
			styleRunProperties5.Append(italicComplexScript2);
			styleRunProperties5.Append(color5);
			styleRunProperties5.Append(spacing1);
			styleRunProperties5.Append(fontSize6);
			styleRunProperties5.Append(fontSizeComplexScript6);

			style8.Append(styleName8);
			style8.Append(basedOn3);
			style8.Append(nextParagraphStyle4);
			style8.Append(linkedStyle4);
			style8.Append(uIPriority7);
			style8.Append(rsid40);
			style8.Append(styleParagraphProperties5);
			style8.Append(styleRunProperties5);

			Style style9 = new Style() { Type = StyleValues.Character, StyleId = "SottotitoloCarattere", CustomStyle = true };
			StyleName styleName9 = new StyleName() { Val = "Sottotitolo Carattere" };
			BasedOn basedOn4 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle5 = new LinkedStyle() { Val = "Sottotitolo" };
			UIPriority uIPriority8 = new UIPriority() { Val = 11 };
			Rsid rsid41 = new Rsid() { Val = "00966BD8" };

			StyleRunProperties styleRunProperties6 = new StyleRunProperties();
			RunFonts runFonts27 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Italic italic3 = new Italic();
			ItalicComplexScript italicComplexScript3 = new ItalicComplexScript();
			Color color6 = new Color() { Val = "4F81BD", ThemeColor = ThemeColorValues.Accent1 };
			Spacing spacing2 = new Spacing() { Val = 15 };
			FontSize fontSize7 = new FontSize() { Val = "24" };
			FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "24" };
			Languages languages4 = new Languages() { Val = "it-IT" };

			styleRunProperties6.Append(runFonts27);
			styleRunProperties6.Append(italic3);
			styleRunProperties6.Append(italicComplexScript3);
			styleRunProperties6.Append(color6);
			styleRunProperties6.Append(spacing2);
			styleRunProperties6.Append(fontSize7);
			styleRunProperties6.Append(fontSizeComplexScript7);
			styleRunProperties6.Append(languages4);

			style9.Append(styleName9);
			style9.Append(basedOn4);
			style9.Append(linkedStyle5);
			style9.Append(uIPriority8);
			style9.Append(rsid41);
			style9.Append(styleRunProperties6);

			Style style10 = new Style() { Type = StyleValues.Paragraph, StyleId = "PreformattatoHTML" };
			StyleName styleName10 = new StyleName() { Val = "HTML Preformatted" };
			BasedOn basedOn5 = new BasedOn() { Val = "Normale" };
			LinkedStyle linkedStyle6 = new LinkedStyle() { Val = "PreformattatoHTMLCarattere" };
			UIPriority uIPriority9 = new UIPriority() { Val = 99 };
			UnhideWhenUsed unhideWhenUsed7 = new UnhideWhenUsed();
			Rsid rsid42 = new Rsid() { Val = "008B204D" };

			StyleParagraphProperties styleParagraphProperties6 = new StyleParagraphProperties();
			SpacingBetweenLines spacingBetweenLines7 = new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto };

			styleParagraphProperties6.Append(spacingBetweenLines7);

			StyleRunProperties styleRunProperties7 = new StyleRunProperties();
			RunFonts runFonts28 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };

			styleRunProperties7.Append(runFonts28);

			style10.Append(styleName10);
			style10.Append(basedOn5);
			style10.Append(linkedStyle6);
			style10.Append(uIPriority9);
			style10.Append(unhideWhenUsed7);
			style10.Append(rsid42);
			style10.Append(styleParagraphProperties6);
			style10.Append(styleRunProperties7);

			Style style11 = new Style() { Type = StyleValues.Character, StyleId = "PreformattatoHTMLCarattere", CustomStyle = true };
			StyleName styleName11 = new StyleName() { Val = "Preformattato HTML Carattere" };
			BasedOn basedOn6 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle7 = new LinkedStyle() { Val = "PreformattatoHTML" };
			UIPriority uIPriority10 = new UIPriority() { Val = 99 };
			Rsid rsid43 = new Rsid() { Val = "008B204D" };

			StyleRunProperties styleRunProperties8 = new StyleRunProperties();
			RunFonts runFonts29 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			FontSize fontSize8 = new FontSize() { Val = "20" };
			FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "20" };
			Languages languages5 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties8.Append(runFonts29);
			styleRunProperties8.Append(fontSize8);
			styleRunProperties8.Append(fontSizeComplexScript8);
			styleRunProperties8.Append(languages5);

			style11.Append(styleName11);
			style11.Append(basedOn6);
			style11.Append(linkedStyle7);
			style11.Append(uIPriority10);
			style11.Append(rsid43);
			style11.Append(styleRunProperties8);

			Style style12 = new Style() { Type = StyleValues.Character, StyleId = "Titolo2Carattere", CustomStyle = true };
			StyleName styleName12 = new StyleName() { Val = "Titolo 2 Carattere" };
			BasedOn basedOn7 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle8 = new LinkedStyle() { Val = "Titolo2" };
			UIPriority uIPriority11 = new UIPriority() { Val = 9 };
			Rsid rsid44 = new Rsid() { Val = "00BD1D5D" };

			StyleRunProperties styleRunProperties9 = new StyleRunProperties();
			RunFonts runFonts30 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Color color7 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
			FontSize fontSize9 = new FontSize() { Val = "26" };
			FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "26" };
			Languages languages6 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties9.Append(runFonts30);
			styleRunProperties9.Append(color7);
			styleRunProperties9.Append(fontSize9);
			styleRunProperties9.Append(fontSizeComplexScript9);
			styleRunProperties9.Append(languages6);

			style12.Append(styleName12);
			style12.Append(basedOn7);
			style12.Append(linkedStyle8);
			style12.Append(uIPriority11);
			style12.Append(rsid44);
			style12.Append(styleRunProperties9);

			Style style13 = new Style() { Type = StyleValues.Character, StyleId = "Titolo3Carattere", CustomStyle = true };
			StyleName styleName13 = new StyleName() { Val = "Titolo 3 Carattere" };
			BasedOn basedOn8 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle9 = new LinkedStyle() { Val = "Titolo3" };
			UIPriority uIPriority12 = new UIPriority() { Val = 9 };
			Rsid rsid45 = new Rsid() { Val = "00BD1D5D" };

			StyleRunProperties styleRunProperties10 = new StyleRunProperties();
			RunFonts runFonts31 = new RunFonts() { AsciiTheme = ThemeFontValues.MajorHighAnsi, HighAnsiTheme = ThemeFontValues.MajorHighAnsi, EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Color color8 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };
			FontSize fontSize10 = new FontSize() { Val = "24" };
			FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "24" };
			Languages languages7 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties10.Append(runFonts31);
			styleRunProperties10.Append(color8);
			styleRunProperties10.Append(fontSize10);
			styleRunProperties10.Append(fontSizeComplexScript10);
			styleRunProperties10.Append(languages7);

			style13.Append(styleName13);
			style13.Append(basedOn8);
			style13.Append(linkedStyle9);
			style13.Append(uIPriority12);
			style13.Append(rsid45);
			style13.Append(styleRunProperties10);

			Style style14 = new Style() { Type = StyleValues.Character, StyleId = "Titolo4Carattere", CustomStyle = true };
			StyleName styleName14 = new StyleName() { Val = "Titolo 4 Carattere" };
			BasedOn basedOn9 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle10 = new LinkedStyle() { Val = "Titolo4" };
			UIPriority uIPriority13 = new UIPriority() { Val = 9 };
			Rsid rsid46 = new Rsid() { Val = "00D30EB8" };

			StyleRunProperties styleRunProperties11 = new StyleRunProperties();
			RunFonts runFonts32 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Italic italic4 = new Italic();
			ItalicComplexScript italicComplexScript4 = new ItalicComplexScript();
			Color color9 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
			FontSize fontSize11 = new FontSize() { Val = "28" };
			FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "20" };
			Languages languages8 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties11.Append(runFonts32);
			styleRunProperties11.Append(italic4);
			styleRunProperties11.Append(italicComplexScript4);
			styleRunProperties11.Append(color9);
			styleRunProperties11.Append(fontSize11);
			styleRunProperties11.Append(fontSizeComplexScript11);
			styleRunProperties11.Append(languages8);

			style14.Append(styleName14);
			style14.Append(basedOn9);
			style14.Append(linkedStyle10);
			style14.Append(uIPriority13);
			style14.Append(rsid46);
			style14.Append(styleRunProperties11);

			Style style15 = new Style() { Type = StyleValues.Paragraph, StyleId = "Testofumetto" };
			StyleName styleName15 = new StyleName() { Val = "Balloon Text" };
			BasedOn basedOn10 = new BasedOn() { Val = "Normale" };
			LinkedStyle linkedStyle11 = new LinkedStyle() { Val = "TestofumettoCarattere" };
			UIPriority uIPriority14 = new UIPriority() { Val = 99 };
			SemiHidden semiHidden4 = new SemiHidden();
			UnhideWhenUsed unhideWhenUsed8 = new UnhideWhenUsed();
			Rsid rsid47 = new Rsid() { Val = "00BD1D5D" };

			StyleParagraphProperties styleParagraphProperties7 = new StyleParagraphProperties();
			SpacingBetweenLines spacingBetweenLines8 = new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto };

			styleParagraphProperties7.Append(spacingBetweenLines8);

			StyleRunProperties styleRunProperties12 = new StyleRunProperties();
			RunFonts runFonts33 = new RunFonts() { Ascii = "Segoe UI", HighAnsi = "Segoe UI", ComplexScript = "Segoe UI" };
			FontSize fontSize12 = new FontSize() { Val = "18" };
			FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "18" };

			styleRunProperties12.Append(runFonts33);
			styleRunProperties12.Append(fontSize12);
			styleRunProperties12.Append(fontSizeComplexScript12);

			style15.Append(styleName15);
			style15.Append(basedOn10);
			style15.Append(linkedStyle11);
			style15.Append(uIPriority14);
			style15.Append(semiHidden4);
			style15.Append(unhideWhenUsed8);
			style15.Append(rsid47);
			style15.Append(styleParagraphProperties7);
			style15.Append(styleRunProperties12);

			Style style16 = new Style() { Type = StyleValues.Character, StyleId = "TestofumettoCarattere", CustomStyle = true };
			StyleName styleName16 = new StyleName() { Val = "Testo fumetto Carattere" };
			BasedOn basedOn11 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle12 = new LinkedStyle() { Val = "Testofumetto" };
			UIPriority uIPriority15 = new UIPriority() { Val = 99 };
			SemiHidden semiHidden5 = new SemiHidden();
			Rsid rsid48 = new Rsid() { Val = "00BD1D5D" };

			StyleRunProperties styleRunProperties13 = new StyleRunProperties();
			RunFonts runFonts34 = new RunFonts() { Ascii = "Segoe UI", HighAnsi = "Segoe UI", EastAsia = "Times New Roman", ComplexScript = "Segoe UI" };
			Color color10 = new Color() { Val = "000000" };
			FontSize fontSize13 = new FontSize() { Val = "18" };
			FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "18" };
			Languages languages9 = new Languages() { EastAsia = "en-GB" };

			styleRunProperties13.Append(runFonts34);
			styleRunProperties13.Append(color10);
			styleRunProperties13.Append(fontSize13);
			styleRunProperties13.Append(fontSizeComplexScript13);
			styleRunProperties13.Append(languages9);

			style16.Append(styleName16);
			style16.Append(basedOn11);
			style16.Append(linkedStyle12);
			style16.Append(uIPriority15);
			style16.Append(semiHidden5);
			style16.Append(rsid48);
			style16.Append(styleRunProperties13);

			Style style17 = new Style() { Type = StyleValues.Paragraph, StyleId = "StropheWC", CustomStyle = true };
			StyleName styleName17 = new StyleName() { Val = "StropheWC" };
			LinkedStyle linkedStyle13 = new LinkedStyle() { Val = "StropheWCCarattere" };
			PrimaryStyle primaryStyle1 = new PrimaryStyle();
			Rsid rsid49 = new Rsid() { Val = "00E62C1A" };

			StyleParagraphProperties styleParagraphProperties8 = new StyleParagraphProperties();
			KeepLines keepLines4 = new KeepLines();
			SpacingBetweenLines spacingBetweenLines9 = new SpacingBetweenLines() { Before = "240", After = "120", Line = "360", LineRule = LineSpacingRuleValues.Auto };

			styleParagraphProperties8.Append(keepLines4);
			styleParagraphProperties8.Append(spacingBetweenLines9);

			StyleRunProperties styleRunProperties14 = new StyleRunProperties();
			RunFonts runFonts35 = new RunFonts() { Ascii = "Eras Medium ITC", HighAnsi = "Eras Medium ITC", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Color color11 = new Color() { Val = "000000" };
			FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "20" };
			Languages languages10 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties14.Append(runFonts35);
			styleRunProperties14.Append(color11);
			styleRunProperties14.Append(fontSizeComplexScript14);
			styleRunProperties14.Append(languages10);

			style17.Append(styleName17);
			style17.Append(linkedStyle13);
			style17.Append(primaryStyle1);
			style17.Append(rsid49);
			style17.Append(styleParagraphProperties8);
			style17.Append(styleRunProperties14);

			Style style18 = new Style() { Type = StyleValues.Paragraph, StyleId = "SongArtist", CustomStyle = true };
			StyleName styleName18 = new StyleName() { Val = "SongArtist" };
			NextParagraphStyle nextParagraphStyle5 = new NextParagraphStyle() { Val = "StropheWC" };
			LinkedStyle linkedStyle14 = new LinkedStyle() { Val = "SongArtistCarattere" };
			PrimaryStyle primaryStyle2 = new PrimaryStyle();
			Rsid rsid50 = new Rsid() { Val = "009847DA" };

			StyleParagraphProperties styleParagraphProperties9 = new StyleParagraphProperties();
			KeepNext keepNext4 = new KeepNext();
			KeepLines keepLines5 = new KeepLines();

			styleParagraphProperties9.Append(keepNext4);
			styleParagraphProperties9.Append(keepLines5);

			StyleRunProperties styleRunProperties15 = new StyleRunProperties();
			RunFonts runFonts36 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Italic italic5 = new Italic();
			ItalicComplexScript italicComplexScript5 = new ItalicComplexScript();
			Color color12 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
			FontSize fontSize14 = new FontSize() { Val = "28" };
			FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "20" };
			Languages languages11 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties15.Append(runFonts36);
			styleRunProperties15.Append(italic5);
			styleRunProperties15.Append(italicComplexScript5);
			styleRunProperties15.Append(color12);
			styleRunProperties15.Append(fontSize14);
			styleRunProperties15.Append(fontSizeComplexScript15);
			styleRunProperties15.Append(languages11);

			style18.Append(styleName18);
			style18.Append(nextParagraphStyle5);
			style18.Append(linkedStyle14);
			style18.Append(primaryStyle2);
			style18.Append(rsid50);
			style18.Append(styleParagraphProperties9);
			style18.Append(styleRunProperties15);

			Style style19 = new Style() { Type = StyleValues.Character, StyleId = "StropheWCCarattere", CustomStyle = true };
			StyleName styleName19 = new StyleName() { Val = "StropheWC Carattere" };
			BasedOn basedOn12 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle15 = new LinkedStyle() { Val = "StropheWC" };
			Rsid rsid51 = new Rsid() { Val = "00E62C1A" };

			StyleRunProperties styleRunProperties16 = new StyleRunProperties();
			RunFonts runFonts37 = new RunFonts() { Ascii = "Eras Medium ITC", HighAnsi = "Eras Medium ITC", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Color color13 = new Color() { Val = "000000" };
			FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "20" };
			Languages languages12 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties16.Append(runFonts37);
			styleRunProperties16.Append(color13);
			styleRunProperties16.Append(fontSizeComplexScript16);
			styleRunProperties16.Append(languages12);

			style19.Append(styleName19);
			style19.Append(basedOn12);
			style19.Append(linkedStyle15);
			style19.Append(rsid51);
			style19.Append(styleRunProperties16);

			Style style20 = new Style() { Type = StyleValues.Paragraph, StyleId = "ChorusWC", CustomStyle = true };
			StyleName styleName20 = new StyleName() { Val = "ChorusWC" };
			BasedOn basedOn13 = new BasedOn() { Val = "StropheWC" };
			LinkedStyle linkedStyle16 = new LinkedStyle() { Val = "ChorusWCCarattere" };
			PrimaryStyle primaryStyle3 = new PrimaryStyle();
			Rsid rsid52 = new Rsid() { Val = "00BE6E7C" };

			StyleRunProperties styleRunProperties17 = new StyleRunProperties();
			Italic italic6 = new Italic();

			styleRunProperties17.Append(italic6);

			style20.Append(styleName20);
			style20.Append(basedOn13);
			style20.Append(linkedStyle16);
			style20.Append(primaryStyle3);
			style20.Append(rsid52);
			style20.Append(styleRunProperties17);

			Style style21 = new Style() { Type = StyleValues.Character, StyleId = "SongArtistCarattere", CustomStyle = true };
			StyleName styleName21 = new StyleName() { Val = "SongArtist Carattere" };
			BasedOn basedOn14 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle17 = new LinkedStyle() { Val = "SongArtist" };
			Rsid rsid53 = new Rsid() { Val = "009847DA" };

			StyleRunProperties styleRunProperties18 = new StyleRunProperties();
			RunFonts runFonts38 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Italic italic7 = new Italic();
			ItalicComplexScript italicComplexScript6 = new ItalicComplexScript();
			Color color14 = new Color() { Val = "365F91", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "BF" };
			FontSize fontSize15 = new FontSize() { Val = "28" };
			FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "20" };
			Languages languages13 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties18.Append(runFonts38);
			styleRunProperties18.Append(italic7);
			styleRunProperties18.Append(italicComplexScript6);
			styleRunProperties18.Append(color14);
			styleRunProperties18.Append(fontSize15);
			styleRunProperties18.Append(fontSizeComplexScript17);
			styleRunProperties18.Append(languages13);

			style21.Append(styleName21);
			style21.Append(basedOn14);
			style21.Append(linkedStyle17);
			style21.Append(rsid53);
			style21.Append(styleRunProperties18);

			Style style22 = new Style() { Type = StyleValues.Paragraph, StyleId = "ChorusWoC", CustomStyle = true };
			StyleName styleName22 = new StyleName() { Val = "ChorusWoC" };
			BasedOn basedOn15 = new BasedOn() { Val = "StropheWoC" };
			NextParagraphStyle nextParagraphStyle6 = new NextParagraphStyle() { Val = "StropheWoC" };
			LinkedStyle linkedStyle18 = new LinkedStyle() { Val = "ChorusWoCCarattere" };
			PrimaryStyle primaryStyle4 = new PrimaryStyle();
			Rsid rsid54 = new Rsid() { Val = "005610C4" };

			StyleRunProperties styleRunProperties19 = new StyleRunProperties();
			Italic italic8 = new Italic();

			styleRunProperties19.Append(italic8);

			style22.Append(styleName22);
			style22.Append(basedOn15);
			style22.Append(nextParagraphStyle6);
			style22.Append(linkedStyle18);
			style22.Append(primaryStyle4);
			style22.Append(rsid54);
			style22.Append(styleRunProperties19);

			Style style23 = new Style() { Type = StyleValues.Character, StyleId = "ChorusWCCarattere", CustomStyle = true };
			StyleName styleName23 = new StyleName() { Val = "ChorusWC Carattere" };
			BasedOn basedOn16 = new BasedOn() { Val = "StropheWCCarattere" };
			LinkedStyle linkedStyle19 = new LinkedStyle() { Val = "ChorusWC" };
			Rsid rsid55 = new Rsid() { Val = "00BE6E7C" };

			StyleRunProperties styleRunProperties20 = new StyleRunProperties();
			RunFonts runFonts39 = new RunFonts() { Ascii = "Eras Medium ITC", HighAnsi = "Eras Medium ITC", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Italic italic9 = new Italic();
			Color color15 = new Color() { Val = "000000" };
			FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "20" };
			Languages languages14 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties20.Append(runFonts39);
			styleRunProperties20.Append(italic9);
			styleRunProperties20.Append(color15);
			styleRunProperties20.Append(fontSizeComplexScript18);
			styleRunProperties20.Append(languages14);

			style23.Append(styleName23);
			style23.Append(basedOn16);
			style23.Append(linkedStyle19);
			style23.Append(rsid55);
			style23.Append(styleRunProperties20);

			Style style24 = new Style() { Type = StyleValues.Paragraph, StyleId = "StropheWoC", CustomStyle = true };
			StyleName styleName24 = new StyleName() { Val = "StropheWoC" };
			BasedOn basedOn17 = new BasedOn() { Val = "StropheWC" };
			LinkedStyle linkedStyle20 = new LinkedStyle() { Val = "StropheWoCCarattere" };
			PrimaryStyle primaryStyle5 = new PrimaryStyle();
			Rsid rsid56 = new Rsid() { Val = "00F36B82" };

			StyleParagraphProperties styleParagraphProperties10 = new StyleParagraphProperties();
			SpacingBetweenLines spacingBetweenLines10 = new SpacingBetweenLines() { Before = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

			styleParagraphProperties10.Append(spacingBetweenLines10);

			style24.Append(styleName24);
			style24.Append(basedOn17);
			style24.Append(linkedStyle20);
			style24.Append(primaryStyle5);
			style24.Append(rsid56);
			style24.Append(styleParagraphProperties10);

			Style style25 = new Style() { Type = StyleValues.Character, StyleId = "ChorusWoCCarattere", CustomStyle = true };
			StyleName styleName25 = new StyleName() { Val = "ChorusWoC Carattere" };
			BasedOn basedOn18 = new BasedOn() { Val = "StropheWoCCarattere" };
			LinkedStyle linkedStyle21 = new LinkedStyle() { Val = "ChorusWoC" };
			Rsid rsid57 = new Rsid() { Val = "005610C4" };

			StyleRunProperties styleRunProperties21 = new StyleRunProperties();
			RunFonts runFonts40 = new RunFonts() { Ascii = "Eras Medium ITC", HighAnsi = "Eras Medium ITC", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Italic italic10 = new Italic();
			Color color16 = new Color() { Val = "000000" };
			FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "20" };
			Languages languages15 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties21.Append(runFonts40);
			styleRunProperties21.Append(italic10);
			styleRunProperties21.Append(color16);
			styleRunProperties21.Append(fontSizeComplexScript19);
			styleRunProperties21.Append(languages15);

			style25.Append(styleName25);
			style25.Append(basedOn18);
			style25.Append(linkedStyle21);
			style25.Append(rsid57);
			style25.Append(styleRunProperties21);

			Style style26 = new Style() { Type = StyleValues.Character, StyleId = "StropheWoCCarattere", CustomStyle = true };
			StyleName styleName26 = new StyleName() { Val = "StropheWoC Carattere" };
			BasedOn basedOn19 = new BasedOn() { Val = "StropheWCCarattere" };
			LinkedStyle linkedStyle22 = new LinkedStyle() { Val = "StropheWoC" };
			Rsid rsid58 = new Rsid() { Val = "00F36B82" };

			StyleRunProperties styleRunProperties22 = new StyleRunProperties();
			RunFonts runFonts41 = new RunFonts() { Ascii = "Eras Medium ITC", HighAnsi = "Eras Medium ITC", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Color color17 = new Color() { Val = "000000" };
			FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "20" };
			Languages languages16 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties22.Append(runFonts41);
			styleRunProperties22.Append(color17);
			styleRunProperties22.Append(fontSizeComplexScript20);
			styleRunProperties22.Append(languages16);

			style26.Append(styleName26);
			style26.Append(basedOn19);
			style26.Append(linkedStyle22);
			style26.Append(rsid58);
			style26.Append(styleRunProperties22);

			Style style27 = new Style() { Type = StyleValues.Paragraph, StyleId = "SongTitle", CustomStyle = true };
			StyleName styleName27 = new StyleName() { Val = "SongTitle" };
			NextParagraphStyle nextParagraphStyle7 = new NextParagraphStyle() { Val = "StropheWC" };
			LinkedStyle linkedStyle23 = new LinkedStyle() { Val = "SongTitleCarattere" };
			PrimaryStyle primaryStyle6 = new PrimaryStyle();
			Rsid rsid59 = new Rsid() { Val = "009847DA" };

			StyleParagraphProperties styleParagraphProperties11 = new StyleParagraphProperties();
			KeepNext keepNext5 = new KeepNext();
			KeepLines keepLines6 = new KeepLines();
			SpacingBetweenLines spacingBetweenLines11 = new SpacingBetweenLines() { Before = "40", After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
			ContextualSpacing contextualSpacing2 = new ContextualSpacing();

			styleParagraphProperties11.Append(keepNext5);
			styleParagraphProperties11.Append(keepLines6);
			styleParagraphProperties11.Append(spacingBetweenLines11);
			styleParagraphProperties11.Append(contextualSpacing2);

			StyleRunProperties styleRunProperties23 = new StyleRunProperties();
			RunFonts runFonts42 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Color color18 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };
			FontSize fontSize16 = new FontSize() { Val = "36" };
			FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "24" };
			Languages languages17 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties23.Append(runFonts42);
			styleRunProperties23.Append(color18);
			styleRunProperties23.Append(fontSize16);
			styleRunProperties23.Append(fontSizeComplexScript21);
			styleRunProperties23.Append(languages17);

			style27.Append(styleName27);
			style27.Append(nextParagraphStyle7);
			style27.Append(linkedStyle23);
			style27.Append(primaryStyle6);
			style27.Append(rsid59);
			style27.Append(styleParagraphProperties11);
			style27.Append(styleRunProperties23);

			Style style28 = new Style() { Type = StyleValues.Character, StyleId = "SongTitleCarattere", CustomStyle = true };
			StyleName styleName28 = new StyleName() { Val = "SongTitle Carattere" };
			BasedOn basedOn20 = new BasedOn() { Val = "Titolo3Carattere" };
			LinkedStyle linkedStyle24 = new LinkedStyle() { Val = "SongTitle" };
			Rsid rsid60 = new Rsid() { Val = "009847DA" };

			StyleRunProperties styleRunProperties24 = new StyleRunProperties();
			RunFonts runFonts43 = new RunFonts() { Ascii = "Cambria", HighAnsi = "Cambria", EastAsiaTheme = ThemeFontValues.MajorEastAsia, ComplexScriptTheme = ThemeFontValues.MajorBidi };
			Color color19 = new Color() { Val = "243F60", ThemeColor = ThemeColorValues.Accent1, ThemeShade = "7F" };
			FontSize fontSize17 = new FontSize() { Val = "36" };
			FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "24" };
			Languages languages18 = new Languages() { Val = "it-IT", EastAsia = "it-IT" };

			styleRunProperties24.Append(runFonts43);
			styleRunProperties24.Append(color19);
			styleRunProperties24.Append(fontSize17);
			styleRunProperties24.Append(fontSizeComplexScript22);
			styleRunProperties24.Append(languages18);

			style28.Append(styleName28);
			style28.Append(basedOn20);
			style28.Append(linkedStyle24);
			style28.Append(rsid60);
			style28.Append(styleRunProperties24);

			Style style29 = new Style() { Type = StyleValues.Paragraph, StyleId = "ChordTB", CustomStyle = true };
			StyleName styleName29 = new StyleName() { Val = "ChordTB" };
			BasedOn basedOn21 = new BasedOn() { Val = "Normale" };
			LinkedStyle linkedStyle25 = new LinkedStyle() { Val = "ChordTBCarattere" };
			PrimaryStyle primaryStyle7 = new PrimaryStyle();
			Rsid rsid61 = new Rsid() { Val = "0020187D" };

			StyleRunProperties styleRunProperties25 = new StyleRunProperties();
			RunFonts runFonts44 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
			Bold bold21 = new Bold();

			OpenXmlUnknownElement openXmlUnknownElement1 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<w14:textOutline w14:w=\"9525\" w14:cap=\"rnd\" w14:cmpd=\"sng\" w14:algn=\"ctr\" xmlns:w14=\"http://schemas.microsoft.com/office/word/2010/wordml\"><w14:noFill /><w14:prstDash w14:val=\"solid\" /><w14:bevel /></w14:textOutline>");

			styleRunProperties25.Append(runFonts44);
			styleRunProperties25.Append(bold21);
			styleRunProperties25.Append(openXmlUnknownElement1);

			style29.Append(styleName29);
			style29.Append(basedOn21);
			style29.Append(linkedStyle25);
			style29.Append(primaryStyle7);
			style29.Append(rsid61);
			style29.Append(styleRunProperties25);

			Style style30 = new Style() { Type = StyleValues.Character, StyleId = "ChordTBCarattere", CustomStyle = true };
			StyleName styleName30 = new StyleName() { Val = "ChordTB Carattere" };
			BasedOn basedOn22 = new BasedOn() { Val = "Carpredefinitoparagrafo" };
			LinkedStyle linkedStyle26 = new LinkedStyle() { Val = "ChordTB" };
			Rsid rsid62 = new Rsid() { Val = "0020187D" };

			StyleRunProperties styleRunProperties26 = new StyleRunProperties();
			RunFonts runFonts45 = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New", EastAsia = "Times New Roman", ComplexScript = "Courier New" };
			Bold bold22 = new Bold();
			Color color20 = new Color() { Val = "000000" };
			FontSize fontSize18 = new FontSize() { Val = "20" };
			FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "20" };
			Languages languages19 = new Languages() { EastAsia = "en-GB" };

			OpenXmlUnknownElement openXmlUnknownElement2 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<w14:textOutline w14:w=\"9525\" w14:cap=\"rnd\" w14:cmpd=\"sng\" w14:algn=\"ctr\" xmlns:w14=\"http://schemas.microsoft.com/office/word/2010/wordml\"><w14:noFill /><w14:prstDash w14:val=\"solid\" /><w14:bevel /></w14:textOutline>");

			styleRunProperties26.Append(runFonts45);
			styleRunProperties26.Append(bold22);
			styleRunProperties26.Append(color20);
			styleRunProperties26.Append(fontSize18);
			styleRunProperties26.Append(fontSizeComplexScript23);
			styleRunProperties26.Append(languages19);
			styleRunProperties26.Append(openXmlUnknownElement2);

			style30.Append(styleName30);
			style30.Append(basedOn22);
			style30.Append(linkedStyle26);
			style30.Append(rsid62);
			style30.Append(styleRunProperties26);

			styles1.Append(docDefaults1);
			styles1.Append(latentStyles1);
			styles1.Append(style1);
			styles1.Append(style2);
			styles1.Append(style3);
			styles1.Append(style4);
			styles1.Append(style5);
			styles1.Append(style6);
			styles1.Append(style7);
			styles1.Append(style8);
			styles1.Append(style9);
			styles1.Append(style10);
			styles1.Append(style11);
			styles1.Append(style12);
			styles1.Append(style13);
			styles1.Append(style14);
			styles1.Append(style15);
			styles1.Append(style16);
			styles1.Append(style17);
			styles1.Append(style18);
			styles1.Append(style19);
			styles1.Append(style20);
			styles1.Append(style21);
			styles1.Append(style22);
			styles1.Append(style23);
			styles1.Append(style24);
			styles1.Append(style25);
			styles1.Append(style26);
			styles1.Append(style27);
			styles1.Append(style28);
			styles1.Append(style29);
			styles1.Append(style30);

			styleDefinitionsPart1.Styles = styles1;
		}

		// Generates content of themePart1.
		private void GenerateThemePart1Content(ThemePart themePart1)
		{
			A.Theme theme1 = new A.Theme() { Name = "Tema di Office" };
			theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

			A.ThemeElements themeElements1 = new A.ThemeElements();

			A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Office" };

			A.Dark1Color dark1Color1 = new A.Dark1Color();
			A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

			dark1Color1.Append(systemColor1);

			A.Light1Color light1Color1 = new A.Light1Color();
			A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

			light1Color1.Append(systemColor2);

			A.Dark2Color dark2Color1 = new A.Dark2Color();
			A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

			dark2Color1.Append(rgbColorModelHex1);

			A.Light2Color light2Color1 = new A.Light2Color();
			A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

			light2Color1.Append(rgbColorModelHex2);

			A.Accent1Color accent1Color1 = new A.Accent1Color();
			A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

			accent1Color1.Append(rgbColorModelHex3);

			A.Accent2Color accent2Color1 = new A.Accent2Color();
			A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

			accent2Color1.Append(rgbColorModelHex4);

			A.Accent3Color accent3Color1 = new A.Accent3Color();
			A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

			accent3Color1.Append(rgbColorModelHex5);

			A.Accent4Color accent4Color1 = new A.Accent4Color();
			A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

			accent4Color1.Append(rgbColorModelHex6);

			A.Accent5Color accent5Color1 = new A.Accent5Color();
			A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

			accent5Color1.Append(rgbColorModelHex7);

			A.Accent6Color accent6Color1 = new A.Accent6Color();
			A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

			accent6Color1.Append(rgbColorModelHex8);

			A.Hyperlink hyperlink1 = new A.Hyperlink();
			A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

			hyperlink1.Append(rgbColorModelHex9);

			A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
			A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

			followedHyperlinkColor1.Append(rgbColorModelHex10);

			colorScheme1.Append(dark1Color1);
			colorScheme1.Append(light1Color1);
			colorScheme1.Append(dark2Color1);
			colorScheme1.Append(light2Color1);
			colorScheme1.Append(accent1Color1);
			colorScheme1.Append(accent2Color1);
			colorScheme1.Append(accent3Color1);
			colorScheme1.Append(accent4Color1);
			colorScheme1.Append(accent5Color1);
			colorScheme1.Append(accent6Color1);
			colorScheme1.Append(hyperlink1);
			colorScheme1.Append(followedHyperlinkColor1);

			A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Office" };

			A.MajorFont majorFont1 = new A.MajorFont();
			A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Cambria" };
			A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
			A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
			A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ ゴシック" };
			A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
			A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
			A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
			A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
			A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
			A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
			A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
			A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
			A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
			A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
			A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
			A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
			A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
			A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
			A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
			A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
			A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
			A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
			A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
			A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
			A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
			A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
			A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
			A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
			A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
			A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
			A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
			A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };

			majorFont1.Append(latinFont1);
			majorFont1.Append(eastAsianFont1);
			majorFont1.Append(complexScriptFont1);
			majorFont1.Append(supplementalFont1);
			majorFont1.Append(supplementalFont2);
			majorFont1.Append(supplementalFont3);
			majorFont1.Append(supplementalFont4);
			majorFont1.Append(supplementalFont5);
			majorFont1.Append(supplementalFont6);
			majorFont1.Append(supplementalFont7);
			majorFont1.Append(supplementalFont8);
			majorFont1.Append(supplementalFont9);
			majorFont1.Append(supplementalFont10);
			majorFont1.Append(supplementalFont11);
			majorFont1.Append(supplementalFont12);
			majorFont1.Append(supplementalFont13);
			majorFont1.Append(supplementalFont14);
			majorFont1.Append(supplementalFont15);
			majorFont1.Append(supplementalFont16);
			majorFont1.Append(supplementalFont17);
			majorFont1.Append(supplementalFont18);
			majorFont1.Append(supplementalFont19);
			majorFont1.Append(supplementalFont20);
			majorFont1.Append(supplementalFont21);
			majorFont1.Append(supplementalFont22);
			majorFont1.Append(supplementalFont23);
			majorFont1.Append(supplementalFont24);
			majorFont1.Append(supplementalFont25);
			majorFont1.Append(supplementalFont26);
			majorFont1.Append(supplementalFont27);
			majorFont1.Append(supplementalFont28);
			majorFont1.Append(supplementalFont29);

			A.MinorFont minorFont1 = new A.MinorFont();
			A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri" };
			A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
			A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
			A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ 明朝" };
			A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
			A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
			A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
			A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
			A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
			A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
			A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
			A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
			A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
			A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
			A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
			A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
			A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
			A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
			A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
			A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
			A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
			A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
			A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
			A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
			A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
			A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
			A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
			A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
			A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
			A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
			A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
			A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };

			minorFont1.Append(latinFont2);
			minorFont1.Append(eastAsianFont2);
			minorFont1.Append(complexScriptFont2);
			minorFont1.Append(supplementalFont30);
			minorFont1.Append(supplementalFont31);
			minorFont1.Append(supplementalFont32);
			minorFont1.Append(supplementalFont33);
			minorFont1.Append(supplementalFont34);
			minorFont1.Append(supplementalFont35);
			minorFont1.Append(supplementalFont36);
			minorFont1.Append(supplementalFont37);
			minorFont1.Append(supplementalFont38);
			minorFont1.Append(supplementalFont39);
			minorFont1.Append(supplementalFont40);
			minorFont1.Append(supplementalFont41);
			minorFont1.Append(supplementalFont42);
			minorFont1.Append(supplementalFont43);
			minorFont1.Append(supplementalFont44);
			minorFont1.Append(supplementalFont45);
			minorFont1.Append(supplementalFont46);
			minorFont1.Append(supplementalFont47);
			minorFont1.Append(supplementalFont48);
			minorFont1.Append(supplementalFont49);
			minorFont1.Append(supplementalFont50);
			minorFont1.Append(supplementalFont51);
			minorFont1.Append(supplementalFont52);
			minorFont1.Append(supplementalFont53);
			minorFont1.Append(supplementalFont54);
			minorFont1.Append(supplementalFont55);
			minorFont1.Append(supplementalFont56);
			minorFont1.Append(supplementalFont57);
			minorFont1.Append(supplementalFont58);

			fontScheme1.Append(majorFont1);
			fontScheme1.Append(minorFont1);

			A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Office" };

			A.FillStyleList fillStyleList1 = new A.FillStyleList();

			A.SolidFill solidFill1 = new A.SolidFill();
			A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

			solidFill1.Append(schemeColor1);

			A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

			A.GradientStopList gradientStopList1 = new A.GradientStopList();

			A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

			A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Tint tint1 = new A.Tint() { Val = 50000 };
			A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

			schemeColor2.Append(tint1);
			schemeColor2.Append(saturationModulation1);

			gradientStop1.Append(schemeColor2);

			A.GradientStop gradientStop2 = new A.GradientStop() { Position = 35000 };

			A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Tint tint2 = new A.Tint() { Val = 37000 };
			A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

			schemeColor3.Append(tint2);
			schemeColor3.Append(saturationModulation2);

			gradientStop2.Append(schemeColor3);

			A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

			A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Tint tint3 = new A.Tint() { Val = 15000 };
			A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

			schemeColor4.Append(tint3);
			schemeColor4.Append(saturationModulation3);

			gradientStop3.Append(schemeColor4);

			gradientStopList1.Append(gradientStop1);
			gradientStopList1.Append(gradientStop2);
			gradientStopList1.Append(gradientStop3);
			A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

			gradientFill1.Append(gradientStopList1);
			gradientFill1.Append(linearGradientFill1);

			A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

			A.GradientStopList gradientStopList2 = new A.GradientStopList();

			A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

			A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Shade shade1 = new A.Shade() { Val = 51000 };
			A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

			schemeColor5.Append(shade1);
			schemeColor5.Append(saturationModulation4);

			gradientStop4.Append(schemeColor5);

			A.GradientStop gradientStop5 = new A.GradientStop() { Position = 80000 };

			A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Shade shade2 = new A.Shade() { Val = 93000 };
			A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

			schemeColor6.Append(shade2);
			schemeColor6.Append(saturationModulation5);

			gradientStop5.Append(schemeColor6);

			A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

			A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Shade shade3 = new A.Shade() { Val = 94000 };
			A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

			schemeColor7.Append(shade3);
			schemeColor7.Append(saturationModulation6);

			gradientStop6.Append(schemeColor7);

			gradientStopList2.Append(gradientStop4);
			gradientStopList2.Append(gradientStop5);
			gradientStopList2.Append(gradientStop6);
			A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

			gradientFill2.Append(gradientStopList2);
			gradientFill2.Append(linearGradientFill2);

			fillStyleList1.Append(solidFill1);
			fillStyleList1.Append(gradientFill1);
			fillStyleList1.Append(gradientFill2);

			A.LineStyleList lineStyleList1 = new A.LineStyleList();

			A.Outline outline6 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

			A.SolidFill solidFill2 = new A.SolidFill();

			A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Shade shade4 = new A.Shade() { Val = 95000 };
			A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

			schemeColor8.Append(shade4);
			schemeColor8.Append(saturationModulation7);

			solidFill2.Append(schemeColor8);
			A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

			outline6.Append(solidFill2);
			outline6.Append(presetDash1);

			A.Outline outline7 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

			A.SolidFill solidFill3 = new A.SolidFill();
			A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

			solidFill3.Append(schemeColor9);
			A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

			outline7.Append(solidFill3);
			outline7.Append(presetDash2);

			A.Outline outline8 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

			A.SolidFill solidFill4 = new A.SolidFill();
			A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

			solidFill4.Append(schemeColor10);
			A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

			outline8.Append(solidFill4);
			outline8.Append(presetDash3);

			lineStyleList1.Append(outline6);
			lineStyleList1.Append(outline7);
			lineStyleList1.Append(outline8);

			A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

			A.EffectStyle effectStyle1 = new A.EffectStyle();

			A.EffectList effectList1 = new A.EffectList();

			A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

			A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
			A.Alpha alpha1 = new A.Alpha() { Val = 38000 };

			rgbColorModelHex11.Append(alpha1);

			outerShadow1.Append(rgbColorModelHex11);

			effectList1.Append(outerShadow1);

			effectStyle1.Append(effectList1);

			A.EffectStyle effectStyle2 = new A.EffectStyle();

			A.EffectList effectList2 = new A.EffectList();

			A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

			A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
			A.Alpha alpha2 = new A.Alpha() { Val = 35000 };

			rgbColorModelHex12.Append(alpha2);

			outerShadow2.Append(rgbColorModelHex12);

			effectList2.Append(outerShadow2);

			effectStyle2.Append(effectList2);

			A.EffectStyle effectStyle3 = new A.EffectStyle();

			A.EffectList effectList3 = new A.EffectList();

			A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

			A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
			A.Alpha alpha3 = new A.Alpha() { Val = 35000 };

			rgbColorModelHex13.Append(alpha3);

			outerShadow3.Append(rgbColorModelHex13);

			effectList3.Append(outerShadow3);

			A.Scene3DType scene3DType1 = new A.Scene3DType();

			A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
			A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

			camera1.Append(rotation1);

			A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
			A.Rotation rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

			lightRig1.Append(rotation2);

			scene3DType1.Append(camera1);
			scene3DType1.Append(lightRig1);

			A.Shape3DType shape3DType1 = new A.Shape3DType();
			A.BevelTop bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

			shape3DType1.Append(bevelTop1);

			effectStyle3.Append(effectList3);
			effectStyle3.Append(scene3DType1);
			effectStyle3.Append(shape3DType1);

			effectStyleList1.Append(effectStyle1);
			effectStyleList1.Append(effectStyle2);
			effectStyleList1.Append(effectStyle3);

			A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

			A.SolidFill solidFill5 = new A.SolidFill();
			A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

			solidFill5.Append(schemeColor11);

			A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

			A.GradientStopList gradientStopList3 = new A.GradientStopList();

			A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

			A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Tint tint4 = new A.Tint() { Val = 40000 };
			A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

			schemeColor12.Append(tint4);
			schemeColor12.Append(saturationModulation8);

			gradientStop7.Append(schemeColor12);

			A.GradientStop gradientStop8 = new A.GradientStop() { Position = 40000 };

			A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Tint tint5 = new A.Tint() { Val = 45000 };
			A.Shade shade5 = new A.Shade() { Val = 99000 };
			A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

			schemeColor13.Append(tint5);
			schemeColor13.Append(shade5);
			schemeColor13.Append(saturationModulation9);

			gradientStop8.Append(schemeColor13);

			A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

			A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Shade shade6 = new A.Shade() { Val = 20000 };
			A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

			schemeColor14.Append(shade6);
			schemeColor14.Append(saturationModulation10);

			gradientStop9.Append(schemeColor14);

			gradientStopList3.Append(gradientStop7);
			gradientStopList3.Append(gradientStop8);
			gradientStopList3.Append(gradientStop9);

			A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
			A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

			pathGradientFill1.Append(fillToRectangle1);

			gradientFill3.Append(gradientStopList3);
			gradientFill3.Append(pathGradientFill1);

			A.GradientFill gradientFill4 = new A.GradientFill() { RotateWithShape = true };

			A.GradientStopList gradientStopList4 = new A.GradientStopList();

			A.GradientStop gradientStop10 = new A.GradientStop() { Position = 0 };

			A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Tint tint6 = new A.Tint() { Val = 80000 };
			A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

			schemeColor15.Append(tint6);
			schemeColor15.Append(saturationModulation11);

			gradientStop10.Append(schemeColor15);

			A.GradientStop gradientStop11 = new A.GradientStop() { Position = 100000 };

			A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
			A.Shade shade7 = new A.Shade() { Val = 30000 };
			A.SaturationModulation saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

			schemeColor16.Append(shade7);
			schemeColor16.Append(saturationModulation12);

			gradientStop11.Append(schemeColor16);

			gradientStopList4.Append(gradientStop10);
			gradientStopList4.Append(gradientStop11);

			A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
			A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

			pathGradientFill2.Append(fillToRectangle2);

			gradientFill4.Append(gradientStopList4);
			gradientFill4.Append(pathGradientFill2);

			backgroundFillStyleList1.Append(solidFill5);
			backgroundFillStyleList1.Append(gradientFill3);
			backgroundFillStyleList1.Append(gradientFill4);

			formatScheme1.Append(fillStyleList1);
			formatScheme1.Append(lineStyleList1);
			formatScheme1.Append(effectStyleList1);
			formatScheme1.Append(backgroundFillStyleList1);

			themeElements1.Append(colorScheme1);
			themeElements1.Append(fontScheme1);
			themeElements1.Append(formatScheme1);

			A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();

			A.TextDefault textDefault1 = new A.TextDefault();

			A.ShapeProperties shapeProperties6 = new A.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };
			A.NoFill noFill11 = new A.NoFill();

			A.Outline outline9 = new A.Outline() { Width = 9525 };
			A.NoFill noFill12 = new A.NoFill();
			A.Miter miter6 = new A.Miter() { Limit = 800000 };
			A.HeadEnd headEnd6 = new A.HeadEnd();
			A.TailEnd tailEnd6 = new A.TailEnd();

			outline9.Append(noFill12);
			outline9.Append(miter6);
			outline9.Append(headEnd6);
			outline9.Append(tailEnd6);

			shapeProperties6.Append(noFill11);
			shapeProperties6.Append(outline9);

			A.BodyProperties bodyProperties1 = new A.BodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.None, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false };
			A.ShapeAutoFit shapeAutoFit6 = new A.ShapeAutoFit();

			bodyProperties1.Append(shapeAutoFit6);
			A.ListStyle listStyle1 = new A.ListStyle();

			textDefault1.Append(shapeProperties6);
			textDefault1.Append(bodyProperties1);
			textDefault1.Append(listStyle1);

			objectDefaults1.Append(textDefault1);
			A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

			theme1.Append(themeElements1);
			theme1.Append(objectDefaults1);
			theme1.Append(extraColorSchemeList1);

			themePart1.Theme = theme1;
		}

		// Generates content of fontTablePart1.
		private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
		{
			Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15" } };
			fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			fonts1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");

			Font font1 = new Font() { Name = "Calibri" };
			Panose1Number panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
			FontCharSet fontCharSet1 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
			Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
			FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C000247B", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

			font1.Append(panose1Number1);
			font1.Append(fontCharSet1);
			font1.Append(fontFamily1);
			font1.Append(pitch1);
			font1.Append(fontSignature1);

			Font font2 = new Font() { Name = "Times New Roman" };
			Panose1Number panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
			FontCharSet fontCharSet2 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
			Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
			FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002EFF", UnicodeSignature1 = "C000785B", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

			font2.Append(panose1Number2);
			font2.Append(fontCharSet2);
			font2.Append(fontFamily2);
			font2.Append(pitch2);
			font2.Append(fontSignature2);

			Font font3 = new Font() { Name = "Candara" };
			Panose1Number panose1Number3 = new Panose1Number() { Val = "020E0502030303020204" };
			FontCharSet fontCharSet3 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Swiss };
			Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
			FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "A00002EF", UnicodeSignature1 = "4000A44B", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

			font3.Append(panose1Number3);
			font3.Append(fontCharSet3);
			font3.Append(fontFamily3);
			font3.Append(pitch3);
			font3.Append(fontSignature3);

			Font font4 = new Font() { Name = "Courier New" };
			Panose1Number panose1Number4 = new Panose1Number() { Val = "02070309020205020404" };
			FontCharSet fontCharSet4 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily4 = new FontFamily() { Val = FontFamilyValues.Modern };
			Pitch pitch4 = new Pitch() { Val = FontPitchValues.Fixed };
			FontSignature fontSignature4 = new FontSignature() { UnicodeSignature0 = "E0002EFF", UnicodeSignature1 = "C0007843", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

			font4.Append(panose1Number4);
			font4.Append(fontCharSet4);
			font4.Append(fontFamily4);
			font4.Append(pitch4);
			font4.Append(fontSignature4);

			Font font5 = new Font() { Name = "Cambria" };
			Panose1Number panose1Number5 = new Panose1Number() { Val = "02040503050406030204" };
			FontCharSet fontCharSet5 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily5 = new FontFamily() { Val = FontFamilyValues.Roman };
			Pitch pitch5 = new Pitch() { Val = FontPitchValues.Variable };
			FontSignature fontSignature5 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "400004FF", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

			font5.Append(panose1Number5);
			font5.Append(fontCharSet5);
			font5.Append(fontFamily5);
			font5.Append(pitch5);
			font5.Append(fontSignature5);

			Font font6 = new Font() { Name = "Segoe UI" };
			Panose1Number panose1Number6 = new Panose1Number() { Val = "020B0502040204020203" };
			FontCharSet fontCharSet6 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily6 = new FontFamily() { Val = FontFamilyValues.Swiss };
			Pitch pitch6 = new Pitch() { Val = FontPitchValues.Variable };
			FontSignature fontSignature6 = new FontSignature() { UnicodeSignature0 = "E4002EFF", UnicodeSignature1 = "C000E47F", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

			font6.Append(panose1Number6);
			font6.Append(fontCharSet6);
			font6.Append(fontFamily6);
			font6.Append(pitch6);
			font6.Append(fontSignature6);

			Font font7 = new Font() { Name = "Eras Medium ITC" };
			Panose1Number panose1Number7 = new Panose1Number() { Val = "020B0602030504020804" };
			FontCharSet fontCharSet7 = new FontCharSet() { Val = "00" };
			FontFamily fontFamily7 = new FontFamily() { Val = FontFamilyValues.Swiss };
			Pitch pitch7 = new Pitch() { Val = FontPitchValues.Variable };
			FontSignature fontSignature7 = new FontSignature() { UnicodeSignature0 = "00000003", UnicodeSignature1 = "00000000", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "00000001", CodePageSignature1 = "00000000" };

			font7.Append(panose1Number7);
			font7.Append(fontCharSet7);
			font7.Append(fontFamily7);
			font7.Append(pitch7);
			font7.Append(fontSignature7);

			fonts1.Append(font1);
			fonts1.Append(font2);
			fonts1.Append(font3);
			fonts1.Append(font4);
			fonts1.Append(font5);
			fonts1.Append(font6);
			fonts1.Append(font7);

			fontTablePart1.Fonts = fonts1;
		}

		private void SetPackageProperties(OpenXmlPackage document)
		{
			document.PackageProperties.Creator = "Diego";
			document.PackageProperties.Revision = "1";
			document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2017-02-26T17:34:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
			document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2017-02-26T17:41:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
			document.PackageProperties.LastModifiedBy = "Diego";
		}


	}
}
