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
	public class ExperienceManager : IExperienceService
	{
		IExperienceDAL _experienceDAL;

		public ExperienceManager(IExperienceDAL experienceDAL)
		{
			_experienceDAL = experienceDAL;
		}

		public void TAdd(Experience t)
		{
			_experienceDAL.Insert(t);
		}

		public void TDelete(Experience t)
		{
			_experienceDAL.Delete(t);
		}

		public List<Experience> TGetAllList(Expression<Func<Experience, bool>> filter = null)
		{
			return _experienceDAL.GetAllList(filter);
		}

		public Experience TGetById(int id)
		{
			return _experienceDAL.GetById(id);
		}

		public void TUpdate(Experience t)
		{
			_experienceDAL.Update(t);
		}
	}
}
