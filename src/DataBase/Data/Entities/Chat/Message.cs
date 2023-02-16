﻿
using Data.Entities.BaseData;

namespace Data.Entities.Chat
{
    public class Message: BaseEntitySqlServer
    {
        public long ReceiverId { get; set; }
        public long SenderId { get; set; }
        public string MessageText { get; set; }

    }
}
