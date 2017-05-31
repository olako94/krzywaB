using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Projekt
{
    public class Vector3D
    {
        private double[] mCoords;

        public Vector3D()
        {
            SetToZero();
        }

        public void SetToZero()
        {
            mCoords = new double[] { 0, 0, 0, 0 };
        }

        public Vector3D(double dX, Double dY, Double dZ, Double dW)
        {
            mCoords = new Double[] { dX, dY, dZ, dW };
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

        public void Normalize()
        {
            double dL;

            dL = Math.Sqrt(mCoords[0] * mCoords[0] + mCoords[1] * mCoords[1] + mCoords[2] * mCoords[2] + mCoords[3] * mCoords[3]);

            mCoords[0] /= dL;
            mCoords[1] /= dL;
            mCoords[2] /= dL;
            mCoords[3] /= dL;
        }

        public Vector3D Cross_prod(Vector3D right_vect)
        {
            Vector3D res;

            res = new Vector3D();

            res[0] = mCoords[1] * right_vect[2] - mCoords[2] * right_vect[1];
            res[1] = -mCoords[0] * right_vect[2] + mCoords[2] * right_vect[0];
            res[2] = mCoords[0] * right_vect[1] - mCoords[1] * right_vect[0];

            return res;
        }

        public double Dot_prod(Vector3D right_vect)
        {
            return mCoords[0] * right_vect[0] + mCoords[1] * right_vect[1] + mCoords[2] * right_vect[2];
        }

    }
}
