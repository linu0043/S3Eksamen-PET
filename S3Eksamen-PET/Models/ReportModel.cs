using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen_PET.Models
{
    public class ReportModel
    {
        private int id;

        /// <summary>
        /// Gets or sets the ID of this report.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime created;

        /// <summary>
        /// Gets or sets the time at which this report was created.
        /// </summary>
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        private string place;

        /// <summary>
        /// Gets or sets the place where this report took place.
        /// </summary>
        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        private PersonModel author;

        /// <summary>
        /// Gets or sets the author of this report.
        /// </summary>
        public PersonModel Author
        {
            get { return author; }
            set { author = value; }
        }

        private ObservantModel observant;

        /// <summary>
        /// Gets or sets the observant that this report is about.
        /// </summary>
        public ObservantModel Observant
        {
            get { return observant; }
            set { observant = value; }
        }

        private string content;

        /// <summary>
        /// Gets or sets the content of this report.
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// Gets all the comments made on this report
        /// </summary>
        /// <returns>A <c>List</c> of type <c>CommentModel</c>.</returns>
        public List<CommentModel> GetComments()
        {
            return null;
        }
    }
}
