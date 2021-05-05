    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen_PET.Models
{
    public class CommentModel
    {
        private int id;

        /// <summary>
        /// Gets or sets the ID of this comment.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int reportId;

        /// <summary>
        /// Gets or sets the ID of the report this comment relates to.
        /// </summary>
        public int ReportId
        {
            get { return reportId; }
            set { reportId = value; }
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

        private DateTime time;

        /// <summary>
        /// Gets or sets the time at which this comment was created.
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// Gets or sets the content of this comment
        /// </summary>
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
