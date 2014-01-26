namespace Juggler
{
    internal class UpdateData
    {
        internal EventType EventType { get; set; }
        internal string Message { get; set; }
        internal string ImageName { get; set; }
        internal ImageStatus ImageStatus { get; set; }

        private UpdateData() { }

        public UpdateData(EventType eventType, string message) : this(eventType, message, string.Empty, ImageStatus.Started) { }

        public UpdateData(EventType eventType, string imageName, ImageStatus imageStatus) : this(eventType, string.Empty, imageName, imageStatus) { }

        public UpdateData(EventType eventType, string message, string imageName, ImageStatus imageStatus)
        {
            this.EventType = eventType;
            this.Message = message;
            this.ImageName = imageName;
            this.ImageStatus = imageStatus;
        }

    }
}
