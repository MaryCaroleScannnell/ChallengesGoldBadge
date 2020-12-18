using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Komodo_Claims_Repo
{
    public class KomodoClaimRepo
    {
        private Queue<KomodoClaims> _queueOfClaims = new Queue<KomodoClaims>();

        //Create
        public void AddClaimToQueue(KomodoClaims claims)
        {
            _queueOfClaims.Enqueue(claims);
        }

        //Read
        public Queue<KomodoClaims> GetKomodoClaims()
        {
            return _queueOfClaims;
        }

        //Remove from Queue
        public void RemoveClaimFromQueue()

        {
            _queueOfClaims.Dequeue();
        }

        //View Next Item in Queue

        public void ViewNextInQueue()
        {

            _queueOfClaims.Peek();
        }
    }
}
