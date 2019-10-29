using IFAvaliacao.Domain.Entities.Enum;
using System;
using Xamarin.Forms;

namespace IFAvaliacao.Domain.Entities
{
    public class Menu : BindableObject
    {
        public Menu(string name, int order, string icon, EMenuType menuType, bool isEnabled, Type targetType)
        {
            Name = name;
            Order = order;
            Icon = icon;
            MenuType = menuType;
            IsEnabled = isEnabled;
            TargetType = targetType;
        }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        private int order;
        public int Order { get => order; set { order = value; OnPropertyChanged(); } }

        private string icon;
        public string Icon { get => icon; set { icon = value; OnPropertyChanged(); } }

        private EMenuType eMenuType;
        public EMenuType MenuType { get => eMenuType; set { eMenuType = value; OnPropertyChanged(); } }

        private Type viewModelType;
        public Type ViewModelType { get => viewModelType; set { viewModelType = value; OnPropertyChanged(); } }

        private bool isEnabled;
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged(); } }

        private Type targetType;
        public Type TargetType { get => targetType; set { targetType = value; OnPropertyChanged(); } }


    }
}
