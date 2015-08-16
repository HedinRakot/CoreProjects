using CoreBase.Entities;

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
	}    
}
