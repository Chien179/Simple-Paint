using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _19110173_NguyenMinhChien_Paint
{
    public partial class Form1 : Form
    {
        #region properties

        Graphics gp;
        bool bLine = false;
        bool bRectangle = false;
        bool bRectangles = false;
        bool bElipse = false;
        bool bElipses = false;
        bool bCircle = false;
        bool bCircles = false;
        bool bCurve = false;
        bool bPolygon = false;
        bool bPolygons = false;
        bool bSquare = false;
        bool bSquares = false;

        Pen myPen;
        Color myColor;
        SolidBrush myBrush;
        int thick;
        DashStyle[] myDashstyle = { DashStyle.Solid, DashStyle.Dot, DashStyle.Dash, DashStyle.DashDot, DashStyle.DashDotDot };
        int indexDashstyle = 0;
        int kieuhinh;

        int MoveIndex = -1;
        int tempMoveIndex = -1;
        int countPoint = 0;
        Point prevPoint;

        Pen selectPen;

        bool isStart = false;
        bool checkCurve = false;
        bool checkPolygon = false;
        bool checkPolygons = false;
        bool isSelected = false;

        List<cGraph> lGraph = new List<cGraph>();
        List<cGraph> isSelectShape = new List<cGraph>();

        bool bMove = false;
        bool bColor = false;
        bool bThick = false;
        bool bStyle = false;
        bool bClear = false;

        public class cGraph
        {
            public Point[] p;
            public Point p1;
            public Point p4;
            public int doday;
            public Color mausac;
            public DashStyle kieuve;
            public int kieuhinh;
        }

        #endregion

        #region contructor
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.gp = this.plMain.CreateGraphics();
            this.myColor = Color.Black;
            this.thick = Convert.ToInt32(this.nudDoDay.Value);
            this.myPen = new Pen(this.myColor, this.thick);
            this.myBrush = new SolidBrush(this.myColor);
            this.indexDashstyle = 0;
            this.pbDoiMau.BackColor = this.myColor;

            for (int i = 0; i < myDashstyle.Length; i++)
            {
                this.cbKieuVe.Items.Add(myDashstyle[i]);
            }
            this.cbKieuVe.SelectedIndex = this.indexDashstyle;
        }
        #endregion

        #region button_Click

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 0;
            this.bLine = true;

            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnKhunghinhchunhat_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 1;
            this.bRectangle = true;

            this.bLine = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnHinhchunhat_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 2;
            this.bRectangles = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnDuongVuong_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 3;
            this.bSquare = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnHinhVuong_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 4;
            this.bSquares = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnDuongelipse_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 5;
            this.bElipse = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnHinhelipse_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 6;
            this.bElipses = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnDuongtron_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 7;
            this.bCircle = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnHinhtron_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 8;
            this.bCircles = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnDuongcong_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 9;
            this.bCurve = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnDuongdagiac_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 10;
            this.bPolygon = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnHinhdagiac_Click(object sender, EventArgs e)
        {
            this.kieuhinh = 11;
            this.bPolygons = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            this.bMove = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;
            this.countPoint = 0;

            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;

            this.bClear = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.bClear = true;
            this.bMove = true;

            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;

            this.isStart = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;

            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;

            if (isSelected == true)
            {
                DialogResult mess = MessageBox.Show("Xoá hình này", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                {
                    if (this.lGraph.Count == 1)
                    {
                        this.btnClear_Click(sender, e);
                    }
                    else
                    {
                        this.lGraph.RemoveAt(this.tempMoveIndex);
                    }
                    this.isSelected = false;
                }

                this.bClear = false;
                this.plMain.Cursor = Cursors.Arrow;
                this.MoveIndex = -1;

                this.plMain.Refresh();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.bLine = false;
            this.bRectangle = false;
            this.bRectangles = false;
            this.bSquare = false;
            this.bSquares = false;
            this.bElipse = false;
            this.bElipses = false;
            this.bCircle = false;
            this.bCircles = false;
            this.bCurve = false;
            this.bPolygon = false;
            this.bPolygons = false;

            this.isStart = false;
            this.checkCurve = false;
            this.checkPolygon = false;
            this.checkPolygons = false;

            this.MoveIndex = -1;

            this.bMove = false;
            this.bColor = false;
            this.bThick = false;
            this.bStyle = false;
            this.isSelected = false;

            this.lGraph.Clear();
            this.plMain.Refresh();
        }

        #endregion

        #region Properties_Changed

        private void pbDoiMau_Click(object sender, EventArgs e)
        {
            this.bColor = true;

            this.colorDialog.AllowFullOpen = true;
            this.colorDialog.ShowDialog();
            this.myColor = this.colorDialog.Color;
            this.pbDoiMau.BackColor = this.colorDialog.Color;

            if (this.isSelected == true)
            {
                this.lGraph[this.tempMoveIndex].mausac = this.colorDialog.Color;

                this.plMain.Refresh();
            }
        }

        private void cbKieuVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bStyle = true;

            this.indexDashstyle = this.cbKieuVe.SelectedIndex;

            if (this.isSelected == true)
            {
                this.lGraph[tempMoveIndex].kieuve = this.myDashstyle[this.cbKieuVe.SelectedIndex];

                this.plMain.Refresh();
            }
        }

        private void nudDoDay_ValueChanged(object sender, EventArgs e)
        {
            this.bThick = true;

            this.thick = Convert.ToInt32(this.nudDoDay.Value);

            if (this.isSelected == true)
            {
                this.lGraph[tempMoveIndex].doday = Convert.ToInt32(this.nudDoDay.Value);

                this.plMain.Refresh();
            }
        }

        #endregion

        #region events

        private void plMain_MouseDown(object sender, MouseEventArgs e)
        {
            this.isStart = true;
            this.isSelected = false;

            if (this.bCurve == true)
            {
                this.countPoint += 3;
            }
            else
            {
                if (this.checkCurve == false && this.checkPolygon == false && this.checkPolygons == false)
                {
                    this.countPoint += 2;
                }
                if ((this.checkPolygon == true && this.bPolygon == false) || (this.checkPolygons == true && this.bPolygons == false))
                {
                    this.countPoint++;
                }
            }

            cGraph mygraph = new cGraph();

            Array.Resize(ref mygraph.p, countPoint);

            mygraph.mausac = myColor;
            mygraph.doday = thick;
            mygraph.kieuve = myDashstyle[indexDashstyle];
            mygraph.kieuhinh = kieuhinh;

            if ((this.bCurve == false && this.checkCurve == true) || (this.bPolygon == false && this.checkPolygon == true) || (this.bPolygons == false && this.checkPolygons == true))
            {
                if ((this.bPolygon == false && this.checkPolygon == true) || (this.bPolygons == false && this.checkPolygons == true))
                {
                    Array.Resize(ref this.lGraph[this.lGraph.Count - 1].p, countPoint);
                }
                this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;
            }

            if (this.bLine == true || this.bRectangle == true || this.bRectangles == true || this.bSquare == true || this.bSquares == true || this.bElipse == true || this.bElipses == true || this.bCircle == true || this.bCircles == true || this.bCurve == true || this.bPolygon == true || this.bPolygons == true)
            {

                for (int i = 0; i < countPoint; i++)
                {
                    mygraph.p[i] = e.Location;
                }

                this.lGraph.Add(mygraph);
            }

            if (this.bMove == true)
            {
                this.selectPen = new Pen(Color.Blue, 2);
                this.selectPen.DashStyle = DashStyle.Dash;
                bool check = true;

                for (int i = lGraph.Count - 1; i >= 0; i--)
                {
                    if (this.lGraph[i].kieuhinh == 0)
                    {
                        if (HitTest(e.Location, this.lGraph[i].p[0], this.lGraph[i].p[1]) == true)
                        {
                            check = propertiesChanged(i, sender, e);

                            if (check == false)
                            {
                                return;
                            }
                        }
                    }

                    if (this.lGraph[i].kieuhinh == 1 || this.lGraph[i].kieuhinh == 2 || this.lGraph[i].kieuhinh == 5 || this.lGraph[i].kieuhinh == 6)
                    {
                        int max_X = Math.Max(this.lGraph[i].p[0].X, this.lGraph[i].p[1].X);
                        int min_X = Math.Min(this.lGraph[i].p[0].X, this.lGraph[i].p[1].X);
                        int max_Y = Math.Max(this.lGraph[i].p[0].Y, this.lGraph[i].p[1].Y);
                        int min_Y = Math.Min(this.lGraph[i].p[0].Y, this.lGraph[i].p[1].Y);

                        int pX = max_X - min_X;
                        int pY = max_Y - min_Y;

                        this.lGraph[i].p1 = new Point(min_X, min_Y);
                        Point p2 = new Point(this.lGraph[i].p1.X, this.lGraph[i].p1.Y + pY);
                        Point p3 = new Point(this.lGraph[i].p1.X + pX, this.lGraph[i].p1.Y);
                        this.lGraph[i].p4 = new Point(p2.X + pX, p2.Y);

                        if (e.X >= this.lGraph[i].p1.X && e.Y >= this.lGraph[i].p1.Y && e.X <= this.lGraph[i].p4.X && e.Y <= this.lGraph[i].p4.Y && e.X >= p2.X && e.Y <= p2.Y && e.X <= p3.X && e.Y >= p3.Y)
                        {
                            check = propertiesChanged(i, sender, e);

                            if (check == false)
                            {
                                return;
                            }
                        }
                    }

                    if (this.lGraph[i].kieuhinh == 3 || this.lGraph[i].kieuhinh == 4 || this.lGraph[i].kieuhinh == 7 || this.lGraph[i].kieuhinh == 8)
                    {
                        int max_X = Math.Max(this.lGraph[i].p[0].X, this.lGraph[i].p[1].X);
                        int min_X = Math.Min(this.lGraph[i].p[0].X, this.lGraph[i].p[1].X);
                        int min_Y = Math.Min(this.lGraph[i].p[0].Y, this.lGraph[i].p[1].Y);

                        int pX = max_X - min_X;

                        this.lGraph[i].p1 = new Point(min_X, min_Y);
                        Point p2 = new Point(this.lGraph[i].p1.X, this.lGraph[i].p1.Y + pX);
                        Point p3 = new Point(this.lGraph[i].p1.X + pX, this.lGraph[i].p1.Y);
                        this.lGraph[i].p4 = new Point(p2.X + pX, p2.Y);

                        if (e.X >= this.lGraph[i].p1.X && e.Y >= this.lGraph[i].p1.Y && e.X <= this.lGraph[i].p4.X && e.Y <= this.lGraph[i].p4.Y && e.X >= p2.X && e.Y <= p2.Y && e.X <= p3.X && e.Y >= p3.Y)
                        {
                            check = propertiesChanged(i, sender, e);

                            if (check == false)
                            {
                                return;
                            }
                        }
                    }

                    if (this.lGraph[i].kieuhinh == 9)
                    {
                        int max_X = Math.Max(this.lGraph[i].p[0].X, Math.Max(this.lGraph[i].p[1].X, this.lGraph[i].p[2].X));
                        int min_X = Math.Min(this.lGraph[i].p[0].X, Math.Min(this.lGraph[i].p[1].X, this.lGraph[i].p[2].X));
                        int max_Y = Math.Max(this.lGraph[i].p[0].Y, Math.Max(this.lGraph[i].p[1].Y, this.lGraph[i].p[2].Y));
                        int min_Y = Math.Min(this.lGraph[i].p[0].Y, Math.Min(this.lGraph[i].p[1].Y, this.lGraph[i].p[2].Y));

                        int pX = max_X - min_X;
                        int pY = max_Y - min_Y;

                        this.lGraph[i].p1 = new Point(min_X - 20, min_Y - 20);
                        Point p2 = new Point(this.lGraph[i].p1.X + 20, this.lGraph[i].p1.Y + pY + 20);
                        Point p3 = new Point(this.lGraph[i].p1.X + pX + 20, this.lGraph[i].p1.Y - 20);
                        this.lGraph[i].p4 = new Point(p2.X + pX + 20, p2.Y + 20);

                        if (e.X >= this.lGraph[i].p1.X && e.Y >= this.lGraph[i].p1.Y && e.X <= this.lGraph[i].p4.X && e.Y <= this.lGraph[i].p4.Y && e.X >= p2.X && e.Y <= p2.Y && e.X <= p3.X && e.Y >= p3.Y)
                        {
                            check = propertiesChanged(i, sender, e);

                            if (check == false)
                            {
                                return;
                            }
                        }
                    }

                    if (this.lGraph[i].kieuhinh == 10 || this.lGraph[i].kieuhinh == 11)
                    {
                        int max_X = this.lGraph[i].p[0].X;
                        int min_X = this.lGraph[i].p[0].X;
                        int max_Y = this.lGraph[i].p[0].Y;
                        int min_Y = this.lGraph[i].p[0].Y;

                        for (int j = 1; j < this.lGraph[i].p.Length; j++)
                        {
                            if (max_X < this.lGraph[i].p[j].X)
                            {
                                max_X = this.lGraph[i].p[j].X;
                            }

                            if (min_X > this.lGraph[i].p[j].X)
                            {
                                min_X = this.lGraph[i].p[j].X;
                            }

                            if (max_Y < this.lGraph[i].p[j].Y)
                            {
                                max_Y = this.lGraph[i].p[j].Y;
                            }

                            if (min_Y > this.lGraph[i].p[j].Y)
                            {
                                min_Y = this.lGraph[i].p[j].Y;
                            }
                        }

                        int pX = max_X - min_X;
                        int pY = max_Y - min_Y;

                        this.lGraph[i].p1 = new Point(min_X, min_Y);
                        Point p2 = new Point(this.lGraph[i].p1.X, this.lGraph[i].p1.Y + pY);
                        Point p3 = new Point(this.lGraph[i].p1.X + pX, this.lGraph[i].p1.Y);
                        this.lGraph[i].p4 = new Point(p2.X + pX, p2.Y);

                        if (e.X >= this.lGraph[i].p1.X && e.Y >= this.lGraph[i].p1.Y && e.X <= this.lGraph[i].p4.X && e.Y <= this.lGraph[i].p4.Y && e.X >= p2.X && e.Y <= p2.Y && e.X <= p3.X && e.Y >= p3.Y)
                        {
                            check = propertiesChanged(i, sender, e);

                            if (check == false)
                            {
                                return;
                            }
                        }
                    }
                }

                this.prevPoint = e.Location;
            }
        }

        private void plMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isStart == true)
            {
                if ((this.bCurve == false && this.checkCurve == true) || (this.bPolygon == false && this.checkPolygon == true) || (this.bPolygons == false && this.checkPolygons == true))
                {
                    this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;
                }

                if (this.bLine == true || this.bRectangle == true || this.bRectangles == true || this.bSquare == true || this.bSquares == true || this.bElipse == true || this.bElipses == true || this.bCircle == true || this.bCircles == true || this.bPolygon == true || this.bCurve == true || this.bPolygons == true)
                {
                    if (this.bCurve == true)
                    {
                        this.lGraph[this.lGraph.Count - 1].p[1] = e.Location;
                    }
                    else
                    {
                        this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;
                    }
                }

                if (this.bMove == true)
                {
                    if (this.MoveIndex != -1)
                    {
                        int pX = e.Location.X - this.prevPoint.X;
                        int pY = e.Location.Y - this.prevPoint.Y;

                        this.lGraph[this.MoveIndex].p1.X += pX;
                        this.lGraph[this.MoveIndex].p1.Y += pY;
                        this.lGraph[this.MoveIndex].p4.X += pX;
                        this.lGraph[this.MoveIndex].p4.Y += pY;

                        for (int i = 0; i < this.lGraph[this.MoveIndex].p.Length; i++)
                        {
                            this.lGraph[this.MoveIndex].p[i].X += pX;
                            this.lGraph[this.MoveIndex].p[i].Y += pY;
                        }

                        this.prevPoint = e.Location;
                    }
                }

                this.plMain.Refresh();
            }
        }

        private void plMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isStart == true)
            {
                if ((this.checkPolygon == false && this.bPolygon == false) && (this.checkPolygons == false && this.bPolygons == false))
                {
                    this.countPoint = 0;
                }

                if (this.bPolygons == false)
                {
                    if (this.checkPolygons == true)
                    {
                        this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;
                    }
                }
                else
                {
                    finalPos(e);
                }

                if (this.bPolygon == false)
                {
                    if (this.checkPolygon == true)
                    {
                        this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;
                    }
                }
                else
                {
                    finalPos(e);
                }

                if (this.bCurve == false)
                {
                    if (this.checkCurve == true)//xác định vị trí cong cuối cùng
                    {
                        this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;

                        this.bCurve = true;
                        this.checkCurve = false;
                    }
                }
                else
                {
                    finalPos(e);
                }

                if (this.bMove == true)
                {
                    if (this.MoveIndex != -1)
                    {
                        int pX = e.Location.X - this.prevPoint.X;
                        int pY = e.Location.Y - this.prevPoint.Y;
                        for (int i = 0; i < this.lGraph[this.MoveIndex].p.Length; i++)
                        {
                            this.lGraph[this.MoveIndex].p[i].X += pX;
                            this.lGraph[this.MoveIndex].p[i].Y += pY;
                        }

                        this.prevPoint = e.Location;
                        this.plMain.Cursor = Cursors.Arrow;
                    }
                }

                this.plMain.Refresh();

                this.tempMoveIndex = MoveIndex;
                this.MoveIndex = -1;

                this.isStart = false;
            }
        }

        private void plMain_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < this.lGraph.Count; i++)
            {
                this.gp.SmoothingMode = SmoothingMode.HighQuality;

                Point[] p = new Point[this.lGraph[i].p.Length];
                for (int j = 0; j < this.lGraph[i].p.Length; j++)
                {
                    p[j] = this.lGraph[i].p[j];
                }
                this.myPen.Color = this.lGraph[i].mausac;
                this.myBrush.Color = this.lGraph[i].mausac;
                this.myPen.Width = this.lGraph[i].doday;
                this.myPen.DashStyle = this.lGraph[i].kieuve;

                if (this.lGraph[i].kieuhinh == 0)
                {
                    FDrawLine(this.myPen, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 1)
                {
                    FDrawRectangle(this.myPen, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 2)
                {
                    FFillRectangle(this.myBrush, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 3)
                {
                    FDrawSquare(this.myPen, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 4)
                {
                    FFillSquare(this.myBrush, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 5)
                {
                    FDrawElipse(this.myPen, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 6)
                {
                    FFillElipse(this.myBrush, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 7)
                {
                    FDrawCircle(this.myPen, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 8)
                {
                    FFillCircle(this.myBrush, p[0], p[1]);
                }

                if (this.lGraph[i].kieuhinh == 9)
                {
                    FDrawCurve(this.myPen, p[0], p[1], p[2]);
                }

                if (this.lGraph[i].kieuhinh == 10)
                {
                    FDrawPolygon(this.myPen, p);
                }

                if (this.lGraph[i].kieuhinh == 11)
                {
                    FFillPolygon(this.myBrush, p);
                }

                if (this.isSelected == true)
                {
                    if (this.bClear == false && this.bColor == false && this.bStyle == false && this.bThick == false && this.MoveIndex != -1)
                    {
                        FDrawRectangle(this.selectPen, this.lGraph[this.MoveIndex].p1, this.lGraph[this.MoveIndex].p4);
                    }
                    else if (this.tempMoveIndex != -1)
                    {
                        FDrawRectangle(this.selectPen, this.lGraph[this.tempMoveIndex].p1, this.lGraph[this.tempMoveIndex].p4);
                    }
                }
            }
        }

        private void plMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.checkPolygon == true && this.bPolygon == false)
            {
                this.checkPolygon = false;
                this.bPolygon = true;

                this.countPoint = 0;

                this.plMain.Refresh();
                this.isStart = false;
            }

            if (this.checkPolygons == true && this.bPolygons == false)
            {
                this.checkPolygons = false;
                this.bPolygons = true;

                this.countPoint = 0;

                this.plMain.Refresh();
                this.isStart = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Ở lại chơi xíu đi mà :((", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            if (exit == DialogResult.Yes)
            {
                MessageBox.Show("Cảm ơn bạn", "hihi");

                e.Cancel = true;
            }
            else
            {
                MessageBox.Show("Bye Bye", "huhu");
            }
        }

        #endregion

        #region Function

        public bool propertiesChanged(int i, object sender, MouseEventArgs e)
        {
            this.isSelected = true;

            this.plMain.Cursor = Cursors.SizeAll;
            this.MoveIndex = i;

            if (this.bColor == true)
            {
                this.lGraph[i].mausac = this.colorDialog.Color;
            }

            if (this.bThick == true)
            {
                this.lGraph[i].doday = Convert.ToInt32(this.nudDoDay.Value);
            }

            if (this.bStyle == true)
            {
                this.lGraph[i].kieuve = this.myDashstyle[this.cbKieuVe.SelectedIndex];
            }

            if (this.bClear == true)
            {
                DialogResult mess = MessageBox.Show("Xoá hình này", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (mess == DialogResult.Yes)
                {
                    if (this.lGraph.Count == 1)
                    {
                        this.btnClear_Click(sender, e);
                    }
                    else
                    {
                        this.lGraph.RemoveAt(i);
                    }
                }
                else
                {
                    this.isStart = false;
                }

                this.plMain.Cursor = Cursors.Arrow;
                this.MoveIndex = -1;
                return false;
            }

            return true;
        }

        public void finalPos(MouseEventArgs e)
        {
            if (this.bLine == true || this.bRectangle == true || this.bRectangles == true || this.bSquare == true || this.bSquares == true || this.bElipse == true || this.bElipses == true || this.bCircle == true || this.bCircles == true || this.bCurve == true || this.bPolygon == true || this.bPolygons == true)
            {
                if (this.bCurve == true)
                {
                    this.lGraph[this.lGraph.Count - 1].p[1] = e.Location;

                    this.checkCurve = true;
                    this.bCurve = false;
                }
                else
                {
                    if (this.bPolygon == true)
                    {
                        this.checkPolygon = true;
                        this.bPolygon = false;
                    }

                    if (this.bPolygons == true)
                    {
                        this.checkPolygons = true;
                        this.bPolygons = false;
                    }

                    this.lGraph[this.lGraph.Count - 1].p[this.lGraph[this.lGraph.Count - 1].p.Length - 1] = e.Location;
                }
            }
        }

        public bool HitTest(Point e, Point P1, Point P2)
        {
            // test if we fall outside of the bounding box:
            if ((e.X < P1.X && e.X < P2.X) || (e.X > P1.X && e.X > P2.X) || (e.Y < P1.Y && e.Y < P2.Y) || (e.Y > P1.Y && e.Y > P2.Y))
                return false;
            // now we calculate the distance:
            float dy = P2.Y - P1.Y;
            float dx = P2.X - P1.X;
            float Z = dy * e.X - dx * e.Y + P1.Y * P2.X - P1.X * P2.Y;
            float N = dy * dy + dx * dx;
            float dist = (float)(Math.Abs(Z) / Math.Sqrt(N));
            float Linewidth = (float)(Math.Sqrt(Math.Abs(dy) + Math.Abs(dx)));
            // done:
            if (dist < Linewidth / 2f)
            {
                return true;
            }

            return false;
        }

        private void FDrawLine(Pen mypen, Point p1, Point p2)
        {
            this.gp.DrawLine(mypen, p1, p2);
        }

        private void FDrawRectangle(Pen mypen, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
            }
        }

        private void FFillRectangle(SolidBrush mybrush, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
            }
        }

        private void FDrawSquare(Pen mypen, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p1.X, p1.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p2.X, p2.Y, p1.X - p2.X, p1.X - p2.X);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p1.X, p2.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawRectangle(mypen, p2.X, p1.Y, p1.X - p2.X, p1.X - p2.X);
            }
        }

        private void FFillSquare(SolidBrush mybrush, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p1.X, p1.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p2.X, p2.Y, p1.X - p2.X, p1.X - p2.X);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p1.X, p2.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillRectangle(mybrush, p2.X, p1.Y, p1.X - p2.X, p1.X - p2.X);
            }
        }

        private void FDrawElipse(Pen mypen, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
            }
        }

        private void FFillElipse(SolidBrush mybrush, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
            }
        }

        private void FDrawCircle(Pen mypen, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p1.X, p1.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p2.X, p2.Y, p1.X - p2.X, p1.X - p2.X);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p1.X, p2.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.DrawEllipse(mypen, p2.X, p1.Y, p1.X - p2.X, p1.X - p2.X);
            }
        }

        private void FFillCircle(SolidBrush mybrush, Point p1, Point p2)
        {
            if (p1.X <= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p1.X, p1.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p2.X, p2.Y, p1.X - p2.X, p1.X - p2.X);
            }

            if (p1.X <= p2.X && p1.Y >= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p1.X, p2.Y, p2.X - p1.X, p2.X - p1.X);
            }

            if (p1.X >= p2.X && p1.Y <= p2.Y)
            {
                this.gp.FillEllipse(mybrush, p2.X, p1.Y, p1.X - p2.X, p1.X - p2.X);
            }
        }

        private void FDrawCurve(Pen mypen, Point p1, Point p2, Point p3)
        {
            Point[] p = { p1, p3, p2 };
            this.gp.DrawCurve(mypen, p);
        }

        private void FDrawPolygon(Pen mypen, Point[] p)
        {
            this.gp.DrawPolygon(mypen, p);
        }

        private void FFillPolygon(SolidBrush myBrush, Point[] p)
        {
            if (p.Length < 3)
            {
                Pen tempPen = new Pen(myBrush.Color);
                this.gp.DrawPolygon(tempPen, p);
            }
            else
            {
                this.gp.FillPolygon(myBrush, p);
            }
        }

        #endregion
    }
}