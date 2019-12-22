using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ResponceModel
/// </summary>
public class MessageData
{
    public string Number { get; set; }
    public string MessageId { get; set; }
}

public class ResponceModel
{
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public string JobId { get; set; }
    public List<MessageData> MessageData { get; set; }
}