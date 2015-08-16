﻿using System;
using CoreBase.ManagerInterfaces;
using CoreBase.Entities;

namespace CoreBase.Managers
{
    /// <summary>
    /// 
    /// </summary>
	public abstract class Manager : IManager
	{
		#region Constructors
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
		protected Manager(IEntities context)
        {
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			DataContext = context;
		} 

		#endregion

		#region Properties

        /// <summary>
        /// 
        /// </summary>
		public IEntities DataContext
		{
			get;
			set;
		}

		#endregion

		#region Methods

        /// <summary>
        /// 
        /// </summary>
		public virtual void SaveChanges()
		{
			DataContext.SaveChanges();
		}

		#endregion
	}
}
