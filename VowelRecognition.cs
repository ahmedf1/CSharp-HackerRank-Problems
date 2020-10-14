/*
Natural Language Understanding is the subdomain of Natural Language Processing where people 
used to design AI based applications have ability to understand the human languages. 
HashInclude Speech Processing team has a project named Virtual Assistant. For this project 
they appointed you as a data engineer (who has good knowledge of creating clean datasets by 
writing efficient code). As a data engineer your first task is to make vowel recognition 
dataset. In this task you have to find the presence of vowels in all possible substrings of 
the given string. For each given string you have to print the total number of vowels.

Input

First line contains an integer T, denoting the number of test cases.

Each of the next lines contains a string, string contains both lower case and upper case .

Output

Print the vowel sum
Answer for each test case should be printed in a new line.

Input Constraints

1<=T<=10

1<=|S|<=100000

*/


using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class VowelRecognition
{


    static void Main()
    {
        int length = Convert.ToInt16(Console.ReadLine());
        string line;
        long total;
        for(int j = 0; j < length; j++){
            total = 0;
            line = Console.ReadLine(); // read in string
            long stringLength = line.Length;
            for (int i = 0; i < stringLength; i++)
            {
                if(line[i] == 'a' || line[i] == 'e' || line[i] == 'i' || line[i] == 'o' || line[i] == 'u' || line[i] == 'A' || line[i] == 'E' || line[i] == 'I' || line[i] == 'O' || line[i] == 'U' ){
                    total += (stringLength-i) * (i+1);
                    // the above product returns the total number of times a vowel will appear in the remaining substrings ahead of first discovering the vowel
                }

            }
            

            Console.WriteLine(total);
        }
    }
}