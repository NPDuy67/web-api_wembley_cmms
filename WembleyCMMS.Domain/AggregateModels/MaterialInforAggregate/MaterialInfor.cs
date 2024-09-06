using WembleyCMMS.Domain.Exceptions;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.Material;
using static WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate.MaterialRequest;

namespace WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate
{
    public class MaterialInfor : Entity, IAggregateRoot
    {
        public string MaterialInforId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal MinimumQuantity { get; set; }
        public List<MaterialHistoryCard> MaterialHistoryCards { get; set; }
        public List<Material> Materials { get; set; }
        public List<MaterialRequest> MaterialRequests { get; set; }

        public MaterialInfor(string materialInforId, string code, string name, string unit, decimal minimumQuantity)
        {
            MaterialInforId = materialInforId;
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
            MaterialHistoryCards = new List<MaterialHistoryCard>();
            Materials = new List<Material>();
            MaterialRequests = new List<MaterialRequest>();
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MaterialInfor() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Update(string code, string name, string unit, decimal minimumQuantity)
        {
            Code = code;
            Name = name;
            Unit = unit;
            MinimumQuantity = minimumQuantity;
        }

        public void AddMaterialHistoryCard(string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            var materialHistoryCard = new MaterialHistoryCard(materialHistoryCardId, timeStamp, before, input, output, after, note);
            if (MaterialHistoryCards.Exists(x => x.MaterialHistoryCardId  == materialHistoryCardId))
            {
                throw new ChildEntityDuplicationException(materialHistoryCardId, materialHistoryCard, MaterialInforId, this);
            }
            MaterialHistoryCards.Add(materialHistoryCard);
        }

        public MaterialHistoryCard GetMaterialHistoryCard(string materialHistoryCardId)
        {
            var materialHistoryCard = MaterialHistoryCards.Find(x => x.MaterialHistoryCardId == materialHistoryCardId) ?? throw new ChildEntityNotFoundException(materialHistoryCardId, typeof(MaterialHistoryCard), MaterialInforId, this);
            return materialHistoryCard;
        }

        public void UpdateMaterialHistoryCard(string materialHistoryCardId, DateTime timeStamp, decimal before, decimal input, decimal output, decimal after, string note)
        {
            var materialHistoryCard = GetMaterialHistoryCard(materialHistoryCardId);

            try
            {
                materialHistoryCard.Update(timeStamp, before, input, output, after, note);
            }
            catch (Exception ex)
            {
                throw new DomainException($"MaterialInfor with id {MaterialInforId} throw an exception. See inner exception for details.", ex);
            }
        }

        public void RemoveMaterialHistoryCard(string materialHistoryCardId)
        {
            var materialHistoryCard = GetMaterialHistoryCard(materialHistoryCardId);

            try
            {
                MaterialHistoryCards.Remove(materialHistoryCard);
            }
            catch (Exception ex)
            {
                throw new DomainException($"MaterialInfor with id {MaterialInforId} throw an exception. See inner exception for details.", ex);
            }
        }

        public void AddMaterial(string materialId, string sku, EMaterialStatus? status)
        {
            var material = new Material(materialId, this, sku, status);
            if (Materials.Exists(x => x.MaterialId == materialId))
            {
                throw new ChildEntityDuplicationException(materialId, material, MaterialInforId, this);
            }
            Materials.Add(material);
        }

        public Material GetMaterial(string materialId)
        {
            var material = Materials.Find(x => x.MaterialId == materialId) ?? throw new ChildEntityNotFoundException(materialId, typeof(Material), MaterialInforId, this);
            return material;
        }

        public void UpdateMaterial(string materialId, EMaterialStatus? status)
        {
            var material = GetMaterial(materialId);

            try
            {
                material.Update(status);
            }
            catch (Exception ex)
            {
                throw new DomainException($"MaterialInfor with id {MaterialInforId} throw an exception. See inner exception for details.", ex);
            }
        }

        public void RemoveMaterial(string materialId)
        {
            var material = GetMaterial(materialId);

            try
            {
                Materials.Remove(material);
            }
            catch (Exception ex)
            {
                throw new DomainException($"MaterialInfor with id {MaterialInforId} throw an exception. See inner exception for details.", ex);
            }
        }

        public void AddMaterialRequest(string materialRequestId, string code, decimal currentNumber, decimal additionalNumber, decimal expectedNumber, DateTime expectedDate, DateTime createdAt, DateTime updatedAt, EMaterialRequestStatus status)
        {
            var materialRequest = new MaterialRequest(materialRequestId, code, this, currentNumber, additionalNumber, expectedNumber, expectedDate, createdAt, updatedAt, status);
            if (MaterialRequests.Exists(x => x.MaterialRequestId == materialRequestId))
            {
                throw new ChildEntityDuplicationException(materialRequestId, materialRequest, MaterialInforId, this);
            }
            MaterialRequests.Add(materialRequest);
        }

        public MaterialRequest GetMaterialRequest(string materialRequestId)
        {
            var materialRequest = MaterialRequests.Find(x => x.MaterialRequestId == materialRequestId) ?? throw new ChildEntityNotFoundException(materialRequestId, typeof(MaterialRequest), MaterialInforId, this);
            return materialRequest;
        }

        public void UpdateMaterialRequest(string materialRequestId, decimal? currentNumber, decimal? additionalNumber, decimal? expectedNumber, DateTime? expectedDate, DateTime? updatedAt, EMaterialRequestStatus? status)
        {
            var materialRequest = GetMaterialRequest(materialRequestId);

            try
            {
                materialRequest.Update(currentNumber, additionalNumber, expectedNumber, expectedDate, updatedAt, status);
            }
            catch (Exception ex)
            {
                throw new DomainException($"MaterialInfor with id {MaterialInforId} throw an exception. See inner exception for details.", ex);
            }
        }

        public void RemoveMaterialRequest(string materialRequestId)
        {
            var materialRequest = GetMaterialRequest(materialRequestId);

            try
            {
                MaterialRequests.Remove(materialRequest);
            }
            catch (Exception ex)
            {
                throw new DomainException($"MaterialInfor with id {MaterialInforId} throw an exception. See inner exception for details.", ex);
            }
        }

        public void InputMaterialHistoryCard(MaterialRequest materialRequest)
        {
            var materialHistoryCardId = Guid.NewGuid().ToString();
            var numberCard = MaterialHistoryCards.Count;
            decimal beforeNumber = 0;
            decimal inputNumber = 0;
            decimal outputNumber = 0;
            decimal afterNumber = 0;
            if (numberCard > 0)
            {
                MaterialHistoryCard lastCard = MaterialHistoryCards[numberCard - 1];
                beforeNumber = lastCard.After;
                inputNumber = materialRequest.AdditionalNumber;
                outputNumber = 0;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }
            else
            {
                beforeNumber = 0;
                inputNumber = materialRequest.AdditionalNumber;
                outputNumber = 0;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }

            MaterialHistoryCard card = new MaterialHistoryCard(materialHistoryCardId: materialHistoryCardId,
                                                               timeStamp: DateTime.Now,
                                                               before: beforeNumber,
                                                               input: inputNumber,
                                                               output: outputNumber,
                                                               after: afterNumber,
                                                               note: "");

            MaterialHistoryCards.Add(card);
        }

        public void OutputMaterialHistoryCard(decimal usedNumber)
        {
            var materialHistoryCardId = Guid.NewGuid().ToString();
            var numberCard = MaterialHistoryCards.Count;
            decimal beforeNumber = 0;
            decimal inputNumber = 0;
            decimal outputNumber = 0;
            decimal afterNumber = 0;
            if (numberCard > 0)
            {
                MaterialHistoryCard lastCard = MaterialHistoryCards[numberCard - 1];
                beforeNumber = lastCard.After;
                inputNumber = 0;
                outputNumber = usedNumber;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }
            else
            {
                beforeNumber = 0;
                inputNumber = 0;
                outputNumber = usedNumber;
                afterNumber = beforeNumber + inputNumber - outputNumber;
            }


            MaterialHistoryCard card = new MaterialHistoryCard(materialHistoryCardId: materialHistoryCardId,
                                                               timeStamp: DateTime.Now,
                                                               before: beforeNumber,
                                                               input: inputNumber,
                                                               output: outputNumber,
                                                               after: afterNumber,
                                                               note: "");
            MaterialHistoryCards.Add(card);

            if (MaterialRequests is null)
            {
                return;
            }

            var materialRequestsInProgress = MaterialRequests.Where(x => x.Status == EMaterialRequestStatus.InProgress).ToList();

            if (materialRequestsInProgress is not null)
            {
                foreach (var item in materialRequestsInProgress)
                {
                    item.UpdateCurrentNumber(card.After);
                }
            }
        }
    }
}
