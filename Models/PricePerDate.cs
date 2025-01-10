using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class PricePerDate
    {
        [Key]
        public int pricePD_id { get; set; }
        public int RoomTypeId { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public float newPricePerDate { get; set; }
        public bool actState { get; set; }
        [ForeignKey("RoomTypeId")]
        public TQePreco TQePreco { get; set; }

        public List<Events> Events { get; set; }
        public List<Sazonalidade> Sazonalidades { get; set; }
        public List<Promos> Promos { get; set; }

        public void CalculateNewPrice(string? promoCode = null)
        {
            if (TQePreco == null || TQePreco.BasePrice == 0)
            {
                newPricePerDate = 0;
                return;
            }

            float maxFee = CalculateMaxFee(dateBegin, dateEnd);
            float totalModifiers = 1.0f + maxFee;

            if (!string.IsNullOrEmpty(promoCode))
            {
                totalModifiers += ApplyPromoCode(promoCode);
            }

            newPricePerDate = TQePreco.BasePrice * totalModifiers;
        }

        private float CalculateMaxFee(DateTime periodStart, DateTime periodEnd)
        {
            float maxFee = 0.0f;

            for (var date = periodStart.AddDays(-7); date <= periodEnd; date = date.AddDays(1))
            {
                float dailyMaxFee = 0.0f;

                if (Events != null)
                {
                    dailyMaxFee = Math.Max(dailyMaxFee, GetEventFeeForDate(date));
                }

                if (Sazonalidades != null)
                {
                    dailyMaxFee = Math.Max(dailyMaxFee, GetSeasonFeeForDate(date));
                }

                maxFee = Math.Max(maxFee, dailyMaxFee);
            }

            return maxFee;
        }

        private float GetEventFeeForDate(DateTime date)
        {
            float eventFee = 0.0f;

            foreach (var ev in Events)
            {
                if (ev.inUse && ev.startDate.AddDays(-7) <= date && ev.endDate >= date)
                {
                    eventFee = Math.Max(eventFee, ev.fee);
                }
            }

            return eventFee;
        }

        private float GetSeasonFeeForDate(DateTime date)
        {
            float seasonFee = 0.0f;

            foreach (var saz in Sazonalidades)
            {
                if (saz.InUse && saz.DateBegin.AddDays(-7) <= date && saz.DateEnd >= date)
                {
                    seasonFee = Math.Max(seasonFee, saz.SeasonFee);
                }
            }

            return seasonFee;
        }

        private float ApplyPromoCode(string promoCode)
        {
            if (Promos == null) return 0.0f;

            foreach (var promo in Promos)
            {
                if (promo.promState && promo.evCode == promoCode)
                {
                    return promo.discount;
                }
            }

            return 0.0f;
        }
    }
}






