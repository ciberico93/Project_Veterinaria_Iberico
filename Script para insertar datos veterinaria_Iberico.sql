 /* Estimado profesor Gusto en saludarlo , le adjunto este script con algunos datos para que pueda agregarlos
 el usuario master es admin@gmail.com y la clave es Admin1234* 
 Muchas gracias por la enseñanza en estos 4 meses , espero poder conseguir un trabajo 
 Mi correo es ciberico93@gmail.com y mi numero es 985730095 para contacto */

use VeterinaWebApp

select * from Clientes

insert into  Clientes values ('Jose','Iberico','joseiberico@gmail.com','2001-04-13' ,'Calle Luis Galvan 102',1,'46345581')
insert into  Clientes values  ('Maria', 'Gonzalez', 'mariagonzalez@gmail.com', '1998-09-22', 'Calle San Martin 45', 1, '55512345')
insert into  Clientes values  ('Luis', 'Rodriguez', 'luisrodriguez@gmail.com', '1995-03-17', 'Avenida Principal 123', 1, '66678901')
insert into  Clientes values('Ana', 'Martinez', 'anamartinez@gmail.com', '2000-12-08', 'Calle Juarez 67', 1, '44456789')
insert into  Clientes values('Pedro', 'Lopez', 'pedrolopez@gmail.com', '1992-06-30', 'Carrera 10 32-56', 1, '77723456')
insert into  Clientes values('Laura', 'Perez', 'lauraperez@gmail.com', '1997-11-14', 'Avenida Libertad 87', 1, '88834567')




select * from TipoMascotas

insert into TipoMascotas values ('Perro',1)
insert into TipoMascotas values ('Gato',1)
insert into TipoMascotas values ('Conejo',1)
insert into TipoMascotas values ('Cuy',1)
insert into TipoMascotas values ('Cerdo',1)

select * from Mascotas

insert into Mascotas values ('Boby','Criollo','2016-08-12',2,1,1,null)
insert into Mascotas values ('Mochita','Criollo','2016-08-12',1,2,1,null)
insert into Mascotas values ('Molly','Criollo','2016-08-12',4,2,1,null)


select * from Servicios

insert into Servicios values ('Peluqueria','Nuestro servicio de peluquería canina y felina ofrece una amplia variedad de cortes de pelo y baños, tanto estéticos como terapéuticos.

Se realizan corte comercial y con tijera y cada animal es bañado con el champú y acondicionador más adecuado para su tipo de piel y pelo. Además, se cortan las uñas, limpian los oídos y vacían los sacos anales.

Igualmente, se procuran tratamientos de champuterapia y corte terapéutico a los animales con problemas dermatológicos que lo requieran.',30,1)

insert into Servicios values ('Baño','Tu mascota se merece lo mejor, por eso regálale una visita al veterinario y un baño completo en la Clínica Veterinaria IBERICO por un precio insuperable.',20,1)

select * from Citas

insert into Citas values (GETdate(),'Baño mensual',2,2,2,1)
insert into Citas values (GETdate(),'Corte mensual',1,2,1,1)

