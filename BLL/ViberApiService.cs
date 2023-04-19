using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using ViberWalkTracker.ViberModels.DeliveryModels;
using ViberWalkTracker.ViberModels.ReceivedModels;

namespace ViberWalkTracker.BLL
{
    public class ViberApiService
    {
        private WalkService _walkService;
        private UserService _userService;
        private const string webhookUrl = @"https://chatapi.viber.com/pa/set_webhook";
        private const string sendMessageUrl = @"https://chatapi.viber.com/pa/send_message";
        private const string enterIMEIMessage = "Введіть IMEI";
        private const string invalidMessage = "Недійсне повідомлення";
        private const string invalidIMEIMessage = "Неіснуючий IMEI";
        private const string Top10Message = "Топ10";
        private const string backMessage = "Назад";


        public ViberApiService(WalkService walkService, UserService userService)
        {
            _walkService = walkService;
            _userService = userService;
        }

        public async Task<bool> ProcessReceivedObject(object obj)
        {
            var stringMessage = obj.ToString();

            var receivedMessage = await JsonConvert.DeserializeObjectAsync<ReceivedMessage>(stringMessage);

            if(receivedMessage.GetType().GetProperties().All(p => p.GetValue(receivedMessage) != null))
            {
                switch(receivedMessage.Message.Text)
                {
                    case Top10Message:

                        if (await _userService.IsUserHasIMEI(receivedMessage.Sender.Id))
                        {
                            var topWalks = await _walkService.GetTop10WalksByIMEI(await _userService.GetUserIMEI(receivedMessage.Sender.Id));
                            var table = "";
                            for (int i = 1; i <= topWalks.Count; i++)
                                table += $"{i}. Прогулянка {topWalks[i-1].Id}, Пройдена відстань, км: {topWalks[i - 1].Distance}, Загальний час, хв: {topWalks[i - 1].Duration} \n\n";

                            var keyboard = new Keyboard() { Buttons = new List<Button>() { new Button() { ActionType = "reply", ActionBody = Top10Message, Text = Top10Message }, new Button() { ActionType = "reply", ActionBody = backMessage, Text = backMessage } } };
                            await new ViberApiSender().SendKeyboard(new MessageToSendWithKeyboard() { Receiver = receivedMessage.Sender.Id, Type = "text", Min_api_version = 3, Text = table, Keyboard = keyboard }, sendMessageUrl);
                        }
                       
                        else
                            await new ViberApiSender().SendMessage(new MessageToSend() { Receiver = receivedMessage.Sender.Id, Type = "text", Text = invalidIMEIMessage }, sendMessageUrl);

                        break;

                    case backMessage:

                        if (await _userService.IsUserHasIMEI(receivedMessage.Sender.Id))
                            await _userService.ChangeUserIMEI(receivedMessage.Sender.Id, "");

                        else
                            await new ViberApiSender().SendMessage(new MessageToSend() { Receiver = receivedMessage.Sender.Id, Type="text", Text=invalidIMEIMessage}, sendMessageUrl);

                        break;

                    default:

                        if (await _userService.IsUserHasIMEI(receivedMessage.Sender.Id))
                        {
                            var keyboard = new Keyboard() { Buttons = new List<Button>() { new Button() { ActionType = "reply", ActionBody = Top10Message, Text = Top10Message }, new Button() { ActionType = "reply", ActionBody = backMessage, Text = backMessage } } };
                            await new ViberApiSender().SendKeyboard(new MessageToSendWithKeyboard() { Receiver = receivedMessage.Sender.Id, Type = "text", Min_api_version = 3, Text = invalidMessage, Keyboard = keyboard }, sendMessageUrl);
                            break;
                        }

                        if(await _walkService.IsExistIMEI(receivedMessage.Message.Text))
                        {
                            var keyboard = new Keyboard() { Buttons = new List<Button>() { new Button() {ActionType="reply", ActionBody = Top10Message, Text = Top10Message }, new Button() { ActionType = "reply", ActionBody = backMessage, Text = backMessage } } };
                            await new ViberApiSender().SendKeyboard(new MessageToSendWithKeyboard() { Receiver = receivedMessage.Sender.Id, Type="text", Min_api_version=3, Text = (await _walkService.GetGeneralWalksByIMEI(receivedMessage.Message.Text)).ToString(), Keyboard = keyboard }, sendMessageUrl);
                            await _userService.ChangeUserIMEI(receivedMessage.Sender.Id, receivedMessage.Message.Text);
                            break;
                        }

                        await new ViberApiSender().SendMessage(new MessageToSend() { Receiver = receivedMessage.Sender.Id, Type = "text", Text = invalidIMEIMessage }, sendMessageUrl);
                        break;

                }

            }
            
            var subscribedMessage = JsonConvert.DeserializeObject<SubscribedCallback>(stringMessage);

            if (subscribedMessage.GetType().GetProperties().All(p => p.GetValue(subscribedMessage) != null))
            {
                await new ViberApiSender().SendMessage(new MessageToSend { Receiver = subscribedMessage.User.Id, Type = "text", Text = enterIMEIMessage }, sendMessageUrl);
                return true;
            }

            var webhookMessage = JsonConvert.DeserializeObject<WebhookResponse>(stringMessage);

            if(webhookMessage.GetType().GetProperties().All(p => p.GetValue(webhookMessage) != null))
            {
                return true;
            }

            return false;
        }
    }
}
