using System;
using System.Collections.Generic;
using UnityEngine;

public class DataSheets : MonoBehaviour
{
	public List<TextAsset> Sheets;
	public List<TextAsset> MatrixSheets;
	public Dictionary<string, double[]> Datas;
	public Dictionary<string, double[][]> MatrixDatas;

	private void Awake()
	{
		Datas = new Dictionary<string, double[]>();
		foreach(TextAsset asset in Sheets) {
			Datas[asset.name] = ToDoubleArray(asset.text);
		}

		MatrixDatas = new Dictionary<string, double[][]>();
	}

	public double[] Get(string name)
	{
		return Datas[name];
	}

	public double[][] GetMatrix(string name, int row, int col)
    {
		if(MatrixDatas.ContainsKey(name))
        {
			return MatrixDatas[name];
		}

		TextAsset asset = MatrixSheets.Find((s) =>
		{
			return s.name == name;
		});
		double[][] matrix = ToDoubleMatrix(asset.text, row, col);
		MatrixDatas[name] = matrix;
		return matrix;
	}

	private double[] ToDoubleArray(string text)
	{
		return Array.ConvertAll(text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries), Double.Parse);
	}

	private double[][] ToDoubleMatrix(string text, int row, int col)
    {
		double[][] matrix = new double[row][];
		string[] rows = text.Split(new char[] { '\n'  }, StringSplitOptions.RemoveEmptyEntries);
		for(int r = 0, rmax = rows.Length; r < rmax; ++r)
        {
			string rowString = rows[r];
			string[] cols = rowString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			matrix[r] = new double[cols.Length];
			for (int c = 0, cmax = cols.Length; c < cmax; ++c)
            {
				double val = Double.Parse(cols[c]);
				matrix[r][c] = val;
            }
        }

		return matrix;
	}
}
