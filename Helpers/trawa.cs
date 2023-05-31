namespace Models
{
    public class trawa
    {
        public static int vertexCount = 6;

        public static float[] vertices ={
                -8.0f,0.0f,-8.0f,1.0f,
                8.0f,0.0f, 8.0f,1.0f,
                8.0f,0.0f,-8.0f,1.0f,

                -8.0f,0.0f,-8.0f,1.0f,
                -8.0f,0.0f, 8.0f,1.0f,
                8.0f,0.0f, 8.0f,1.0f,
            };

        public static float[] normals ={
				0.0f,-1.0f, 0.0f,0.0f,
                0.0f,-1.0f, 0.0f,0.0f,
                0.0f,-1.0f, 0.0f,0.0f,

                0.0f,-1.0f, 0.0f,0.0f,
                0.0f,-1.0f, 0.0f,0.0f,
                0.0f,-1.0f, 0.0f,0.0f,
            };

        public static float[] vertexNormals ={
                -2.0f,-1.0f,-2.0f,0.0f,
                2.0f,-1.0f, 2.0f,0.0f,
                2.0f,-1.0f,-2.0f,0.0f,

                -2.0f,-1.0f,-2.0f,0.0f,
                -2.0f,-1.0f, 2.0f,0.0f,
                2.0f,-1.0f, 2.0f,0.0f,
            };

        public static float[] texCoords ={
				1.0f,1.0f, 0.0f,0.0f, 0.0f,1.0f,
                1.0f,1.0f, 1.0f,0.0f, 0.0f,0.0f,
            };
    }
}
