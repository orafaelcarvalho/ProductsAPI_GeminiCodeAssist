using ProductsAPI_GeminiCodeAssist.Domain.Enums;

namespace ProductsAPI_GeminiCodeAssist.Domain.Entities;

public class Product
{
    public Product(string description, DateTime manufacturingDate, DateTime expirationDate, string supplierCode)
    {
        Id = Guid.NewGuid();
        Description = description;
        Status = ProductStatus.Active;
        ManufacturingDate = manufacturingDate;
        ExpirationDate = expirationDate;
        SupplierCode = supplierCode;

        Validate();
    }

    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public ProductStatus Status { get; private set; }
    public DateTime ManufacturingDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public string SupplierCode { get; private set; }

    public void SetStatusToDeleted()
    {
        Status = ProductStatus.Deleted;
    }

    private void Validate()
    {
        if (string.IsNullOrEmpty(Description))
        {
            throw new ArgumentException("Descrição é obrigatória.");
        }

        if (ManufacturingDate > ExpirationDate)
        {
            throw new ArgumentException("Data de fabricação não pode ser posterior à data de validade.");
        }

        if (string.IsNullOrEmpty(SupplierCode))
        {
            throw new ArgumentException("Código do fornecedor é obrigatório.");
        }
    }
}
