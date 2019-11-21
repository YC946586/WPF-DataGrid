using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace WPF_DataGrid.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<MainModel> _gridModelList = new ObservableCollection<MainModel>();
        /// <summary>
        /// 表单数据
        /// </summary>
        public ObservableCollection<MainModel> GridModelList
        {
            get { return _gridModelList; }
            set { _gridModelList = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            for (int i = 0; i < 6; i++)
            {
                MainModel model = new MainModel()
                {
                    Depict = "嘻嘻嘻嘻" + i,
                    FunName = "洋葱" + i,
                    BrushsPath = "PiuPiuPiu" + i
                };
                GridModelList.Add(model);
            }
        }
    }

    /// <summary>
    /// model
    /// </summary>
    public  class MainModel : ViewModelBase
    {
        private string _funName;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string FunName
        {
            get { return _funName; }
            set
            {
                _funName = value;
                RaisePropertyChanged();
            }
        }

        private string _depict;
        /// <summary>
        /// 节点描述
        /// </summary>
        public string Depict
        {
            get { return _depict; }
            set
            {
                _depict = value;
                RaisePropertyChanged();
            }
        }

        private string _brushsPatht;
        /// <summary>
        /// 节点颜色
        /// </summary>
        public string BrushsPath
        {
            get { return _brushsPatht; }
            set
            {
                _brushsPatht = value;
                RaisePropertyChanged();
            }
        }
    }
}