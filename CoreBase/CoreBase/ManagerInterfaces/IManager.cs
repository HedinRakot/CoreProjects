using CoreBase.Entities;
using System.Threading.Tasks;

namespace CoreBase.ManagerInterfaces
{
    /// <summary>
    /// 
    /// </summary>
	public interface IManager
	{
        /// <summary>
        /// 
        /// </summary>
		IEntities DataContext
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		void SaveChanges();

        Task<int> SaveChangesAsynchron();
    }    
}
