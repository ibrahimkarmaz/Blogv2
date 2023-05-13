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
	public class EducationManager : IEducationService
	{
		IEducationDAL _educationDAL;

		public EducationManager(IEducationDAL educationDAL)
		{
			_educationDAL = educationDAL;
		}

		public void TAdd(Education t)
		{
			_educationDAL.Insert(t);
		}

		public void TDelete(Education t)
		{
			_educationDAL.Delete(t);
		}

		public List<Education> TGetAllList(Expression<Func<Education, bool>> filter = null)
		{
			return _educationDAL.GetAllList(filter);
		}

		public Education TGetById(int id)
		{
			return _educationDAL.GetById(id);
		}

		public void TUpdate(Education t)
		{
			_educationDAL.Update(t);
		}
	}
}
