﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Text.RegularExpressions;


namespace AdventOfCode_2020
{
    class Day2
    {
        
        //string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";


        public static readonly string textfilenameDay2 = @"C:\Users\damir\Desktop\Visual\AdventOfCode_2020\AdventOfCode_2020\Input1.txt";

        

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
       public static GroupCollection ExtractingGroupCollection(string input, string sPattern)
       {
           MatchCollection matches = Regex.Matches(input, sPattern);
           GroupCollection groups = null;
           foreach (Match match in matches)
           {
               groups = match.Groups;
               string minValue= match.Groups[1].Value;
               string maxValue = match.Groups[2].Value;

                Console.WriteLine("{0}, {1},{2},{3}", groups[1], groups[2], groups[3], groups[4]);
           }
           return groups;
       }

        /*public static bool ValidPasswordNumber(string input, string sPattern)
        {
            var groups = ExtractingGroupCollection(input, sPattern);
            string beeeeeka=
            int temp = 0;

            for (int i = 0; i < groups[4].Length; i++)
            {
                
            }


            return false;
        }*/
    }

}
