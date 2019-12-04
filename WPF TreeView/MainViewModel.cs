using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

namespace WPF_TreeView
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<MenuGroupModel> _MenuGroupModels = new ObservableCollection<MenuGroupModel>();

        /// <summary>
        /// Tree功能节点
        /// </summary>
        public ObservableCollection<MenuGroupModel> MenuGroupModels
        {
            get { return _MenuGroupModels; }
            set
            {
                _MenuGroupModels = value;
                RaisePropertyChanged();
            }
        }
        private  object _selectMenuGroup;
      /// <summary>
      /// 选择的数据
      /// </summary>
        public  object SelectMenuGroup
        {
            get { return _selectMenuGroup; }
            set
            {
                _selectMenuGroup = value;
                RaisePropertyChanged();
            }  
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public MainViewModel()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    MenuGroupModel loader = new MenuGroupModel
                    {
                        ID = i,
                        MenuName = "洋葱Biu" + i,
                    };
                    BindingChildNode(loader);
                    MenuGroupModels.Add(loader);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 绑定子节点  递归    通过父级ID 找到下层节点 
        /// </summary>
        /// <param name="treeViewItem"></param>
        private static void BindingChildNode(MenuGroupModel treeViewItem)
        {
            try
            {
                for (int i =1; i < 3; i++)
                {
                    MenuGroupModel groupModel = new MenuGroupModel
                    {
                        ID = i + 10,
                        ParentId = treeViewItem.ID,
                        MenuName = "洋葱Biu" + i + 10,
                        CurModel= "WPF_TreeView.SelectView.UserControl"+i
                    };
                    treeViewItem.Nodes.Add(groupModel);
                }
            }
            catch (Exception ex)
            {

            }
        }


        private RelayCommand<MenuGroupModel> _selectCommand;

        /// <summary>
        /// 选中
        /// </summary>
        public RelayCommand<MenuGroupModel> SelectComamnd
        {
            get
            {
                if (_selectCommand == null)
                {
                    _selectCommand = new RelayCommand<MenuGroupModel>(Select);
                }
                return _selectCommand;
            }
            set { _selectCommand = value; }
        }

        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="model"></param>
        private void Select(MenuGroupModel model)
        {
            try
            {
                if (model.CurModel!=null)
                {
                    SelectMenuGroup = GetUserControl(model.CurModel.ToString());
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// 反射UserControl
        /// </summary>
        /// <returns></returns>
        private  UserControl GetUserControl(string userctolAction)
        {
            try
            {
                UserControl uc = (UserControl)Assembly.Load(Assembly.GetExecutingAssembly().FullName).CreateInstance(userctolAction);
                
                return uc;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
    }
}
