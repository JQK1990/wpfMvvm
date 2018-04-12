using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MainProject.Service;
namespace MainProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DbConnectViewModel : ViewModelBase
    {
        private DbConnetService _dbConnetService;
        public List<string> ServerList { get; set; }
        public List<string> DataBaseList { get; set; }
        public RelayCommand FlashDataBase { get; set; }
        public RelayCommand FlashServer { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerName { get; set; }
        public string DbName { get; set; }
        /// <summary>
        /// Initializes a new instance of the DbConnectViewModel class.
        /// </summary>
        public DbConnectViewModel()
        {
            GetServerList();
            _dbConnetService = new DbConnetService();
            FlashServer = new RelayCommand(GetServerList);
            FlashDataBase = new RelayCommand(GetDataBase);
        }

        public void GetDataBase()
        {
            DataBaseList = _dbConnetService.GetDataBase(ServerName, UserName, Password);
            RaisePropertyChanged(()=>DataBaseList);
        }
        public void GetServerList()
        {
            ServerList = Common.DbHelper.GetSqlServerNames();
            RaisePropertyChanged(()=>ServerList);
        }
    }
}