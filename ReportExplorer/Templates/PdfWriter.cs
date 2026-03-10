using DevExpress.Drawing;
using DevExpress.Drawing.Internal.Fonts.Interop;
using DevExpress.Pdf.Drawing;
using DevExpress.Utils.ScrollAnnotations;
using DevExpress.XtraEditors;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace ReportExplorer
{
    public class PdfWriter
    {
        
        public XGraphics PdfGraphics { get; set; }
        public string Filename { get; set; }
        public PdfDocument PdfDocument { get; set; }
        public Bounds Bounds = new Bounds();
        public int PdfPageCount = 0;

        public PdfWriter(string name)
        {
        

        }

        public void Open(string title)
        {
            PdfDocument = new PdfDocument();
            
           

            //PdfDocument.SecuritySettings.UserPassword = "ABC";
            GlobalFontSettings.ResetFontManagement();
            PdfDocument.Info.Title = title;
        }

        public void NewPage()
        {

            try
            {
                if (PdfDocument == null) return;
                PdfPageCount++;
                PdfPage page = PdfDocument.AddPage();
                page.Size = PageSize.A4;
                page.Orientation = PageOrientation.Landscape;
                Bounds = null;
                PdfGraphics = XGraphics.FromPdfPage(page);
            }
            catch
            {
            }
        }

        public string Preview(bool protect)
        {
            string path = Directory.GetCurrentDirectory() + "\\preview.pdf";

            if (protect) //write protect?
            {
                PdfDocument.SecurityHandler.SetEncryptionToV2With128Bits();
                PdfDocument.SecuritySettings.OwnerPassword = "amium07#";
                PdfDocument.SecuritySettings.PermitAssembleDocument = true;
                PdfDocument.SecuritySettings.PermitModifyDocument = true;
            }


            PdfDocument.Save(path);
            return path;
        }

        public void Save(bool protect, string filename = null)
        {
            Console.WriteLine("Try save protected " + protect);
            if (PdfDocument == null) return;

            Filename = null;
            if (filename == null) {
                using (System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog())
                {

                    ofd.Filter = "(*.pdf)|*.*";
                    ofd.FilterIndex = 1;
                    ofd.RestoreDirectory = true;
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Filename = ofd.FileName;
                    }
                }
            }

            if (Filename == null)
                return;

            if (!Filename.ToUpper().EndsWith(".PDF")) Filename += ".pdf";

           

            try
            {
                if (protect) //write protect?
                {
                    PdfDocument.SecurityHandler.SetEncryptionToV2With128Bits();
                    PdfDocument.SecuritySettings.OwnerPassword = "amium07#";
                    PdfDocument.SecuritySettings.PermitAssembleDocument = true;
                    PdfDocument.SecuritySettings.PermitModifyDocument = true;
                }
 
               
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("PDF File open!!");
                //  throw ex;
            }

            PdfDocument.Save(Filename);
        }

        public void Show()
        {
            try
            {
                Process.Start(Path.Combine(@"C:\temp", Filename));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 
     
        public double mmToPxPdf = 2.835f; //@72dpi, 595dots, 21cm)
        double nextY = 0f;
        double nextX = 0f;
        double nextW = 0f;
        double nextFontSize = 2.5;
        Color nextForeColor = Color.Black;
        string nextFontName = "Calibri";
        public double lineFeed = 5;
        System.Drawing.ContentAlignment nextTextAlign = System.Drawing.ContentAlignment.TopLeft;
        public void Text(string text, string fontName = "Calibri", double size = double.NaN, object color = null, double x = double.NaN, double y = double.NaN, double w = double.NaN, object align = null, string fontStyle = "Regular")
        {
            if (double.IsNaN(x))
                x = nextX;
            if (double.IsNaN(y))
                y = nextY + lineFeed;
            if (double.IsNaN(w))
                w = nextW;

        
            if (double.IsNaN(size))
                size = nextFontSize;
            if (color == null)
                color = nextForeColor;

            if (color is string)
                nextForeColor = ColorTranslator.FromHtml(color as string);
            if (color is Color)
                nextForeColor = (Color)color;

            if (align == null)
                align = nextTextAlign;

            if (align is string)
            {
                string ta = ((string)align).ToUpper().Trim();
                if ((ta == "LEFT") || (ta == "L"))
                    align = System.Drawing.ContentAlignment.TopLeft;
                if ((ta == "MIDDLE") || (ta == "M") || (ta == "CENTER") || (ta == "C"))
                    align = System.Drawing.ContentAlignment.MiddleCenter;
                if ((ta == "RIGHT") || (ta == "R"))
                    align = System.Drawing.ContentAlignment.TopRight;
            }

            if (align is System.Drawing.ContentAlignment)
                nextTextAlign = (System.Drawing.ContentAlignment)align;

            FontStyle style = FontStyle.Regular;

            if (fontStyle.ToUpper() == "BOLD")
                style = FontStyle.Bold;

            if (fontStyle.ToUpper() == "ITALIC")
                style = FontStyle.Italic;

            if (fontStyle.ToUpper() == "UNDERLINE")
                style = FontStyle.Underline;

            Text(text, x, y, w, new Font(fontName, (float)size, style), nextForeColor, (System.Drawing.ContentAlignment)align);

            nextFontName = fontName;
            nextY = y;
            nextX = x;
            nextW = w;
        }

        void Text(string text, double x, double y, double width, Font font, Color color, System.Drawing.ContentAlignment align)
        {
            if (Bounds != null)
            {
                x += Bounds.X;
                y += Bounds.Y;
            }

            if (text == null)
                return;
            try
            {
                if (PdfGraphics != null)
                {
      
                    XFontStyleEx style = XFontStyleEx.Regular;
       
                    if (font.Style == FontStyle.Bold) style = XFontStyleEx.Bold;
                    if (font.Style == FontStyle.Italic) style = XFontStyleEx.Italic;
                    if (font.Style == FontStyle.Underline) style = XFontStyleEx.Underline;
       
                    XFont xFont  = new XFont(font.Name.ToString(), font.Size * 1.40 * mmToPxPdf, style);
                    XBrush brush = new XSolidBrush(XColor.FromArgb(color.ToArgb()));
    
                    if (align == System.Drawing.ContentAlignment.MiddleRight || align == System.Drawing.ContentAlignment.TopRight || align == System.Drawing.ContentAlignment.BottomRight)
                    {
                   
                        XStringFormat sf = new XStringFormat();
                        XSize xs = PdfGraphics.MeasureString(text, xFont);
                        PdfGraphics.DrawString(text, xFont, brush, (x + width) * mmToPxPdf - xs.Width, y * mmToPxPdf, XStringFormats.TopLeft);
                    }
                    else if (align == System.Drawing.ContentAlignment.MiddleLeft || align == System.Drawing.ContentAlignment.TopLeft || align == System.Drawing.ContentAlignment.BottomLeft)
                    {
                        
                        PdfGraphics.DrawString(text, xFont, brush, x * mmToPxPdf, y * mmToPxPdf, XStringFormats.TopLeft);
                    }
                    else
                    {
                   
                        XSize xs = PdfGraphics.MeasureString(text, xFont);
                        PdfGraphics.DrawString(text, xFont, brush, (x + width / 2) * mmToPxPdf - xs.Width / 2, y * mmToPxPdf, XStringFormats.TopLeft);
                    }
                }
            }
            catch
            {
                Debug.WriteLine("pdf Error write Text");
            }
        }

        public void TextBox(string text, double x, double y, double w, double h, string fontName, object color, double size, string fontStyle = "Regular")
        {

            text = text.Replace("\\r", "\r");
            text = text.Replace("\\n", "\n");


            XTextFormatter textBox = new XTextFormatter(PdfGraphics);

            Color xColor = Color.Black;

            if (color is string)
                xColor = ColorTranslator.FromHtml(color as string);
            if (color is Color)
                xColor = (Color)color;

            XFontStyleEx style = XFontStyleEx.Regular;

            if (fontStyle.ToUpper() == "BOLD")
                style = XFontStyleEx.Bold;

            if (fontStyle.ToUpper() == "ITALIC")
                style = XFontStyleEx.Italic;

            if (fontStyle.ToUpper() == "UNDERLINE")
                style = XFontStyleEx.Underline;

            XRect rect = new XRect(x * mmToPxPdf, y * mmToPxPdf, w * mmToPxPdf, h * mmToPxPdf);

            XBrush brush = new XSolidBrush(XColor.FromArgb(xColor.ToArgb()));
            XFont xFont = new XFont(fontName, size * 1.40 * mmToPxPdf, style);
            textBox.Alignment = XParagraphAlignment.Left;
            textBox.DrawString(text, xFont, brush, rect, XStringFormats.TopLeft);


        }

        Color nextLineColor = Color.Black;
        double nextLineWidth = 0.2;
        double nextLineX = 0;
        double nextLineY = 0;
        public void Line(object color = null, double width = double.NaN, double x1 = double.NaN, double y1 = double.NaN, double x2 = double.NaN, double y2 = double.NaN)
        {
            if (color == null)
                color = nextLineColor;

            if (color is string)
                nextLineColor = ColorTranslator.FromHtml(color as string);
            if (color is Color)
                nextLineColor = (Color)color;

            if (double.IsNaN(width))
                width = nextLineWidth;
            nextLineWidth = width;

            if (double.IsNaN(x1))
                x1 = nextLineX;
            if (double.IsNaN(y1))
                y1 = nextLineY;

            nextLineX = x2;
            nextLineY = y2;


            if (Bounds != null)
            {
                x1 += Bounds.X;
                y1 += Bounds.Y;
                x2 += Bounds.X;
                y2 += Bounds.Y;
            }

            if (double.IsNaN(x1))
                return;
            if (double.IsNaN(y1))
                return;
            if (double.IsNaN(x2))
                return;
            if (double.IsNaN(y2))
                return;
            try
            {
                if (PdfGraphics != null)
                {
                    XPen xpen = new XPen(XColor.FromArgb(nextLineColor.ToArgb()), nextLineWidth * mmToPxPdf);
                    PdfGraphics.DrawLine(xpen, x1 * mmToPxPdf, y1 * mmToPxPdf, x2 * mmToPxPdf, y2 * mmToPxPdf);
                }
            }
            catch
            {
            }
        }

        Color nextRectColor = Color.Black;
        double nextRectWidth = 0.2;
        public void Rectangle(object color = null, double width = double.NaN, double x = 0, double y = 0, double w = 10, double h = 10)
        {
            if (color == null)
                color = nextRectColor;

            if (color is string)
                nextRectColor = ColorTranslator.FromHtml(color as string);
            if (color is Color)
                nextRectColor = (Color)color;

            if (double.IsNaN(width))
                width = nextRectWidth;
            nextRectWidth = width;

            if (Bounds != null)
            {
                x += Bounds.X;
                y += Bounds.Y;
            }

            try
            {
                if (double.IsNaN(x))
                    return;
                if (double.IsNaN(y))
                    return;

                if (PdfGraphics != null)
                {
                    XPen xpen = new XPen(XColor.FromArgb(nextRectColor.ToArgb()), nextRectWidth * mmToPxPdf);
                    PdfGraphics.DrawRectangle(xpen, x * mmToPxPdf, y * mmToPxPdf, w * mmToPxPdf, h * mmToPxPdf);
                }
            }
            catch
            {
            }
        }

        Color nextFillColor = Color.Black;
        public void FillRectangle(object color = null, double x = 0, double y = 0, double w = 10, double h = 10)
        {

            if (color == null)
                color = nextRectColor;

            if (color is string)
                nextFillColor = ColorTranslator.FromHtml(color as string);
            if (color is Color)
                nextFillColor = (Color)color;


            if (Bounds != null)
            {
                x += Bounds.X;
                y += Bounds.Y;
            }

            try
            {
                if (PdfGraphics != null)
                {
                    XBrush xbrush = new XSolidBrush(XColor.FromArgb(nextFillColor.ToArgb()));
                    PdfGraphics.DrawRectangle(xbrush, x * mmToPxPdf, y * mmToPxPdf, w * mmToPxPdf, h * mmToPxPdf);
                }
            }
            catch
            {
            }
        }

        public void Image(object image, double x = 0, double y = 0, double w = 10, double h = 10)
        {
            System.Drawing.Image _image = null;
            if (image is System.Drawing.Image)
                _image = (System.Drawing.Image)image;

            if (image is string)
            {
                _image = new System.Drawing.Bitmap(Path.Combine(@"C:\temp", image as string));
            }


            if (Bounds != null)
            {
                x += Bounds.X;
                y += Bounds.Y;
            }

            try
            {
                double ratioX = _image.PhysicalDimension.Width / (w);
                double ratioY = _image.PhysicalDimension.Height / (h);
                double ratio = Math.Max(ratioX, ratioY);
                double mmW = _image.PhysicalDimension.Width / ratio;
                double mmH = _image.PhysicalDimension.Height / ratio;
                double mmHReduction = (h) - mmH;
                double mmWReduction = (w) - mmW;

                Bitmap bitmap3 = new Bitmap(_image);



                if (PdfGraphics != null)
                {

                    Bitmap bitmap = null;

                    Metafile metafile = _image as Metafile;

                    if (metafile != null)
                    {
                        int wi = (int)_image.PhysicalDimension.Width;
                        int he = (int)_image.PhysicalDimension.Height;

                        while (wi > 2000)
                        {
                            wi /= 2;
                            he /= 2;
                        }

                        bitmap = new Bitmap(wi, he);
                        bitmap.SetResolution((float)200, (float)200);
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            g.DrawImage(metafile, 0, 0, (float)wi, (float)he);
                            g.Dispose();
                        }

                        XImage xImage = XImage.FromGdiPlusImage(bitmap);
                        PdfGraphics.DrawImage(xImage, new XRect((x + (mmWReduction / 2)) * mmToPxPdf, (y + (mmHReduction / 2)) * mmToPxPdf, mmW * mmToPxPdf, mmH * mmToPxPdf));
                    }
                    else
                    {
                        XImage xImage = XImage.FromGdiPlusImage(new Bitmap(_image));
                        PdfGraphics.DrawImage(xImage, new XRect((x + (mmWReduction / 2)) * mmToPxPdf, (y + (mmHReduction / 2)) * mmToPxPdf, mmW * mmToPxPdf, mmH * mmToPxPdf));
                    }
                }
            }
            catch
            { }
        }
    }
}
