# crate simulator

# Simple

core:
- simple like loading bar simulator, trump game
- lose money and open card packs

hook:
- lack of direction is intriguing for exploration
- opening card packs, lose money

goal:
- lose $10,000 dollars
- gamble cards
- get pink cards

effort:
- clicking cards
- upgrading stuff

end:
- reaching achievement milestones

game:
start just by opening loot
- similar to the nba2k card pack
- display generic backs, then show colours
- count points

Dates:
August 14th: 
- Basic concept

August 15th:
- concept

August 16th:
- colours have different spawn rates (common white 30%, brown 20%, etc
.)
- make cards have a points value that is counted up when all 6 have been revealed
- card effects when opened (particle effects)

August 17th:
- card effects when opened (particle effects)

August 18th:
- menu to start game
- exit game gameobject

August 19th:
- inventory to view the cards (figure out if it is persistent)

August 22th:
- four crates per open instead of six
- money counter, sell cards in inventory

August 23st:
- set inventory to be created by positions and a for loop to set index of card automatically
- upgrade shop
- button click sound

August 24th:
- upgrade shop
- show balance in main screen? (no)
- gamble microtransactions (possibly)

August 25th:
- trophy room
- button click sound
- get shop to work with better upgrades
- win condition
- steamworks api and achievements

August 26th:
- steamworks api (done)
- achievements (one done)

August 28th:
- submit app
- get first one free, casino, and schooled achievements to work
- chlsea logo

August 29th:
- implement 3 more achievements
- implement loading screen

August 30th:
- more achievements
- intro logo

August 31st:
- fix peach fuzz etc.
- fix screenshot for crate simulator

Sept 2nd:
- google analytics
- EULA (no)

Sept 3rd:
- save progress (do it for shop and inventory) (done)
- save progress cash balance
- fix achievement text for the description
- fix screen resolution issue on windows (done)
- graphics options

Sept 4th:
- enumerator (done)
- post an annoucement (done)
- save load (finish up ALL data)
- turn down ka-ching sound (too loud)
- achievements (done)
- rehaul cardOpenList and cardInfoList (done)
- combos (done-basic)
- clean up save and load (done)

Sept 5th:
- persist shopFlags (done)
- improve the upgrades ( and architect->hangman)
- adventures and prestiging (write doc specs) (done)
- flip cards effect
- shine when hover over cards

Sept 6th:
- prestiging
- speedrun->one click button
- complex combos
- generic text popup


known issues:
- inventory sometimes not subtracting cards correctly for fuzz or otherwise (fixed)
- shop flags not saving (fixed)
- opening partially will fill cardInfoList, but not cardOpenList

upgrades: (8)
- meaninglessUpgrade 25 - nothing? (done)
- Card Trick 60 - (nothing right now)
- betterLuckNextTime 200 - luck upgrade (done)
- Mayan2012 300 - clickable avocado (done)
- SCOGLotto 1000 - casino (doneish)
- TrophyRoom 1997 - trophy room (done poorly)
- Architect 4000 - open it with -1000 dollars (fake?)
- SpeedRunZ 9999 - Speedrun button (fake)

achievements:

implemented:
- first one is free (open a pack)
- the house always wins, old habits die hard (buy casino in shop)
- Schooled, some people graduate but they still stupid (buy degree in shop)
- oh what a feeling (open 50 packs)
- dancing on the ceiling (open 100 packs)
- Guacamole (click avocado at least once)
- peach fuzz (pull a fuzz colour)
- turquoise turquoise (pull a turquoise colour)
- green pea (pull a green colour)
- red beet (pull a red colour)
- purple grape (pull a purple colour)
- blue berry (pull a blue colour)
- brown bag (pull a brown colour)
- white onion (pull a white colour)
- the year is 2017 (get more than 2017 value in 4 cards)
- holy moly (get more than 10k value in 4 cards)
- rich (get $5000)
- against all odds (get more than 24k value in 4 cards)

in progress:


not yet implemented:
- Negative 100 dollars (get -$100)
- time well spent (get $1000)
- tricks are for kids (card trick in shop)
- lack of content (DLC in DLC)
- FNG (reach prestige 2)

quests:
- certain challenges (get 2 red in one pull)
- complete it and get prestige points

prestige:
- lower pack cost
- better odds
- new rarities
- new shop items

real extension:
- each colour card has a use (blue ocean, etc.)
- sparkle sound on rare cards
- move inventory interface to the main screen instead of a new scene
- more card types: gold, silver, etc.
- more upgrades in the shop


extension:
- get opening crates by playing simple games
- get currency to buy loot boxes through simple games (ex. tower defense, rare loot are rare tower type variants)
- Cards have letters (A, B, D) denoting type
- limit at 10 crates every 2 hours, show timer
- saving the game and persistent data
- simplify colours (still deciding on this)

plan:
- simulate opening a card pack/crate
- crates 10 every day
- rarity:
fuzz
turquoise
green
red
purple
blue
brown
white

ideas:

notes:
shootawatch overwatch
hat castle tf2
magikcardZ hearthstone
duty of honour call of duty


