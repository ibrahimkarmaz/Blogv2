using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SummaryManager : ISummaryService
	{
		ISummaryDAL _summaryDAL;

		public SummaryManager(ISummaryDAL summaryDAL)
		{
			_summaryDAL = summaryDAL;
		}

		public void TAdd(Summary t)
		{
			_summaryDAL.Insert(t);
		}

		public void TDelete(Summary t)
		{
			_summaryDAL.Delete(t);
		}

		public List<Summary> TGetAllList(Expression<Func<Summary, bool>> filter = null)
		{
			if (filter==null)
			{
				return _summaryDAL.GetAllList();
			}
			else
			{
				return _summaryDAL.GetAllList(filter);
			}
		}

		public Summary TGetById(int id)
		{
			return _summaryDAL.GetById(id);
		}

		public void TUpdate(Summary t)
		{
			_summaryDAL.Update(t);
		}
	}
}
