using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailMatrix
{
    class Matrix
    {
        private int[,] privateMatrix;

        public Matrix()   //create matrix (MEGA CRUTCH)
        {
            int someValue = 10;
            int count = 5;
            privateMatrix = new int[6, 6];

            for (count = 5; count >= 0; count--)    //column 5
            {
                for (int i = 5; i >= 0; i--)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (int i = 0; i < 1;)                 //string 0
            {
                for (count = 4; count >= 0; count--)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (count = 0; count <= 0;)            //column 0
            {
                for (int i = 1; i <= 5; i++)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (int i = 5; i < 6;)                //string 5
            {
                for (count = 1; count < 5; count++)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (count = 4; count > 0;)             //column 4
            {
                for (int i = 4; i > 0; i--)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (int i = 1; i < 2;)                 //string 1
            {
                for (count = 3; count > 0; count--)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (count = 1; count > 0;)             //column 1
            {
                for (int i = 2; i <= 4; i++)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (int i = 4; i > 2;)                     //string 4
            {
                for (count = 2; count < 4; count++)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (count = 3; count > 0;)                 //column 3
            {
                for (int i = 3; i >= 2; i--)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }

            for (count = 2; count > 0;)                 //column 2
            {
                for (int i = 2; i <4; i++)
                {
                    privateMatrix[i, count] = someValue++;
                }
                break;
            }
            }
            
            public void MatrixShow()     //Matrix show
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                {
                    Console.Write( privateMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        class User
        {
            static void Main()
            {
                Matrix newMatrix = new Matrix();
                newMatrix.MatrixShow();
            }
        }

    }
}
