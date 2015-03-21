using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NumberToWords
{
	public partial class MainForm : Form
	{
		private long myInputNumber = 0;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void processNumber()
		{
			string myNumberString = myInputNumber.ToString();
			string stringBuffer = "";
			string messyWord = "";
			List<int> numberValueList = new List<int>{};
			
			if(myNumberString == "0")
			{
				richTextBox1.Text = "Zero";
				return;
			}
			
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
		
		private string cleanTeenValues(string dirtyWords)
		{
			string dirtyMessage = dirtyWords;
			
			dirtyMessage = dirtyMessage.Replace("ten  one", "eleven");
			dirtyMessage = dirtyMessage.Replace("ten  two", "twelve");
			dirtyMessage = dirtyMessage.Replace("ten  three", "thirteen");
			dirtyMessage = dirtyMessage.Replace("ten  four", "fourteen");
			dirtyMessage = dirtyMessage.Replace("ten  five", "fifteen");
			dirtyMessage = dirtyMessage.Replace("ten  six", "sixteen");
			dirtyMessage = dirtyMessage.Replace("ten  seven", "seventeen");
			dirtyMessage = dirtyMessage.Replace("ten  eight", "eighteen");
			dirtyMessage = dirtyMessage.Replace("ten  nine", "nineteen");
			
			dirtyMessage = dirtyMessage.Replace("ten thousand one thousand", "eleven thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand two thousand", "twelve thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand three thousand", "thirteen thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand four thousand", "fourteen thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand five thousand", "fifteen thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand six thousand", "sixteen thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand seven thousand", "seventeen thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand eight thousand", "eighteen thousand");
			dirtyMessage = dirtyMessage.Replace("ten thousand nine thousand", "nineteen thousand");
			
			dirtyMessage = dirtyMessage.Replace("ten million one million", "eleven million");
			dirtyMessage = dirtyMessage.Replace("ten million two million", "twelve million");
			dirtyMessage = dirtyMessage.Replace("ten million three million", "thirteen million");
			dirtyMessage = dirtyMessage.Replace("ten million four million", "fourteen million");
			dirtyMessage = dirtyMessage.Replace("ten million five million", "fifteen million");
			dirtyMessage = dirtyMessage.Replace("ten million six million", "sixteen million");
			dirtyMessage = dirtyMessage.Replace("ten million seven million", "seventeen million");
			dirtyMessage = dirtyMessage.Replace("ten million eight million", "eighteen million");
			dirtyMessage = dirtyMessage.Replace("ten million nine million", "nineteen million");
			
			dirtyMessage = dirtyMessage.Replace("ten billion one billion", "eleven billion");
			dirtyMessage = dirtyMessage.Replace("ten billion two billion", "twelve billion");
			dirtyMessage = dirtyMessage.Replace("ten billion three billion", "thirteen billion");
			dirtyMessage = dirtyMessage.Replace("ten billion four billion", "fourteen billion");
			dirtyMessage = dirtyMessage.Replace("ten billion five billion", "fifteen billion");
			dirtyMessage = dirtyMessage.Replace("ten billion six billion", "sixteen billion");
			dirtyMessage = dirtyMessage.Replace("ten billion seven billion", "seventeen billion");
			dirtyMessage = dirtyMessage.Replace("ten billion eight billion", "eighteen billion");
			dirtyMessage = dirtyMessage.Replace("ten billion nine billion", "nineteen billion");
			
			dirtyMessage = dirtyMessage.Replace("ten trillion one trillion", "eleven trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion two trillion", "twelve trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion three trillion", "thirteen trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion four trillion", "fourteen trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion five trillion", "fifteen trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion six trillion", "sixteen trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion seven trillion", "seventeen trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion eight trillion", "eighteen trillion");
			dirtyMessage = dirtyMessage.Replace("ten trillion nine trillion", "nineteen trillion");
			
			dirtyMessage = dirtyMessage.Replace("ten quadrillion one quadrillion", "eleven quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion two quadrillion", "twelve quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion three quadrillion", "thirteen quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion four quadrillion", "fourteen quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion five quadrillion", "fifteen quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion six quadrillion", "sixteen quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion seven quadrillion", "seventeen quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion eight quadrillion", "eighteen quadrillion");
			dirtyMessage = dirtyMessage.Replace("ten quadrillion nine quadrillion", "nineteen quadrillion");
			
			return dirtyMessage;
		}
		
		private void fixNumberWord(string wordToFix)
		{
			string numberWord = wordToFix;
			
			numberWord = cleanTeenValues(numberWord);
			
			while(countOccurances(numberWord, "thousand") > 1)
			{
				numberWord = replaceFirst(numberWord, "thousand", "");
			}
			
			while(countOccurances(numberWord, "million") > 1)
			{
				numberWord = replaceFirst(numberWord, "million", "");
			}
			
			while(countOccurances(numberWord, "billion") > 1)
			{
				numberWord = replaceFirst(numberWord, "billion", "");
			}
			
			while(countOccurances(numberWord, "trillion") > 1)
			{
				numberWord = replaceFirst(numberWord, "trillion", "");
			}
			
			while(countOccurances(numberWord, "quadrillion") > 1)
			{
				numberWord = replaceFirst(numberWord, "quadrillion", "");
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
		
		private string replaceFirst(string text, string search, string replace)
		{
  			int pos = text.IndexOf(search);
  			
  			if (pos < 0)
  			{
    				return text;
  			}
  			
  			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}
		
		private string getShortWord(long myNumber)
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
				case 11: placeWord = "hundred billion";
					break;
				case 12: 
				case 13: placeWord = "trillion";
					break;
				case 14: placeWord = "hundred trillion";
					break;
				case 15: 
				case 16: placeWord = "quadrillion";
					break;
				case 17: placeWord = "hundred quadrillion";
					break;
			}
			
			myWord = numberWord + " " + placeWord;
			
			return myWord;
		}
		
		private void TextBox1TextChanged(object sender, EventArgs e)
		{
			try
			{
				myInputNumber = Convert.ToInt64(textBox1.Text);
				processNumber();
			}
			catch
			{
				richTextBox1.Text = "A really big number...";
			}
			finally
			{
			}
		}
	}
}
