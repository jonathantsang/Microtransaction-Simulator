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
- improve the upgrades (architect->hangman) (partial)
- adventures and prestiging (write doc specs) (done)

Sept 6th:
- finish hangman (done)
- make rare cards worth more
- shine when hover over cards (done)

Sept 7th:
- generic text popup
- prestiging

Sept 11:
- save lucid flag (or count)
- perks of lucid (not visual changes)
- set illuminate to correct colours based on rarity instead of random (done)
- win the game achievement (done)

Sept 12:
- turn off debug (done)
- fix save data (corruption) (omitted)
- restart button (done)
- fix hangman
- click start game (for the masses who I "fooled" unknowingly)
- implement meaningless upgrade, card trick, speedrun (done)
- show how much each card sells for (fix card amounts not right?)
- debt achievement (done)

Next Build:
Sept 14:
Day One DLC Patch
- save stats should work now (phew...hopefully)
- removed ESC to quit due to popular demand?
- fixed guacamole "exploit"
- achievements should be fixed (FNG, Dead, win game)
- fixing shrinking buttons and growing when click spammed
- lucid isn't game breaking (my QA people are fired. AKA me)

Sept 14: // Hi people reading this to get achievements
- sell all quicker
future achievements:
- might number 8
- Bee Movie
- AMATH cool math dude
- PMATH wow
- Broccoli eat your green veggies
- early adopter (play the game on release date September 14-15th)
v1.1:
- hangman rewards
- harder to win

Sept 18:
- lucid rehaul (more graphic)
- sell all button for speedrun
- quests with timer
- clean up inventoryStorage methods
- harder achievements

achievements:
- mute
- anti-mute
- anti-anti-mute
- new game++
- casino royale
- open 1000 packs
- open 500 packs

Plan for Future:
- better lucid perks
- more achievements/longer game since some people wanted more substance
- increase shop prices
- new game++
- lucid popup in the middle of the screen
- fix casino, architect, trophyroom
- get a mute button
- free to use music
- obfuscate the code


lessons:
- test it (a week or so everything)
- game dev is an iterative process

Not sure:
- flip cards effect
- speedrun->one click button
- complex combos
- reset progress
- scouting party?
- quests

known issues:
- opening partially will fill cardInfoList, but not cardOpenList
- lucid priceofpack drop is hardcoded to $1 and will go negative

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
- renaissance man 1776

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
- tricks are for kids (card trick in shop)
- FNG (reach lucid 2)
- Negative 100 dollars (get -$100)
- dead (get -$1000)

in progress:


not yet implemented:
- lack of content (DLC in DLC)


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

fixed:
- inventory sometimes not subtracting cards correctly for fuzz or otherwise (fixed)
- shop flags not saving (fixed)

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


