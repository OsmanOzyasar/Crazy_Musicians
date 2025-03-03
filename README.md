# Musicians API

Bu proje, bir müzisyen listesi yönetimi için oluşturulmuş basit bir RESTful API'dir. API, müzisyen ekleme, listeleme, güncelleme ve silme işlemlerini destekler.

## Başlangıç

Bu projeyi çalıştırmak için aşağıdaki adımları izleyin:

### Gereksinimler
- .NET 6 veya üstü
- Visual Studio veya herhangi bir .NET geliştirme ortamı

### Kurulum
1. Proje dizinine gidin:
   ```sh
   cd <proje-dizini>
   ```
2. Bağımlılıkları yükleyin (gerekirse):
   ```sh
   dotnet restore
   ```
3. API'yi çalıştırın:
   ```sh
   dotnet run
   ```

## API Kullanımı

### Müzisyenleri Listeleme
**Endpoint:** `GET /musician-list`

Tüm müzisyenleri listeler.

**Örnek İstek:**
```sh
GET http://localhost:5000/musician-list
```

**Örnek Yanıt:**
```json
[
    {
        "id": 1,
        "name": "Ahmet Çalgı",
        "expertise": "Ünlü Çalgı Çalar",
        "funnyFeature": "Her Zaman Yanlış Nota Çalar Ama Çok Eğlenceli"
    }
]
```

---

### Belirli Bir Müzisyeni Getirme
**Endpoint:** `GET /{id}`

Belirtilen ID'ye sahip müzisyeni getirir.

**Örnek İstek:**
```sh
GET http://localhost:5000/1
```

**Örnek Yanıt:**
```json
{
    "id": 1,
    "name": "Ahmet Çalgı",
    "expertise": "Ünlü Çalgı Çalar",
    "funnyFeature": "Her Zaman Yanlış Nota Çalar Ama Çok Eğlenceli"
}
```

---

### Yeni Müzisyen Ekleme
**Endpoint:** `POST /create-musician`

Yeni bir müzisyen eklemek için kullanılır.

**Örnek İstek:**
```sh
POST http://localhost:5000/create-musician
Content-Type: application/json

{
    "name": "Deniz Akor",
    "expertise": "Gitar Virtüözü",
    "funnyFeature": "Gitarı Ters Tutup Çalıyor"
}
```

**Örnek Yanıt:**
```json
{
    "id": 3,
    "name": "Deniz Akor",
    "expertise": "Gitar Virtüözü",
    "funnyFeature": "Gitarı Ters Tutup Çalıyor"
}
```

---

### Müzisyen Bilgilerini Güncelleme (PATCH)
**Endpoint:** `PATCH /update/{id}`

Sadece belirtilen alanları günceller.

**Örnek İstek:**
```sh
PATCH http://localhost:5000/update/1
Content-Type: application/json

{
    "expertise": "Yeni Uzmanlık",
    "funnyFeature": "Yeni Komik Özellik"
}
```

---

### Müzisyeni Tamamen Güncelleme (PUT)
**Endpoint:** `PUT /change/{id}`

Tüm alanları günceller.

**Örnek İstek:**
```sh
PUT http://localhost:5000/change/1
Content-Type: application/json

{
    "name": "Yeni İsim",
    "expertise": "Yeni Uzmanlık",
    "funnyFeature": "Yeni Komik Özellik"
}
```

---

### Müzisyeni Silme
**Endpoint:** `DELETE /delete/{id}`

Belirtilen ID'ye sahip müzisyeni siler.

**Örnek İstek:**
```sh
DELETE http://localhost:5000/delete/1
```

**Örnek Yanıt:**
```json
[
    {
        "id": 2,
        "name": "Zeynep Melodi",
        "expertise": "Popüler Melodi Yazarı",
        "funnyFeature": "Şarkıları Yanlış Anlaşılır Ama Çok Popüler"
    }
]
```

---

## Validasyon Kuralları
- `Name`: Zorunlu, maksimum 50 karakter.
- `Expertise`: Zorunlu.
- `FunnyFeature`: Zorunlu.

**Hatalı İstek Örneği:**
```sh
POST http://localhost:5000/create-musician
Content-Type: application/json

{
    "name": "",
    "expertise": "",
    "funnyFeature": ""
}
```

**Yanıt:**
```json
{
    "name": ["zorunlu alan"],
    "expertise": ["zorunlu alan"],
    "funnyFeature": ["zorunlu alan"]
}
```

## Lisans
Bu proje MIT lisansı altında lisanslanmıştır.

