using System;
using System.IO;

namespace Document
{
    class Program
    {
        static void Main(string[] args)
        {

            bool again = true;
            Console.WriteLine(" ~~ Document ~~ \n");

            do
            {
                Console.WriteLine("What would you like to name this document?");

                string docName = Console.ReadLine();

                if (!docName.EndsWith(".txt"))
                {
                    docName += ".txt";  //add .txt if not there
                }

                Console.WriteLine("What would you like to put in your document?");

                string docContent = Console.ReadLine();

                try
                {
                    StreamWriter sw = new StreamWriter(docName); 

                    sw.WriteLine(docContent);

                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);   
                }
                finally
                {
                    Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", docName, docContent.Length);
                }

                again = GoAgain();  //new file creation

            } while (again == true);

        }

        static public bool GoAgain()
        {
            Console.WriteLine("\nWould you like to make another file?");
            Console.WriteLine("Y/N:");
            string response = Console.ReadLine();

            switch (response.ToUpper())   
            {
                case "Y":
                    return true;
                case "N":
                    Console.WriteLine("Exiting program.");
                    return false;
                default:
                    Console.WriteLine("That is not a valid response. Exiting program.");
                    return false;
            }
        }
    }
}
