# CarManufacturersAPI

Веб-API приложение для управления автомобилями и производителями.

### ДЗ 15:

![DZ](images/DZ.png)

Все в точности как из проекта что создавали на паре. Просто с другой бдшкой. Я номер 13. 

### Cars:
- GET /api/cars - получить все автомобили ![GET api cars](images/GET%20api%20cars.png)
- GET /api/cars/{id} - получить автомобиль по ID ![GET api cars id](images/GET%20api%20cars%20id.png)
- POST /api/cars - создать новый автомобиль ![POST api cars](images/POST%20api%20cars.png)
- PUT /api/cars/{id} - обновить автомобиль ![PATCH api cars id](images/PATCH%20api%20cars%20id.png)
- DELETE /api/cars/{id} - удалить автомобиль ![DELETE api cars id](images/DELETE%20api%20cars%20id.png)

### Manufacturers:
- GET /api/manufacturers - получить всех производителей ![GET api manufacturers](images/GET%20api%20manufacturers.png)
- GET /api/manufacturers/{id} - получить производителя по ID ![GET api manufacturers id](images/GET%20api%20manufacturers%20id.png)
- POST /api/manufacturers - создать нового производителя ![POST api manufacturers](images/POST%20api%20manufacturers.png)
- PUT /api/manufacturers/{id} - обновить производителя ![PATCH api manufacturers id](images/PATCH%20api%20manufacturers%20id.png)
- DELETE /api/manufacturers/{id} - удалить производителя ![DELETE api manufacturers id](images/DELETE%20api%20manufacturers%20id.png)

## Примеры обработки ошибок

### Cars:
- POST с пустыми данными ![POST api cars empty](images/POST%20api%20cars%20empty.png)
- PATCH с пустыми данными ![PATCH api cars id empty](images/PATCH%20api%20cars%20id%20empty.png)
- GET с неизвестным ID ![GET api cars id unknown](images/GET%20api%20cars%20id%20unknown.png)

### Manufacturers:
- POST с пустыми данными ![POST api manufacturers empty](images/POST%20api%20manufacturers%20empty.png)
- PATCH с пустыми данными ![PATCH api manufacturers id empty](images/PATCH%20api%20manufacturers%20id%20empty.png)
- GET с неизвестным ID ![GET api manufacturers id unknown](images/GET%20api%20manufacturers%20id%20unknown.png) 