﻿using ShareInvest.Entities;
using ShareInvest.Entities.Google;
using ShareInvest.Entities.Kakao;

namespace ShareInvest.Repositories;

public interface IUserRepository
{
    int RegisterTheFriends(string userId, IEnumerable<KakaoFriend> friends);

    int SaveCallback(KakaoCallback callback);

    int RemovePushKey(string fcmToken);

    string[] GetAccountsById(string userName);

    string[] GetFOAccountsById(string userId);

    string[] GetFuturesAccount(Securities securities);

    KakaoFriend[] BringFriends(string userId);

    Securities[] RetrieveAccountsThatOwnFutures(string date);

    Securities[] GetSecuritiesById(string userName);

    Securities[] GetSecuritiesById();

    CoordinateUser[] GetClientCoordinates(IEnumerable<string> imageUrl, string? userName = null, string? userId = null);

    IEnumerable<string> GetPushKeys();

    IEnumerable<(string userId, string loginProvider)> ConfirmedExistingUsers(string deviceId);

    IEnumerable<(string? securitiesId, string? pushKey)> GetPushKeys(string userId, string serialKey);
}