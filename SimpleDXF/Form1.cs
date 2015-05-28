using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Globalization;

namespace SimpleDXF
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        string file;
        DXF drawing = new DXF();

        public Form1()
        {
            InitializeComponent();
        }

        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w,0,h,-1,1);
            GL.Viewport(0,0,w,h);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;

            GL.ClearColor(Color.White);
            SetupViewport();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded) return;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            drawing.Draw_All();

            glControl1.SwapBuffers();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            StreamReader fileDXF = new StreamReader(fs);

            drawing.Clear();

            char separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string input;

            while (!fileDXF.EndOfStream)
            {
                input = fileDXF.ReadLine().Replace('.', separator);
                drawing.Read(input);
            }
            fileDXF.Close();

            drawing.Draw_All();
            glControl1.SwapBuffers();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            drawing.Save();
        }
    }
}
