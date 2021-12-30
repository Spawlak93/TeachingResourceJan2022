using System;
using Repository.Library;

namespace Repository.UI
{
    public class UserInterface
    {
        private readonly StreamingContentRepository _repo = new StreamingContentRepository();
        public void Run()
        {
            RunMenu();
        }

        //after building this discuss why making it private vs public. 
        private void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                //Add this later
                Console.Clear();


                Console.WriteLine(
                    "Enter the number of your selection:\n" +
                    "1. Show all streaming content\n" +
                    "2. Find content by title\n" +
                    "3. Add new content\n" +
                    "4. Remove streaming content by title\n" +
                    "5. Exit"
                );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    // might be worth pointing out difference between 1 and "1"

                    case "1":
                        //Todo Get all content
                        break;

                    case "2":
                        //Todo Content by title
                        break;

                    case "3":
                        //Todo add new content
                        break;

                    case "4":
                        //Remove content by title
                        break;

                    case "5":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        //what do we want to do with invalid input?
                        break;
                }

            }


        }


        //Add new
        private void CreateNewContent()
        {

        }
        //Add Movie/Show?

        //Get all

        //Get by title

        //Remove

        //Update?






    }
}