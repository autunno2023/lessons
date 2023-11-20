namespace Exception.Lesson.Exception
{
    class Under18OrderException : GeneralOrderException
    {
        public Under18OrderException(string Message) : base(Message)
        {

        }
    }
}
