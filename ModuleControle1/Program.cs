using System;
using System.IO;

namespace ModuleControle1
{
    public class Cube
    {
        public int front;
        public int back;
        public int top;
        public int bottom;
        public int left;
        public int right;

        // Reads cube data from a line and initializes a Cube object
        public static Cube ReadFromLine(string line)
        {
            string[] input = line.Split(' ');
            int front = int.Parse(input[0]);
            int back = int.Parse(input[1]);
            int top = int.Parse(input[2]);
            int bottom = int.Parse(input[3]);
            int left = int.Parse(input[4]);
            int right = int.Parse(input[5]);

            return new Cube { front = front, back = back, top = top, bottom = bottom, left = left, right = right };
        }

        // Rotates the cube to bring the bottom face to the front
        public Cube RotateToTop()
        {
            return new Cube { front = this.bottom, back = this.top, top = this.front, bottom = this.back, left = this.left, right = this.right };
        }

        // Rotates the cube to bring the left face to the front
        public Cube RotateRight()
        {
            return new Cube { front = this.left, back = this.right, top = this.top, bottom = this.bottom, left = this.back, right = this.front };
        }

        // Rotates the cube clockwise on the front face
        public Cube RotateCW()
        {
            return new Cube { front = this.front, back = this.back, top = this.left, bottom = this.right, left = this.bottom, right = this.top };
        }

        // Equality operator to check if two cubes are the same
        public static bool operator ==(Cube a, Cube b)
        {
            return a.front == b.front && a.back == b.back && a.top == b.top && a.bottom == b.bottom && a.left == b.left && a.right == b.right;
        }

        // Inequality operator to check if two cubes are different
        public static bool operator !=(Cube a, Cube b)
        {
            return !(a == b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Read the input file INPUT.TXT
            string inputFilePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "ModuleControle1", "INPUT.txt");
            string[] lines = File.ReadAllLines(inputFilePath);

            // Initialize the first cube
            Cube cube1 = Cube.ReadFromLine(lines[0]);

            // Initialize the second cube
            Cube cube2 = Cube.ReadFromLine(lines[1]);

            bool cubesMatch = false;

            // Compare cubes after all possible rotations
            for (int i = 0; i < 4; i++)
            {
                cube1 = cube1.RotateToTop(); // Rotate to bring each face to the top
                for (int j = 0; j < 4; j++)
                {
                    cube1 = cube1.RotateRight(); // Rotate to bring each side to the front
                    for (int k = 0; k < 4; k++)
                    {
                        cube1 = cube1.RotateCW(); // Rotate clockwise
                        if (cube1 == cube2)
                        {
                            cubesMatch = true;
                            break;
                        }
                    }
                    if (cubesMatch) break;
                }
                if (cubesMatch) break;
            }

            // Output the result to OUTPUT.TXT
            string outputFilePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "ModuleControle1", "OUTPUT.txt");
            File.WriteAllText(outputFilePath, cubesMatch ? "YES" : "NO");
        }
    }
}