using System.Collections.Generic;
using System.Windows.Documents;
using GalaSoft.MvvmLight;

namespace WpfApplication1.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DbConnectViewModel : ViewModelBase
    {
        public List<string> ServerList { get; set; }
        /// <summary>
        /// Initializes a new instance of the DbConnectViewModel class.
        /// </summary>
        public DbConnectViewModel()
        {
            GetServerList();
        }

        public void GetServerList()
        {
            ServerList = Common.DbHelper.GetSqlServerNames();
            RaisePropertyChanged(()=>ServerList);
        }
    }
}