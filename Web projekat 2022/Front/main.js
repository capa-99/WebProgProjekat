import {Predstava} from "./Predstava.js"
import {Pozoriste} from "./Pozoriste.js"
import {Sala} from "./Sala.js"
import {Izvedba} from "./Izvedba.js"

fetch("https://localhost:5001/Pozoriste/PreuzmiPozorista").then(p => {
    p.json().then(data => {
        data.forEach(poz => {
            let izvedbetmp = []
            var pozoriste = new Pozoriste(poz.name);
            poz.predstave.forEach(pred => {
                var predstava = new Predstava([pred.naziv, pred.opis, pred.ogranicenje], pozoriste);
                pozoriste.predstave.push(predstava);
                if (pred.izvedbe != null){
                pred.izvedbe.forEach(izv => {
                    var tmpsala = new Sala([0,0], null);
                    var izvedba = new Izvedba([izv.datum, izv.vreme, izv.karte], predstava, tmpsala, izv.id);
                    predstava.izvedbe.push(izvedba);
                    izvedbetmp.push(izvedba);
                });
            }
            });
            poz.sale.forEach(sal => {
                var sala = new Sala([sal.broj, sal.kapacitet], pozoriste);
                pozoriste.sale.push(sala);
                if(sal.izvedbe != null){
                sal.izvedbe.forEach(izv => {
                    izvedbetmp.forEach(i => {
                        if(izv.id == i.id){
                            i.sala = sala;
                            sala.izvedbe.push(i);
                        }
                    });
                });
            }
            });
            pozoriste.draw(document.body);
            pozoriste.sale.forEach(s => {
                s.addOption(pozoriste.container);
            });
            console.log(izvedbetmp);
        });
    })
});