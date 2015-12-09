using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatekeeper.Toolbox.DataAccess
{
    /// <summary>
    /// Manager the Data visitor
    /// </summary>
    public class DataVisitor
    {
        /// <summary>
        /// create data visitor instance.
        /// </summary>
        /// <typeparam name="T">instance type which implementing the interface IDataVisitor</typeparam>
        /// <returns>data visitor instance</returns>
        public static T Create<T>() where T : IDataVisitor
        {
            //return DataVisitor.Create<T>(null);
            var dataVisitor = IocFactory.CreateObject<T>();
            return dataVisitor;
        }
        /// <summary>
        /// create data visitor instance.
        /// </summary>
        /// <typeparam name="T">instance type which implementing the interface IDataVisitor</typeparam>
        /// <param name="user">current user</param>
        /// <returns>data visitor instance</returns>
        //public static T Create<T>(CurrentUserDM user) where T : IDataVisitor
        //{
        //    var dataVisitor = IocFactory.CreateObject<T>();
        //    dataVisitor.CurrentUser = user;                     //set current user.
        //    return dataVisitor;
        //}
    }
}
