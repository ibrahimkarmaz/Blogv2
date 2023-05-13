using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Education
	{
		public int EducationID { get; set; }
		public string EducationSchoolName { get; set; }
		public string EducationSectionName { get; set; }
		public DateTime? EducationStartYear { get; set; }
		public DateTime? EducationStopYear { get; set; }
		public bool EducationContinue { get; set; }
		public string EducationContent { get; set; }
		public bool EducationArchive { get; set; }
	}
}
