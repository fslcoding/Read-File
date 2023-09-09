using System;
using System.IO;//This imports a library of code which allows you to read in data from an external file

class MainClass 
{
  //This file is stored in your bin>debug folder within your solution on left hand side
  static string path = "students.csv";
  
  //This create a 1D array capable of storing all user records from the student.csv file
  static string[] users = new string[File.ReadAllLines(path).Length];
  
  //This checks the number of students records in the users array
  static int noStudents = users.Length;
  
  //The number of columns (fields) in the file.
  static int numberOfBitsOfInfo = 2;
  
  //This 2D array will store the student details in working memory (RAM) while the program is running.
  static string[,] students = new string[noStudents, numberOfBitsOfInfo];// 
  
  //This is teh executablepart of the program
  public static void Main (string[] args) 
  {
    //This populates the student list with the data from the students.csv file
    readInUsers();

    for(int i=0;i<students.GetLength(0);i++)
      {
        for(int j=0;j<students.GetLength(1);j++)
        {
          Console.Write(students[i,j]+",");
        }
        Console.WriteLine();
      }
  }

  static void readInUsers()
  {
    //A try...catch will ensure any exceptions are 'caught' and handled appropriately.
    try
    {
      //This reads in the users into an array from file path location specified
      users = File.ReadAllLines(path);
    }

    //FileNotFoundException is derived from the Exception class
    catch (FileNotFoundException fnfex)
    {
      Console.WriteLine("File not found. Type any ket to continue" + fnfex.ToString());
    }
    //This array will store each students details split during the outer for loop
    string[] tempStudent = new string[numberOfBitsOfInfo];

    //This nested for loop will iterate through the tempstudent populating the students array based on the contents of the tempStudent
    for (int i = 0; i < noStudents; i++)
    {
      tempStudent = users[i].Split(',');
      for(int j = 0; j < numberOfBitsOfInfo; j++)
          {
            students[i, j] = tempStudent[j];
          }
    }
  }
}
