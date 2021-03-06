﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Text.RegularExpressions;
using static System.Int32;


namespace AdventOfCode_2020
{
    class Day2
    {
        private static GroupCollection _groups;


        /* public static List<int> ReadFile(string text)
        {
            int min, max;
            char looked_character;
            string sample;
            string sPattern = @"^(?<min>\d{2})-(?<max>\d{2})\s\w:\s?<sample>\w+)$";
            
            
            string input = @"17-19 p: pwpzpfbrcpppjppbmppp";
            Regex r = new Regex(sPattern,RegexOptions.None);
            Match m = r.Match(input);
            if (m.Success)
                Console.WriteLine(m.Result("${min}${max}"));
           // string[] lines = File.ReadAllLines(text);


            return result;
        }*/

        
        private static GroupCollection ExtractingGroupCollection(string input, string sPattern)
       {
           MatchCollection matches = Regex.Matches(input, sPattern);
        
           foreach (Match match in matches)
           {
               _groups = match.Groups;
               var minValue= match.Groups[1].Value;
               var maxValue = match.Groups[2].Value;
           }
           return _groups;
       }

        private static bool ValidPassword(string input, string sPattern)
        {
            var groups = ExtractingGroupCollection(input, sPattern);
            var min = Parse(groups[1].ToString());
            var max = Parse(groups[2].ToString());
            var c = Convert.ToChar(groups[3].ToString());
            var code = groups[4].ToString();
            var temp = 0;
            for (var i = 0; i < groups[4].Length; i++)
            {
                if (c == code[i]) temp++;
            }
            return (temp >= min && temp <= max) ? true : false;
        }

        private static bool ValidPasswordPartTwo(string input, string sPattern)
        {
            var groups = ExtractingGroupCollection(input, sPattern);
            var min = Parse(groups[1].ToString());
            var max = Parse(groups[2].ToString());
            char c = Convert.ToChar(groups[3].ToString());
            var code = groups[4].ToString();
            return (code[min-1] == c ^ code[max-1] == c) ? true : false;
        }

        public static int NumberOfValidPassowords(string input, string sPattern)
        {
            var result=0; string line;
            var file = new System.IO.StreamReader(input);
            while ((line = file.ReadLine()) != null)
            {
                if (ValidPassword(line, sPattern) == true) result++;
            }
            return result;
        }
        public static int NumberOfValidPassowordsPartTwo(string input, string sPattern) //change to overload?
        {
            var result = 0; string line;
            var file = new System.IO.StreamReader(input);
            while ((line = file.ReadLine()) != null)
            {
                if (ValidPasswordPartTwo(line, sPattern) == true) result++;
            }
            return result;
        }
    }
}

