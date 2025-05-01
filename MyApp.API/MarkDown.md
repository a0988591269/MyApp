 MyApp/
├── MyApp.API/                             ← 接收 HTTP 請求的入口
│   ├── Controllers/
│   │   └── PlayerController.cs            ← 呼叫應用層處理邏輯
│   └── Program.cs                         ← 主程式進入點 (註冊 DI)
│
├── MyApp.Application/                     ← 應用邏輯層，負責 orchestrate 運作
│   ├── Interfaces/                        ← 對 Service 的抽象 (for test/mocking)
│   │   └── IPlayerService.cs
│   ├── Services/
│   │   └── PlayerService.cs               ← 業務邏輯處理
│   └── DTOs/
│       └── PlayerDto.cs                   ← 用於輸出/輸入的資料結構
│
├── MyApp.Domain/                          ← 核心模型與行為，無任何基礎設施相依
│   ├── Entities/
│   │   └── Player.cs
│   │   └── Character.cs
│   ├── ValueObjects/
│   │   └── AccountType.cs                 ← 自定的值物件
│   └── Interfaces/
│       └── IPlayerRepository.cs           ← 資料存取抽象定義
│
├── MyApp.Infrastructure/                 ← 資料存取具體實作（依賴 EF、DB）
│   ├── Data/
│   │   └── AppDbContext.cs                ← EF Core DbContext
│   │   └── DataSeed.cs                    ← 預設資料初始化
│   └── Repositories/
│       └── PlayerRepository.cs            ← 實作 IPlayerRepository
│
├── MyApp.Persistence/                    ← 儲存資料設定，如 Migrations
│   └── Migrations/
│       └── [timestamp]_Initial.cs         ← EF Core Migrations
│   └── PersistenceModule.cs               ← 專責 DI 註冊 Infrastructure 的地方
│
├── MyApp.Shared/                          ← 共用元件
│   ├── Constants/
│   │   └── AppSettings.cs
│   ├── Exceptions/
│   │   └── NotFoundException.cs
│   ├── Utils/
│   │   └── DateTimeHelper.cs
│   └── Results/
│       └── ApiResponse.cs                 ← 統一 API 回傳格式