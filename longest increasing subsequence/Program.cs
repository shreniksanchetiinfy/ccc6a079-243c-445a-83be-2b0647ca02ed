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

            input = getInput();

            //check if any charecters are there in the input if yes then exit the code
            bool invalidInput = input.Any(x => x != ' ' && !char.IsDigit(x));
            if (invalidInput)
            {
                Console.WriteLine();
                Console.WriteLine("This is an invalid input, please enter only numbers with spaces");
                Console.ReadKey();
                Environment.Exit(0);
            }

            // Code to split the input with spaces
            List<string> inputList =  input.Trim().Split(' ').ToList();
            //check if all the entered are numbers
            List<SequenceAndCountMapping> interimOutput = new List<SequenceAndCountMapping>();

            // Get the list of optimized possibility if outcomes
            interimOutput = getSeq(inputList, 0, interimOutput);

            displayOutput(interimOutput);
            Console.ReadKey();
        }

        /// <summary>
        /// Method to get user input
        /// As Console.ReadLine has limitation to enter the limted charecter I have created this function to have unlimited input charecters
        /// </summary>
        /// <returns></returns>
        private static string getInput()
        {
            Console.WriteLine("Please enter your numeric input");
            string input = string.Empty;
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
            return input;
        }


        /// <summary>
        /// Method to provide the output i.e. 1st maximum Longest increasing subsequence
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

        /// <summary>
        /// Method to scan for Longest increasing subsequence
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="currentIndex"></param>
        /// <param name="outPut"></param>
        /// <returns></returns>
        public static List<SequenceAndCountMapping> getSeq(List<string> inputList, int currentIndex, List<SequenceAndCountMapping> outPut)
        {

            int currentNumber;
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
                    // Handle last number
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
