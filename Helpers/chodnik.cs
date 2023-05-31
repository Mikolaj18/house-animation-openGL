namespace cieniowanie
{
    public class chodnik
    {
        public static int vertexCount = 6;

        public static float[] vertices ={
                -1.0f,0.0f,2.5f,1.0f,
                -1.0f,0.0f,-2.5f,1.0f,
                1.0f,0.0f,2.5f,1.0f,

                1.0f,0.0f,2.5f,1.0f,
                1.0f,0.0f,-2.5f,1.0f,
                -1.0f,0.0f,-2.5f,1.0f,
            };

        public static float[] normals ={
                -1.0f,0.0f,3.0f,0.0f,
                -1.0f,0.0f,-3.0f,0.0f,
                1.0f,0.0f,3.0f,0.0f,

                1.0f,0.0f,3.0f,0.0f,
                1.0f,0.0f,-3.0f,0.0f,
                -1.0f,0.0f,-3.0f,0.0f,
            };

        public static float[] vertexNormals ={
                1.0f,-1.0f,-3.0f,0.0f,
                -1.0f, 1.0f,-3.0f,0.0f,
                -1.0f,-1.0f,-3.0f,0.0f,

                1.0f,-1.0f,-3.0f,0.0f,
                1.0f, 1.0f,-3.0f,0.0f,
                -1.0f, 1.0f,-3.0f,0.0f,
            };

        public static float[] texCoords ={
				-1.0f,3.0f, -1.0f,-3.0f, 1.0f,3.0f,
                1.0f,3.0f, 1.0f,-3.0f, -1.0f,-3.0f,
            };
    }
}
