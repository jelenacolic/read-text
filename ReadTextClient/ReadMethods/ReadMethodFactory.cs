namespace ReadTextClient.ReadMethods
{
    class ReadMethodFactory
    {
        public IReadMethod GetReadMethod(ReadMethodEnum selected)
        {
            if (selected == ReadMethodEnum.CONSOLE)
            {
                return new ConsoleReadMethod();
            }
            else if (selected == ReadMethodEnum.FILE)
            {
                return new FileReadMethod();
            }
            else if (selected == ReadMethodEnum.DATABASE)
            {
                return new DBReadMethod();
            }
            
            return null;
        }
    }
}
