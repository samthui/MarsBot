using Microsoft.Bot.Connector.DirectLine;

class BotConnection{
	public DirectLineClient Client = new DirectLineClient("Place key here");
	public Conversation MainConversation;
	public ChannelAccount Account;

	public BotConnection(string accountName){        
		MainConversation = Client.Conversations.StartConversation();        
		Account = new ChannelAccount {Id = accountName, Name = accountName };    
	}
}

public void SendMessage(string message){    
	Activity activity = new Activity
	{        
		From = Account,
		Text = message,
		Type = ActivityTypes.Message
	};    
	Client.Conversations.PostActivity(MainConversation.ConversationId, activity);
}