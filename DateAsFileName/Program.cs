using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DateAsFileName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  =====================================");
            Console.WriteLine("    DateAsFileName");
            Console.WriteLine("    Copyright 2019 Genta Ito");
            Console.WriteLine("  =====================================");
            Console.WriteLine("");
            Console.WriteLine("    ◎説明");
            Console.WriteLine("      ビデオのファイル名などを日付+時刻の形式に変換します。");
            Console.WriteLine("");

			string[] files = System.Environment.GetCommandLineArgs();
			List<DateTime> listDT = new List<DateTime>();
			HashSet<DateTime> hsDT = new HashSet<DateTime>();

            Console.WriteLine("  処理するファイルは以下の" + (files.Length - 1).ToString() + "個です ...");
            for (int i = 1; i < files.Length; i++)
            {
                Console.WriteLine("    " + files[i]);
				DateTime dt = File.GetLastWriteTime(files[i]);
				listDT.Add(dt);
				hsDT.Add(dt);
			}
			if (listDT.Count > hsDT.Count)
			{
				Console.WriteLine("  重複するタイムスタンプをもつファイルがあります。");
				Console.WriteLine("  このプログラムでは処理不可能です。");
				Console.WriteLine("  終了します");
				Console.WriteLine("  何かキーを押してください");
				Console.ReadKey();
				Environment.Exit(0);
			}
			else
			{
				Console.WriteLine("  続行するには何かキーを押してください ...");
				Console.ReadKey();
				Console.WriteLine("");
			}

            for (int i = 1; i < files.Length; i++)
            {
				string folder = Path.GetDirectoryName(files[i]);
				string ext = Path.GetExtension(files[i]);
				DateTime dt = File.GetLastWriteTime(files[i]);
				string newName = dt.ToString("yyyyMMddHHmmss") + ext;
				string newPath = folder + "\\" + newName;
				File.Move(files[i], newPath);
				Console.WriteLine("  " + files[i] + "を");
				Console.WriteLine("    " + newPath+ "に変更しました。");
				Console.WriteLine("");
			}

			Console.WriteLine("  処理が完了しました。");
			Console.WriteLine("  終了するには何かキーを押してください ...");
			Console.ReadKey();
			Console.WriteLine("");
		}
    }
}
