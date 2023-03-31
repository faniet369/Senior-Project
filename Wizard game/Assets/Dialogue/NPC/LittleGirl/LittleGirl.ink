VAR npcChoice = ""
~npcChoice = "{~Rock|Paper|Scissors}"
->main
===main===
Brother, let's play!
* [Yes] -> Play
* [No]  -> Notplay

=== Notplay ===
Play with me pleaseeee!!
    * [Okay] -> Play
    * [Go away!]
        Sob Sob waaaaahhhhh!
        -> DONE
    
=== Play ===
VAR round = 1
VAR playerScore = 0
VAR NPCScore = 0
Yeah! Let's play Rock Paper Scissors 3 rounds!
->Logic


=== Logic ===
Let Start Round {round}:
+ [Rock] You choose Rock! I choose {npcChoice}.
{npcChoice == "Rock": Tie!}
{npcChoice == "Paper": {lose(1)}}
{npcChoice == "Scissors": {win(1)}}

~ round = round + 1
{round < 4 : ->Logic}
{round==4 : ->Score}

+ [Paper] You choose Paper! I choose {npcChoice}.
{npcChoice == "Rock" : {win(1)}}
{npcChoice == "Paper": Tie!}
{npcChoice == "Scissors": {lose(1)}}

~ round = round + 1
{round<4 : ->Logic}
{round==4 : ->Score}

+ [Scissors] You choose Scissors! I choose {npcChoice}.
{npcChoice == "Rock": {lose(1)}}
{npcChoice == "Paper": {win(1)}}
{npcChoice == "Scissors": Tie!}

~ round = round + 1
{round<4 : ->Logic}
{round==4 : ->Score}

=== Score ===
You win {playerScore} from 3 rounds. I win {NPCScore} from 3 round.
{playerScore < NPCScore : Yay! I win! Thank you for playing with me.}
{playerScore > NPCScore : Aw! I lost, I will give you candy as a reward.}
{playerScore == NPCScore : Uh...We tie? I guess this is a good game!}
->DONE

=== function win(x) ===
You win!
~ playerScore = playerScore + x

=== function lose(x) ===
You lose!
~ NPCScore = NPCScore + x



