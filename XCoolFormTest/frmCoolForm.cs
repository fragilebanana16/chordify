using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Collections.Specialized;

namespace XCoolFormTest
{
    public partial class frmCoolForm : XCoolForm.XCoolForm
    {
        private XmlThemeLoader xtl = new XmlThemeLoader();

        const int verticalInterval = 20;
        const int horizonalInterval = 50;
        const int offsetX = 30;
        const int offsetY = 30;
        const int width = 150;
        static string[] mediaExtensions = {
            ".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", //etc
            ".WAV", ".MID", ".MIDI", ".WMA", ".MP3", ".OGG", ".RMA", //etc
            ".AVI", ".MP4", ".DIVX", ".WMV", //etc
        };

        
        private double trackBarPos;
        int curr;
        private MP3Player mp3Player;


        List<Chord> songChord = new List<Chord>();
        // Chord Cmajor = new Chord(new String[] { "1", "9", "16" }, 0);
        public frmCoolForm() : base()
        {
            InitializeComponent();

            string[] chordsUsed = new String[] { "C", "Gm", "#Fm", "B" };
            List<string[]> chordsEle = getChordEle(chordsUsed);
            int chordIndex = 0;
            foreach (string[] c in chordsEle)
            {
                // [WOW] use ArraySegment<T> to take a slice of an array
                songChord.Add(new Chord(chordsUsed[chordIndex], new ArraySegment<string>(c, 1, c.Count() - 1).ToArray(), int.Parse(c[0])));
                chordIndex++;
            }
            mp3Player = new MP3Player(musicList);
        }

        private void frmCoolForm_Load(object sender, EventArgs e)
        {
            this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.predator_256x256;
            this.MenuIcon = XCoolFormTest.Properties.Resources.alien_vs_predator_3_48x48.GetThumbnailImage(24, 24, null, IntPtr.Zero);

            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.disc_predator_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Blue Winter"));
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.alien_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Dark System"));
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.alien_egg_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Animal Kingdom"));
            this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(XCoolFormTest.Properties.Resources.predator_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Valentine"));

           
            this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.disc_predator_48x48;
            this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.alien_48x48;
            this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.alien_egg_48x48;
            this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.predator_48x48;

            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
            this.StatusBar.EllipticalGlow = false;
            
            this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
            xtl.ThemeForm = this;
            

        }

        private void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.candy_cane;
                    this.TitleBar.TitleBarCaption = "Blue Winter Theme";
                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.AdvancedRendering;
                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rounded;

                    this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.FullFill;
                    this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.FullFill;
                    this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.FullFill;

                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.xmas_tree.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.xmas_decoration_green.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.xmas_decoration_red_.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.snowman.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                 
                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.xmas_tree;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.xmas_decoration_green;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.xmas_decoration_red_;
                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.snowmansmall;
                    this.MenuIcon = XCoolFormTest.Properties.Resources.Snowman1.GetThumbnailImage(30, 30, null, IntPtr.Zero);

                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.snowman.GetThumbnailImage(80, 80, null, IntPtr.Zero); ;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Right;

                    this.StatusBar.BarItems[1].BarItemText = "Snow level: 0.5 m";
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\BlueWinterTheme.xml"));
                    break;
                case 1:
                    this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.X3D;
                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rounded;
                    this.TitleBar.TitleBarCaption = "Dark System Theme";

                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.AdvancedRendering;

                    this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.UpperGlow;
                    this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.UpperGlow;
                    this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.UpperGlow;

                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.Quake_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.Quake_III_Arena_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.Quake_IV_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.Quake_II_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_48x48;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_III_Arena_48x48;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_IV_48x48;
                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.Quake_II_48x48;

                    this.MenuIcon = XCoolFormTest.Properties.Resources.GDI_256x256.GetThumbnailImage(30, 25, null, IntPtr.Zero);
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.Quake_IV;

                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.Quake_256x256;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;
                    this.StatusBar.BarItems[1].BarItemText = "Date: 12/12/2045";
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\DarkSystemTheme.xml"));
                    break;
                case 2:
                    this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.Mammooth_1;
                    this.TitleBar.TitleBarCaption = "Animal Kingdom Theme";

                    this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
                    this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
                    this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;

                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Angular;
                    this.MenuIcon = XCoolFormTest.Properties.Resources.Mammooth_128x128.GetThumbnailImage(30, 30, null, IntPtr.Zero);
                    this.StatusBar.EllipticalGlow = false;

                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.UpperGlow;

                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.Funshine_Bear_1;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;

                    this.StatusBar.BarItems[1].BarItemText = "Place: Madagascar";
                    this.StatusBar.BarItems[1].ItemTextAlign = StringAlignment.Center;
                    
                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.cow_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.bird_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.panda_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.penguine_32.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.cow_32;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.bird_32;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.panda_32;
                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.penguine_32;
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\AnimalKingdomTheme.xml"));
                    break;
                case 3:
                    this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.X3D;
                    this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Rectangular;
                    this.TitleBar.TitleBarCaption = "Valentine Theme";
                    
                    this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.LinearRendering;
                    
                    this.TitleBar.TitleBarBackImage = XCoolFormTest.Properties.Resources.heart_valentine_128x128;
                    this.StatusBar.EllipticalGlow = false;
                    
                    this.StatusBar.BarBackImage = XCoolFormTest.Properties.Resources.paisley_6_48x48;
                    this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Center;
                    this.StatusBar.BarItems[1].BarItemText = "Hearts left: 4";
                    this.MenuIcon = XCoolFormTest.Properties.Resources.purple_flower_48x48.GetThumbnailImage(30, 30, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[0].ButtonImage = XCoolFormTest.Properties.Resources.butterfly_pink_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[1].ButtonImage = XCoolFormTest.Properties.Resources.butterfly_purple_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[2].ButtonImage = XCoolFormTest.Properties.Resources.lotus_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    this.IconHolder.HolderButtons[3].ButtonImage = XCoolFormTest.Properties.Resources.symbol_48x48.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                    this.IconHolder.HolderButtons[0].FrameBackImage = XCoolFormTest.Properties.Resources.butterfly_pink_48x48;
                    this.IconHolder.HolderButtons[1].FrameBackImage = XCoolFormTest.Properties.Resources.butterfly_purple_48x48;
                    this.IconHolder.HolderButtons[2].FrameBackImage = XCoolFormTest.Properties.Resources.lotus_48x48;
                    this.IconHolder.HolderButtons[3].FrameBackImage = XCoolFormTest.Properties.Resources.symbol_48x48;
                    xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"..\..\Themes\ValentineTheme.xml"));
                    break;
            }

        }
        public List<string[]> getChordEle(string[] keys)
        {
            List<string[]> chordsEleList = new List<string[]>();
            foreach(string k in keys)
            {
                string sAttr;
                sAttr = ConfigurationManager.AppSettings.Get(k);
                string[] splitedAttr = sAttr.Split(',');
                chordsEleList.Add(splitedAttr);
                
            }
            foreach (string[] i in chordsEleList)
            {
                Console.WriteLine("sAttr:{0}", string.Join(",", i));

            }
            return chordsEleList;
        }

        
      
        private void drawArrow(Point start, Point end, Graphics g, Pen apen)
        {
            const int arrowEdge = 8;
            g.DrawLine(apen, start, end);
            g.DrawLine(apen, new Point(end.X + arrowEdge, end.Y + arrowEdge), end);
            g.DrawLine(apen, new Point(end.X - arrowEdge, end.Y + arrowEdge), end);
        }

        private void drawChordName(string txt, Point txtPos, Graphics g, Pen apen, Font fnt)
        {
            g.DrawString(txt, fnt, new SolidBrush(Color.Black), txtPos.X, txtPos.Y);
        }
        private void drawSingleGrid(Graphics g, int chordIndex, Chord chord)
        {
            Point[] ptsLeft = new Point[6];
            Point[] ptsRight = new Point[6];
            Point[] plcPts = getPlaceCoords(ptsLeft, ptsRight);

            Pen pn = new Pen(Color.Black, 2);
            Font fnt = new Font("Verdana", 14);
            Pen pnSolid = new Pen(Color.Black, 4);
            Pen pnMid = new Pen(Color.Black, (float)2.5);
            const int interval = 50;
            int offsetChordInterval = interval * chordIndex;

            int finalOffset = width * chordIndex + offsetChordInterval;
            // draw grid: 1st string to 6th string
            for (int i = 0; i <= ptsLeft.Length - 1; i++)
            {
                g.DrawLine(pn, new Point(ptsLeft[i].X + finalOffset, ptsLeft[i].Y), new Point(ptsRight[i].X + finalOffset, ptsRight[i].Y));
            }
            // draw grid: margins
            g.DrawLine(pn, new Point(ptsLeft[0].X + finalOffset, ptsLeft[0].Y), new Point(ptsLeft[5].X + finalOffset, ptsLeft[5].Y));
            g.DrawLine(pn, new Point(ptsRight[0].X + finalOffset, ptsRight[0].Y), new Point(ptsRight[5].X + finalOffset, ptsRight[5].Y));

            // draw grid: 1fret-3fret seperators
            g.DrawLine(pn, new Point(horizonalInterval + offsetX + finalOffset, 0 + offsetY), new Point(horizonalInterval + offsetX + finalOffset, 100 + offsetY));
            g.DrawLine(pn, new Point(horizonalInterval * 2 + offsetX + finalOffset, 0 + offsetY), new Point(horizonalInterval * 2 + offsetX + finalOffset, 100 + offsetY));
            
            // draw capo
            g.DrawString(chord.capo.ToString(), fnt, new SolidBrush(Color.Black), offsetX - 5 + finalOffset, offsetY - 24);

       
            // draw chord points
           
            int lastX = -1;
            int sameXCounter = 0;
            if (chord.plcPtPos.Count > 5)
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (plcPts[(int)chord.plcPtPos[i]].X == lastX)
                    {
                        sameXCounter++;
                    }
                    lastX = plcPts[(int)chord.plcPtPos[i]].X;
                }
            }
            int startX;
            startX = sameXCounter == 5 ? sameXCounter + 1 : 0;
            for (int i = startX; i <= chord.plcPtPos.Count - 1; i++)
            {
                Rectangle rectTemp = new Rectangle(plcPts[(int)chord.plcPtPos[i]].X + finalOffset, plcPts[(int)chord.plcPtPos[i]].Y, 4, 4);
                g.DrawEllipse(pnSolid, rectTemp);
                //g.DrawString(string.Format("{0},{1}", plcPts[(int)chord.plcPtPos[i]].X + finalOffset, plcPts[(int)chord.plcPtPos[i]].Y), fnt, new SolidBrush(Color.Black), plcPts[(int)chord.plcPtPos[i]].X + finalOffset, plcPts[(int)chord.plcPtPos[i]].Y);
            }
            if (sameXCounter == 5)
            {
                drawArrow(new Point(plcPts[(int)chord.plcPtPos[5]].X + finalOffset, plcPts[(int)chord.plcPtPos[5]].Y), new Point(plcPts[(int)chord.plcPtPos[0]].X + finalOffset, plcPts[(int)chord.plcPtPos[0]].Y), g, pnMid);
              
                //g.DrawString(string.Format("{0},{1}", plcPts[(int)chord.plcPtPos[5]].X + finalOffset, plcPts[(int)chord.plcPtPos[5]].Y), fnt, new SolidBrush(Color.Red), plcPts[(int)chord.plcPtPos[5]].X + finalOffset + 80, plcPts[(int)chord.plcPtPos[5]].Y);
                //g.DrawString(string.Format("{0},{1}", plcPts[(int)chord.plcPtPos[0]].X + finalOffset, plcPts[(int)chord.plcPtPos[0]].Y), fnt, new SolidBrush(Color.Red), plcPts[(int)chord.plcPtPos[0]].X + finalOffset + 80, plcPts[(int)chord.plcPtPos[0]].Y);
            }

            // draw chord text


            drawChordName(chord.chordName, new Point((int)((double)horizonalInterval * (4 * (double)chordIndex + 1)) + offsetX, offsetY + verticalInterval * 5), g, pnMid, fnt);
            /*
            // draw all points 
            Pen pnSolid = new Pen(Color.Black, 5);  
            for (int i = 0; i <= plcPts.Length - 1; i++)
            {
                Rectangle rectTemp = new Rectangle(plcPts[i].X, plcPts[i].Y, 4, 4);
                g.DrawEllipse(pnSolid, rectTemp);
            }
            */
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        static private Point[] getPlaceCoords(Point[] ptsLeft, Point[] ptsRight)
        {
            Point[] placePts = new Point[18];
            for (int i = 0; i <= ptsLeft.Length - 1; i++)
            {
                ptsLeft[i] = new Point(offsetX, offsetY + verticalInterval * i);
                ptsRight[i] = new Point(offsetX + width, offsetY + verticalInterval * i);
            }
            // col first index 0-17 coords
            for (int j = 1; j <= 3; j++)
            {
                for (int i = 0; i <= ptsLeft.Length - 1; i++)
                {
                    placePts[(j - 1) * ptsLeft.Length + i] = new Point(ptsLeft[i].X + horizonalInterval * j - (horizonalInterval / 2) - 2, ptsLeft[i].Y - 2);
                }
            }
            return placePts;
        }

   

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Mp3 Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    mp3Player.Open(ofd.FileName);
                }
            }
            /*OpenFileDialog open = new OpenFileDialog();     
            open.Filter = "ÒôÆµÎÄ¼þ(*.mp3)|*.mp3";      
            if (open.ShowDialog() == DialogResult.OK)
            {
                max = 0.0;
                min = 0.0;
                bal = 0.0;
                trackBar1.Value = 0;
                axWindowsMediaPlayer1.URL = open.FileName;      
                musicList.Items.Add(open.FileName);    
                musicList.SelectedIndex = musicList.Items.Count - 1;    
                timer1.Enabled = true;  
            }*/
        }
      

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            mp3Player.Play(0);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
           
            mp3Player.Pause();
              
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mp3Player.IsPlaying())
            {
                curr = mp3Player.GetCurentMilisecond();

                trackBarPos = (double)curr / (double)mp3Player.musicLength;
                Console.WriteLine("curr / mp3Player.musicLength  : {0}/{1}", curr, mp3Player.musicLength);
                trackBar1.Value = (int)(trackBarPos * 10000);
                Console.WriteLine("trackBar1  : {0}", trackBar1.Value);
            }
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < songChord.Count; i++)
            {
                drawSingleGrid(g, i, songChord[i]);
            }
        }

     

    
        class Chord
        {
            public ArrayList plcPtPos = new ArrayList();
            public int capo = 0;
            public string chordName;
            public Chord(string chordName, String[] indexPos, int capo)
            {
                this.capo = capo;
                this.chordName = chordName;
                foreach (String i in indexPos)
                {
                    plcPtPos.Add(int.Parse(i));
                }
            }

            public void drawPts()
            {
                foreach (int i in plcPtPos)
                {
                    Console.WriteLine("{0}", i);
                }

            }


        }

        class MP3Player
        {
            Random randomNumber;
            public bool resumeFlag = false;
            public bool pauseFlag = true;
            private StringBuilder msg;  // MCI Error message
            private StringBuilder returnData;  // MCI return data
            private int error;
            private string Pcommand;  // String that holds the MCI command
            private ListBox playlist;  // ListView as a playlist with the song path

            public int musicLength;
            public int NowPlaying { get; set; }
            public bool Paused { get; set; }
            public bool Loop { get; set; }
            public bool Shuffle { get; set; }

            [DllImport("winmm.dll")]
            private static extern int mciSendString(string strCommand,
                    StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
            [DllImport("winmm.dll")]
            public static extern int mciGetErrorString(int errCode,
                          StringBuilder errMsg, int buflen);

            public MP3Player(ListBox pl)
            {
                randomNumber = new Random();
                playlist = pl;
                NowPlaying = 0;
                Loop = false;
                Shuffle = true;
                Paused = false;
                msg = new StringBuilder(128);
                returnData = new StringBuilder(128);
                musicLength = 0;
            }

            public void Close()
            {
                Pcommand = "close MediaFile";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }


            public bool Open(string sFileName)
            {
                Close();

                // Let MCI deside which file type the song is
                Pcommand = "open \"" + sFileName +
                           "\" alias MediaFile";
                error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                //Pcommand = "play MediaFile";
                //error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                if (error == 0)
                {
                    playlist.Items.Add(sFileName);

                    Pcommand = "play MediaFile";
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    this.musicLength = GetSongLenght();
                    Console.WriteLine("this.musicLength :{0}", this.musicLength);
                    //Console.WriteLine("{0}", playlist.Items[0].SubItems[0].Text);



                    return true;

                }

                else
                    return false;

            }

            public bool Play(int track)
            {

                if (playlist.Items[track] != null)
                {
                    //int musicLength = GetSongLenght();
                    Console.WriteLine("musicLength is {0}", musicLength);
                    Pcommand = "play MediaFile";
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    if (error == 0)
                    {
                        NowPlaying = track;
                        return true;
                    }
                    else
                    {
                        Close();
                        return false;
                    }
                }
                else
                    return false;
            }
            public void Pause()
            {
                if (Paused)
                {
                    Resume();
                    Paused = false;
                }
                else if (IsPlaying())
                {
                    Pcommand = "pause MediaFile";
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    Paused = true;
                }
            }

            public void Stop()
            {
                Pcommand = "stop MediaFile";
                error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                Paused = false;
                Close();
            }

            public void Resume()
            {
                Pcommand = "resume MediaFile";
                error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }

            public bool IsPlaying()
            {
                Pcommand = "status MediaFile mode";
                error = mciSendString(Pcommand, returnData, 128, IntPtr.Zero);
                Console.WriteLine("return data is {0}", returnData.ToString());
                if (returnData.Length == 7 &&
                          returnData.ToString().Substring(0, 7) == "playing")
                    return true;
                else
                    return false;
            }
            public int GetCurentMilisecond()
            {
                Pcommand = "status MediaFile position";
                error = mciSendString(Pcommand, returnData,
                                      returnData.Capacity, IntPtr.Zero);
                //Console.WriteLine("get curr : {0}", returnData.ToString());
                return int.Parse(returnData.ToString());
            }

            public void SetPosition(int miliseconds)
            {
                if (IsPlaying())
                {
                    Pcommand = "play MediaFile from " + miliseconds.ToString();
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                }
                else
                {
                    Pcommand = "seek MediaFile to " + miliseconds.ToString();
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                }
            }

            public int GetSongLenght()
            {
                if (IsPlaying())
                {
                    Pcommand = "status MediaFile length";
                    error = mciSendString(Pcommand, returnData, returnData.Capacity, IntPtr.Zero);
                    return int.Parse(returnData.ToString());
                }
                else
                    return 0;
            }
            public bool SetVolume(int volume)
            {
                if (volume >= 0 && volume <= 1000)
                {
                    Pcommand = "setaudio MediaFile volume to " + volume.ToString();
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    return true;
                }
                else
                    return false;
            }

            public bool SetBalance(int balance)
            {
                if (balance >= 0 && balance <= 1000)
                {
                    Pcommand = "setaudio MediaFile left volume to " + (1000 - balance).ToString();
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    Pcommand = "setaudio MediaFile right volume to " + balance.ToString();
                    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                    return true;
                }
                else
                    return false;
            }
            public int GetSong(bool previous)
            {
                if (Shuffle)
                {
                    int i;
                    if (playlist.Items.Count == 1)
                        return 0;
                    while (true)
                    {
                        i = randomNumber.Next(playlist.Items.Count);
                        if (i != NowPlaying)
                            return i;
                    }
                }
                else if (Loop && !previous)
                {
                    if (NowPlaying == playlist.Items.Count - 1)
                        return 0;
                    else
                        return NowPlaying + 1;
                }
                else if (Loop && previous)
                {
                    if (NowPlaying == 0)
                        return playlist.Items.Count - 1;
                    else
                        return NowPlaying - 1;
                }
                else
                {
                    if (previous)
                    {
                        if (NowPlaying != 0)
                            return NowPlaying - 1;
                        else
                            return 0;
                    }
                    else
                    {
                        if (NowPlaying != playlist.Items.Count - 1)
                            return NowPlaying + 1;
                        else
                            return 0;
                    }
                }
            }

        }
        static bool IsMediaFile(string path)
        {
            return -1 != Array.IndexOf(mediaExtensions, Path.GetExtension(path).ToUpperInvariant());
        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Path.GetDirectoryName(typeof(frmCoolForm).Assembly.Location);
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    bool choosePathErr = false;
                    string[] filePaths = Directory.GetFiles(fbd.SelectedPath);
                    if (filePaths.Length == 0)
                    {
                        MessageBox.Show("No files found!", "Watch out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    foreach (var f in filePaths)
                    {
                        if (IsMediaFile(f))
                        {
                            musicList.Items.Add(Path.GetFileName(f));
                        }
                        else
                        {
                            choosePathErr = true;
                        }

                    }
                    if (choosePathErr)
                    {
                        MessageBox.Show("Not all files are media!", "Watch out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
            }
            
        }


       
    }
}