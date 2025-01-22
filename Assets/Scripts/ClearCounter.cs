using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
        [SerializeField] private KitchenObjectsSo kitchenObjectsSO;
        [SerializeField] private Transform counterTopPoint;
        
        private KitchenObjects kitchenObject;
        
        public override void Interact(Player player)
        {
                if (kitchenObject == null)
                {
                        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint); 
                        kitchenObjectTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
                }
                else
                {      
                        kitchenObject.SetKitchenObjectParent(player);
                }
        }

        public Transform GetKitchenObjectFollowTransform()
        {
                return counterTopPoint;
        }

        public void SetKitchenObject(KitchenObjects kitchenObject)
        {
                this.kitchenObject = kitchenObject;
        }

        public KitchenObjects GetKitchenObject()
        {
                return kitchenObject;
        }

        public void ClearKitchenObject()
        {
                kitchenObject = null;
        }

        public bool HasKitchenObject()
        {
                return kitchenObject != null;
        }
        
}
