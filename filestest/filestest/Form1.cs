using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.Bookmarks;
using Spire.Pdf.General;
using Spire.Pdf.Graphics;
using System.IO;

 

namespace filestest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter text");
                textBox1.Focus();
            }
            else
            {
                string path = @"e:\t.txt";
                string text = File.ReadAllText(path,Encoding.Default);
                PdfDocument doc = new PdfDocument();
                PdfSection section = doc.Sections.Add();
                PdfPageBase page = section.Pages.Add();
                //PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 11);
                PdfCjkStandardFont font = new PdfCjkStandardFont(PdfCjkFontFamily.SinoTypeSongLight, 12.0F);
                PdfStringFormat format = new PdfStringFormat();
                format.LineSpacing = 20f;
                PdfBrush brush = PdfBrushes.Black;
                PdfTextWidget textWidget = new PdfTextWidget(text, font, brush);
                float y = 0;
                PdfTextLayout textLayout = new PdfTextLayout();
                textLayout.Break = PdfLayoutBreakType.FitPage;
                textLayout.Layout = PdfLayoutType.Paginate;
                RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
                textWidget.StringFormat = format;
                textWidget.Draw(page, bounds, textLayout);
                string path2 = @"e:\t.pdf";
                doc.SaveToFile(path2 , FileFormat.PDF); 
            }
        }
    }
}
