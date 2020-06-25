using EchoBot1.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Connector.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot1.Services
{
    public class BotStateService
    {
        public ConversationState ConversationState { get; }
        public UserState UserState { get; }

        public static string ConversationDataId { get; } = $"{nameof(BotStateService)}.ConversationData";
        public static string UserProfileId { get; } = $"{nameof(BotStateService)}.UserProfile";

        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }

        public BotStateService(ConversationState conversationState, UserState userState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
            UserState = userState ?? throw new ArgumentNullException(nameof(userState));

            InitializeAccessors();
        }

        private void InitializeAccessors()
        {
            ConversationDataAccessor = ConversationState.CreateProperty<ConversationData>(ConversationDataId);
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
        }
    }
}
