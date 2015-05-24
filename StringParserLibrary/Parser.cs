using System;
using System.Collections.Generic;

/*
 * Author:      Ian McAdams
 * Written:     5/23/15
 * 
 * This library class provides methods to do the following:
 * 
 * 1. Accept a string of text as input
 * 2. Analyze that string of text and return the following information
 *       a.	Total count of words.
 *       b.	Total count of unique words.
 *       c.	Alphabetized list of unique words.
 *       d.	Total count of each unique word.
 * 
 */

namespace StringParserLibrary
{
    public class Parser
    {
        private string input;
        private string[] stringArr;
        private int totalWords;
        private int totalUniqueWords;
        private List<string> uniqueArr;
        private List<Tuple<string, int>> uniqueCount;

        public List<Tuple<string, int>> UniqueCount
        {
            get { return uniqueCount; }
            set { uniqueCount = value; }
        }

        public List<string> UniqueArr
        {
            get { return uniqueArr; }
            set { uniqueArr = value; }
        }

        public int TotalUniqueWords
        {
            get { return totalUniqueWords; }
            set { totalUniqueWords = value; }
        }

        public int TotalWords
        {
            get { return totalWords; }
            set { totalWords = value; }
        }

        public string[] StringArr
        {
            get { return stringArr; }
            set { stringArr = value; }
        }

        public string Input
        {
            get { return input; }
            set { input = value; }
        }


        //-------------------------------------------------------------
        //  Reads the user's input.
        //-------------------------------------------------------------
        public string Read()
        {
            //request the string
            Console.WriteLine("Please enter a string:\n");

            //increase the length limit in ReadLine method
            Console.SetIn(new System.IO.StreamReader(Console.OpenStandardInput(8192)));

            //get the string
            input = Console.ReadLine();

            //test this method
            //Console.WriteLine("\n\nThis is the input: {0}", input);

            return input;
        }

        //-------------------------------------------------------------
        //  Splits the string into words and puts them into an array.
        //-------------------------------------------------------------
        public string[] StringArray()
        {
            //parse the string and put the words in an array
            stringArr = input.Split(new Char[] { ' ', ',', '.', ':', ';', '?', '!', '\"', '\'', '(', ')', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            //return the array of 
            return stringArr;
        }

        //-------------------------------------------------------------
        //  Returns a total count of words.
        //-------------------------------------------------------------
        public int StringCount()
        {
            //get the length of the array
            totalWords = stringArr.Length;

            //test this method
            //Console.WriteLine("\nTotal count of words: {0}", totalWords);

            //return the total word count
            return totalWords;
        }

        //-------------------------------------------------------------
        //  Returns an alphabetized list of unique words.
        //-------------------------------------------------------------
        public List<string> UniqueWordList()
        {
            //sort the array
            Array.Sort(stringArr);

            //initialize the list
            uniqueArr = new List<string>();

            //loop through the array and add unique strings to a list
            for (int i = 0; i < stringArr.Length; i++)
            {
                string words = stringArr[i];
                uniqueArr.Add(words);

                for (int j = i + 1; j < stringArr.Length; j++)
                {                    
                    if (words.Equals(stringArr[j], StringComparison.InvariantCultureIgnoreCase))
                    {
                        i++;
                    }
                }   
            }

            //test this method
            //Console.WriteLine("\nAlphabetized list of unique words:");
            //for (int j = 0; j < uniqueArr.Count; j++)
            //{                
            //    Console.Write("{0} ", uniqueArr[j]);
            //}

            //return the alphabetized list of unique words
            return uniqueArr;
        }

        //-------------------------------------------------------------
        //  Returns a total count of unique words.
        //-------------------------------------------------------------
        public int TotalUniqueCount()
        {
            //get the length of the unique word list and assign it to the total unique word variable
            totalUniqueWords = uniqueArr.Count;

            //test this method
            //Console.WriteLine("\n\nTotal count of unique words: {0}", totalUniqueWords);

            //return the total unique word count
            return totalUniqueWords;
        }

        //-------------------------------------------------------------
        //  Returns a tuple list with the total count of each unique word.
        //-------------------------------------------------------------
        public List<Tuple<string, int>> EachWordCount()
        {
            //initialize the list
            uniqueCount = new List<Tuple<string, int>>();

            //loop through the alphabetized array of words and get each word and its count
            for (int i = 0; i < stringArr.Length; i++)
            {
                int count = 1;
                string words = stringArr[i];

                for (int j = i + 1; j < stringArr.Length; j++)
                {
                    if (words.Equals(stringArr[j], StringComparison.InvariantCultureIgnoreCase))
                    {
                        count++;
                        i++;
                    }
                }

                //add the word and its count to a tuple list
                uniqueCount.Add(Tuple.Create(words, count));
            }

            //test this method
            //foreach (Tuple<string, int> element in uniqueCount)
            //{
            //    Console.Write("\n{0}\n", element);
            //}

            //return a tuple list with the total count of each unique word
            return uniqueCount;
        }

        //method to run the program
        public static void RunProgram()
        {
            Parser p = new Parser();
            p.Read();
            p.StringArray();
            int totalWords = p.StringCount();
            List<string> uniqueArr = p.UniqueWordList();
            int totalUniqueWords = p.TotalUniqueCount();
            List<Tuple<string, int>> uniqueCount = p.EachWordCount();

            //print the results
            Console.WriteLine("\nTotal count of words: {0}", totalWords);

            Console.WriteLine("\nTotal count of unique words: {0}", totalUniqueWords);

            Console.WriteLine("\nAlphabetized list of unique words: ");
            foreach (string element in uniqueArr)
            {
                Console.WriteLine("{0}", element);
            }

            Console.WriteLine("\nTotal count of each unique word:");
            foreach (Tuple<string, int> element in uniqueCount)
            {
                Console.WriteLine("{0}", element);
            }

            Console.ReadLine();
        }
    }
}
