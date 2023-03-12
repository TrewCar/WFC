
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        Graphics g = Graphics.FromImage(pictureBox1.Image);
        //g.FillRectangle(Brushes.Black, 0, 0, 5, 5);
        g.FillRectangle(Brushes.Blue, 0, 0, 5, 5);
        g.FillRectangle(Brushes.Blue, 0, 5, 5, 5);
        g.FillRectangle(Brushes.Red, 0, 10, 5, 5);

        g.FillRectangle(Brushes.Blue, 0, 0+100, 5, 5);
        g.FillRectangle(Brushes.Blue, 0, 5+100, 5, 5);
        var t = CreateGrid.CreateGri((Bitmap)pictureBox1.Image);
    }
}
