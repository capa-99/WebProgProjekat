export class Sala {

    constructor(arr, p) {
        this.broj = arr[0];
        this.kapacitet = arr[1];
        this.attrs = arr;
        this.poz = p;
        this.izvedbe = [];
    }

    draw(host) {
        let s = document.createElement("tr");
        this.container = s;
            host.appendChild(s);
            s.className = "sala";
            this.attrs.forEach(e => {
                let x = document.createElement("td");
                s.appendChild(x);
                x.innerHTML = e;
            });
    }

    addOption(host) {
        let y = document.createElement("option");
        y.text = this.broj;
        let z = host.querySelector("select");
        z.add(y);
    }
}