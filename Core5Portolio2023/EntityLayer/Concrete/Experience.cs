using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Experience
	{
		public int ExperienceID { get; set; }
		public string ExperienceCompanyName { get; set; }
		public string ExperienceJobName { get; set; }
		public DateTime? ExperienceStartYear { get; set; }
		public DateTime? ExperienceStopYear { get; set; }
		public bool ExperienceContinue { get; set; }
		public string ExperienceContext { get; set; }
		public bool ExperienceArchive { get; set; }
	}
}
