using System;
using System.Collections.Generic;
using Repository.Library;
using Repository.UI.Consoles;

namespace Repository.UI
{
    public class UserInterface
    {
        private IConsole _console;
        private readonly StreamingContentRepository _repo = new StreamingContentRepository();
        public UserInterface(IConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            SeedContentList();
            RunMenu();
        }

        //after building this discuss why making it private vs public. 
        private void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                //Add this later
                _console.Clear();


                _console.WriteLine(
                    "Enter the number of your selection:\n" +
                    "1. Show all streaming content\n" +
                    "2. Find content by title\n" +
                    "3. Add new content\n" +
                    "4. Remove streaming content by title\n" +
                    "5. Exit"
                );

                string userInput = _console.ReadLine();

                switch (userInput)
                {
                    // might be worth pointing out difference between 1 and "1"

                    case "1":
                        //Todo Get all content
                        ShowAllContent();
                        break;

                    case "2":
                        //Todo Content by title
                        ShowContentByTitle();
                        break;

                    case "3":
                        //Todo add new content
                        CreateNewContent();
                        break;

                    case "4":
                        //Remove content by title
                        RemoveContentFromRepo();
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

            _console.Clear();

            StreamingContent content = new StreamingContent();

            _console.Write("Please enter a title: ");
            content.Title = _console.ReadLine();

            _console.Write("Please enter a description: ");
            content.Description = _console.ReadLine();

            _console.Write("Please enter a rating 1-10");
            content.StarRating = double.Parse(_console.ReadLine());

            _console.WriteLine(
                "Select a Maturity Rating: \n" +
                "1. G \n" +
                "2. PG \n" +
                "3. PG-13 \n" +
                "4. R \n" +
                "5. NC-17 \n"
                );

            string maturityResponse = _console.ReadLine();
            switch (maturityResponse)
            {
                case "1":
                    content.MaturityRating = MaturityRating.G;
                    break;

                case "2":
                    content.MaturityRating = MaturityRating.PG;
                    break;
                case "3":
                    content.MaturityRating = MaturityRating.PG_13;
                    break;
                case "4":
                    content.MaturityRating = MaturityRating.R;
                    break;
                case "5":
                    content.MaturityRating = MaturityRating.NC_17;
                    break;
            }

            _repo.AddContentToDirectory(content);
        }
        //Add Movie/Show?

        //Get all
        private void ShowAllContent()
        {
            _console.Clear();
            List<StreamingContent> listOfContent = _repo.GetContents();//could do movie/show

            //can print to the console the collection initally if desired.
            foreach (StreamingContent content in listOfContent)
            {
                //Initially can write out display info here
                DisplayContent(content);

            }
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
        }

        //Helper method
        private void DisplayContent(StreamingContent content)
        {
            _console.WriteLine(
                $"Title: {content.Title} \n" +
                $"Description: {content.Description}\n" +
                $"Stars: {content.MaturityRating} \n" +
                $"Maturity Rating \n" +
                $"Family Friendly \n"
            );
        }

        //Get by title
        private void ShowContentByTitle()
        {
            _console.Clear();
            _console.WriteLine("What title are you looking for?");

            string targetTitle = _console.ReadLine();

            StreamingContent content = _repo.GetContentByTitle(targetTitle);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                _console.WriteLine("Title not found");
            }

            Continue();
        }

        private void Continue()
        {
            _console.WriteLine("Press any key to continue...");
            _console.ReadKey();
        }

        //At this point might want to go ahead and add a seed method for testing.

        //Remove
        private void RemoveContentFromRepo()
        {
            //Ask class what the best way of removing would be? might get suggestion for remove by title. But going to lean towards showing what we have first and then making a selection.

            _console.Clear();

            _console.WriteLine("Which item would you like to remove?");

            List<StreamingContent> contentList = _repo.GetContents();
            //can add this after getting initial display up and running
            int count = 0;

            foreach(StreamingContent content in contentList)
            {
                count++;
                _console.WriteLine($"{count}. {content.Title}");
            }

            int contentSelection = int.Parse(_console.ReadLine());
            int targetIndex = contentSelection - 1;

            //check for valid selection(depending on time can leave as challenge)
            if(targetIndex >= 0 && targetIndex < contentList.Count)
            {
                StreamingContent targetContent = contentList[targetIndex];

                if(_repo.DeleteExistingContent(targetContent))
                {
                    _console.WriteLine($"{targetContent.Title} was successfully removed");
                }
                else//If content fails to be removed.
                {
                    _console.WriteLine("Something went wrong!");
                }

            }
            else//If given invalid selection
            {
                _console.WriteLine("Invalid Selction");
            }
            Continue();
        }
        //Update?



        //Seed
        private void SeedContentList()
        {
            StreamingContent alien = new StreamingContent("Alien", "Deep Space Sci-Fi Horror Movie", 8.4, MaturityRating.R);
            StreamingContent theTrumanShow = new StreamingContent("The Truman Show", "The Real Reality TV", 9.3, MaturityRating.PG);
            StreamingContent insideOut = new StreamingContent("Inside Out", "Do you ever look at someone and wonder \"What is going on inside their head?\"", 8.7, MaturityRating.G);

            _repo.AddContentToDirectory(alien);
            _repo.AddContentToDirectory(theTrumanShow);
            _repo.AddContentToDirectory(insideOut);
        }





    }
}