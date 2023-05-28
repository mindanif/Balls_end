using Balls_end;
using System.Text;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public partial class Form1 : Form
    {
        private Painter p;
        private Database db;
        Point click;
        private int id = 0;
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            p = new Painter(mainPanel.CreateGraphics());
            p.Start();
            db = new Database("localhost", "postgres", "dkz777000777", "db_circles", true);
            form2 = new Form2();
            form2.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<(int rectangleId, int score)> scores = db.get_score();

            StringBuilder sb = new StringBuilder();

            foreach (var score in scores)
            {
                sb.AppendLine($"Rectangle ID: {score.rectangleId}, Score: {score.score}");
            }
            

            form2.show_string(sb.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Stop();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            if (p != null)
            {
                p.MainGraphics = mainPanel.CreateGraphics();
            }
        }

        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            click = e.Location;
            id++;
            p.AddNew(click.X, click.Y, id, db);
        }

    }
}