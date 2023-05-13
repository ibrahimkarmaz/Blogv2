using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Summary
	{
		public int SummaryID { get; set; }
		public string SummaryTitle { get; set; }
		public string SummaryContent { get; set; }
		public bool SummaryArchive { get; set; }
	}
}
