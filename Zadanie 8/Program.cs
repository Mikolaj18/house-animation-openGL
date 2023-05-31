using GLFW;
using GlmSharp;
using Shaders;
using Models;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System.Drawing;

namespace cieniowanie
{
    public class BC: IBindingsContext
    {
        public IntPtr GetProcAddress(string procName)
        {
            return Glfw.GetProcAddress(procName);
        }
    }

    class Program
    {
        static int sciany;
        static int dach;
        static int tlo;
        static int ziemia;
        static int drzwi;
        static int okno;
        static int krzew;
        static int chodnik;
        static KeyCallback kc = KeyProcessor;
        static ShaderProgram sp;
        static float obrot_y;

        //Obsługa klawiatury
        public static void KeyProcessor(System.IntPtr window, Keys key, int scanCode, InputState state, ModifierKeys mods) { 
            if (state==InputState.Press)
            {
                if (key == Keys.Left) obrot_y = -1.0f;
                if (key == Keys.Right) obrot_y =  1.0f;
            }
            if (state == InputState.Release)
            {
                if (key == Keys.Left) obrot_y = 0;
                if (key == Keys.Right) obrot_y = 0;
            }
        }

        public static void InitOpenGLProgram(Window window)
        {
            GL.ClearColor(0, 0, 0, 1);
            sp = new ShaderProgram("v_shader.glsl","f_shader.glsl");
            Glfw.SetKeyCallback(window, kc);
            GL.Enable(EnableCap.DepthTest);
            //poniższe ściezki do zmiany
            sciany = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\sciana.jpg");
            dach = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\dach.jpg");
            tlo = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\tlo.jpg");
            ziemia = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\ziemia.jpg");
            drzwi = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\drzwi.png");
            okno = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\okno.png");
            krzew = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\krzew.jpg");
            chodnik = ReadTexture("C:\\Users\\Mikołaj Urbański\\Desktop\\zadanie2\\cieniowanie\\Zadanie 8\\chodnik.jpg");
        }

        public static void FreeOpenGLProgram(Window window)
        {
            GL.DeleteTexture(sciany);
            GL.DeleteTexture(dach);
            GL.DeleteTexture(tlo);
            GL.DeleteTexture(ziemia);
            GL.DeleteTexture(drzwi);
            GL.DeleteTexture(okno);
            GL.DeleteTexture(krzew);
            GL.DeleteTexture(chodnik);
        }

        public static int ReadTexture(string filename)
        {
            var tex = GL.GenTexture();
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            Bitmap bitmap = new Bitmap(filename);
            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
            new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width,
                data.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
             
            bitmap.UnlockBits(data);
            bitmap.Dispose();

            GL.TexParameter(TextureTarget.Texture2D,
              TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D,
              TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            return tex;
        }

        public static void DrawScene(Window window, float obrot_y)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit| ClearBufferMask.DepthBufferBit);

            mat4 P = mat4.Perspective(glm.Radians(75.0f), 1, 1, 50);
            mat4 V = mat4.LookAt(new vec3(0, 0, -6), new vec3(0, 0, 0), new vec3(0, 2, 0));

            sp.Use();
            GL.UniformMatrix4(sp.U("P"), 1, false, P.Values1D);
            GL.UniformMatrix4(sp.U("V"), 1, false, V.Values1D);

            //dom
            mat4 dom = mat4.Rotate(obrot_y, new vec3(0, 1, 0));
            GL.UniformMatrix4(sp.U("M"), 1, false, dom.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, sciany);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.dom.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.dom.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.dom.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.dom.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //dach
            mat4 dach = dom * mat4.Translate(new vec3(0, 1.5f, 0));
            GL.UniformMatrix4(sp.U("M"), 1, false, dach.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.dach);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.dach.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.dach.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.dach.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.dach.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //tlo
            mat4 tlo = mat4.Translate(new vec3(0, 3, 3));
            GL.UniformMatrix4(sp.U("M"), 1, false, tlo.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.tlo);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));

            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.tlo.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.tlo.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.tlo.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.tlo.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));
            GL.DisableVertexAttribArray(sp.A("color"));

            //ziemia
            mat4 ziemia = dom * mat4.Translate(new vec3(0, -1, 0));
            GL.UniformMatrix4(sp.U("M"), 1, false, ziemia.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.ziemia);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.trawa.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.trawa.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.trawa.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.trawa.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //komin
            mat4 komin = dom * mat4.Translate(new vec3(0.6f, 1.6f, 0.0f));
            GL.UniformMatrix4(sp.U("M"), 1, false, komin.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, sciany);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.komin.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.komin.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.komin.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.komin.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));                       

            //okno1
            mat4 okno1 = dom * mat4.Translate(new vec3(1.21f, 0.25f, 0.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, okno1.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.okno);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.okno.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.okno.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //okno2
            mat4 okno2 = dom * mat4.Translate(new vec3(1.21f, 0.25f, -0.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, okno2.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.okno);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.okno.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.okno.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //okno3
            mat4 okno3 = dom * mat4.Translate(new vec3(-1.21f, 0.25f, 0.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, okno3.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.okno);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.okno.texCoords);
            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.okno.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));
            GL.DisableVertexAttribArray(sp.A("color"));

            //okno4
            mat4 okno4 = dom * mat4.Translate(new vec3(-1.21f, 0.25f, -0.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, okno4.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.okno);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));
            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.okno.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.okno.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.okno.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));
            GL.DisableVertexAttribArray(sp.A("color"));

            //drzwi1
            mat4 drzwi1 = dom * mat4.Translate(new vec3(0.0f, -0.5f, -0.69f)) * mat4.Rotate(1.570796f, new vec3(0, 0, 1.570796f));
            GL.UniformMatrix4(sp.U("M"), 1, false, drzwi1.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.drzwi);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));

            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, Models.drzwi.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, Models.drzwi.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, Models.drzwi.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, Models.drzwi.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord")); 

            //chodnik
            mat4 chodnik = dom * mat4.Translate(new vec3(0, -0.99f, -1.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, chodnik.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.chodnik);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));

            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, cieniowanie.chodnik.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, cieniowanie.chodnik.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, cieniowanie.chodnik.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, cieniowanie.chodnik.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //krzew1
            mat4 krzew1 = dom * mat4.Translate(new vec3(-1.5f, -0.7f, -2.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, krzew1.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.krzew);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));

            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, cieniowanie.krzew.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, cieniowanie.krzew.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, cieniowanie.krzew.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, cieniowanie.krzew.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));


            //krzew2
            mat4 krzew2 = dom * mat4.Translate(new vec3(1.5f, -0.7f, -2.5f));
            GL.UniformMatrix4(sp.U("M"), 1, false, krzew2.Values1D);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Program.krzew);
            GL.Uniform1(sp.U("textureMap0"), 0);

            GL.EnableVertexAttribArray(sp.A("vertex"));
            GL.EnableVertexAttribArray(sp.A("normal"));
            GL.EnableVertexAttribArray(sp.A("texCoord"));

            GL.VertexAttribPointer(sp.A("vertex"), 4, VertexAttribPointerType.Float, false, 0, cieniowanie.krzew.vertices);
            GL.VertexAttribPointer(sp.A("normal"), 4, VertexAttribPointerType.Float, false, 0, cieniowanie.krzew.vertexNormals);
            GL.VertexAttribPointer(sp.A("texCoord"), 2, VertexAttribPointerType.Float, false, 0, cieniowanie.krzew.texCoords);

            GL.DrawArrays(PrimitiveType.Triangles, 0, cieniowanie.krzew.vertexCount);

            GL.DisableVertexAttribArray(sp.A("vertex"));
            GL.DisableVertexAttribArray(sp.A("normal"));
            GL.DisableVertexAttribArray(sp.A("texCoord"));

            //Skopiuj ukryty bufor do bufora widocznego            
            Glfw.SwapBuffers(window);
        }

        static void Main(string[] args)
        {
            Glfw.Init();

            Window window = Glfw.CreateWindow(500, 500, "OpenGL", GLFW.Monitor.None, Window.None);

            Glfw.MakeContextCurrent(window);
            Glfw.SwapInterval(1);

            GL.LoadBindings(new BC());

            InitOpenGLProgram(window);

            float obrot_y = 0;

            Glfw.Time = 0;

            while (!Glfw.WindowShouldClose(window))
            {
                obrot_y += Program.obrot_y * (float)Glfw.Time;
                Glfw.Time = 0;
                DrawScene(window, obrot_y);
                Glfw.PollEvents();
            }
            FreeOpenGLProgram(window);
            Glfw.Terminate();
        }                  
    }
}