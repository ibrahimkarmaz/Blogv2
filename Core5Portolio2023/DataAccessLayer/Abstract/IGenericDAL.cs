using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDAL<T> where T:class,new()
	{
		void Insert(T t);
		void Update(T t);
		void Delete(T t);
		List<T> GetAllList(Expression<Func<T,bool>> filter=null);
		T GetById(int id);
	}
}
