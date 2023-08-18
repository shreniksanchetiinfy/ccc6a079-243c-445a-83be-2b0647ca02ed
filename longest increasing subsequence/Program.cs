using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_increasing_subsequence
{
    /// <summary>
    /// Class to get the sequence list and count
    /// </summary>
    class SequenceAndCountMapping
    {
        public string sequenceList;
        public int countOfNumbers;
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = string.Empty;

            // As Console.ReadLine has limitation to enter the limted charecter I have created this function to have unlimited input charecters
            while (true)
            {
                ConsoleKeyInfo keyIn = Console.ReadKey();
                if (keyIn.Key.ToString().ToUpper() == "ENTER")
                    break;
                else
                {

                    input += keyIn.KeyChar.ToString();
                }
            }
            
            // Code to split the input with spaces
            List<string> inputList =  input.Trim().Split(' ').ToList();
            //check if all the entered are numbers
            List<SequenceAndCountMapping> interimOutput = new List<SequenceAndCountMapping>();
            SequenceAndCountMapping singleOutput = new SequenceAndCountMapping();
            // 6 1 5 9 2 12 33 45 12 34 56 78 90

            interimOutput = getSeq(inputList, 0, interimOutput);

            displayOutput(interimOutput);

            Console.ReadKey();
        }

        /// <summary>
        /// Methods to provide the output
        /// </summary>
        /// <param name="outPut"></param>
        private static void displayOutput(List<SequenceAndCountMapping> outPut)
        {
            string seqToBePrinted = string.Empty;
            int maxCount = 0;
            Console.WriteLine();
            Console.WriteLine("``` OUTPUT ```");
            foreach(SequenceAndCountMapping crntOutput in outPut)
            {
                if (maxCount < crntOutput.countOfNumbers)
                    seqToBePrinted = crntOutput.sequenceList;
            }

            Console.WriteLine(seqToBePrinted);
            
        }

        public static List<SequenceAndCountMapping> getSeq(List<string> inputList, int currentIndex, List<SequenceAndCountMapping> outPut)
        {
            
            int currentNumber = Convert.ToInt32(inputList[currentIndex]);
            int nextNumber = Convert.ToInt32(inputList[currentIndex + 1]);
            SequenceAndCountMapping currentOutput;
            int currentSequenceCount = 0;
            int maxCout = 0;

            string list = string.Empty;
            while(currentIndex <= inputList.Count - 1)
            {
                currentNumber = Convert.ToInt32(inputList[currentIndex]);
                if(!((currentIndex + 1) > inputList.Count - 1))
                    nextNumber = Convert.ToInt32(inputList[currentIndex + 1]);
                else
                {
                    if(currentNumber > Convert.ToInt32(inputList[currentIndex -1]))
                    {
                        currentSequenceCount += 1;

                        list += currentNumber.ToString();

                        currentOutput = new SequenceAndCountMapping();
                        currentOutput.sequenceList = list;
                        currentOutput.countOfNumbers = currentSequenceCount;

                        if (currentOutput.countOfNumbers > maxCout)
                        {
                            maxCout = currentOutput.countOfNumbers;
                            outPut.Add(currentOutput);
                        }
                        
                        list = string.Empty;
                        currentSequenceCount = 0;
                        break;
                    }
                }
                if (currentNumber < nextNumber)
                {
                    list += currentNumber.ToString() + " ";
                    currentSequenceCount += 1;
                }
                else
                {

                    currentSequenceCount += 1;
                    list += currentNumber.ToString();

                    currentOutput = new SequenceAndCountMapping();
                    currentOutput.sequenceList = list;
                    currentOutput.countOfNumbers = currentSequenceCount;

                    if (currentOutput.countOfNumbers > maxCout)
                    {
                        maxCout = currentOutput.countOfNumbers;
                        outPut.Add(currentOutput);
                    }

                    list = string.Empty;
                    currentSequenceCount = 0;
                }
                currentIndex += 1;
            }


            
            return outPut;
        }
    }
}
