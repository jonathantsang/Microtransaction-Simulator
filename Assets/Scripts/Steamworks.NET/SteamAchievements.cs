using UnityEngine;
using System.Collections;
using System.ComponentModel;
using Steamworks;

// This is a port of StatsAndAchievements.cpp from SpaceWar, the official Steamworks Example.
class SteamAchievements : MonoBehaviour {
	private enum Achievement : int {
		ACH_FIRST_ONE_IS_FREE,
		ACH_THE_HOUSE_ALWAYS_WINS,
		ACH_SCHOOLED,
		ACH_FEELING,
		ACH_CEILING,
		ACH_GUACAMOLE,
		ACH_FUZZ,
		ACH_TURQUOISE,
		ACH_GREEN,
		ACH_RED,
		ACH_PURPLE,
		ACH_BLUE,
		ACH_BROWN,
		ACH_WHITE,
		ACH_CHLSEA,
		ACH_YEARIS20XX,
		ACH_RICH,
		ACH_HOLYMOLY,
		ACH_AGAINSTALLODDS
	};

	private Achievement_t[] m_Achievements = new Achievement_t[] {
		new Achievement_t(Achievement.ACH_FIRST_ONE_IS_FREE, "First One is Free", "Sometimes there is a free lunch"),
		new Achievement_t(Achievement.ACH_THE_HOUSE_ALWAYS_WINS, "The House Always Wins", "Old habits die hard"),
		new Achievement_t(Achievement.ACH_SCHOOLED, "SCHOOLED", "Some people graduate but they still stupid"),
		new Achievement_t(Achievement.ACH_FEELING, "Oh What a Feeling", "Open 50 packs"),
		new Achievement_t(Achievement.ACH_CEILING, "We're dancing on the ceiling", "Open 100 packs"),
		new Achievement_t(Achievement.ACH_GUACAMOLE, "Guacamole", "Yum"),
		new Achievement_t(Achievement.ACH_FUZZ, "Peach Fuzz", "Get a fuzz"),
		new Achievement_t(Achievement.ACH_TURQUOISE, "Turquoise Turquoise", "Get a turquoise"),
		new Achievement_t(Achievement.ACH_GREEN, "Green Peas", "Get a green"),
		new Achievement_t(Achievement.ACH_RED, "Red Beet", "Get a red"),
		new Achievement_t(Achievement.ACH_PURPLE, "Purple Grape", "Get a purple"),
		new Achievement_t(Achievement.ACH_BLUE, "Blue Berry", "Get a blue"),
		new Achievement_t(Achievement.ACH_BROWN, "Brown Bagel", "Get a brown"),
		new Achievement_t(Achievement.ACH_WHITE, "White Onion", "Get a white"),
		new Achievement_t(Achievement.ACH_CHLSEA, "chlsea", "It's a secret to everybody"),
		new Achievement_t(Achievement.ACH_YEARIS20XX, "The Year is 20XX", "2017"),
		new Achievement_t(Achievement.ACH_RICH, "Riches", "A small loan of 1 million dollars"),
		new Achievement_t(Achievement.ACH_HOLYMOLY, "Holy Moly", "Unrelated"),
		new Achievement_t(Achievement.ACH_AGAINSTALLODDS, "Against All Odds", "Take a look at me now")
	};

	// Our GameID
	private CGameID m_GameID;

	// Did we get the stats from Steam?
	private bool m_bRequestedStats;
	private bool m_bStatsValid;

	// Should we store stats this frame?
	private bool m_bStoreStats;

	// Persisted Stat details
	private int m_nTotalGamesPlayed;
	private int m_nTotalNumWins;
	private int m_nTotalNumLosses;
	private float m_flTotalFeetTraveled;
	private float m_flMaxFeetTraveled;
	private float m_flAverageSpeed;

	private int m_nHighScore;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;
	protected Callback<UserStatsStored_t> m_UserStatsStored;
	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	// Look for the inventory storage with the game data
	inventoryStorage iS;
	// shop storage with the shop data
	shopStorage sS;

	void OnEnable() {
		if (!SteamManager.Initialized)
			return;

		// Cache the GameID for use in the Callbacks
		m_GameID = new CGameID(SteamUtils.GetAppID());

		m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
		m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
		m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);

		// These need to be reset to get the stats upon an Assembly reload in the Editor.
		m_bRequestedStats = false;
		m_bStatsValid = false;

		iS = GameObject.FindGameObjectWithTag ("inventoryStorage").GetComponent<inventoryStorage>();
		sS = GameObject.FindGameObjectWithTag ("shopStorage").GetComponent<shopStorage>();
	}

	private void Update() {
		if (!SteamManager.Initialized)
			return;

		if (!m_bRequestedStats) {
			// Is Steam Loaded? if no, can't get stats, done
			if (!SteamManager.Initialized) {
				m_bRequestedStats = true;
				return;
			}

			// If yes, request our stats
			bool bSuccess = SteamUserStats.RequestCurrentStats();

			// This function should only return false if we weren't logged in, and we already checked that.
			// But handle it being false again anyway, just ask again later.
			m_bRequestedStats = bSuccess;
		}

		if (!m_bStatsValid)
			return;

		// Get info from sources

		// Evaluate achievements
		foreach (Achievement_t achievement in m_Achievements) {
			int achievementIndex = 0;
			int cardIndex = 0;
			if (achievement.m_bAchieved)
				continue;

			switch (achievement.m_eAchievementID) {
			case Achievement.ACH_FIRST_ONE_IS_FREE:
				// Check if the inventory storage has more than 1 opened pack
				if (iS.getPacksOpened () > 1) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_THE_HOUSE_ALWAYS_WINS:
				// Check in the shop storage has the casino flag is on
				achievementIndex = 4; // TODO casino index is hardcoded
				if (sS.checkFlag (achievementIndex) == 1) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_SCHOOLED:
				// Check in the shop storage has the architect flag is on
				achievementIndex = 6; // TODO architect index is hardcoded
				if (sS.checkFlag (achievementIndex) == 1) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_FEELING:
				// Check if the inventory storage has 50 opened packs
				if (iS.getPacksOpened () >= 50) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_CEILING:
				// Check if the inventory storage has 100 opened packs
				if (iS.getPacksOpened() >= 100) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_GUACAMOLE:
				// Check in the inventory storage has the guacamole flag is on
				if (iS.getAvocadoClicked() == 1) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_FUZZ:
				cardIndex = 7; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_TURQUOISE:
				cardIndex = 6; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_GREEN:
				cardIndex = 5; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_RED:
				cardIndex = 4; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_PURPLE:
				cardIndex = 3; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_BLUE:
				cardIndex = 2; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_BROWN:
				cardIndex = 1; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_WHITE:
				cardIndex = 0; // TODO hardcoded cardIndex for colour
				if (iS.checkCard(cardIndex) > 0) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_CHLSEA:
				if (iS.checkFlag ("logo") == 1) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_YEARIS20XX:
				foreach (cardOpen cardOpenInformation in iS.cardOpenList) {
					if (cardOpenInformation.totalCardOpenValue > 2017) {
						UnlockAchievement (achievement);
					}
				}
				break;
			case Achievement.ACH_RICH:
				if (iS.getBalance() > 5000) {
					UnlockAchievement (achievement);
				}
				break;
			case Achievement.ACH_HOLYMOLY:
				foreach (cardOpen cardOpenInformation in iS.cardOpenList) {
					if (cardOpenInformation.totalCardOpenValue > 24000) {
						UnlockAchievement (achievement);
					}
				}
				break;
			case Achievement.ACH_AGAINSTALLODDS:
				foreach (cardOpen cardOpenInformation in iS.cardOpenList) {
					if (cardOpenInformation.totalCardOpenValue > 10000) {
						UnlockAchievement (achievement);
					}
				}
				break;
		}
	}

		//Store stats in the Steam database if necessary
		if (m_bStoreStats) {
			// set stats
			SteamUserStats.SetStat("NumGames", m_nTotalGamesPlayed);
			SteamUserStats.SetStat("NumWins", m_nTotalNumWins);
			SteamUserStats.SetStat("NumLosses", m_nTotalNumLosses);
			SteamUserStats.SetStat("FeetTraveled", m_flTotalFeetTraveled);
			SteamUserStats.SetStat("MaxFeetTraveled", m_flMaxFeetTraveled);
			// The averaged result is calculated for us
			SteamUserStats.GetStat("AverageSpeed", out m_flAverageSpeed);

			bool bSuccess = SteamUserStats.StoreStats();
			// If this failed, we never sent anything to the server, try
			// again later.
			m_bStoreStats = !bSuccess;
		}
	}

	//-----------------------------------------------------------------------------
	// Purpose: Unlock this achievement
	//-----------------------------------------------------------------------------
	private void UnlockAchievement(Achievement_t achievement) {
		achievement.m_bAchieved = true;

		// the icon may change once it's unlocked
		//achievement.m_iIconImage = 0;

		// mark it down
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());

		// Store stats end of frame
		m_bStoreStats = true;
	}

	//-----------------------------------------------------------------------------
	// Purpose: We have stats data from Steam. It is authoritative, so update
	//			our data with those results now.
	//-----------------------------------------------------------------------------
	private void OnUserStatsReceived(UserStatsReceived_t pCallback) {
		if (!SteamManager.Initialized)
			return;

		// we may get callbacks for other games' stats arriving, ignore them
		if ((ulong)m_GameID == pCallback.m_nGameID) {
			if (EResult.k_EResultOK == pCallback.m_eResult) {
				Debug.Log("Received stats and achievements from Steam\n");

				m_bStatsValid = true;

				// load achievements
				foreach (Achievement_t ach in m_Achievements) {
					bool ret = SteamUserStats.GetAchievement(ach.m_eAchievementID.ToString(), out ach.m_bAchieved);
					if (ret) {
						ach.m_strName = SteamUserStats.GetAchievementDisplayAttribute(ach.m_eAchievementID.ToString(), "name");
						ach.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(ach.m_eAchievementID.ToString(), "desc");
					}
					else {
						Debug.LogWarning("SteamUserStats.GetAchievement failed for Achievement " + ach.m_eAchievementID + "\nIs it registered in the Steam Partner site?");
					}
				}

				// load stats
				SteamUserStats.GetStat("NumGames", out m_nTotalGamesPlayed);
				SteamUserStats.GetStat("NumWins", out m_nTotalNumWins);
				SteamUserStats.GetStat("NumLosses", out m_nTotalNumLosses);
				SteamUserStats.GetStat("FeetTraveled", out m_flTotalFeetTraveled);
				SteamUserStats.GetStat("MaxFeetTraveled", out m_flMaxFeetTraveled);
				SteamUserStats.GetStat("AverageSpeed", out m_flAverageSpeed);
			}
			else {
				Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	//-----------------------------------------------------------------------------
	// Purpose: Our stats data was stored!
	//-----------------------------------------------------------------------------
	private void OnUserStatsStored(UserStatsStored_t pCallback) {
		// we may get callbacks for other games' stats arriving, ignore them
		if ((ulong)m_GameID == pCallback.m_nGameID) {
			if (EResult.k_EResultOK == pCallback.m_eResult) {
				Debug.Log("StoreStats - success");
			}
			else if (EResult.k_EResultInvalidParam == pCallback.m_eResult) {
				// One or more stats we set broke a constraint. They've been reverted,
				// and we should re-iterate the values now to keep in sync.
				Debug.Log("StoreStats - some failed to validate");
				// Fake up a callback here so that we re-load the values.
				UserStatsReceived_t callback = new UserStatsReceived_t();
				callback.m_eResult = EResult.k_EResultOK;
				callback.m_nGameID = (ulong)m_GameID;
				OnUserStatsReceived(callback);
			}
			else {
				Debug.Log("StoreStats - failed, " + pCallback.m_eResult);
			}
		}
	}

	//-----------------------------------------------------------------------------
	// Purpose: An achievement was stored
	//-----------------------------------------------------------------------------
	private void OnAchievementStored(UserAchievementStored_t pCallback) {
		// We may get callbacks for other games' stats arriving, ignore them
		if ((ulong)m_GameID == pCallback.m_nGameID) {
			if (0 == pCallback.m_nMaxProgress) {
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
			}
			else {
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' progress callback, (" + pCallback.m_nCurProgress + "," + pCallback.m_nMaxProgress + ")");
			}
		}
	}
		
	private class Achievement_t {
		public Achievement m_eAchievementID;
		public string m_strName;
		public string m_strDescription;
		public bool m_bAchieved;

		/// <summary>
		/// Creates an Achievement. You must also mirror the data provided here in https://partner.steamgames.com/apps/achievements/yourappid
		/// </summary>
		/// <param name="achievement">The "API Name Progress Stat" used to uniquely identify the achievement.</param>
		/// <param name="name">The "Display Name" that will be shown to players in game and on the Steam Community.</param>
		/// <param name="desc">The "Description" that will be shown to players in game and on the Steam Community.</param>
		public Achievement_t(Achievement achievementID, string name, string desc) {
			m_eAchievementID = achievementID;
			m_strName = name;
			m_strDescription = desc;
			m_bAchieved = false;
		}
	}
}
