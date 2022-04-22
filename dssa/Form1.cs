using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dssa
{

    public partial class Form1 : Form
    {
        int size = 20;
        int width = 16;
        int height = 16;
        int SizeWH = 0;

        CordesSF Start = new CordesSF();
        CordesSF Finich = new CordesSF();
        Point UserMause = new Point(0, 0);
        Random rnd = new Random();
        Dictionary<string, ListProp> CordXY = new Dictionary<string, ListProp>();
        Dictionary<string, ListProp> CompliteCordXY = new Dictionary<string, ListProp>();
        CordesUserStep UserStep = new CordesUserStep();


        public Form1()
        {
            InitializeComponent();
        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

            SizeWH = 0;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    DrawBox2(i, j, Brushes.White, e.Graphics);



            /*            int x = rnd.Next(0, width);
                        int y = rnd.Next(0, height);*/
            int x = 0, y = 0;
            string sizeid = $"{x} {y}";
            CordXY.Add(sizeid, new ListProp() { x = x, y = y });
            Start.x = x;
            Start.y = y;
            int sizex= (x * size * 2) + size,sizey= (y * size * 2) + size;
            UserStep.Minx = size- sizex;
            UserStep.Maxx = sizex + size;

            UserStep.Miny = size- sizey;
            UserStep.Maxy = sizey + size;

            UserMause = new Point(sizex, sizey);



            while (SizeWH < width * height)
            {
                var checklist = CordXY.ToList();

                int randchecklist = rnd.Next(0, checklist.Count);
                DrawBox(checklist[randchecklist].Value.x, checklist[randchecklist].Value.y, Brushes.White, e.Graphics);
            }
            e.Graphics.FillRectangle(Brushes.Red, (Start.x * size * 2) + size, (Start.y * size * 2) + size, 20, 20);
            e.Graphics.FillRectangle(Brushes.Green, Finich.x , Finich.y, 20, 20);


        }

        void DrawBox(int x, int y, Brush br, Graphics gr)
        {
            string sizeid = $"{x} {y}";
            bool exit = false;
            while (exit != true)
            {
                Random rnd = new Random();
                int check = rnd.Next(0, CordXY[sizeid].direction.Count);
                switch (CordXY[sizeid].direction[check])
                {
                    case "left":
                        CordXY[sizeid].direction.Remove("left");

                        if (x - 1 >= 0 && !CompliteCordXY.ContainsKey($"{x * size * 2} {(y * size * 2) + size}") && !CordXY.ContainsKey($"{x - 1} {y}") && !CompliteCordXY.ContainsKey($"{((x - 1) * size * 2) + size} {(y * size * 2) + size}"))
                        {

                            CompliteCordXY.Add($"{x * size * 2} {(y * size * 2) + size}", new ListProp() { x = x * size * 2, y = y * size * 2 });
                            CordXY.Add($"{x - 1} {y}", new ListProp() { x = x - 1, y = y });
                            gr.FillRectangle(br, ((x - 1) * size * 2) + size, (y * size * 2) + size, 40, 20);
                            exit = true;
                        }
                        break;
                    case "rigth":
                        CordXY[sizeid].direction.Remove("rigth");

                        if (x + 1 < width && !CompliteCordXY.ContainsKey($"{(x * size * 2) + size * 2} {(y * size * 2) + size}") && !CordXY.ContainsKey($"{x + 1} {y}") && !CompliteCordXY.ContainsKey($"{((x + 1) * size * 2) + size} {(y * size * 2) + size}"))
                        {
                            CompliteCordXY.Add($"{(x * size * 2) + size * 2} {(y * size * 2) + size}", new ListProp() { x = (x * size * 2) + size * 2, y = y * size * 2 });
                            CordXY.Add($"{x + 1} {y}", new ListProp() { x = x + 1, y = y });
                            gr.FillRectangle(br, (x * size * 2) + size, (y * size * 2) + size, 40, 20);
                            exit = true;
                        }

                        break;
                    case "up":
                        CordXY[sizeid].direction.Remove("up");
                        if (y - 1 >= 0 && !CompliteCordXY.ContainsKey($"{(x * size * 2) + size} {y * size * 2}") && !CordXY.ContainsKey($"{x} {y - 1}") && !CompliteCordXY.ContainsKey($"{(x * size * 2) + size} {((y - 1) * size * 2) + size}"))
                        {
                            CompliteCordXY.Add($"{(x * size * 2) + size} {y * size * 2}", new ListProp() { x = (x * size * 2) + size, y = y * size * 2 });
                            CordXY.Add($"{x} {y - 1}", new ListProp() { x = x, y = (y - 1) });
                            gr.FillRectangle(br, (x * size * 2) + size, ((y - 1) * size * 2) + size, 20, 40);
                            exit = true;
                        }
                        break;
                    case "down":
                        CordXY[sizeid].direction.Remove("down");
                        if (y + 1 < height && !CompliteCordXY.ContainsKey($"{(x * size * 2) + size} {(y * size * 2) + size * 2}") && !CordXY.ContainsKey($"{x} {y + 1}") && !CompliteCordXY.ContainsKey($"{(x * size * 2) + size} {((y + 1) * size * 2) + size}"))
                        {
                            CompliteCordXY.Add($"{(x * size * 2) + size} {(y * size * 2) + size * 2}", new ListProp() { x = (x * size * 2) + size, y = (y * size * 2) + size * 2 });
                            CordXY.Add($"{x} {y + 1}", new ListProp() { x = x, y = (y + 1) });
                            gr.FillRectangle(br, (x * size * 2) + size, (y * size * 2) + size, 20, 40);
                            exit = true;
                        }
                        break;
                }

                if (CordXY[sizeid].direction.Count == 0)
                {
                    CordXY.Remove(sizeid);
                    CompliteCordXY.Add($"{(x * size * 2) + size} {(y * size * 2) + size}", new ListProp() { x = (x * size * 2) + size, y = (y * size * 2) + size });
                    SizeWH++;
                    Finich.x = (x * size * 2) + size;
                    Finich.y = (y * size * 2) + size;
                    exit = true;
                }
            }
        }
        void DrawBox2(int x, int y, Brush br, Graphics gr)
        {
            gr.FillRectangle(br, (x * size * 2) + size, (y * size * 2) + size, 20, 20);

        }





        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {


            double x = e.X - (e.X % 10);
            double y = e.Y - (e.Y % 10);

            if ((CompliteCordXY.ContainsKey($"{x} {y}") || 
                (CompliteCordXY.ContainsKey($"{x + 10} {y}") && CompliteCordXY.ContainsKey($"{x - 10} {y}")) || 
                (CompliteCordXY.ContainsKey($"{x} {y + 10}") && CompliteCordXY.ContainsKey($"{x} {y - 10}"))) &&
                (UserStep.Minx <= x & UserStep.Maxx >= x & UserStep.Miny <= y & UserStep.Maxy >= y))
            {
                
                textBox1.Text = "While";
                UserMause = new Point(e.X, e.Y);

                UserStep.Minx = size - x;
                UserStep.Maxx = x + size;

                UserStep.Miny = size - y;
                UserStep.Maxy = y + size;
                if(x==Finich.x && y==Finich.y)
                {
                    MessageBox.Show("You win");
                }


            }
            else
            {
                textBox1.Text = "Black";

                Cursor.Position = panel1.PointToScreen(new Point(UserMause.X, UserMause.Y));
            }
            if (CompliteCordXY.ContainsKey($"{x} {y}"))
                textBox2.Text = $"{x} {y}";
            else
                textBox2.Text = "";

            if (CompliteCordXY.ContainsKey($"{x + 10} {y}"))
                textBox3.Text = $"{x + 10} {y}";
            else
                textBox3.Text = "";

            if (CompliteCordXY.ContainsKey($"{x} {y + 10}"))
                textBox4.Text = $"{x} {y + 10}";
            else
                textBox4.Text = "";
            textBox5.Text = $"{e.X} {e.Y}";
            textBox7.Text = $"{UserStep.Minx<=x} {UserStep.Maxx>=x} {UserStep.Miny<=y} {UserStep.Maxy>=y}";
            textBox6.Text = $"{UserStep.Minx}<={x} {UserStep.Maxx}>={x} {UserStep.Miny}<={y} {UserStep.Maxy}>={y}";
            textBox8.Text = $"{x} == {Finich.x} && {y} == {Finich.y}";





        }


        /*        private void panel1_Click(object sender, EventArgs e)
                {
                    if (builded)
                    {
                        // выбираем начальную точку стартовой
                        currentCell = new Point(1, 1);


                }
                    builded = true;
                    panel3.Invalidate();
                }
        */

    }
    public class ListProp
    {
        public int x;
        public int y;
        public List<string> direction = new List<string>() { "left", "rigth", "up", "down" };
    }
    public class CordesSF
    {
        public int x;
        public int y;
    }
    public class CordesUserStep
    {
        public double Minx;
        public double Maxx;

        public double Miny;
        public double Maxy;

    }
}



