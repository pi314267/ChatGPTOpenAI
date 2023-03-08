using ChatGPTOpenAI.ViewModels.Base;
using System.Collections.ObjectModel;
using ChatGPTOpenAI.OpenAI;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatGPTOpenAI.ViewModels
{
    public partial class ChatGPTUseApiViewModel : BaseViewModel
    {
        private string API_KEY = "YOUR_API_KEY_HERE";
        private const string ENGINE_ID = "gpt-3.5-turbo";
        private const int MAX_TOKENS = 150;
        private const double TEMPERATURE = 0.7;

        private MyOpenAI _openAI;
        private readonly List<string> _chatLog;

        public ChatGPTUseApiViewModel()
        {
            //API_KEY = System.Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            API_KEY = "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";
            _openAI = new MyOpenAI(API_KEY);
            _chatLog = new List<string>();

        }

        public ObservableCollection<MessageViewModel> Messages { get; } = new ObservableCollection<MessageViewModel>();

        [ObservableProperty]
        public string newMessage;


        [RelayCommand]
        private async Task SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                // 사용자가 입력한 새로운 메시지를 추가합니다.
                var userMessage = new MessageViewModel { Text = NewMessage, Alignment = TextAlignment.End };
                Messages.Add(userMessage);
                _chatLog.Add(NewMessage);

                // OpenAI API를 사용하여 챗봇에게 메시지를 전송하고, 응답을 받습니다.
                var response = await _openAI.GenerateText(NewMessage, ENGINE_ID, MAX_TOKENS, TEMPERATURE);

                // 챗봇이 응답한 메시지를 추가합니다.
                var botMessage = new MessageViewModel { Text = response, Alignment = TextAlignment.Start };
                Messages.Add(botMessage);
                _chatLog.Add(response);

                // 사용자가 입력한 메시지를 초기화합니다.
                NewMessage = string.Empty;
            }
        }
    }



    public class MessageViewModel
    {
        public string Text { get; set; }

        public TextAlignment Alignment { get; set; }
    }

}