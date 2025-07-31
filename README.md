# HangiKredi.API

HangiKredi.API, banka ve kredi bilgilerini yöneten RESTful bir API servisidir.

---

## Özellikler

- Banka kayıtlarını listeleme, oluşturma, güncelleme ve silme  
- Kredi bilgilerini sorgulama  
- JSON ve plain text formatlarında veri dönebilme  
- Swagger ile API dokümantasyonu destekli

---

## API Endpoints

### Banka İşlemleri

| HTTP Metodu | Yol                     | Açıklama                    | Parametreler                             |
|-------------|-------------------------|-----------------------------|-----------------------------------------|
| GET         | `/api/v1/Bank/get`       | Banka listesini getirir      | `currentPage` (query, int, default 0), `perPage` (query, int, default 10) |
| GET         | `/api/v1/Bank/get/{id}`  | ID ile banka detaylarını getirir | `id` (path, int, zorunlu)               |
| POST        | `/api/v1/Bank/create`    | Yeni banka oluşturur         | Body: BankDto (JSON)                     |
| PATCH       | `/api/v1/Bank/update/{id}` | Var olan bankayı günceller  | `id` (path, int), Body: BankDto (JSON) |
| DELETE      | `/api/v1/Bank/delete/{id}` | Banka kaydını siler         | `id` (path, int, zorunlu)               |

---

### Kredi İşlemleri

| HTTP Metodu | Yol                     | Açıklama                    | Parametreler                             |
|-------------|-------------------------|-----------------------------|-----------------------------------------|
| GET         | `/api/v1/Loan/get/{id}`  | ID ile kredi bilgilerini getirir | `id` (path, int, zorunlu)               |

---

## Veri Modelleri

### BankDto

- `name` (string, max 50, zorunlu)  
- `createdAt` (datetime)  
- `updatedAt` (datetime, nullable)  

### LoanDto

- `name` (string, max 50, zorunlu)  
- `bankId` (int)  
- `rate` (double)  
- `createdAt` (datetime)  
- `updatedAt` (datetime, nullable)  

---

## Response Formatları

Tüm başarılı istekler aşağıdaki yapıya sahiptir:

```json
{
  "success": true,
  "data": { /* İlgili veri modeli */ },
  "error": null
}
