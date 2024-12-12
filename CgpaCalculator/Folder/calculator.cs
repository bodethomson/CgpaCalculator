using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.XPath;
using static System.Formats.Asn1.AsnWriter;

namespace CgpaCalculator.Folder
{
    public static class calculator
    {

        public static void Courses()
        {
            string name = Name("name");

            Console.WriteLine();

            int numCourses = 0;
            bool looping = true;
            while (looping)
            {
                try
                {
                    Console.Write("How many are your courses: ");
                    numCourses = Convert.ToInt32(Console.ReadLine());
                    looping = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Must be integer");
                }
            }

            string[] course = new string[numCourses];
            int[] score = new int[numCourses];
            int[] unitCourse = new int[numCourses];
            for (int i = 0; i < course.Length; i++)
            {
                bool success = true;
                bool access = true;
                Console.Write($"Enter Course {i + 1}: ");
                course[i] = Console.ReadLine();
                while (success)
                {
                    try
                    {
                        Console.Write($"Enter the course unit: ");
                        unitCourse[i] = Convert.ToInt32(Console.ReadLine());
                        success = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("*Must be Integer*");
                    }
                }
                while (access)
                {
                    try
                    {
                        Console.Write($"Enter your score: ");
                        score[i] = Convert.ToInt32(Console.ReadLine());
                        access = false;


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("*Must be an Integer*");
                   
                    }

                }

            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"| COURSES | SCORES |  COURSE UNIT  |   GRADE  |  POINTS  |");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var (courses, unit, scores) in course.Zip(unitCourse, score)) 
            {
               
                Console.WriteLine($"|   {courses.ToUpper()}   |   {scores}   |       {unit}       |      {GetData(scores)}    |   {Calc(GetGrade, scores, unit)}    |");
                Console.WriteLine("--------------------------------------------------------");
            }
            sumUnit(unitCourse, name);
            
        }

        public static void sumUnit(int[] unitCourse, string name)
        {
            int courseTotal = 0;
            foreach (int course in unitCourse)
            {
                courseTotal += course;
            }
            Console.WriteLine($"HELLO {name.ToUpper()}, Your Cummulative Grade Point is {courseTotal}"); 

        }

        /*static void sumPoint(Func<int, int> Calc, numCourses)
        {
            int sum = 0;
            for(int i = 0; i < numCourses.Length; i++ )
        }*/


        public static int Calc(Func<int, int> GetGrade, int score, int unitCourse)
        {
            int answer = GetGrade(score) * unitCourse;
            return answer;
            
        }
        

        static string Name(string message)
        {
            Console.Write($"Enter {message}: ");
            return Console.ReadLine();

        }

        public static char GetData(int score)
        {
            if ((score >= 70) && (score <= 100)) 
            {
                return 'A';
            }
            else if ((score >= 60) && (score <= 69))
            {
                 return 'B';
            }
            else if ((score >= 50 ) && (score <= 59))
            {
                return 'C';
            }
            else if ((score >= 40) && (score <= 49))
            {
                return 'D';
            }
            else if ((score >= 35) && (score <= 39))
            {
                return 'E';
            }
            else if ((score >= 0) && (score <= 34))
            {
                return 'F';
            }
            return 'F';
        }

        public static int GetGrade(int score)
        {
            if ((score >= 70) && (score <= 100))
            {
                return 5;
            }
            else if ((score >= 60) && (score <= 69))
            {
                return 4;
            }
            else if ((score >= 50) && (score <= 59))
            {
                return 3;
            }
            else if ((score >= 40) && (score <= 49))
            {
                return 2;
            }
            else if ((score >= 35) && (score <= 39))
            {
                return 1;
            }
            else if ((score >= 0) && (score <= 34))
            {
                return 0;
            }
            return 0;
        }

    }
}
