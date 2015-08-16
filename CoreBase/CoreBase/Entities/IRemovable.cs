using System;

namespace CoreBase.Entities
{
    /// <summary>
    /// Interface entity with Delete Data
    /// </summary>
    public interface IRemovable
    {
        /// <summary>
        /// Delete date entity 
        /// </summary>
        DateTime? DeleteDate { get; set; }
    }
}
