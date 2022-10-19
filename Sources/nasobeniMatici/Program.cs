using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace nasobeniMatici
{
	class Program
	{
		private static string rozmerMatice1String, rozmerMatice2String, typOperace;
		private static int radkyMatice1, radkyMatice2, sloupceMatice1, sloupceMatice2, cislo;

		public static bool dalsiVypocet { get; private set; }
		public static string chceteDalsiVypocet { get; private set; }
		public static string chceteVymazatKonzoli { get; private set; }

		static void Main(string[] args)
		{
			dalsiVypocet = false;
			chceteDalsiVypocet = "ne";
			chceteVymazatKonzoli = "ano";

			do
			{
				try
				{
					if (!dalsiVypocet)
					{
						Console.WriteLine("Created by Matej Tydlitat (CZ) all rights reserved by Matej Tydlitat a.s.\n");
						Console.WriteLine("Vitejte v programu pro nasobeni matici. Program nasobi pouze dve matice najednou. Vstup potvrdite entrem.\n");
					}

					dalsiVypocet = false;
					chceteDalsiVypocet = "ne";
					chceteVymazatKonzoli = "ano";

					Console.WriteLine("Pro nasobeni dvou matic -> napiste 0");
					Console.WriteLine("Pro nasobeni matice cislem -> napiste 1");
					Console.WriteLine("Pro secteni dvou matic -> napiste 2");
					Console.WriteLine("Pro odecteni dvou matic -> napiste 3");
					Console.WriteLine("Pro umocneni matice na druhou -> napiste 4");
					Console.Write("Typ operace: ");
					typOperace = Console.ReadLine().Trim();
					char typOperacZnak = Convert.ToChar(typOperace);

					switch (typOperacZnak)
					{
						case '0':
							nacti2Rozmery();

							if (sloupceMatice1 == radkyMatice2)
							{
								int[,] matice1_0 = new int[radkyMatice1, sloupceMatice1];
								int[,] matice2_0 = new int[radkyMatice2, sloupceMatice2];

								naplnMatice(ref matice1_0, "A", radkyMatice1, sloupceMatice1);
								Console.WriteLine();
								naplnMatice(ref matice2_0, "B", radkyMatice2, sloupceMatice2);

								int[,] vysledek0 = nasob2Matice(matice1_0, matice2_0);
								vypisVysledek(vysledek0);
							}
							else
							{
								Console.WriteLine("\nToto nasobeni je nedefinovane, nemuze byt provedeno.");
							}
							break;

						case '1':
							nactiRozmer();

							int[,] matice_1 = new int[radkyMatice1, sloupceMatice1];
							naplnMatice(ref matice_1, "A", radkyMatice1, sloupceMatice1);

							Console.Write("\nCislo kterym bude nasobena matice: ");
							cislo = Convert.ToInt32(Console.ReadLine().Trim());

							int[,] vysledek1 = nasobMaticiCislem(matice_1, cislo);
							vypisVysledek(vysledek1);
							break;

						case '2':
							nacti2Rozmery();

							if (rozmerMatice1String == rozmerMatice2String)
							{
								int[,] matice1_2 = new int[radkyMatice1, sloupceMatice1];
								int[,] matice2_2 = new int[radkyMatice2, sloupceMatice2];

								naplnMatice(ref matice1_2, "A", radkyMatice1, sloupceMatice1);
								Console.WriteLine();
								naplnMatice(ref matice2_2, "B", radkyMatice2, sloupceMatice2);

								int[,] vysledek2 = secti2Matice(matice1_2, matice2_2);
								vypisVysledek(vysledek2);
							}
							else
							{
								throw new Exception("Toto nasobeni je nedefinovane, nemuze byt provedeno.");
							}
							break;

						case '3':
							nacti2Rozmery();

							if (rozmerMatice1String == rozmerMatice2String)
							{
								int[,] matice1_3 = new int[radkyMatice1, sloupceMatice1];
								int[,] matice2_3 = new int[radkyMatice2, sloupceMatice2];

								naplnMatice(ref matice1_3, "A", radkyMatice1, sloupceMatice1);
								Console.WriteLine();
								naplnMatice(ref matice2_3, "B", radkyMatice2, sloupceMatice2);

								int[,] vysledek3 = odecti2Matice(matice1_3, matice2_3);
								vypisVysledek(vysledek3);
							}
							else
							{
								throw new Exception("Toto nasobeni je nedefinovane, nemuze byt provedeno.");
							}
							break;

						case '4':
							nactiRozmer();

							Console.WriteLine();
							int[,] matice1_4 = new int[radkyMatice1, sloupceMatice1];
							naplnMatice(ref matice1_4, "A", radkyMatice1, sloupceMatice1);

							int[,] vysledek4 = umocniMaticiNaDruhou(matice1_4);
							vypisVysledek(vysledek4);
							break;

						default:
							break;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("\nDoslo k neocekavane vyjimce a spadnuti programu, muze byt zpusobeno spatne zadanym vstupem.");
					Console.WriteLine("Chybova hlazka (nekdy v anglictine): " + e.Message);
				}
				finally
				{
					finalne();
				}
			} while (dalsiVypocet);
		}

		private static void naplnMatice(ref int[,] maticeProNaplneni, string nazevMatice, int radkyMatice, int sloupceMatice)
		{
			for (int i = 0; i < radkyMatice; i++)
			{
				for (int j = 0; j < sloupceMatice; j++)
				{
					Console.Write("Zadejte cislo v matici {2} na pozici {0},{1}: ", i + 1, j + 1, nazevMatice);
					int cislo = Convert.ToInt32(Console.ReadLine().Trim());
					maticeProNaplneni[i, j] = cislo;
				}
			}
		}

		private static int[,] nasob2Matice(int[,] matice1, int[,] matice2)
		{
			int[,] matice2Sloupce = new int[sloupceMatice2, radkyMatice2];
			int[,] vysledek = new int[radkyMatice1, sloupceMatice2];

			for (int i = 0; i < sloupceMatice2; i++)
			{
				for (int j = 0; j < radkyMatice2; j++)
				{
					matice2Sloupce[i, j] = matice2[j, i];
				}
			}

			for (int i = 0; i < vysledek.GetLength(0); i++)
			{
				for (int j = 0; j < vysledek.GetLength(1); j++)
				{
					int vysledekNaIndexu = 0;
					for (int k = 0; k < sloupceMatice1; k++)
					{
						vysledekNaIndexu += matice1[i, k] * matice2Sloupce[j, k];
					}
					vysledek[i, j] = vysledekNaIndexu;
				}
			}

			return vysledek;
		}

		private static int[,] nasobMaticiCislem(int[,] matice, int cislo)
		{
			int[,] vysledek = matice;

			for (int i = 0; i < vysledek.GetLength(0); i++)
			{
				for (int j = 0; j < vysledek.GetLength(1); j++)
				{
					vysledek[i, j] = matice[i, j] * cislo;
				}
			}

			return vysledek;
		}

		private static int[,] secti2Matice(int[,] matice1, int[,] matice2)
		{
			int[,] vysledek = matice1;

			for (int i = 0; i < vysledek.GetLength(0); i++)
			{
				for (int j = 0; j < vysledek.GetLength(1); j++)
				{
					vysledek[i, j] = matice1[i, j] + matice2[i, j];
				}
			}

			return vysledek;
		}

		private static int[,] odecti2Matice(int[,] matice1, int[,] matice2)
		{
			int[,] vysledek = matice1;

			for (int i = 0; i < vysledek.GetLength(0); i++)
			{
				for (int j = 0; j < vysledek.GetLength(1); j++)
				{
					vysledek[i, j] = matice1[i, j] - matice2[i, j];
				}
			}

			return vysledek;
		}

		private static int[,] umocniMaticiNaDruhou(int[,] matice)
		{
			int[,] vysledek = matice;

			for (int i = 0; i < vysledek.GetLength(0); i++)
			{
				for (int j = 0; j < vysledek.GetLength(1); j++)
				{
					vysledek[i, j] *= vysledek[i, j];
				}
			}

			return vysledek;
		}

		private static void nactiRozmer()
		{
			Console.Write("\nZadejte rozmer prvni matice (ve formatu radky,sloupce napr.: 2x2): ");
			rozmerMatice1String = Console.ReadLine().ToLower();

			string delitko = rozmerMatice1String.Contains("x") ? "x" : ",";

			radkyMatice1 = Convert.ToInt32(rozmerMatice1String.Split(delitko)[0].Trim());
			sloupceMatice1 = Convert.ToInt32(rozmerMatice1String.Split(delitko)[1].Trim());

			Console.WriteLine();
		}

		private static void nacti2Rozmery()
		{
			Console.Write("\nZadejte rozmer prvni matice (ve formatu radky,sloupce napr.: 2x2): ");
			rozmerMatice1String = Console.ReadLine().ToLower();
			Console.Write("Zadejte rozmer druhe matice (ve formatu radky,sloupce napr.: 2x2): ");
			rozmerMatice2String = Console.ReadLine().ToLower();

			string delitko1 = rozmerMatice1String.Contains("x") ? "x" : ",";
			string delitko2 = rozmerMatice2String.Contains("x") ? "x" : ",";

			radkyMatice1 = Convert.ToInt32(rozmerMatice1String.Split(delitko1)[0].Trim());
			sloupceMatice1 = Convert.ToInt32(rozmerMatice1String.Split(delitko1)[1].Trim());
			radkyMatice2 = Convert.ToInt32(rozmerMatice2String.Split(delitko2)[0].Trim());
			sloupceMatice2 = Convert.ToInt32(rozmerMatice2String.Split(delitko2)[1].Trim());

			Console.WriteLine();
		}

		private static void vypisVysledek(int[,] matice)
		{
			Console.WriteLine("\nRozmer vysledne matice: {0}x{1}", matice.GetLength(0), matice.GetLength(1));
			Console.WriteLine("Vysledna matice:\n");

			for (int i = 0; i < matice.GetLength(0); i++)
			{
				for (int j = 0; j < matice.GetLength(1); j++)
				{
					Console.Write($"{matice[i, j]},");
				}
				Console.WriteLine();
			}
		}

		private static void finalne()
		{
			try
			{
				Console.Write("\nChcete provest dalsi vypocet? (ano/ne): ");
				chceteDalsiVypocet = Console.ReadLine().ToLower();

				if (chceteDalsiVypocet == "ano" || chceteDalsiVypocet == "a" || chceteDalsiVypocet == "yes" || chceteDalsiVypocet == "y")
				{
					dalsiVypocet = true;
					Console.Write("Chcete vymazat vsechen text na konzoli? (ano/ne): ");
					chceteVymazatKonzoli = Console.ReadLine().ToLower();

					if (chceteVymazatKonzoli == "ano" || chceteVymazatKonzoli == "a" || chceteVymazatKonzoli == "yes" || chceteVymazatKonzoli == "y")
					{
						Console.Clear();
					}
					else if (chceteVymazatKonzoli == "ne" || chceteVymazatKonzoli == "n" || chceteVymazatKonzoli == "no") 
					{
						Console.WriteLine();
					}
					else
					{
						throw new Exception("Spatne zadany vztup.");
					}
				}
				else if (chceteDalsiVypocet == "ne" || chceteDalsiVypocet == "n" || chceteDalsiVypocet == "no") 
				{ 
					// Aplikace se vypne
				}
				else
				{
					throw new Exception("Spatne zadany vztup.");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("\nDoslo k neocekavane vyjimce a spadnuti programu, muze byt zpusobeno spatne zadanym vstupem.");
				Console.WriteLine("Chybova hlazka (nekdy v anglictine): " + e.Message);
				finalne();
			}
		}
	}
}