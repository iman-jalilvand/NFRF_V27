using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;

public static class MathlabUtility
{
#if UNITY_STANDALONE
	[StructLayout(LayoutKind.Sequential)]
	private struct emxArray_real_T
	{
		public IntPtr data;
		public IntPtr size;
		public int allocatedSize;
		public int numDimensions;
		[MarshalAs(UnmanagedType.U1)]
		public bool canFreeData;
	}


	private class emxArray_real_T_Wrapper : IDisposable
	{
		private emxArray_real_T value;
		private GCHandle dataHandle;
		private GCHandle sizeHandle;

		public ref emxArray_real_T Value
		{
			get { return ref value; }
		}

		public double[] Data
		{
			get
			{
				double[] data = new double[value.allocatedSize];
				Marshal.Copy(value.data, data, 0, value.allocatedSize);
				return data;
			}
		}


		public emxArray_real_T_Wrapper(double[] data)
		{
			dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
			value.data = dataHandle.AddrOfPinnedObject();
			sizeHandle = GCHandle.Alloc(new int[] { 1, data.Length }, GCHandleType.Pinned);
			value.size = sizeHandle.AddrOfPinnedObject();
			value.allocatedSize = data.Length;
			value.numDimensions = 1;
			value.canFreeData = false;
		}

		public void Dispose()
		{
			dataHandle.Free();
			sizeHandle.Free();
			GC.SuppressFinalize(this);
		}

		~emxArray_real_T_Wrapper()
		{
			Dispose();
		}
	}

	[DllImport("pf.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern void pf(ref emxArray_real_T x, ref emxArray_real_T y, double n, ref emxArray_real_T coefficients);

	[DllImport("pv.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern void pv(ref emxArray_real_T p, ref emxArray_real_T x, ref emxArray_real_T y);

	[DllImport("ls.dll", CallingConvention = CallingConvention.Cdecl)]
	private static extern void ls(double x1, double x2, double n, ref emxArray_real_T y1);

	public static double[] polyval(double[] p, double[] x)
	{
		double[] y = new double[x.Length];
		emxArray_real_T_Wrapper xw = new emxArray_real_T_Wrapper(x);
		emxArray_real_T_Wrapper yw = new emxArray_real_T_Wrapper(y);
		emxArray_real_T_Wrapper pw = new emxArray_real_T_Wrapper(p);
		pv(ref pw.Value, ref xw.Value, ref yw.Value);

		return yw.Data;
	}

	public static double[] polyfit(double[] x, double[] y, int n)
	{
		double[] p = new double[n + 1];
		emxArray_real_T_Wrapper xw = new emxArray_real_T_Wrapper(x);
		emxArray_real_T_Wrapper yw = new emxArray_real_T_Wrapper(y);
		emxArray_real_T_Wrapper pw = new emxArray_real_T_Wrapper(p);

		pf(ref xw.Value, ref yw.Value, n, ref pw.Value);

		return pw.Data;
	}

	public static double[] linspace(double x1, double x2, int n)
	{
		double[] y = new double[n];
		emxArray_real_T_Wrapper y1m = new emxArray_real_T_Wrapper(y);
		ls(x1, x2, n, ref y1m.Value);
		return y1m.Data;
	}
#endif
	public static double[,] Submatrix(double[,] original, int[] rowIndicies, int[] columnIndicies, bool blacklist = true)
	{
		int rowCount = blacklist ? (original.GetLength(0) - rowIndicies.Length) : rowIndicies.Length;
		int colCount = blacklist ? (original.GetLength(1) - columnIndicies.Length) : columnIndicies.Length;

		double[,] sub = new double[rowCount, colCount];
		int xi = 0;

		HashSet<int> rowBan = new HashSet<int>(rowIndicies);
		HashSet<int> colBan = new HashSet<int>(columnIndicies);

		for (int i = 0, imax = original.GetLength(0); i < imax; ++i)
		{
			if ((blacklist && rowBan.Contains(i)) || (!blacklist && !rowBan.Contains(i)))
			{
				continue;
			}

			int yi = 0;
			for (int j = 0, jmax = original.GetLength(1); j < jmax; ++j)
			{
				if ((blacklist && colBan.Contains(j)) || (!blacklist && !colBan.Contains(j)))
				{
					continue;
				}
				sub[xi, yi] = original[i, j];
				yi++;
			}
			xi++;
		}

		return sub;
	}

	public static double[] Scale(double[] x, double y)
	{
		for (int i = 0, max = x.Length; i < max; ++i)
		{
			x[i] = x[i] * y;
		}
		return x;
	}

	public static double[,,] Scale(double[,,] x, double y)
	{
		for (int i = 0, imax = x.GetLength(0); i < imax; ++i)
		{
			for (int j = 0, jmax = x.GetLength(1); j < jmax; ++j)
			{
				for (int k = 0, kmax = x.GetLength(2); k < kmax; ++k)
				{
					x[i, j, k] *= y;
				}
			}
		}
		return x;
	}

	public static void PowEach(double[,,] m, double p)
	{
		for (int x = 0, mx = m.GetLength(0); x < mx; ++x)
		{
			for (int y = 0, my = m.GetLength(1); y < my; ++y)
			{
				for (int z = 0, mz = m.GetLength(2); z < mz; ++z)
				{
					m[x, y, z] = Math.Pow(m[x, y, z], p);
				}
			}
		}
	}


	public static double[] Add(double[] x, double[] y)
	{
		int length = Math.Min(x.Length, y.Length);
		double[] added = new double[length];
		for (int i = 0; i < length; ++i)
		{
			added[i] = x[i] + y[i];
		}
		return added;
	}

	public static double[] Add(double[] x, double y)
	{
		int max = x.Length;
		double[] added = new double[max];
		for (int i = 0; i < max; ++i)
		{
			added[i] = x[i] + y;
		}
		return added;
	}


	public static double[,] Add(double[,] x, double y)
	{
		int imax = x.GetLength(0);
		int jmax = x.GetLength(1);
		double[,] added = new double[imax, jmax];
		for (int i = 0; i < imax; ++i)
		{
			for (int j = 0; j < jmax; ++j)
			{
				added[i, j] = x[i, j] + y;
			}
		}
		return added;
	}

	public static double[] Abs(double[] x)
	{
		int max = x.Length;
		double[] v = new double[max];
		for (int i = 0; i < max; ++i)
		{
			v[i] = Math.Abs(x[i]);
		}
		return v;
	}

	public static double Min(double[] x)
	{
		int max = x.Length;
		double min = double.MaxValue;
		for (int i = 0; i < max; ++i)
		{
			double val = x[i];
			if (val < min)
			{
				min = val;
			}
		}
		return min;
	}

	public static int Find(double[] x, Predicate<double> check)
	{
		List<int> indicies = new List<int>();
		for (int i = 0, max = x.Length; i < max; ++i)
		{
			if (check(x[i]))
			{
				return i;
			}
		}

		return -1;
	}

	public static double Sum(double[,] m)
	{
		double sum = 0;
		for (int xi = 0, mx = m.GetLength(0); xi < mx; ++xi)
		{
			for (int yi = 0, my = m.GetLength(1); yi < my; ++yi)
			{
				sum += m[xi, yi];
			}
		}
		return sum;
	}

	public static double[,] Matrix(int x, int y, double val = 1)
	{
		double[,] m = new double[x, y];

		for (int xi = 0; xi < x; ++xi)
		{
			for (int yi = 0; yi < y; ++yi)
			{
				m[xi, yi] = val;
			}
		}

		return m;
	}


	public static double[,] Matrix(int x, int y, double[,] valM)
	{
		double[,] m = new double[x, y];

		for (int xi = 0; xi < x; ++xi)
		{
			for (int yi = 0; yi < y; ++yi)
			{
				m[xi, yi] = valM[xi, yi];
			}
		}

		return m;
	}



	public static double[] IncrementalArray(double from, double to, double increment)
	{
		int count = (int)((to - from) / increment) + 1;
		double[] ia = new double[count];

		for (int i = 0; i < count; ++i)
		{
			ia[i] = from + increment * i;
		}

		return ia;
	}

	public static double Mean(double[,] m)
	{
		int count = m.GetLength(0) * m.GetLength(1);
		double sum = Sum(m);
		return sum / count;
	}

	public static int[] IncrementalArray(int from, int to, int increment = 1)
	{
		int count = (int)((to - from) / increment) + 1;
		int[] ia = new int[count];

		for (int i = 0; i < count; ++i)
		{
			ia[i] = from + increment * i;
		}

		return ia;
	}

	public static void Display(double[][] m)
	{
		string msg = "";
		for (int x = 0; x < m.Length; ++x)
		{
			for (int y = 0; y < m[x].Length; ++y)
			{
				msg += (m[x][y] + "\t\t\t");
			}
			msg += ('\n');
		}
		Debug.Log(msg);
	}


	public static void Display(double[,] m)
	{
		string msg = "";
		for (int x = 0; x < m.GetLength(0); ++x)
		{
			for (int y = 0; y < m.GetLength(1); ++y)
			{
				msg += (m[x, y] + "\t\t\t");
			}
			msg += ('\n');
		}
		Debug.Log(msg);
	}

	public static double[] ToOneDimension(double[,] m, int column = 0)
	{
		double[] r = new double[m.Length];

		for (int i = 0, max = m.Length; i < max; ++i)
		{
			r[i] = m[i, column];
		}

		return r;
	}

	public static double[,] ToTwoDimension(double[] m)
	{
		int max = m.Length;
		double[,] td = new double[max, 1];
		for (int x = 0; x < max; ++x)
		{
			td[x, 0] = m[x];
		}
		return td;
	}

	public static void Display(int[] m)
	{
		string msg = "";
		for (int x = 0; x < m.GetLength(0); ++x)
		{
			msg += (m[x] + "\t\t\t");
		}
		Debug.Log(msg);
	}
}
