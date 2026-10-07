# Configuration Guide

Bu proje development ve production ortamları için gizli veya ortama bağlı ayarları environment variable ya da local config override üzerinden bekler.

## Backend

Backend önce standart `appsettings.json` / `appsettings.{Environment}.json` dosyalarını okur, sonra varsa şu local override dosyalarını yükler:

- `src/backend/MusicTw.Api/appsettings.Local.json`
- `src/backend/MusicTw.Api/appsettings.Development.Local.json`

Bu dosyalar `.gitignore` içinde yer alır ve repoya commit edilmez.

Development için örnek dosya:

- `src/backend/MusicTw.Api/appsettings.Development.Local.example.json`

Kopyalayıp `appsettings.Development.Local.json` olarak kullanabilirsin.

### Gerekli backend config değerleri

- `ConnectionStrings__DefaultConnection`
- `Jwt__Issuer`
- `Jwt__Audience`
- `Jwt__Key`
- `Jwt__ExpiresMinutes` isteğe bağlı
- `Cors__AllowedOrigins__0` isteğe bağlı

Örnek environment variable adları:

```powershell
$env:ConnectionStrings__DefaultConnection="Server=(localdb)\MSSQLLocalDB;Database=MusicTwDb.Dev;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
$env:Jwt__Issuer="MusicTw.Api.Dev"
$env:Jwt__Audience="MusicTw.Web.Dev"
$env:Jwt__Key="replace-with-a-long-random-secret-at-least-32-characters"
$env:Cors__AllowedOrigins__0="http://localhost:5173"
```

## Frontend

Frontend Vite env yapısını kullanır.

Örnek dosya:

- `src/frontend/musictw-web/.env.example`

Kopyalayıp `.env.local` veya `.env.development.local` olarak kullanabilirsin.

### Gerekli frontend env değerleri

- `VITE_API_BASE_URL`
  Production ya da ayrı origin kullanımında API adresi.
- `VITE_DEV_API_PROXY_TARGET`
  Development sırasında Vite proxy hedefi.

Örnek:

```env
VITE_API_BASE_URL=
VITE_DEV_API_PROXY_TARGET=http://localhost:5004
```

`VITE_API_BASE_URL` boş bırakılırsa frontend mevcut origin üzerinden `/api` çağrıları yapar.

## Production deploy

Production ortamında platform üzerinden en az şu değerleri set et:

- `ConnectionStrings__DefaultConnection`
- `Jwt__Issuer`
- `Jwt__Audience`
- `Jwt__Key`
- gerekiyorsa `Cors__AllowedOrigins__0`, `Cors__AllowedOrigins__1` ...
- frontend için `VITE_API_BASE_URL`

Repodaki placeholder değerler gerçek ayar değildir; override edilmezse backend başlatma sırasında hata verir.
