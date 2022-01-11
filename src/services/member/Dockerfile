#Projede hangi kütüphane kullanıldı.
FROM node:16-alpine

#Projenin kaynak dosyalarını nereye kopyalacak.
WORKDIR /usr/src/app

#Gerekli dosyaların kopyalanması.
COPY package.json ./

#package.json daki gerekli kütüphanelerin yüklenmesi için gerekli.
#Express, body-parser, vs.
RUN npm install 

#"." bütün kaynak kodları -> "." workdir de belirttiğim klasöre kopyala.
COPY . .

#kullanılacak port.
EXPOSE 3000

#docker run komutunu çalıştırırken çalışıcak komut.
ENTRYPOINT [ "node" ]

#docker run komutunu çalıştırırken ENTRYPOINT komutunun yanına eklenicek ekstra parametre
#docker run komutunu çalıştırırken değiştirebiliriz.
CMD [ "./app.js" ]