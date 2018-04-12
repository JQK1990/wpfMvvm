
using System;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MainProject.Service;

namespace MainProject
{
    /// <summary>
    /// DBConnect.xaml 的交互逻辑
    /// </summary>
    public partial class DBConnect
    {
        private DbConnetService _dbConnetService;
        public DBConnect()
        {
            
            InitializeComponent();
            _dbConnetService = new DbConnetService();
        }

        private void IsUseWindows_OnChecked(object sender, RoutedEventArgs e)
        {
            
        }
        private async void ShowProgressDialog(object sender, RoutedEventArgs e)
        {
            
            

            
        }
        private async void Test_Click(object sender, RoutedEventArgs e)
        {
            var message = string.Empty;
            var serverName = SeverName.Text;
            var dbName = DataBase.Text;
            var userName = TxtName.Text;
            var password = TxtPw.Password;
            try
            {
                var mySettings = new MetroDialogSettings()
                {
                    NegativeButtonText = "取消",
                    AnimateShow = false,
                    AnimateHide = false
                };

                var controller = await this.ShowProgressAsync("请稍等", "正在连接数据库……", settings: mySettings);
                controller.SetIndeterminate();
                controller.SetCancelable(true);

                if (_dbConnetService.TestConnection(serverName, userName, password, dbName))
                {
                    message = "连接数据库成功！";
                }
                else
                {
                    message = "连接数据库失败！";
                }
                await controller.CloseAsync();

                if (controller.IsCanceled)
                {
                    await this.ShowMessageAsync("测试结果", "取消测试");
                }
                else
                {
                    await this.ShowMessageAsync("测试结果",message);
                }
            }
            catch (Exception exception)
            {
                //
            }
            
        }

        
    }
}
