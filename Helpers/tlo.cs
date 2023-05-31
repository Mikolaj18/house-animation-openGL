namespace Models
{
    public class tlo
    {
        public static int vertexCount = 6;

        public static float[] vertices ={
                //Ściana 1
                7.0f, -5.0f, 0.0f, 1.0f,
                -7.0f, 5.0f, 0.0f, 1.0f,
                -7.0f, -5.0f, 0.0f, 1.0f,

                7.0f, -5.0f, 0.0f, 1.0f,
                7.0f, 5.0f, 0.0f, 1.0f,
                -7.0f, 5.0f, 0.0f, 1.0f,
            };

        public static float[] normals ={
				//Ściana 1
				0.0f, 0.0f,-1.0f,0.0f,
                0.0f, 0.0f,-1.0f,0.0f,
                0.0f, 0.0f,-1.0f,0.0f,

                0.0f, 0.0f,-1.0f,0.0f,
                0.0f, 0.0f,-1.0f,0.0f,
                0.0f, 0.0f,-1.0f,0.0f,
            };

        public static float[] vertexNormals ={
				//Ściana 1
				1.0f,-1.0f,-1.0f,0.0f,
                -1.0f, 1.0f,-1.0f,0.0f,
                -1.0f,-1.0f,-1.0f,0.0f,

                1.0f,-1.0f,-1.0f,0.0f,
                1.0f, 1.0f,-1.0f,0.0f,
                -1.0f, 1.0f,-1.0f,0.0f,
            };

        public static float[] texCoords ={
				//Ściana 1
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,
            };
    }
}
