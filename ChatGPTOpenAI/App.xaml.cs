namespace ChatGPTOpenAI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override void OnStart()
    {
        base.OnStart();

        // API Key 설정
        Environment.SetEnvironmentVariable("OPENAI_API_KEY", "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");
    }
}
