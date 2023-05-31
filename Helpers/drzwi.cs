namespace Models
{
    public class drzwi
    {
        public static int vertexCount = 36;
        public static float scale = 3;

        public static float[] vertices ={
                //Ściana 1
                2.0f/scale, -1.0f/scale, -1.0f/scale, 1.0f,
                -2.0f/scale, 1.0f/scale, -1.0f/scale, 1.0f,
                -2.0f/scale, -1.0f/scale, -1.0f/scale, 1.0f,

                2.0f/scale, -1.0f/scale, -1.0f/scale, 1.0f,
                2.0f/scale, 1.0f/scale, -1.0f/scale, 1.0f,
                -2.0f/scale, 1.0f/scale, -1.0f/scale, 1.0f,

                //Ściana 2
                -2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,

                -2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,
                -2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,

                //Ściana 3
                -2.0f/scale,-1.0f/scale,-1.0f/scale,1.0f,
                2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale,-1.0f/scale,-1.0f/scale,1.0f,

                -2.0f/scale,-1.0f/scale,-1.0f/scale,1.0f,
                -2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,

                //Ściana 4
                -2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale,-1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,

                -2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,
                -2.0f/scale, 1.0f/scale,-1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale,-1.0f/scale,1.0f,

                //Ściana 5
                -2.0f/scale,-1.0f/scale,-1.0f/scale,1.0f,
                -2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,
                -2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,

                -2.0f/scale,-1.0f/scale,-1.0f/scale,1.0f,
                -2.0f/scale, 1.0f/scale,-1.0f/scale,1.0f,
                -2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,

                //Ściana 6
                2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale,-1.0f/scale,1.0f,
                2.0f/scale,-1.0f/scale,-1.0f/scale,1.0f,

                2.0f/scale,-1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale, 1.0f/scale,1.0f,
                2.0f/scale, 1.0f/scale,-1.0f/scale,1.0f,
            };

        public static float[] vertexNormals ={
				//Ściana 1
				1.0f,-1.0f,-1.0f,0.0f,
                -1.0f, 1.0f,-1.0f,0.0f,
                -1.0f,-1.0f,-1.0f,0.0f,

                1.0f,-1.0f,-1.0f,0.0f,
                1.0f, 1.0f,-1.0f,0.0f,
                -1.0f, 1.0f,-1.0f,0.0f,

				//Ściana 2
				-1.0f,-1.0f, 1.0f,0.0f,
                1.0f, 1.0f, 1.0f,0.0f,
                1.0f,-1.0f, 1.0f,0.0f,

                -1.0f,-1.0f, 1.0f,0.0f,
                -1.0f, 1.0f, 1.0f,0.0f,
                1.0f, 1.0f, 1.0f,0.0f,

				//Ściana 3
				-1.0f,-1.0f,-1.0f,0.0f,
                1.0f,-1.0f, 1.0f,0.0f,
                1.0f,-1.0f,-1.0f,0.0f,

                -1.0f,-1.0f,-1.0f,0.0f,
                -1.0f,-1.0f, 1.0f,0.0f,
                1.0f,-1.0f, 1.0f,0.0f,

				//Ściana 4
				-1.0f, 1.0f, 1.0f,0.0f,
                1.0f, 1.0f,-1.0f,0.0f,
                1.0f, 1.0f, 1.0f,0.0f,

                -1.0f, 1.0f, 1.0f,0.0f,
                -1.0f, 1.0f,-1.0f,0.0f,
                1.0f, 1.0f,-1.0f,0.0f,

				//Ściana 5
				-1.0f,-1.0f,-1.0f,0.0f,
                -1.0f, 1.0f, 1.0f,0.0f,
                -1.0f,-1.0f, 1.0f,0.0f,

                -1.0f,-1.0f,-1.0f,0.0f,
                -1.0f, 1.0f,-1.0f,0.0f,
                -1.0f, 1.0f, 1.0f,0.0f,

				//Ściana 6
				1.0f,-1.0f, 1.0f,0.0f,
                1.0f, 1.0f,-1.0f,0.0f,
                1.0f,-1.0f,-1.0f,0.0f,

                1.0f,-1.0f, 1.0f,0.0f,
                1.0f, 1.0f, 1.0f,0.0f,
                1.0f, 1.0f,-1.0f,0.0f,
            };

        public static float[] texCoords ={
				//Ściana 1
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,

				//Ściana 2
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,

				//Ściana 3
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,

				//Ściana 4
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,

				//Ściana 5
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,

				//Ściana 6
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,
            };
    }
}
