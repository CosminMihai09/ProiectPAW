using ProiectPAW.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAW
{
    public partial class HomeForm : Form
    {
        private LoanContext context;

        public HomeForm()
        {
            InitializeComponent();
            context = new LoanContext();
            Load += HomeForm_Load;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            var clients = context.Clients.ToList();

            var clientsByDate = clients
                .GroupBy(c => c.DateAdded.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .OrderBy(g => g.Date)
                .ToList();

            if (clientsByDate.Count == 0)
            {
                return;
            }

            Bitmap bmp = new Bitmap(ChartPictureBox.Width, ChartPictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(46, 51, 73));

                int margin = 40;
                int width = ChartPictureBox.Width - 2 * margin;
                int height = ChartPictureBox.Height - 2 * margin;

                Color axisColor = Color.LightGray;
                Color dataPointColor = Color.FromArgb(0, 126, 249);
                Color connectingLineColor = Color.FromArgb(0, 126, 249);
                Color labelColor = Color.White;

                Pen axisPen = new Pen(axisColor, 2);
                Pen connectingLinePen = new Pen(connectingLineColor, 2);
                Brush dataPointBrush = new SolidBrush(dataPointColor);
                Brush labelBrush = new SolidBrush(labelColor);

                int maxCount = clientsByDate.Max(d => d.Count);
                float xScale = width / (float)clientsByDate.Count;
                float yScale = height / (float)maxCount;

                g.DrawLine(axisPen, margin, ChartPictureBox.Height - margin, ChartPictureBox.Width - margin, ChartPictureBox.Height - margin);
                g.DrawLine(axisPen, margin, ChartPictureBox.Height - margin, margin, margin);

                for (int i = 0; i < clientsByDate.Count; i++)
                {
                    float x = margin + i * xScale;
                    float y = ChartPictureBox.Height - margin - clientsByDate[i].Count * yScale;
                    g.FillEllipse(dataPointBrush, x - 5, y - 5, 10, 10);

                    if (i > 0)
                    {
                        float prevX = margin + (i - 1) * xScale;
                        float prevY = ChartPictureBox.Height - margin - clientsByDate[i - 1].Count * yScale;
                        g.DrawLine(connectingLinePen, prevX, prevY, x, y);
                    }
                }

                Font labelFont = new Font("Arial", 10);

                for (int i = 0; i < clientsByDate.Count; i++)
                {
                    float x = margin + i * xScale;
                    float y = ChartPictureBox.Height - margin - clientsByDate[i].Count * yScale;
                    g.DrawString(clientsByDate[i].Date.ToShortDateString(), labelFont, labelBrush, x - 20, ChartPictureBox.Height - margin + 5);
                    g.DrawString(clientsByDate[i].Count.ToString(), labelFont, labelBrush, margin - 30, y - 10);
                }
            }

            ChartPictureBox.Image = bmp;
        }
    }
}