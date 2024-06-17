using System;
using UnityEngine;
using System.Collections.Generic;
public class ClientSocket
{ 
    private static CommBase_CHA.TcpSocketClient Client;
    public bool connected = false;

    private byte[] m_recvBuff;
    private AsyncCallback m_recvCb;
    private Queue<string> m_msgQueue = new Queue<string>();

    /// <summary>
    /// 當收到伺服器的消息時會呼叫这个函數
    /// </summary>
    private void RecvCallBack(IAsyncResult ar)
    {

    }

    /// <summary>
    /// 從消息隊列中取出消息
    /// </summary>
    /// <returns></returns>
    public string GetMsgFromQueue()
    {
        if (m_msgQueue.Count > 0)
            return m_msgQueue.Dequeue();
        return null;
    }

    /// <summary>
    /// 關閉Socket
    /// </summary>
    public void CloseSocket()
    {
    }
    
}

