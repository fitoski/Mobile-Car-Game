// Original: https://assetstore.unity.com/packages/p/chain2d-58558


namespace ALIyerEdon
{ // Класс контролирующий свойсва цепи в игровом режиме для пользователя.
    public class ChainController
    {
        Chain chain;

        public float coilASpeed
        {
            get { return chain.coilASpeed; }
            set { chain.coilASpeed = value; }
        }

        public float coilBSpeed
        {
            get { return chain.coilBSpeed; }
            set { chain.coilBSpeed = value; }
        }

        public ChainController(Chain chain)
        {
            this.chain = chain;
        }


        public void snapOffA()
        {
            chain.snapOffA();
        }

        public void snapOffB()
        {
            chain.snapOffB();
        }
    }
}