using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NumberToWords
{
	public partial class MainForm : Form
	{
		private int myInputNumber = 0;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void Button1Click(object sender, EventArgs e)
		{
			myInputNumber = Convert.ToInt32(textBox1.Text);
			processNumber();
		}
		
		private void processNumber()
		{
			string myNumberString = myInputNumber.ToString();
			string stringBuffer = "";
			string messyWord = "";
			List<int> numberValueList = new List<int>{};
			
			for(int a = myNumberString.Length - 1; a >= 0; a--)
			{
				stringBuffer = myNumberString[a].ToString();
				numberValueList.Add(Convert.ToInt32(stringBuffer));
			}
			
			richTextBox1.Clear();
			
			if(myInputNumber > 10 && myInputNumber < 20)
			{
				richTextBox1.Text = richTextBox1.Text + (getShortWord(myInputNumber));
			}
			else
			{
				for(int b = 0; b < numberValueList.Count; b++)
				{
					messyWord = messyWord + getNumberWord(numberValueList[(numberValueList.Count  - 1) - b], (numberValueList.Count  - 1) - b) + " ";
				}
				
				fixNumberWord(messyWord);
			}
		}
		
		private void fixNumberWord(string wordToFix)
		{
			string numberWord = wordToFix;
			
			numberWord = numberWord.Replace("ten  one", "eleven");
			numberWord = numberWord.Replace("ten  two", "twelve");
			numberWord = numberWord.Replace("ten  three", "thirteen");
			numberWord = numberWord.Replace("ten  four", "fourteen");
			numberWord = numberWord.Replace("ten  five", "fifteen");
			numberWord = numberWord.Replace("ten  six", "sixteen");
			numberWord = numberWord.Replace("ten  seven", "seventeen");
			numberWord = numberWord.Replace("ten  eight", "eighteen");
			numberWord = numberWord.Replace("ten  nine", "nineteen");
			
			numberWord = numberWord.Replace("ten thousand one thousand", "eleven thousand");
			numberWord = numberWord.Replace("ten thousand two thousand", "twelve thousand");
			numberWord = numberWord.Replace("ten thousand three thousand", "thirteen thousand");
			numberWord = numberWord.Replace("ten thousand four thousand", "fourteen thousand");
			numberWord = numberWord.Replace("ten thousand five thousand", "fifteen thousand");
			numberWord = numberWord.Replace("ten thousand six thousand", "sixteen thousand");
			numberWord = numberWord.Replace("ten thousand seven thousand", "seventeen thousand");
			numberWord = numberWord.Replace("ten thousand eight thousand", "eighteen thousand");
			numberWord = numberWord.Replace("ten thousand night thousand", "nineteen thousand");
			
			while(countOccurances(numberWord, "thousand") > 1)
			{
				numberWord = ReplaceFirst(numberWord, "thousand", "");
			}
			
			while(countOccurances(numberWord, "million") > 1)
			{
				numberWord = ReplaceFirst(numberWord, "million", "");
			}
			
			while(countOccurances(numberWord, "billion") > 1)
			{
				numberWord = ReplaceFirst(numberWord, "billion", "");
			}
			
			numberWord = numberWord.Replace("  ", " ");
			
			richTextBox1.Text = numberWord;
		}
		
		private int countOccurances(string wordToScan, string wordToLookFor)
		{
			int myOccurances = 0;
			string[] lineBuffer = wordToScan.Split(' ');
			
			for(int a = 0; a < lineBuffer.Length; a++)
			{
				if(lineBuffer[a].Trim() == wordToLookFor.Trim())
				{
					myOccurances++;
				}
			}
			
			return myOccurances;
		}
		
		private string ReplaceFirst(string text, string search, string replace)
		{
  			int pos = text.IndexOf(search);
  			
  			if (pos < 0)
  			{
    				return text;
  			}
  			
  			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}
		
		private string getShortWord(int myNumber)
		{
			string myNumberWord = "";
			
			switch(myNumber)
			{
				case 11: myNumberWord = "eleven";
					break;
				case 12: myNumberWord = "twelve";
					break;
				case 13: myNumberWord = "thirteen";
					break;
				case 14: myNumberWord = "fourteen";
					break;
				case 15: myNumberWord = "fifteen";
					break;
				case 16: myNumberWord = "sixteen";
					break;
				case 17: myNumberWord = "seventeen";
					break;
				case 18: myNumberWord = "eighteen";
					break;
				case 19: myNumberWord = "nineteen";
					break;
			}
			
			return myNumberWord;
		}
		
		private string getNumberWord(int myNumber, int myIndex)
		{
			if(myNumber == 0)
			{
				return "";
			}
			
			string myWord = "";
			string numberWord = "";
			string placeWord = "";
			
			switch(myNumber)
			{
				case 1: if((myIndex -1)%3 == 0)
					{
						numberWord = "ten";
					}
					else
					{
						numberWord = "one";
					}
					break;
				case 2: if((myIndex -1)%3 == 0)
							{
								numberWord = "twenty";
							}
							else
							{
								numberWord = "two";
							}
					break;
				case 3: if((myIndex -1)%3 == 0)
							{
								numberWord = "thirty";
							}
							else
							{
								numberWord = "three";
							}
					break;
				case 4: if((myIndex -1)%3 == 0)
							{
								numberWord = "fourty";
							}
							else
							{
								numberWord = "four";
							}
					break;
				case 5: if((myIndex -1)%3 == 0)
							{
								numberWord = "fifty";
							}
							else
							{
								numberWord = "five";
							}
					break;
				case 6: if((myIndex -1)%3 == 0)
							{
								numberWord = "sixty";
							}
							else
							{
								numberWord = "six";
							}
					break;
				case 7: if((myIndex -1)%3 == 0)
							{
								numberWord = "seventy";
							}
							else
							{
								numberWord = "seven";
							}
					break;
				case 8: if((myIndex -1)%3 == 0)
							{
								numberWord = "eighty";
							}
							else
							{
								numberWord = "eight";
							}
					break;
				case 9: if((myIndex -1)%3 == 0)
							{
								numberWord = "ninety";
							}
							else
							{
								numberWord = "nine";
							}
					break;
			}
			
			switch(myIndex)
			{
				case 2: placeWord = "hundred";
					break;
				case 3: 
				case 4: placeWord = "thousand";
					break;
				case 5: placeWord = "hundred thousand";
					break;
				case 6: 
				case 7: placeWord = "million";
					break;
				case 8: placeWord = "hundred million";
					break;
				case 9: 
				case 10: placeWord = "billion";
					break;
			}
			
			myWord = numberWord + " " + placeWord;
			
			return myWord;
		}
	}
}
