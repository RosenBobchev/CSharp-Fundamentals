using System;
using System.Collections.Generic;
using System.Text;

public interface ITweetRepository
{
    void SaveTweet(string content);
}