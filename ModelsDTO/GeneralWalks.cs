namespace ViberWalkTracker.ModelsDTO
{
    public class GeneralWalks
    {
        public GeneralWalks(List<WalkDTO> walks) {
            _walksAmount = walks.Count;
            _generalDistance = walks.Sum(x => x.Distance);
            _generalDuration = walks.Sum(_x => _x.Duration);
        }

        private int _walksAmount;
        private decimal _generalDistance; 
        private int _generalDuration; 

        public override string ToString()
        {
            return $"Всього прогулянок: {_walksAmount} \n Всього км пройдено: {_generalDistance} \n Всього часу, хв: {_generalDuration}";
        }
    }
}
