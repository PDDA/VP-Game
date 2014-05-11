using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TheGame.Properties;

namespace TheGame
{
    public partial class Form1 : Form
    {
        public Point[,] matrica { get; set; }
        Point pocetna;
        Point tocka;
        public int size { get; set; }
        public int size2 { get; set; }
        public bool imaCekan { get; set; }
        public int coveceX { get; set; }
        public int coveceY { get; set; }
        public MazeGenerator Maze { get; set; }
        public Point portalBlueLocation { get; set; }
        public Point portalOrangeLocation { get; set; }
        public Point hammerLocation { get; set; }
        public Point CharacterLocation { get; set; }
        public Point tockaTajmer1 { get; set; }
        public Point tockaTajmer2 { get; set; }
        public List<Label> lista { get; set; }
        Random random;
        Timer timer;
        public int sekundi { get; set; }
        public MusicPlayer player { get; set; }
        public Point FINISH { get; set; }
        public Point MagickPotion { get; set; }
        public bool diskoFlag { get; set; }
        public int countLevel { get; set; }

        private static readonly int TOTAL = 300;

        public Form1()
        {
            InitializeComponent();
            startMenu();
        }

        public void startMenu()
        {
            lista = new List<Label>();
            hammerLocation = new Point();
            setVisibility();
            countLevel = 0;
            int br = 0;
            for (int i = 19; i < 42; i = i + 2)
            {
                for (int j = 19; j < 72; j = j + 2)
                {
                    comboBox1.Items.Insert(br, i.ToString() + "X" + j.ToString());
                    br++;
                }
            }
        }

        private void setVisibility()
        {
            mainMenu.Visible = false;
            plav.Visible = false;
            portokalov.Visible = false;
            vreme.Visible = false;
            level.Visible = false;
            covece.Visible = false;
            cel.Visible = false;
            cekan.Visible = false;
            napivka.Visible = false;
            pbTimer1.Visible = false;
            pbTimer2.Visible = false; 
            imaCekan = false;
            napivka.Visible = false;
        }

        private void newGame(int golemina1, int golemina2, int sekRemaining)
        {

            countLevel++;
            this.KeyPreview = true;
            level.Text = String.Format("Level {0}", countLevel);
            imaCekan = false;
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            if (lista.Count > 0)
            {
                foreach (Label lab in lista)
                {
                    this.Controls.Remove(lab);
                    lab.Dispose();
                }
                lista.Clear();
            }
            
            this.BackgroundImage = null;
            chooseSize.Visible = false;
            novaIgra.Visible = false;
            rules.Visible = false;
            practice.Visible = false;
            comboBox1.Visible = false;
            mainMenu.Visible = true;
            plav.Visible = true;
            napivka.Visible = true;
            portokalov.Visible = true;
            vreme.Visible = true;
            level.Visible = true;
            covece.Visible = true;
            cel.Visible = true;
            cekan.Visible = true;
            pbTimer1.Visible = true;
            pbTimer2.Visible = true; 
            imaCekan = false ;
            player = new MusicPlayer();
            player.stop();
            player.open("C:\\Users\\Ata\\Desktop\\pesna.mp3");
            player.play();
            diskoFlag = false;
            random = new Random();
            lista = new List<Label>();
            timer = new Timer();
            timer.Interval = 1000;
            if ((TOTAL - sekRemaining) % 60 < 10)
            {
                vreme.Text = String.Format("0{0}:0{1}", (TOTAL - sekRemaining) / 60, (TOTAL - sekRemaining) % 60);
            }
            else {
                vreme.Text = String.Format("0{0}:{1}", (TOTAL - sekRemaining) / 60, (TOTAL - sekRemaining) % 60);
            }
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            size = golemina1;
            size2 = golemina2;
            this.Size = new Size((size2 * 15 + 100), (size * 15 + 100));
            matrica = new Point[size, size2];
            tocka = new Point(25, 35);
            pocetna = new Point(25, 35);
            coveceX = 2;
            coveceY = 2;
            CharacterLocation = matrica[2, 2];
            Maze = new MazeGenerator(size, size2);
            LocationsOnMaze();
            mazeDraw();
            finishLine();
            covece.Location = matrica[2, 2];
            loadElements();
        }


        private void finish()
        {
            if (CharacterLocation == FINISH)
            {
                bool flag = true;
                if (size == 39 && size2 == 59)
                {
                    flag = false;
                    timer.Stop();
                    Kraj k = new Kraj();
                    DialogResult kres = k.ShowDialog();
                    if (kres == System.Windows.Forms.DialogResult.Cancel) {
                        backToMenu();
                        startMenu();
                    }
                }
                if (flag)
                newGame(size + 2, size2 + 4, sekundi);
            }
        }

        //Postavuvanje cel
        private void finishLine()
        {
            while (true)
            {
                Point krajnaCel = new Point(random.Next(2, size - 2), random.Next(size2 - 7, size2 - 2));

                if (Maze.maze[krajnaCel.X, krajnaCel.Y] == 0)
                {
                    cel.Location = matrica[krajnaCel.X, krajnaCel.Y];
                    FINISH = cel.Location;
                    break;
                }
            }
        }

        //Tajmer
        void timer_Tick(object sender, EventArgs e)
        {
            sekundi++;
            if ((TOTAL - sekundi) % 60 < 10)
            {
                vreme.Text = String.Format("0{0}:0{1}", (TOTAL - sekundi) / 60, (TOTAL - sekundi) % 60);
            }
            else
            {
                vreme.Text = String.Format("0{0}:{1}", (TOTAL - sekundi) / 60, (TOTAL - sekundi) % 60);
            }
            if (diskoFlag)
                disko();
            else
            {
                if ((TOTAL - sekundi) >= 60)
                    semfor(Color.Green);
                else if ((TOTAL - sekundi) < 60 && (TOTAL - sekundi) >= 20)
                    semfor(Color.YellowGreen);
                else
                    semfor(Color.Firebrick);
            }

            if (sekundi % 5 == 0)
            {
                diskoFlag = false;
                plav.Visible = true;
                portokalov.Visible = true;
                napivka.Visible = true;
                pbTimer1.Visible = true;
                pbTimer2.Visible = true;
                loadElements();
            }
            if (sekundi == TOTAL)
            {
                timer.Stop();
                Izgubi iz = new Izgubi();
                DialogResult rez = iz.ShowDialog();
                if (rez == System.Windows.Forms.DialogResult.Cancel) {
                    backToMenu();
                    startMenu();
                }
            }
        }

        //Postavuvanje portali
        private void loadElements()
        {
            while (true)
            {
                Point portal1 = new Point(random.Next(2, size - 2), random.Next(2, size2 - 2));
                Point portal2 = new Point(random.Next(2, size - 2), random.Next(2, size2 - 2));
                Point hammer = new Point(random.Next(2, size - 2), random.Next(2, size2 - 2));
                Point magic_potion = new Point(random.Next(2, size - 2), random.Next(2, size2 - 2));
                tockaTajmer1 = new Point(random.Next(2, size - 2), random.Next(2, size2 - 2));
                tockaTajmer2 = new Point(random.Next(2, size - 2), random.Next(2, size2 - 2));

                if (Maze.maze[portal1.X, portal1.Y] == 0 && Maze.maze[portal2.X, portal2.Y] == 0 && Maze.maze[hammer.X, hammer.Y] == 0
                    && Maze.maze[magic_potion.X, magic_potion.Y] == 0 && Maze.maze[tockaTajmer1.X, tockaTajmer1.Y] == 0 && Maze.maze[tockaTajmer2.X, tockaTajmer2.Y] == 0)
                {
                    plav.Location = matrica[portal1.X, portal1.Y];
                    portalBlueLocation = plav.Location;
                    portokalov.Location = matrica[portal2.X, portal2.Y];
                    portalOrangeLocation = portokalov.Location;
                    cekan.Location = matrica[hammer.X, hammer.Y];
                    hammerLocation = cekan.Location;
                    napivka.Location = matrica[magic_potion.X, magic_potion.Y];
                    MagickPotion = napivka.Location;
                    pbTimer1.Location = matrica[tockaTajmer1.X, tockaTajmer1.Y];
                    tockaTajmer1 = pbTimer1.Location;
                    pbTimer2.Location = matrica[tockaTajmer2.X, tockaTajmer2.Y];
                    tockaTajmer2 = pbTimer2.Location;
                    break;
                }
            }
        }

        //Menuvanje na boite na dzidovite vo zavisnost od vremeto preostanato
        private void semfor(Color boja)
        {
            foreach (Label lab in lista)
            {
                lab.BackColor = boja;
            }
        }

        //Disko
        private void disko()
        {
            foreach (Label lab in lista)
            {
                int min = 0;
                int max = 255;
                int rand1 = random.Next(min, max);
                int rand2 = random.Next(min, max);
                int rand3 = random.Next(min, max);
                Color myColor = Color.FromArgb(rand1, rand2, rand3);
                lab.BackColor = myColor;
            }
        }

        //Teleportiranje od eden vo drug Portal
        private void Teleport()
        {
            if (CharacterLocation == hammerLocation)
            {
                imaCekan = true;
                cekan.Visible = false;
            }
            if (CharacterLocation == tockaTajmer1)
            {
                pbTimer1.Visible = false;
                sekundi -= 10;
            }
            if (CharacterLocation == tockaTajmer2)
            {
                pbTimer2.Visible = false;
                sekundi -= 10;
            }
            if (CharacterLocation == portalBlueLocation)
            {
                CharacterLocation = portalOrangeLocation;
                portokalov.Visible = false;
                coveceY = ((CharacterLocation.X - 25) / 15);
                coveceX = ((CharacterLocation.Y - 35) / 15);
                covece.Location = matrica[coveceX, coveceY];
            }
            else if (CharacterLocation == portalOrangeLocation)
            {
                CharacterLocation = portalBlueLocation;
                plav.Visible = false;
                coveceY = ((CharacterLocation.X - 25) / 15);
                coveceX = ((CharacterLocation.Y - 35) / 15);
                covece.Location = matrica[coveceX, coveceY];
            }
        }

        private void ActivateMagic()
        {
            if (CharacterLocation == MagickPotion)
            {
                diskoFlag = true;
                napivka.Visible = false;
                disko();
            }
        }

        //Matrica so lokacii vo lavirintot
        private void LocationsOnMaze()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    matrica[i, j] = tocka;
                    tocka = new Point(tocka.X + 15, tocka.Y);
                }
                tocka = new Point(pocetna.X, tocka.Y + 15);
            }
        }

        private void isClicked (System.Object sender, EventArgs e) { 
            Control lab = (Control)sender;
            if (imaCekan) {
                lab.Visible = false;
                Maze.maze[(lab.Location.Y - 35) / 15, (lab.Location.X - 25) / 15] = 0;
                imaCekan = false;
            }
        }

        //Iscrtuvanje na lavirintot
        private void mazeDraw()
        {
            for (int i = 0; i < Maze.size; i++)
            {
                for (int j = 0; j < Maze.size2; j++)
                {
                    if (Maze.maze[i, j] == 1)
                    {
                        Label lab = new Label();
                        lab.AutoSize = false;
                        lab.Text = "";
                        lab.Location = matrica[i,j];
                        lab.Size = new Size(15, 15);

                        if ((TOTAL - sekundi) >= 60)
                            lab.BackColor = Color.Green;
                        else if ((TOTAL - sekundi) < 60 && (TOTAL - sekundi) >= 20)
                            lab.BackColor = Color.YellowGreen;
                        else
                            lab.BackColor = Color.Green;

                        lab.Visible = true;
                        lab.Click += new System.EventHandler(this.isClicked);
                        this.Controls.Add(lab);
                        lista.Add(lab);
                    }
                }
            }
        }

        //Dvizenje na Coveceto
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (Maze.maze[coveceX - 1, coveceY] == 0)
                {
                   coveceX -= 1;
                   CharacterLocation = covece.Location = matrica[coveceX, coveceY];
                   finish();
                   Teleport();
                   ActivateMagic();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (Maze.maze[coveceX + 1, coveceY] == 0)
                {
                    coveceX += 1;
                    CharacterLocation = covece.Location = matrica[coveceX, coveceY];
                    finish();
                    Teleport();
                    ActivateMagic();
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (Maze.maze[coveceX, coveceY - 1] == 0)
                {
                    coveceY -= 1;
                    CharacterLocation = covece.Location = matrica[coveceX, coveceY];
                    finish();
                    Teleport();
                    ActivateMagic();
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (Maze.maze[coveceX, coveceY + 1] == 0)
                {
                    coveceY += 1;
                    CharacterLocation = covece.Location = matrica[coveceX, coveceY];
                    finish();
                    Teleport();
                    ActivateMagic();
                }
            }
            if (CharacterLocation != portalBlueLocation) {
                plav.Visible = true;
            }
            if (CharacterLocation != portalOrangeLocation)
            {
                portokalov.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            newGame(21, 23, sekundi);
        }
            
        private void novaIgra_MouseLeave(object sender, EventArgs e)
        {
            novaIgra.ForeColor = Color.Black;
        }

        private void practice_MouseEnter(object sender, EventArgs e)
        {
            practice.ForeColor = Color.White;
        }

        private void practice_MouseLeave(object sender, EventArgs e)
        {
            practice.ForeColor = Color.Black;
        }

        private void novaIgra_MouseEnter(object sender, EventArgs e)
        {
            novaIgra.ForeColor = Color.White;
        }

        private void rules_MouseEnter(object sender, EventArgs e)
        {
            rules.ForeColor = Color.White;
        }

        private void rules_MouseLeave(object sender, EventArgs e)
        {
            rules.ForeColor = Color.Black;
        }

        private void practice_Click(object sender, EventArgs e)
        {

            plav.Visible = true;
            portokalov.Visible = true;
            vreme.Visible = true;
            covece.Visible = true;
            cel.Visible = true;
            cekan.Visible = true;
            imaCekan = true;
            if (comboBox1.SelectedItem != null)
            {
                String golemina = (String)comboBox1.SelectedItem;
                int red = int.Parse(golemina.Substring(0, 2));
                int kol = int.Parse(golemina.Substring(3));
                newGame(red, kol, sekundi);
            }
            else
                newGame(19, 19, sekundi);
        }

        private void rules_Click(object sender, EventArgs e)
        {
            Pravila pravila = new Pravila();
            pravila.Show();
        }


        public void backToMenu()
        {
            sekundi = 0;
            novaIgra.Visible = true;
            chooseSize.Visible = true;
            rules.Visible = true;
            practice.Visible = true;
            comboBox1.Visible = true;
            setVisibility();
            if (lista.Count > 0)
            {
                foreach (Label lab in lista)
                {
                    this.Controls.Remove(lab);
                    lab.Dispose();
                }
                lista.Clear();
            }
            timer.Stop();
            this.BackgroundImage = Properties.Resources.pozadinaFinal;
            this.Size = new Size(864, 569);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void mainMenu_MouseClick(object sender, MouseEventArgs e)
        {
            backToMenu();
            startMenu();
            countLevel = 0;
        }

        private void mainMenu_MouseEnter(object sender, EventArgs e)
        {
            mainMenu.ForeColor = Color.White;

        }

        private void mainMenu_MouseLeave(object sender, EventArgs e)
        {
            mainMenu.ForeColor = Color.Black;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.White;
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.Black;
        }
    }
}
