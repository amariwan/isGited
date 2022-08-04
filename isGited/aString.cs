using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace isGited
{
	class AString
	{
		public int Length(string value)
		{
			int i = 0;
			foreach (char s in value)
			{
				i++;
			}
			return i;
		}

		public string Copy(string values)
		{
			char[] value_coped = new char[Length(values)];
			for (int i = 0; i < Length(values); i++)
			{
				value_coped[i] = values[i];
			}
			return new string(value_coped);
		}

		public bool Comparison(string values, string values2)
		{
			int len1 = Length(values);
			int len2 = Length(values2);

			if (len1 != len2)
			{
				return false;
			}

			for (int i = 0; i < len1; i++)
			{
				if (values[i] != values2[i])
				{
					return false;
				}
			}
			return true;
		}

		public string SubString(string value, int start, int len)
		{
			string name = "";
			int start_len = start + len;
			if (Length(value) < start_len || len <= 0 || start <= 0)
			{
				return "Fehler";
			}

			for (int x = 0; x < len; x++)
			{
				name += value[start + x];
			}

			return name;
		}

		public int Search(string value, string suchWort, int start_point_input)
		{
			int SWLen = Length(suchWort);
			int VALen = Length(value);
			int x = 0;
			int start_point = -1;
			for (int i = start_point_input; i < VALen; i++)
			{
				if (x < SWLen)
				{
					if (value[i] == suchWort[x])
					{
						if (SWLen - 1 == x)
						{
							return i - x;
						}
						x++;
					}
					else
					{
						x = 0;
						start_point = -1;
					}
				}
			}
			return start_point;
		}

		public string Ersetzen(string value, string suchWort, string ersetzenWort)
		{
			int SWLen = Length(suchWort);
			int VALen = Length(value);
			int x = 0;
			int y = 0;
			string answer = "";
			int start_point = 0;
			int[] points = new int[VALen];
			for (int i = 0; i < VALen; i++)
			{
				start_point = Search(value, suchWort, x);
				if (start_point != -1)
				{
					x = start_point + SWLen;
					points[y] = start_point;
					y++;
				}
			}

			y = 0;
			x = 0;
			for (int i = 0; i < VALen; i++)
			{
				if (i == points[y])
				{
					answer += ersetzenWort;
					y++;
					i += SWLen - 1;
				}
				else
				{
					answer += value[i];
				}
			}
			return answer;
		}

		// wenn !§"$§&
		public string CheckString(string value)
		{
			string answer = "";
			string meull = "";

			for (int i = 0; i < Length(value); i++)
			{
				if (i == 0 || Length(value) - 1 == i)
				{
					if (value[i] >= 'a' && value[i] <= 'z' || value[i] >= 'A' && value[i] <= 'Z')
					{
						answer += value[i];
					}
				}
				else
				{
					meull += value[i];
				}
			}
			return answer;
		}

		public string changeCase(string value, string type)
		{
			string answer = "";
			string upper = "";
			int d = 0;
			char c = ' ';
			for (int i = 0; i < Length(value); i++)
			{
				upper += value[i];
				d = (int)value[i];
				int s = d;

				if (type == "Lower" && d >= 65 && d <= 90)
				{
					s = d + 32;
				}
				else if (type == "Upper" && d >= 97 && d <= 122)
				{
					s = d - 32;
				}
				c = (char)s;
				answer += c;
			}
			return answer;
		}
		
		public string ToLower(string value)
		{
			return changeCase(value, "Lower");
		}
		
		public string ToUpper(string value)
		{
			return changeCase(value, "Upper");
		}

		public bool Contains(string value, string suchWort)
		{
			int VLen = Length(value);
			int SWLen = Length(suchWort);
			int y = 0;
			int x = 0;

			for (int i = 0; i < Length(value); i++)
			{
				if (x < SWLen)
				{
					if (value[i] == suchWort[x])
					{
						if (SWLen - 1 == x)
						{
							y++;
							x = 0;
							return true;
						}
						x++;
					}
					else
					{
						x = 0;
					}
				}
			}
			return false;
		}

		public string Reverse(string value)
		{
			string answer = "";
			int VALen = Length(value) - 1;

			for (int i = VALen; i >= 0; i--)
			{
				answer += value[i];
			}
			return answer;
		}
	}
}