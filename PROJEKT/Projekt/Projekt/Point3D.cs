using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Projekt
{
    public class Point3D
    {
        private double[] mCoords;

        public Point3D()
        {
            SetToZero();
        }

        public void SetToZero()
        {
            mCoords = new double[] { 0, 0, 0, 1 };
        }

        public Point3D(double dX, double dY, double dZ, double dW)
        {
            mCoords = new double[] { dX, dY, dZ, dW };
        }

        public Point3D(Point3D p)
        {
            mCoords = new double[] {p[0], p[1], p[2], p[3]};
        }

                // return the number of point coordinates
        public int Size()
        {
            return mCoords.GetLength(0);
        }

        // return the Max index in the point coordinate array
        public int MaxInd()
        {
            return mCoords.GetUpperBound(0);
        }

        // return the Min index in the point coordinate array
        public int MinInd()
        {
            return mCoords.GetLowerBound(0);
        }

        // return/set the value of the specified coordinate
        public double this[int i]
        {
            get
            {
                // if (0<=i && i<=3)
                //  v = mCoords[i];
                // else
                //  throw new IndexOutOfRangeException;

                return mCoords[i];

            }
            set
            {
                mCoords[i] = value;
            }
        }

        public void TransformBy(Matrix4x4 Mat)
        {
            double dX, dY, dZ, dW;

            dX = Mat[0, 0] * mCoords[0] + Mat[0, 1] * mCoords[1] + Mat[0, 2] * mCoords[2] + Mat[0, 3] * mCoords[3];
            dY = Mat[1, 0] * mCoords[0] + Mat[1, 1] * mCoords[1] + Mat[1, 2] * mCoords[2] + Mat[1, 3] * mCoords[3];
            dZ = Mat[2, 0] * mCoords[0] + Mat[2, 1] * mCoords[1] + Mat[2, 2] * mCoords[2] + Mat[2, 3] * mCoords[3];
            dW = Mat[3, 0] * mCoords[0] + Mat[3, 1] * mCoords[1] + Mat[3, 2] * mCoords[2] + Mat[3, 3] * mCoords[3];

            mCoords[0] = dX;
            mCoords[1] = dY;
            mCoords[2] = dZ;
            mCoords[3] = dW;
        }

        public static Point3D operator *(Matrix4x4 Mat, Point3D p) 
        {
            Point3D res;
            double dX, dY, dZ, dW;

            dX = Mat[0, 0] * p[0] + Mat[0, 1] * p[1] + Mat[0, 2] * p[2] + Mat[0, 3] * p[3];
            dY = Mat[1, 0] * p[0] + Mat[1, 1] * p[1] + Mat[1, 2] * p[2] + Mat[1, 3] * p[3];
            dZ = Mat[2, 0] * p[0] + Mat[2, 1] * p[1] + Mat[2, 2] * p[2] + Mat[2, 3] * p[3];
            dW = Mat[3, 0] * p[0] + Mat[3, 1] * p[1] + Mat[3, 2] * p[2] + Mat[3, 3] * p[3];

            res = new Point3D(dX, dY, dZ, dW);

            return res;
        }

        public static Point3D operator /(Point3D p, double d)
        {
            Point3D res;
            res = new Point3D(p[0] / d, p[1] / d, p[2] / d, p[3] / d);

            return res;
        }

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            Point3D res;
            res = new Point3D(p1[0] + p2[0], p1[1] + p2[1], p1[2] + p2[2], p1[3] + p2[3]);

            return res;
        }

        public static Point3D operator -(Point3D p1)
        {
            Point3D res;
            res = new Point3D(-p1[0], -p1[1], -p1[2], -p1[3]);

            return res;
        }

        public static Vector3D operator -(Point3D p2, Point3D p1)
        {
            Vector3D res;
            res = new Vector3D(p2[0] - p1[0], p2[1] - p1[1], p2[2] - p1[2], p2[3] - p1[3]);

            return res;
        }

    }
}
