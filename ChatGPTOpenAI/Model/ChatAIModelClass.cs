using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTOpenAI.Model
{
    class ChatAIModelClass
    {
    }

    public class ChatCompletion
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Created { get; set; }
        public ChatCompletionChoice[] Choices { get; set; }
        public ChatCompletionUsage Usage { get; set; }
    }

    public class ChatCompletionChoice
    {
        public int Index { get; set; }
        public ChatCompletionMessage Message { get; set; }
        public string FinishReason { get; set; }
    }

    public class ChatCompletionMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class ChatCompletionUsage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }

}
