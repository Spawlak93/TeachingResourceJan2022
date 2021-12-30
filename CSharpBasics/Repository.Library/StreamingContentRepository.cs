

using System.Collections.Generic;

namespace Repository.Library
{
    public class StreamingContentRepository
    {
        private readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        //CRUD 

        //Create
        public bool AddContentToDirectory(StreamingContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = startingCount < _contentDirectory.Count;
            return wasAdded;
        }

        //Read
        //Read all
        public List<StreamingContent> GetContents()
        {
            return _contentDirectory;
        }

        //Read by title
        public StreamingContent GetContentByTitle(string title)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                if (title.ToLower() == content.Title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        //Update
        //Update by title
        public bool UpdateExistingContent(string oldTitle, StreamingContent updatedContent)
        {
            StreamingContent oldContent = GetContentByTitle(oldTitle);

            //Does the content exist?
            if (oldContent != null)
            {
                oldContent.Title = updatedContent.Title;
                oldContent.Description = updatedContent.Description;
                oldContent.StarRating = updatedContent.StarRating;
                oldContent.MaturityRating = updatedContent.MaturityRating;
                oldContent.IsFamilyFriendly = updatedContent.IsFamilyFriendly;
                // oldContent.RuntimeInMinutes = updatedContent.RuntimeInMinutes;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteExistingContent(StreamingContent contentToDelete)
        {
            return _contentDirectory.Remove(contentToDelete);
        }
        //DeleteByTitle
        public bool DeleteByTitle(string title)
        {
            StreamingContent contentToDelete = GetContentByTitle(title);
            return DeleteExistingContent(contentToDelete);
        }

        //Movie Additions
        public Movie GetMovieByTitle(string title)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Movie && content.Title == title)
                {
                    return (Movie)content;
                }
            }
            return null;
        }
        public List<Movie> GetAllMovies()
        {
            List<Movie> moviesToReturn = new();
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content is Movie)
                {
                    moviesToReturn.Add(content as Movie);
                }
            }

            return moviesToReturn;
        }
    }
}