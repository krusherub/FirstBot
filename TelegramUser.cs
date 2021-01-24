using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBot
{
    class TelegramUser : INotifyPropertyChanged, IEquatable<TelegramUser>
    {
        private string name;
        private long id;
        public event PropertyChangedEventHandler PropertyChanged;
       

        public TelegramUser(string Name, long ChatId)
        {
            this.Name = Name;
            this.Id = ChatId;
            Messages = new ObservableCollection<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                // ??????????????
                this.name = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                // ??????????????????
                this.id = value;
              //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        public bool Equals(TelegramUser other)
        {
            return this.id == other.Id;
        }

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string text) => Messages.Add(text);
    }
}
