
namespace GoogleTest.Data
{
    public sealed class WordForSearchRepository
    {
        public string InputText;
        private WordForSearchRepository(string InputText)
        {
            this.InputText = InputText;
        }

        public static WordForSearchRepository GetWiki()
        {
            return new WordForSearchRepository("Wiki");        
        }

        public static WordForSearchRepository GetNews()
        {
            return new WordForSearchRepository("News");
        }

        public override string ToString()
        {
            return InputText;
        }
    }
}
