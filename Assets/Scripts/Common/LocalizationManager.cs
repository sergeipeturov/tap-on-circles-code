using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationManager
{
    public static LocalizationLanguage Language { get; private set; }

    public static bool IsRus { get { return Language == LocalizationLanguage.ru; } }

    public static void SetLanguage(bool rus)
    {
        Language = rus ? LocalizationLanguage.ru : LocalizationLanguage.en;
    }

    public static string GetStringByKey(string key)
    {
        switch (key)
        {
            case "RageCombo":
                return IsRus ? "Длина комбо для входа в ярость" : "Combo Length to get Rage Mode";

            case "MaxCoinOnField":
                return IsRus ? "Макс. кол-во монет на поле" : "Max count of Coins on the Field";

            case "ChanceCoinOnField":
                return IsRus ? "Wанс появления монеты на поле" : "Chance of spawn a Coin on the Field";

            case "TimeOfLifeCoinOnField":
                return IsRus ? "Время жизни монеты на поле" : "Time of Life of a Coin on the Field";

            case "CoinCountInCircle":
                return IsRus ? "Макс. кол-во монет в круге" : "Max count of Coins in a Circle";

            case "ChanceCoinCountInCircle":
                return IsRus ? "Wанс появления монеты в круге" : "Chance of spawn a Coin in a Circle";

            case "LossesToGameOver":
                return IsRus ? "Кол-во потерь для проигрыша" : "Count of Losses before Game Over";

            case "ChanceOfGoodCircle":
                return IsRus ? "Wанс появления * круга" : "Chance of spawn a * Circle";

            case "ChanceOfBadCircle":
                return IsRus ? "Wанс появления X круга" : "Chance of spawn a X Circle";

            case "TapCostOfCircle":
                return IsRus ? "Очки за тап по кругу (в т.ч. для ярости)" : "Score for Tap on a Circle (for Rage too)";

            case "TimeOfLifeCircle":
                return IsRus ? "Скорость уменьшения кругов" : "Circle decrease Speed";

            case "RoundScoreAch1":
                return IsRus ? "3аработать 100 очков за один раунд." : "Earn 100 Score for one round.";

            case "RoundScoreAch2":
                return IsRus ? "3аработать 1000 очков за один раунд." : "Earn 500 Score for one round.";

            case "RoundScoreAch3":
                return IsRus ? "3аработать 10000 очков за один раунд." : "Earn 1000 Score for one round.";

            case "RoundCoinsAch1":
                return IsRus ? "3аработать 100 монет за один раунд." : "Earn 100 Coins for one round.";

            case "RoundCoinsAch2":
                return IsRus ? "3аработать 1000 монет за один раунд." : "Earn 500 Coins for one round.";

            case "RoundCoinsAch3":
                return IsRus ? "3аработать 10000 монет за один раунд." : "Earn 1000 Coins for one round.";

            case "ComboAch1":
                return IsRus ? "Комбо: 25." : "Combo: 25.";

            case "ComboAch2":
                return IsRus ? "Комбо: 100." : "Combo: 100.";

            case "ComboAch3":
                return IsRus ? "Комбо: 250." : "Combo: 250.";

            case "RagePlayedAch1":
                return IsRus ? "Сыграть 1 ярость хотя бы раз." : "Play 1 Rage at least one time.";

            case "RagePlayedAch2":
                return IsRus ? "Сыграть 5 ярость хотя бы раз." : "Play 5 Rage at least one time.";

            case "RagePlayedAch3":
                return IsRus ? "Сыграть 10 ярость хотя бы раз." : "Play 10 Rage at least one time.";

            case "RageDoneAch1":
                return IsRus ? "3авершить 1 ярость." : "Done 1 Rage.";

            case "RageDoneAch2":
                return IsRus ? "3авершить 5 ярость." : "Done 5 Rage.";

            case "RageDoneAch3":
                return IsRus ? "3авершить 10 ярость." : "Done 10 Rage.";

            case "RageIdealAch1":
                return IsRus ? "Идеально завершить 1 ярость." : "Done Ideal 1 Rage.";

            case "RageIdealAch2":
                return IsRus ? "Идеально завершить 1 ярость." : "Done Ideal 1 Rage.";

            case "RageIdealAch3":
                return IsRus ? "Идеально завершить 1 ярость." : "Done Ideal 1 Rage.";

            case "RageDoneByRoundAch1":
                return IsRus ? "3авершить 2 ярости за один раунд." : "Done 2 Rage in one round.";

            case "RageDoneByRoundAch2":
                return IsRus ? "3авершить 6 ярости за один раунд." : "Done 6 Rage in one round.";

            case "RageDoneByRoundAch3":
                return IsRus ? "3авершить 10 ярости за один раунд." : "Done 10 Rage in one round.";

            case "LevelPassedAch1":
                return IsRus ? "Достигнуть 5 уровня." : "Reach 5 Level.";

            case "LevelPassedAch2":
                return IsRus ? "Достигнуть 7 уровня." : "Reach 7 Level.";

            case "LevelPassedAch3":
                return IsRus ? "Достигнуть 10 уровня." : "Reach 10 Level.";

            case "LevelPassedNoLossAch1":
                return IsRus ? "Достигнуть 5 уровня без потерь." : "Reach 5 Level without Losses.";

            case "LevelPassedNoLossAch2":
                return IsRus ? "Достигнуть 7 уровня без потерь." : "Reach 7 Level without Losses.";

            case "LevelPassedNoLossAch3":
                return IsRus ? "Достигнуть 10 уровня без потерь." : "Reach 10 Level without Losses.";

            case "ScoresTotalAch1":
                return IsRus ? "3аработать 10000 очков всего." : "Earn 10000 Score total.";

            case "ScoresTotalAch2":
                return IsRus ? "3аработать 100000 очков всего." : "Earn 100000 Score total.";

            case "ScoresTotalAch3":
                return IsRus ? "3аработать 1000000 очков всего." : "Earn 1000000 Score total.";

            case "CoinsTotalAch1":
                return IsRus ? "3аработать 10000 монет всего." : "Earn 10000 Coins total.";

            case "CoinsTotalAch2":
                return IsRus ? "3аработать 100000 монет всего." : "Earn 100000 Coins total.";

            case "CoinsTotalAch3":
                return IsRus ? "3аработать 1000000 монет всего." : "Earn 1000000 Coins total.";

            case "WinModeText":
                if (IsRus)
                {
                    return $"Вы набрали {Environment.NewLine}" +
                        $"1 000 000 000 очков (или монет).{Environment.NewLine}" +
                        $"Я не знаю, как и зачем, но это было впечатляюще. Примите мои искренние поздравления! Надеюсь, вам было приятно и интересно.{Environment.NewLine}{Environment.NewLine}" +
                        $"Спасибо за игру!";
                }
                else
                {
                    return $"You have reached {Environment.NewLine}" +
                        $"1 000 000 000 points (or coins).{Environment.NewLine}" +
                        $"I don`t know, how and why, but this was impressive. Accept my sincere congratulations! I hope you found it pleasant and interesting.{Environment.NewLine}{Environment.NewLine}" +
                        $"Thanks for playing!";
                }

            case "WellcomeMessage1_1":
                if (IsRus)
                    return $"Добро пожаловать в {Environment.NewLine}Tap On Circles!";
                else
                    return $"Wellcome to {Environment.NewLine}Tap On Circles!";

            case "WellcomeMessage1_2":
                if (IsRus)
                    return $"Мне очень приятно, что вы решили попробовать мою первую игру. Позвольте объяснить вам правила.";
                else
                    return $"I`m very pleased that you decided to try my first game. Let me tell you the rules.";

            case "WellcomeMessage2":
                if (IsRus)
                    return $"Все, что нужно делать в этой игре - тапать по кругам. Каждый тап приносит вам очки. Они отображаются в левом верхнем углу.";
                else
                    return $"All you have to do in this game is tap on circles. Each tap brings you points. They are displayed in the upper left corner.";

            case "WellcomeMessage3":
                if (IsRus)
                    return $"Однако, как вы могли заметить, у каждого круга внутри есть число. Это ПОРЯДОК.";
                else
                    return $"However, as you may have noticed, each circle has a number inside it. This is ORDER.";

            case "WellcomeMessage4":
                if (IsRus)
                    return $"Тапая на круги в правильном порядке (1 - 2 - 3 и т.д.), вы совершаете КОМБО и заполняете особую шкалу.";
                else
                    return $"By tapping on circles in the correct order (1 - 2 - 3, etc.) you make a COMBO and fill a special scale.";

            case "WellcomeMessage5":
                if (IsRus)
                    return $"Если вы не успеваете тапнуть по кругу до того, как он исчез с поля, этот круг записывается в ПОТЕРИ. Когда вы наберете определенное число потерь, вы проиграете.";
                else
                    return $"If you don`t tap a circle before it disappears from the field, this circle is recorded as LOSS. When you get a certain number of losses, you will lose.";

            case "WellcomeMessage6":
                if (IsRus)
                    return $"Отличной игры!";
                else
                    return $"Good luck!";

            case "RageMessage1":
                if (IsRus)
                    return $"Когда шкала комбо заполнена, вы можете войти в особый режим ЯРОСТИ, нажав эту кнопку.";
                else
                    return $"When the combo scale is full, you can enter a special RAGE mode by pressing this button.";

            case "RageMessage2":
                if (IsRus)
                    return $"В режиме ярости вам будет предложено одно из нескольких нестандартных испытаний, основное правило в которых то же - тапать на круги.";
                else
                    return $"In rage mode, you will be offered one of several non-standard challenges, the basic rule in which is the same - to tap on circles.";

            case "RageMessage3":
                if (IsRus)
                    return $"Для идеального прохождения испытания нужно соблюдать порядок. Это необязательно, но за это начисляется бонус.";
                else
                    return $"To pass a challenge ideally, you must follow the order. This is optional, but a bonus is awarded for this.";

            case "SpecialMessage1":
                if (IsRus)
                    return $"Во время игры вам обязательно встретятся особые круги. Их можно игнорировать - потеря такого круга не засчитывается.";
                else
                    return $"During the game, you will definitely encounter special circles. They can be ignored - the loss of such a circle does not count.";

            case "SpecialMessage2":
                if (IsRus)
                    return $"Круг с символом * - это хороший круг. Тап на него очищает поле и начисляет вам очки и монеты за каждый круг, который был на поле. Правда, за это он сбивает шкалу комбо.";
                else
                    return $"A circle with a * is a good circle. Tap on it clears the field and gives you points and coins for each circle that was on the field. But it knocks down the combo scale.";

            case "SpecialMessage3":
                if (IsRus)
                    return $"Круг с символом X - это плохой круг. Он тоже очищает поле, но засчитывает вам потерю за каждый объект. Он также сбивает шкалу комбо.";
                else
                    return $"A circle with an X is a bad circle. It also clears the field, but counts the loss for each object. It also knocks down the combo scale.";

            case "SpecialMessage4":
                if (IsRus)
                    return $"Маленькие желтые круги - это монеты. На них написан их номинал. Собирайте монеты и тратьте их на улучшения в магазине в главном меню. Кстати, тап по монете тоже сбивает шкалу комбо.";
                else
                    return $"The small yellow circles are coins. Their denomination is written on them. Collect coins and spend them on improvements in the store in the main menu. By the way, tapping on a coin also knocks down the combo scale.";

            case "SpecialMessage5":
                if (IsRus)
                    return $"Монеты могут встретиться внутри обычного круга. В этом случае тап по кругу принесет не только очки, но и столько монет, сколько будет в этом круге. При этом шкала комбо не собьется.";
                else
                    return $"Coins can meet inside an ordinary circle. In this case, tapping in a circle will bring not only points, but also as many coins as there will be in this circle. In this case, the combo scale will not go astray.";

            case "AchieveMessage1":
                if (IsRus)
                    return $"Когда вы видите снизу такое сообщение, это значит, что вы выполнили условие для разблокировки какого-то достижения.";
                else
                    return $"When you see such a message below, it means that you have met the condition for unlocking an achievement.";

            case "AchieveMessage2":
                if (IsRus)
                    return $"Список достижений можно посмотреть из главного меню или меню паузы, тапнув по этому значку.";
                else
                    return $"The list of achievements can be viewed from the main menu or the pause menu by tapping on this icon.";

            case "AchieveMessage3":
                if (IsRus)
                    return $"Каждое достижение имеет три ранга, за которые назначаются медали. Тапнув по медали, вы получите награду за достижение.";
                else
                    return $"Each achievement has three ranks, for which medals are awarded. By tapping on a medal, you will receive an achievement reward.";

            case "GameOverMessage1":
                if (IsRus)
                    return $"Вы проиграли! Но не расстраивайтесь, это не конец света. Даже не конец раунда, если быть честным...";
                else
                    return $"You lose! But don't worry, this is not the end of the world. Not even the end of the round, to be honest...";

            case "GameOverMessage2":
                if (IsRus)
                    return $"Вы можете продолжить раунд с момента проигрыша, если нажмете эту кнопку. Потратьте несколько секунд на просмотр рекламы и возвращайтесь в игру!";
                else
                    return $"You can continue the round from the moment of loss if you press this button. Spend a few seconds watching ads and get back in the game!";

            case "GameOverMessage3":
                if (IsRus)
                    return $"Кроме того, посмотрев рекламу таким образом вы поддержите меня как разработчика и это поможет мне в дальнейшем создать более сложные и интересные игры. Спасибо!";
                else
                    return $"In addition, by watching ads in this way, you will support me as a developer and this will help me create more complex and interesting games in the future. Thank you!";

            case "GameOverMessage4":
                if (IsRus)
                    return $"Еще поддержать меня и мою команду можно, вступив в нашу группу VK и подписавшись на Youtube канал. Когда мы видим, что мы нужны, это вдохновляет нас.";
                else
                    return $"You can also support me and my team by joining our VK group and subscribing to the Youtube channel. When we see that we are needed, it inspires us!";

            case "ResetTutorButton":
                if (IsRus)
                    return $"Сбросить обучение";
                else
                    return $"Reset Tutorial";

            case "ResetAllButton":
                if (IsRus)
                    return $"Сбросить все";
                else
                    return $"Reset All";

            default:
                return "";
        }
    }
}

public enum LocalizationLanguage : int
{
    en = 0,
    ru
}