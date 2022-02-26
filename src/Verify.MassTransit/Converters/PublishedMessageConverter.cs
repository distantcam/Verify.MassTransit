﻿using MassTransit.Testing;

class PublishedMessageConverter :
    WriteOnlyJsonConverter<IPublishedMessage>
{
    public override void Write(VerifyJsonWriter writer, IPublishedMessage message)
    {
        writer.WriteStartObject();
        writer.WriteProperty(message, message.MessageType, "Published");
        writer.WriteProperty(message, message.MessageObject, "Message");
        if (message.Exception != null)
        {
            writer.WriteProperty(message, message.Exception, "Exception");
        }
        writer.WriteEndObject();
    }
}