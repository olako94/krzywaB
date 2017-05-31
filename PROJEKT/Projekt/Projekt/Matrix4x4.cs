using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Projekt
{
    public class Matrix4x4
    {

        private double[,] mValues; // double[4,4]

        public Matrix4x4()
        {
            SetToZero();
        }

        public Matrix4x4(double dX, double dY, double dZ)
        {
            SetToTrans(dX, dY, dZ);
        }

        public void SetToZero()
        {
            mValues = new double[,] {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};
        }

        public void SetToIdent()
        {
            mValues = new double[,] {{1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 1}};
        }


        public void  SetToTrans(double dX, double dY, double dZ)
        {
            mValues = new double[,] {{1, 0, 0, dX}, {0, 1, 0, dY}, {0, 0, 1, dZ}, {0, 0, 0, 1}};
        }

        public void  SetToTrans(Point3D Pnt)
        {
            mValues = new double[,] {{1, 0, 0, Pnt[0]}, {0, 1, 0, Pnt[1]}, {0, 0, 1, Pnt[2]}, {0, 0, 0, 1}};
        }

        public void  SetToUCS(Point3D pnt, Vector3D vX, Vector3D vY, Vector3D vZ)
        {
            mValues = new double[,] {{vX[0], vX[1], vX[2], 0}, {vY[0], vY[1], vY[2], 0}, {vZ[0], vZ[1], vZ[2], 0}, {0, 0, 0, 1}};

            Matrix4x4 Mat2;
            Mat2 = new Matrix4x4(-pnt[0], -pnt[1], -pnt[2]);

            this.MultiplyBy(Mat2);

        }

        public void SetToScale(double dS)
        {
            SetToIdent();

            mValues[0, 0] = dS;
            mValues[1, 1] = dS;
            mValues[2, 2] = dS;
        }

        public void  SetToScale(double dSx, double dSy, double dSz)
        {
            SetToIdent();

            mValues[0, 0] = dSx;
            mValues[1, 1] = dSy;
            mValues[2, 2] = dSz;
        }

        public void SetToAxRot(double dAngle, int nAxInd)
        {
            int nUL, nLR;
            double dSinA = Math.Sin(dAngle);
            double dCosA = Math.Cos(dAngle);

            SetToIdent();

            switch (nAxInd)
            {
                case 0:
                    nUL = 1;
                    nLR = 2;
                    break;
                case 1:
                    nUL = 0;
                    nLR = 2;
                    dSinA = -dSinA;
                    break;
                case 2:
                    nUL = 0;
                    nLR = 1;
                    break;
                default:
                    return;
            }

            mValues[nUL, nUL] = dCosA;
            mValues[nUL, nLR] = -dSinA;
            mValues[nLR, nUL] = dSinA;
            mValues[nLR, nLR] = dCosA;

        }

        public double this[int i, int j]
        {
            get
            {
                // if (0<=i && i<=3 && 0<=j && j<=3)
                //  v = mValues[i, j];
                // else
                //  throw new IndexOutOfRangeException;

                return mValues[i, j];
            }
            set
            {
                mValues[i, j] = value;
            }
        }


        public void  MultiplyBy(Matrix4x4 Right_Mat)
        {
            int i, ii, n;
            Matrix4x4 temp;
            temp = new Matrix4x4();

            for(i=0; i<4; i++)
                for(ii=0; ii<4; ii++)
                    for (n=0; n<4; n++)
                        temp[i, ii] += this[i, n] * Right_Mat[n, ii];

            for(i=0; i<4; i++)
                for(ii=0; ii<4; ii++)
                    this[i, ii] = temp[i, ii];

        }

        public static Matrix4x4 operator *(Matrix4x4 Mat1, Matrix4x4 Mat2)
        {
            int i, ii, n;
            Matrix4x4 res;
            res = new Matrix4x4();

            for(i=0; i<4; i++)
                for(ii=0; ii<4; ii++)
                    for(n=0; n<4; n++)
                        res[i, ii] += Mat1[i, n] * Mat2[n, ii];

            return (res);
        }

    }
}
