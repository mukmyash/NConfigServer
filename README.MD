# NConfigServer
Микросервис конфигураций

## Добавление конфигурации
1. Resources\Configurations создайте каталог с названием ({**ProjectName**}) проекта\модуля\.... 
1. В созданном каталоге (см. пункт 1) создаздайте файлы конфигурации
    1. base.(_json\xml_) - базовый конфигурационный файл
    1. {**environment**}.(_json\xml_) - файл конфигарации который переопределит настройки базового конфигурационного файла.

### Поддерживаемые форматы конфигурационных файлов
На текущий момент поддердживается работы следующих форматов
- JSON
- XML

## Получение конфигурации
Для получения конфигурации необходимо выполнить запрос по ссылке:
- http://{**serverName**}/{**ProjectName**} для получения базовой конфигурации
- http://{**serverName**}/{**ProjectName**}/{**environment**} для получения конфигурации конкретной среды
