using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaterLogic : MonoBehaviour
{
	public Transform HeaterCenter, SheetCenter;


	private const double conductivity = 0.18;
	private const double specificHeat = 1465;
	private const double density = 1380;
	private const double Lx = 0.8;
	private const double Ly = 0.4;
	private const double Lz = 0.002;
	private const int Nx = 61;
	private const int Ny = 61;
	private const double T_init = 25 + 273;
	private const double epsilon_S = 0.95;
	//private const double H = 0.15;
	private double H
	{
		get
		{
			return Mathf.Abs(HeaterCenter.position.y - SheetCenter.position.y);
		}
	}

	private const double W_H = 0.06;
	private const double L_H = 0.24;
	private const double A_H = W_H * L_H;
	private const double epsilon_H = 0.92;
	private const double sigma = 0.0000000567;
	private const double T_in_H = 25 + 273;
	private const double T_ambient = 25 + 273;
	private const double h1 = 5;
	private const double h2 = 1;
	private const double t_end = 900;
	private double dt {
		get {
			return 1;// Time.deltaTime;
		}
	}
	private const double cb_min = 25;
	private const double cb_max = 200;

	public DataSheets Sheets;

	private double[] x;
	private double dx;
	private double[] y;
	private double dy;
	private double[,] T;
	private double alpha;

	double[] Ceramicx_150W_H_X;
	double[] Ceramicx_250W_H_X;
	double[] Ceramicx_400W_H_X;
	double[] Ceramicx_500W_H_X;

	double[] Ceramicx_150W_H_Y;
	double[] Ceramicx_250W_H_Y;
	double[] Ceramicx_400W_H_Y;
	double[] Ceramicx_500W_H_Y;
	double[][] P_H;

	double[] Ceramicx_150W_C_X;
	double[] Ceramicx_250W_C_X;
	double[] Ceramicx_400W_C_X;
	double[] Ceramicx_500W_C_X;

	double[] Ceramicx_150W_C_Y;
	double[] Ceramicx_250W_C_Y;
	double[] Ceramicx_400W_C_Y;
	double[] Ceramicx_500W_C_Y;

	double[][] P_C;
	double[] tt;

	double[][] Ceramic_T_t_H;
	double[][] Ceramic_T_t_C;

	int ww;
	int ll;

	double[,,] F;
	double[,] T_H;
	double[,] Power;
	double[,] Heater_PWR;
	double[,] hh1;

	private double[] PowerInput
	{
		get
		{
			return PowerControlPanel.Instance.Power;
		}
	}


	private void Start()
    {
        x = Sheets.Get("x");
        dx = x[2 - 1] - x[1 -1];
		y = Sheets.Get("y");
		dy = y[2 - 1] - y[1 - 1];

		T = MathlabUtility.Matrix(Ny + 1, Nx + 1, T_init);
		alpha = conductivity / (specificHeat * density);


		Ceramicx_150W_H_X = Sheets.Get("C150W_H_X");
		Ceramicx_250W_H_X = Sheets.Get("C250W_H_X");
		Ceramicx_400W_H_X = Sheets.Get("C400W_H_X");
		Ceramicx_500W_H_X = Sheets.Get("C500W_H_X");

		Ceramicx_150W_H_Y = Sheets.Get("C150W_H_Y");
		Ceramicx_250W_H_Y = Sheets.Get("C250W_H_Y");
		Ceramicx_400W_H_Y = Sheets.Get("C400W_H_Y");
		Ceramicx_500W_H_Y = Sheets.Get("C500W_H_Y");

		P_H = Sheets.GetMatrix("P_H", 4, 10);
		P_C = Sheets.GetMatrix("P_C", 4, 10);

		Ceramicx_150W_C_X = Sheets.Get("C150W_H_X");
		Ceramicx_250W_C_X = Sheets.Get("C250W_H_X");
		Ceramicx_400W_C_X = Sheets.Get("C400W_H_X");
		Ceramicx_500W_C_X = Sheets.Get("C500W_H_X");

		Ceramicx_150W_C_Y = Sheets.Get("C150W_H_Y");
		Ceramicx_250W_C_Y = Sheets.Get("C250W_H_Y");
		Ceramicx_400W_C_Y = Sheets.Get("C400W_H_Y");
		Ceramicx_500W_C_Y = Sheets.Get("C500W_H_Y");


		tt = MathlabUtility.IncrementalArray(0, 890, 0.5);

		Ceramic_T_t_H = Sheets.GetMatrix("Ceramic_T_t_H", 71, 1781);

		Ceramic_T_t_C = Sheets.GetMatrix("Ceramic_T_t_C", 71, 1781);

		ww = (int)((1 / (1 + 10 * H)) * W_H / (dy * 2));
		ll = (int)((1 / (1 + 10 * H)) * L_H / (dx * 2));

		F = new double[61, 61, 15];

		for (int i = 1; i <= Ny; ++i)
		{
			for (int j = 1; j <= Nx; ++j)
			{
				F[i - 1, j - 1, 0]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - ww) * dy), 2) + Math.Pow(((j - 1 - ll) * dx), 2)));
				F[i - 1, j - 1, 3]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)3 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - ll) * dx), 2)));
				F[i - 1, j - 1, 6]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)5 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - ll) * dx), 2)));
				F[i - 1, j - 1, 9]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)7 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - ll) * dx), 2)));
				F[i - 1, j - 1, 12] = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Ny + ww) * dy), 2) + Math.Pow(((j - 1 - ll) * dx), 2)));

				F[i - 1, j - 1, 1]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - ww) * dy), 2) + Math.Pow(((j - 1 - Math.Floor((double)Nx / 2)) * dx), 2)));
				F[i - 1, j - 1, 4]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)3 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - Math.Floor((double)Nx / 2)) * dx), 2)));
				F[i - 1, j - 1, 7]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)5 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - Math.Floor((double)Nx / 2)) * dx), 2)));
				F[i - 1, j - 1, 10] = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)7 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - Math.Floor((double)Nx / 2)) * dx), 2)));
				F[i - 1, j - 1, 13] = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Ny + ww) * dy), 2) + Math.Pow(((j - 1 - Math.Floor((double)Nx / 2)) * dx), 2)));

				F[i - 1, j - 1, 2]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - ww) * dy), 2) + Math.Pow(((j - 1 - (Nx - ll)) * dx), 2)));
				F[i - 1, j - 1, 5]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)3 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - (Nx - ll)) * dx), 2)));
				F[i - 1, j - 1, 8]  = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)5 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - (Nx - ll)) * dx), 2)));
				F[i - 1, j - 1, 11] = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Math.Floor((double)7 * Ny / 10)) * dy), 2) + Math.Pow(((j - 1 - (Nx - ll)) * dx), 2)));
				F[i - 1, j - 1, 14] = (H / Math.Sqrt(Math.Pow(H, 2) + Math.Pow(((i - 1 - Ny + ww) * dy), 2) + Math.Pow(((j - 1 - (Nx - ll)) * dx), 2)));
			}
		}


		// ------------------ LINE 130 func.m----------------- //
		List<int> Fx = new List<int>();
		List<int> Fy = new List<int>();

		for (int i = 1; i <= 2 * ww; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 1; i <= 2 * ll; ++i)
		{
			Fy.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1 , Fy[j] - 1, 0] = 1;
			}
		}

		Fx.Clear();
		for (int i = (3 * Ny / 10) - ww, max = (3 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 3] = 1;
			}
		}
		Fx.Clear();
		for (int i = (5 * Ny / 10) - ww, max = (5 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 3] = 1;
			}
		}
		Fx.Clear();
		for (int i = (7 * Ny / 10) - ww, max = (7 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 3] = 1;
			}
		}


		Fx.Clear();
		for (int i = Ny - 2 * ww, max = F.GetLength(1); i <= max; ++i)
		{
			Fx.Add(i);
		}
		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 12] = 1;
			}
		}



		// ------------------ LINE 136 func.m----------------- //
		Fx.Clear();
		for (int i = 1; i <= 2 * ww; ++i)
		{
			Fx.Add(i);
		}

		Fy.Clear();
		for (int i = Nx / 2 - ll, max = Nx / 2 + ll; i <= max; ++i)
		{
			Fy.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 1] = 1;
			}
		}

		Fx.Clear();
		for (int i = (3 * Ny / 10) - ww, max = (3 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}
		Fy.Clear();
		for (int i = Nx / 2 - ll, max = Nx / 2 + ll; i <= max; ++i)
		{
			Fy.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 4] = 1;
			}
		}

		Fx.Clear();
		for (int i = (5 * Ny / 10) - ww, max = (5 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 7] = 1;
			}
		}

		Fx.Clear();
		for (int i = (7 * Ny / 10) - ww, max = (7 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 10] = 1;
			}
		}

		Fx.Clear();
		for (int i = Ny - 2 * ww, max = F.GetLength(1); i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 13] = 1;
			}
		}


		// ------------------ LINE 142 func.m----------------- //
		Fx.Clear();
		for (int i = 1; i <= 2 * ww; ++i)
		{
			Fx.Add(i);
		}

		Fy.Clear();
		for (int i = Nx - 2 * ll; i <= F.GetLength(1); ++i)
		{
			Fy.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 2] = 1;
			}
		}

		Fx.Clear();
		for (int i = (3 * Ny / 10) - ww, max = (3 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}

		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 5] = 1;
			}
		}

		Fx.Clear();
		for (int i = (5 * Ny / 10) - ww, max = (5 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}
		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 8] = 1;
			}
		}

		Fx.Clear();
		for (int i = (7 * Ny / 10) - ww, max = (7 * Ny / 10) + ww; i <= max; ++i)
		{
			Fx.Add(i);
		}
		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 11] = 1;
			}
		}

		Fx.Clear();
		for (int i = Ny - 2 * ww, max = F.GetLength(1); i <= max; ++i)
		{
			Fx.Add(i);
		}
		for (int i = 0; i < Fx.Count; ++i)
		{
			for (int j = 0; j < Fy.Count; ++j)
			{
				F[Fx[i] - 1, Fy[j] - 1, 14] = 1;
			}
		}


		// ------------------ LINE 147 func.m----------------- //
		MathlabUtility.PowEach(F, 2);

		double FF = 0;
		for (int i = 0, imax = F.GetLength(0); i < imax; ++i)
		{
			for (int j = 0, jmax = F.GetLength(1); j < jmax; ++j)
			{
				FF += F[i, j, 7];
			}
		}

		MathlabUtility.Scale(F, 1 / FF);


		// ------------------ LINE 152 func.m----------------- //
		T_H = MathlabUtility.Matrix(15, 1, T_ambient);
		Power = MathlabUtility.Matrix(15, 1, 0);
		Heater_PWR = MathlabUtility.Matrix(15, 1, 0);
		hh1 = MathlabUtility.Matrix(15, 1, T_in_H - 273);
	}


	private void Update()
	{
		for (int l = 1; l <= 15; ++l)
		{
			int xIndex = (int)((Power[l - 1, 0] - 150) / 5);
			if ((Power[l - 1, 0] == 0) ||
			Ceramic_T_t_H[xIndex][Ceramic_T_t_H[xIndex].Length - 1] < hh1[l - 1, 0])
			{
				double[] row = Ceramic_T_t_C[Ceramic_T_t_C.GetLength(0) - 1];
				double hh1Val = hh1[l - 1, 0];
				double[] s2 = MathlabUtility.Add(row, -hh1Val);
				s2 = MathlabUtility.Abs(s2);
				double d2 = MathlabUtility.Min(s2);
				double n2 = MathlabUtility.Find(s2, (v) =>
				{
					return v == d2;
				}) + 1;

				if (n2 > 1780)
				{
					n2 = 1780;
				}
				T_H[l - 1, 0] = Ceramic_T_t_C[Ceramic_T_t_C.GetLength(0) - 1][(int)n2] + 273;
			}
			else if (Ceramic_T_t_H[xIndex][Ceramic_T_t_H[xIndex].Length - 1] > hh1[l - 1, 0])
			{
				double[] row = Ceramic_T_t_H[(int)((Power[l - 1, 0] - 150) / 5)];
				double hh1Val = hh1[l - 1, 0];
				double[] s1 = MathlabUtility.Add(row, -hh1Val);
				s1 = MathlabUtility.Abs(s1);
				double d1 = MathlabUtility.Min(s1);
				double n1 = MathlabUtility.Find(s1, (v) =>
				{
					return v == d1;
				}) + 1;

				if (n1 > 1780)
				{
					n1 = 1780;
				}

				T_H[l - 1, 0] = Ceramic_T_t_H[(int)((Power[l - 1, 0] - 150) / 5)][(int)(n1 + dt / 0.5 - 1)] + 273;
			}
		}


		// ------------------ LINE 187 func.m----------------- //
		hh1 = MathlabUtility.Add(T_H, -273);
		double[,] Heater_surface_temperature = MathlabUtility.Add(T_H, -273);
		double[,] Told = MathlabUtility.Matrix(T.GetLength(0), T.GetLength(1), T);
		for (int i = 2; i <= Ny; ++i)
		{
			for (int j = 2; j <= Nx; ++j)
			{
				for (int l = 1; l <= 15; ++l)
				{
					Heater_PWR[l - 1, 0] =
						sigma * F[i - 1, j - 1, l - 1] *
						(epsilon_H * A_H * Math.Pow(T_H[l - 1, 0], 4) - epsilon_S * dx * dy * (Math.Pow(T[i - 1, j - 1], 4)));
				}

				T[i - 1, j - 1] = dt * alpha * ((((T[i - 2, j - 1] - 2 * T[i - 1, j - 1] + T[i, j - 1]) / Math.Pow(dy, 2)) +
					((T[i - 1, j - 2] - 2 * T[i - 1, j - 1] + T[i - 1, j]) / Math.Pow(dx, 2))) +
					(1 / (conductivity * Lz)) * (h1 * (T_ambient - T[i - 1, j - 1]) + h2 * (T_ambient - T[i - 1, j - 1]) +
					(1 / (dx * dy)) * MathlabUtility.Sum(Heater_PWR))) + Told[i - 1, j - 1];

				T[0, 0] = dt * alpha * ((((T[1, 0] - T[0, 0]) / Math.Pow(dy, 2)) + ((T[0, 1] - T[0, 0]) / Math.Pow(dx, 2)))
					+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[0, 0]) + h2 * (T_ambient - T[0, 0]))) + Told[0, 0];

				T[0, Nx] = dt * alpha * ((((T[1, Nx] - T[0, Nx]) / Math.Pow(dy, 2)) + ((T[0, Nx - 1] - T[0, Nx]) / Math.Pow(dx, 2)))
					+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[0, Nx]) + h2 * (T_ambient - T[0, Nx]))) + Told[0, Nx];

				T[Ny, 0] = dt * alpha * ((((T[Ny - 1, 0] - T[Ny, 0]) / Math.Pow(dy, 2)) + ((T[Ny, 1] - T[Ny, 0]) / Math.Pow(dx, 2)))
					+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[Ny, 0]) + h2 * (T_ambient - T[Ny, 0]))) + Told[Ny, 0];

				T[Ny, Nx] = dt * alpha * ((((T[Ny, Nx - 1] - T[Ny, Nx]) / Math.Pow(dy, 2)) + ((T[Ny - 1, Nx] - T[Ny, Nx]) / Math.Pow(dx, 2)))
					+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[Ny, Nx]) + h2 * (T_ambient - T[Ny, Nx]))) + Told[Ny, Nx];

				// ------------------ LINE 214 func.m----------------- //
				if (i == 2)
				{

					T[0, j - 1] = dt * alpha * ((((T[i, j - 1] - T[0, j - 1]) / Math.Pow(dy, 2)) + ((T[0, j - 2] - 2 * T[0, j - 1] + T[0, j]) / Math.Pow(dx, 2)))
						+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[0, j - 1]) + h2 * (T_ambient - T[0, j - 1]) + (1 / (dx * dy)) * MathlabUtility.Sum(Heater_PWR))) + Told[0, j - 1];
				}

				if (i == Ny)
				{
					T[Ny, j - 1] = dt * alpha * ((((T[Ny - 1, j - 1] - T[Ny, j - 1]) / Math.Pow(dy, 2)) + ((T[Ny, j - 2] - 2 * T[Ny, j - 1] + T[Ny, j]) / Math.Pow(dx, 2)))
						+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[Ny, j - 1]) + h2 * (T_ambient - T[Ny, j - 1]) + (1 / (dx * dy)) * MathlabUtility.Sum(Heater_PWR))) + Told[Ny, j - 1];
				}

				if (j == Nx)
				{

					T[i - 1, Nx] = dt * alpha * ((((T[i - 2, Nx] - 2 * T[i - 1, Nx] + T[i, Nx]) / Math.Pow(dy, 2)) + ((T[i - 1, Nx - 1] - T[i - 1, Nx]) / Math.Pow(dx, 2)))
						+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[i - 1, Nx]) + h2 * (T_ambient - T[i - 1, Nx]) + (1 / (dx * dy)) * MathlabUtility.Sum(Heater_PWR))) + Told[i - 1, Nx];
				}

				if (j == 2)
				{
					T[i - 1, 0] = dt * alpha * ((((T[i - 2, 0] - 2 * T[i - 1, 0] + T[i, 0]) / Math.Pow(dy, 2)) + ((T[i - 1, 1] - T[i - 1, 0]) / Math.Pow(dx, 2)))
						+ (1 / (conductivity * Lz)) * (h1 * (T_ambient - T[i - 1, 0]) + h2 * (T_ambient - T[i - 1, 0]) + (1 / (dx * dy)) * MathlabUtility.Sum(Heater_PWR))) + Told[i - 1, 0];
				}
			}
		}


		// ------------------ LINE 239 func.m----------------- //
		double[,] T_a = MathlabUtility.Submatrix(T, new int[] { 0, T.GetLength(0) - 1 }, new int[] { 0, T.GetLength(1) - 1 });
		// T_actual not used
		// x_actual not used
		// y_actual not used

		// double[] p = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		double[] p = PowerInput;
		// double[] p = Sheets.Get("Power");
		Power = MathlabUtility.ToTwoDimension(p);

		double[,] Z11 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(0, 11), MathlabUtility.IncrementalArray(0, 19), false);
		double[,] Z12 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(0, 11), MathlabUtility.IncrementalArray(20, 39), false);
		double[,] Z13 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(0, 11), MathlabUtility.IncrementalArray(40, 59), false);

		double z1 = MathlabUtility.Mean(Z11) - 273.15;
		double z2 = MathlabUtility.Mean(Z12) - 273.15;
		double z3 = MathlabUtility.Mean(Z13) - 273.15;

		double[,] Z21 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(12, 23), MathlabUtility.IncrementalArray(0, 19), false);
		double[,] Z22 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(12, 23), MathlabUtility.IncrementalArray(20, 39), false);
		double[,] Z23 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(12, 23), MathlabUtility.IncrementalArray(40, 59), false);

		double z4 = MathlabUtility.Mean(Z21) - 273.15;
		double z5 = MathlabUtility.Mean(Z22) - 273.15;
		double z6 = MathlabUtility.Mean(Z23) - 273.15;

		double[,] Z31 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(24, 35), MathlabUtility.IncrementalArray(0, 19), false);
		double[,] Z32 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(24, 35), MathlabUtility.IncrementalArray(20, 39), false);
		double[,] Z33 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(24, 35), MathlabUtility.IncrementalArray(40, 59), false);

		double z7 = MathlabUtility.Mean(Z31) - 273.15;
		double z8 = MathlabUtility.Mean(Z32) - 273.15;
		double z9 = MathlabUtility.Mean(Z33) - 273.15;

		double[,] Z41 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(36, 47), MathlabUtility.IncrementalArray(0, 19), false);
		double[,] Z42 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(36, 47), MathlabUtility.IncrementalArray(20, 39), false);
		double[,] Z43 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(36, 47), MathlabUtility.IncrementalArray(40, 59), false);

		double z10 = MathlabUtility.Mean(Z41) - 273.15;
		double z11 = MathlabUtility.Mean(Z42) - 273.15;
		double z12 = MathlabUtility.Mean(Z43) - 273.15;

		double[,] Z51 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(48, 59), MathlabUtility.IncrementalArray(0, 19), false);
		double[,] Z52 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(48, 59), MathlabUtility.IncrementalArray(20, 39), false);
		double[,] Z53 = MathlabUtility.Submatrix(T_a, MathlabUtility.IncrementalArray(48, 59), MathlabUtility.IncrementalArray(40, 59), false);

		double z13 = MathlabUtility.Mean(Z51) - 273.15;
		double z14 = MathlabUtility.Mean(Z52) - 273.15;
		double z15 = MathlabUtility.Mean(Z53) - 273.15;

		double[,] zones_temp = new double[,] { { z1, z2, z3 }, { z4, z5, z6 }, { z7, z8, z9 }, { z10, z11, z12 }, { z13, z14, z15 } };
		// double[] temperatures = new double[] { z1, z2, z3, z4, z5, z6, z7, z8, z9, z10, z11, z12, z13, z14, z15 };

		HeatManagement.Instance.SetSheetTemperature(zones_temp); // should be used for sheet
		HeatManagement.Instance.SetTemperature(MathlabUtility.ToOneDimension(Heater_surface_temperature));
		HeatManagement.Instance.SetPower(p);
	}
}
