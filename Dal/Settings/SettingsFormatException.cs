namespace Dal.Settings
{
    using System;
    //using System.Runtime.Serialization;

    //[Serializable]
    public sealed class SettingsFormatException : Exception
    {
        private int lineNumber;
        private int linePosition;

        public SettingsFormatException()
        {
        }

        public SettingsFormatException(string message) : base(message)
        {
        }

        /*private SettingsFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.lineNumber = info.GetInt32("lineNumber");
            this.linePosition = info.GetInt16("linePosition");
        }*/

        public SettingsFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SettingsFormatException(string message, int lineNumber, int linePosition) : this(message)
        {
            this.lineNumber = lineNumber;
            this.linePosition = linePosition;
        }

        public SettingsFormatException(string message, int lineNumber, int linePosition, Exception innerException) : this(message, innerException)
        {
            this.lineNumber = lineNumber;
            this.linePosition = linePosition;
        }

        /*public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("lineNumber", this.lineNumber);
            info.AddValue("linePosition", this.linePosition);
            base.GetObjectData(info, context);
        }*/

        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }

        public int LinePosition
        {
            get
            {
                return this.linePosition;
            }
        }

        public override string Message
        {
            get
            {
                string message = base.Message;
                if ((this.lineNumber != 0) & (this.linePosition != 0))
                {
                    string str2 = message;
                    message = str2 + message + " ,Error at Line Number(" + this.lineNumber.ToString() + ") , Position(" + this.linePosition.ToString() + ")";
                }
                return message;
            }
        }
    }
}

