using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

public class JsonData
{
    public string Script { get; set; }
    public string Html { get; set; }
    public bool Success { get; set; }
    public long ID { get; set; }
}
public class MessageBox
{
    public static JavaScriptResult Show(string message, MessageType type = MessageType.Alert, bool modal = false, MessageAlignment layout = MessageAlignment.Center, bool dismissQueue = false)
    {
        string txt = " $.noty.defaults.killer = true;$.noty.closeAll(); noty({ text: \"" + message + "\", type: \"" + type.ToString().ToLower() + "\", layout: \"" + layout.ToString().ToLowerFirst() + "\", dismissQueue: " + dismissQueue.ToString().ToLower() + ", modal: " + modal.ToString().ToLower() + ", killer: true,timeout:1000});";
        return new JavaScriptResult() { Script = txt };
    }
    public static JavaScriptResult ShowbyTime(string message, MessageType type = MessageType.Alert, bool modal = false, MessageAlignment layout = MessageAlignment.Center, int Time = 1000, bool dismissQueue = false)
    {
        string txt = " $.noty.defaults.killer = true;$.noty.closeAll(); noty({ text: \"" + message + "\", type: \"" + type.ToString().ToLower() + "\", layout: \"" + layout.ToString().ToLowerFirst() + "\", dismissQueue: " + dismissQueue.ToString().ToLower() + ", modal: " + modal.ToString().ToLower() + ", killer: true,timeout:" + Time + "});";
        return new JavaScriptResult() { Script = txt };
    }
}
public enum MessageType
{
    Success,
    Error,
    Information,
    Warning,
    Alert,
    Notification
}
public enum MessageAlignment
{
    Bottom,
    BottomCenter,
    BottomLeft,
    BottomRight,
    Center,
    CenterLeft,
    CenterRight,
    Inline,
    Top,
    TopCenter,
    TopLeft,
    TopRight
}

