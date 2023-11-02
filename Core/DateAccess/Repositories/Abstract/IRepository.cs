using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DateAccess.Repositories.Abstract
{

	public interface IRepository<T> where T : class, new()
	{
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params string[] includes);
		Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includes);
		Task<List<T>> GetAllPaginatedAsync(int page, int size, Expression<Func<T, bool>> filter = null, params string[] includes);
		Task<bool> IsExistsAsync(Expression<Func<T, bool>> filter);
		Task<int> SaveAsync();
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}

}
