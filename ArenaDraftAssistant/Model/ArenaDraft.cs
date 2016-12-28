using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace ArenaDraftAssistant.Model
{
    class ArenaDraft
    {
        public static double ProbabilityOfXDropByTurnX(int manaCost, int cardsInOpeningHand, int mulliganAmount, int xDropsInDeck, int cardsInDeck = 30)
        {
            if (manaCost < 0 || manaCost > 10)
            {
                throw new ArgumentException($"{nameof(manaCost)} should be between 0 and 10");
            }
            if (cardsInOpeningHand < 0 || cardsInOpeningHand > cardsInDeck + manaCost)
            {
                throw new ArgumentException($"{nameof(cardsInOpeningHand)} should be between 0 and {nameof(cardsInDeck)} - {nameof(manaCost)}");
            }
            if (mulliganAmount < 0 || mulliganAmount > cardsInOpeningHand)
            {
                throw new ArgumentException($"{nameof(mulliganAmount)} should be between 0 and {nameof(cardsInOpeningHand)}");
            }
            if (xDropsInDeck < 0 || xDropsInDeck > cardsInDeck)
            {
                throw new ArgumentException($"{nameof(xDropsInDeck)} should be between 0 and {nameof(cardsInDeck)}");
            }
            if (cardsInDeck < mulliganAmount || cardsInDeck < xDropsInDeck)
            {
                throw new ArgumentException($"{nameof(cardsInDeck)} should be greater or equal to {nameof(mulliganAmount)} and {nameof(xDropsInDeck)}");
            }

            var noSuccessInOpeningHand = Hypergeometric.PMF(cardsInDeck, xDropsInDeck, cardsInOpeningHand, 0);
            var noSuccessAfterMulligan = Hypergeometric.PMF(cardsInDeck - cardsInOpeningHand, xDropsInDeck, mulliganAmount, 0);
            var noSuccessInFirstXDrops = Hypergeometric.PMF(cardsInDeck - cardsInOpeningHand, xDropsInDeck, manaCost, 0);

            var successInOpeningHand = 1d - noSuccessInOpeningHand;
            var successAfterMulligan = 1d - noSuccessAfterMulligan;
            var successInFirstXDrops = 1d - noSuccessInFirstXDrops;

            return successInOpeningHand + (noSuccessInOpeningHand * successAfterMulligan) + (noSuccessInOpeningHand * noSuccessAfterMulligan * successInFirstXDrops);
        }
    }
}
