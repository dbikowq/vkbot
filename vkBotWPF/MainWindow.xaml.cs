using System.Windows;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Exception;
using VkNet.UWP.Model;
using VkNet.Model.LeadForms;
using VkNet.Enums.SafetyEnums;
using System.Net;
using System.IO;
using VkNet.AudioBypassService.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace vkBotWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int authInt;
        public static string codeAuth;
        public MainWindow()
        {
            InitializeComponent();
            authInt = 0;
        }

        public string GettingCaptcha { get; private set; }

        //public static HttpWebRequest request;
        //public static HttpWebResponse response;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (checkbox2.IsChecked == false)
            {
                var services = new ServiceCollection();
                services.AddAudioBypass();
                var api = new VkApi(services);
                api.Authorize(new ApiAuthParams
                {
                    Login = tbLogin.Text,
                    Password = tbPass.Text,
                    ApplicationId = 7641738
                });
            }
            else
            {
                authCode authcode = new authCode();
                //auth.Show();
                var services = new ServiceCollection();
                services.AddAudioBypass();
                var api = new VkApi(services);

                string login_ = tbLogin.Text;
                string pass_ = tbPass.Text;
                string captchaKey = null;
                ulong captchaSid = 0;
                while (true)
                {
                    try
                    {
                        api.Authorize(new ApiAuthParams
                        {
                            ApplicationId = 12345,
                            Login = login_,
                            Password = pass_,
                            Settings = Settings.All,
                            CaptchaKey = captchaKey,
                            CaptchaSid = (ulong?)captchaSid
                            
                        });
                        break;
                    }
                    catch (CaptchaNeededException ex)
                    {
                        
                       
                        //captchaKey = getKey();
                        //captchaSid = ex.Sid;
                        api.Authorize(new ApiAuthParams
                        {
                            ApplicationId = 12345,
                            Login = login_,
                            Password = pass_,
                            Settings = Settings.All,
                            CaptchaKey = getKey(ex.Img.AbsoluteUri),
                            CaptchaSid = ex.Sid

                        });
                    }
                }
            }
        }



        public string getKey(string s)
        {
            return "hduepmq";
        }



        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            authCode authcode = new authCode();
            if (authcode.ShowDialog().Value)
            {
                codeAuth = authcode.tbCode.Text;
                authInt = 1;
            }
        }
    }
}
