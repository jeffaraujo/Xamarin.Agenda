using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(Xamarin.Agenda.Droid.Config))]


namespace Xamarin.Agenda.Droid
{
    public class Config : IConfig
    {

        private string _diretorioDB;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return _diretorioDB;
            }

        }

        private SQLite.Net.Interop.ISQLitePlatform _plataforma;

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }

                return _plataforma;
            }
        }



    }
}