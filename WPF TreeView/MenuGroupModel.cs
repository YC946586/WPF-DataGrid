using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WPF_TreeView
{
    /// <summary>
    /// 树形菜单  商品编码维护
    /// </summary>
    [Serializable]
    public class MenuGroupModel : ViewModelBase
    {
        public MenuGroupModel()
        {
            Nodes = new ObservableCollection<MenuGroupModel>();
        }

        private bool _IsChecked = false;
        private bool _IsSelected = false;
        private string _menuName;
        /// <summary>
        /// 主键序号
        /// </summary>
        public int ID
        {
            get; set;
        }


        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get { return _menuName; } set { _menuName = value; RaisePropertyChanged(); } }
        /// <summary>
        /// 菜单代码
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentId
        {
            get; set;
        }

        /// <summary>
        /// 当前的实体
        /// </summary>
        public object CurModel
        {
            get; set;
        }
        /// <summary>
        /// 权限值
        /// </summary>
        public int? AuthValue { get; set; }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsChecked { get { return _IsChecked; } set { _IsChecked = value; RaisePropertyChanged(); } }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; RaisePropertyChanged(); } }

        private ObservableCollection<MenuGroupModel> _Nodes = new ObservableCollection<MenuGroupModel>();

        public ObservableCollection<MenuGroupModel> Nodes
        {
            get { return _Nodes; }
            set
            {
                _Nodes = value;
                RaisePropertyChanged();
            }
        }
    }
}
