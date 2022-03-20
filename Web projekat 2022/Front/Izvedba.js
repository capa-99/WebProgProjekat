import { Predstava } from "./Predstava.js";

export class Izvedba {

    constructor(arr, p, sala, id){
        this.predstava = p;
        this.sala= sala;
        this.datum = arr[0];
        this.vreme =arr[1];
        this.karte = arr[2];
        this.attrs = arr;
        this.container = null;
        this.id = id;
    }

    update(arr, s) {
        this.sala= s;
        this.datum = arr[0];
        this.vreme =arr[1];
        this.karte = arr[2];
        this.attrs = arr;
    }

    draw(host) {
        let item = document.createElement("tr");
        this.container = item;
            host.appendChild(item);
            item.className = "izvedba";
            let z = document.createElement("td");
            item.appendChild(z);
            z.innerHTML = this.sala.broj;
            this.attrs.forEach(e => {
                let x = document.createElement("td");
                item.appendChild(x);
                x.innerHTML = e;
            });

            item.onclick = (ev => 
                {
                    this.predstava.select(this);
                    this.export(this.predstava);
                    this.container.style.backgroundColor = "#5e7c83";
                });

    }

    export(parent) {
        console.log(this.attrs);
            let x = parent.poz.container.querySelectorAll(".inputIzvedba");
            x.forEach((el, ind) => {
                if(ind == 0) {
                    el.value = this.sala.broj;
                }
                else {
                    el.value = this.attrs[ind-1];
                }
            });
    }


}