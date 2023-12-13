using _3WinForm.Library;

namespace _3WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _ = await ExecuteAsync();
            richTextBox1.AppendText("Done\r\n", Color.Red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var s = SynchronizationContext.Current;
            richTextBox1.AppendText($"SynchronizationContext: {s?.ToString()}\r\n");
        }
        
        async Task<int> ExecuteAsync()
        {
            
            richTextBox1.AppendText($"ExecuteAsync Thread: {Thread.CurrentThread.ManagedThreadId}\r\n");
            string id = ""; 
            await Task.Delay(5000).ContinueWith((t) =>
            {
                id = $"Task Delay Thread: {Thread.CurrentThread.ManagedThreadId}\r\n";
            });
            richTextBox1.AppendText(id); 

            richTextBox1.AppendText( $"ExecuteAsync Thread after delay: {Thread.CurrentThread.ManagedThreadId}\r\n");
            return await Execute2Async();
        }

        async Task<int> Execute2Async()
        {
            richTextBox1.Text += $"Execute2Async Thread: {Thread.CurrentThread.ManagedThreadId}\r\n";
            return await Task.FromResult( 0 );
        }
    }
}
