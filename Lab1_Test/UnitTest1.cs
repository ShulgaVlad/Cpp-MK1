using Lab1;
using System;
using Xunit;

namespace Lab1_Test
{
    public class CubeTests
    {
        [Fact]
        public void CubeEquality_SameCubes_ReturnsTrue()
        {
            var cube1 = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var cube2 = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            Assert.True(cube1 == cube2);
        }

        [Fact]
        public void CubeEquality_DifferentCubes_ReturnsFalse()
        {
            var cube1 = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var cube2 = new Cube { front = 6, back = 5, top = 4, bottom = 3, left = 2, right = 1 };
            Assert.False(cube1 == cube2);
        }

        [Fact]
        public void RotateToTop_CorrectRotation_ReturnsExpected()
        {
            var cube = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var rotated = cube.RotateToTop();
            Assert.Equal(4, rotated.front); // The bottom should become the front face
            Assert.Equal(3, rotated.back);  // The top should become the back face
        }

        [Fact]
        public void RotateRight_CorrectRotation_ReturnsExpected()
        {
            var cube = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var rotated = cube.RotateRight();
            Assert.Equal(5, rotated.front); // The left should become the front face
            Assert.Equal(6, rotated.back);  // The right should become the back face
        }

        [Fact]
        public void RotateCW_CorrectRotation_ReturnsExpected()
        {
            var cube = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var rotated = cube.RotateCW();
            Assert.Equal(5, rotated.top);   // The left should become the top face
            Assert.Equal(6, rotated.bottom); // The right should become the bottom face
        }

        [Fact]
        public void TestCubesEqualWithRotation()
        {
            var cube1 = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var cube2 = new Cube { front = 5, back = 6, top = 3, bottom = 4, left = 2, right = 1 };

            // Check that cubes are initially not equal
            Assert.False(cube1 == cube2);

            // Rotate cube to the right
            cube1 = cube1.RotateRight();
            // Now the front and back should be the left and right faces respectively
            Assert.Equal(5, cube1.front);
            Assert.Equal(6, cube1.back);

            // Now the cubes should be equal
            Assert.True(cube1 == cube2);
        }

        [Fact]
        public void TestCubesEqualWithMultipleRotations()
        {
            var cube1 = new Cube { front = 1, back = 2, top = 3, bottom = 4, left = 5, right = 6 };
            var cube2 = new Cube { front = 5, back = 6, top = 3, bottom = 4, left = 2, right = 1 };

            bool cubesMatch = false;

            // Try all possible rotations
            for (int i = 0; i < 4; i++)
            {
                cube1 = cube1.RotateToTop(); // Rotate to top face
                for (int j = 0; j < 4; j++)
                {
                    cube1 = cube1.RotateRight(); // Rotate to right face
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

            Assert.True(cubesMatch); // Test passes if cubes match after rotations
        }
    }
}
