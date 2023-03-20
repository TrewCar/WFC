public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        g = Graphics.FromImage(pictureBox1.Image);
    }
    Graphics g;
    bool Draw = false;
    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (Draw)
        {
            Point pos = new Point(e.X / 5, e.Y / 5);
            g.FillRectangle(new SolidBrush(pen), pos.X * 5, pos.Y * 5, 5, 5);
            pictureBox1.Invalidate();
            
        }
    }

    private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        Draw = true;
        UpdatePicture = false;
    }
    Color pen = Color.FromArgb(50, 50, 50);
    private void Button1_Click(object sender, EventArgs e)
    {
        pen = Color.FromArgb(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text));
    }
    private bool UpdatePicture = false;
    private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        Draw = false;
        UpdatePicture = false;
    }
    List<Tile> Tiles;
    private void Button2_Click(object sender, EventArgs e)
    {
        Bitmap pic;
        int i = 0;
        while (true)
        {
            i++;
            if (i >= 1000)
            {
                MessageBox.Show("Не получилось");
                break;
            }
            try
            {
                if (!UpdatePicture)
                {
                    Tiles = CreateGrid.CreateTile((Bitmap)pictureBox1.Image);
                }
                var t = new WFC(Tiles, pictureBox2.Width, pictureBox2.Height);
                pic = t.CreateIMG();
                pictureBox2.Image = pic;
                pictureBox2.Invalidate();
                break;
            }
            catch
            {
                continue;
            }
        }
        UpdatePicture = true;
    }
}
