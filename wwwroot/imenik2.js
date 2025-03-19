
    let drzave = [];
    let modal = new bootstrap.Modal(document.getElementById('osobaModal'));

    document.addEventListener('DOMContentLoaded', () => {
        ucitajDrzave();
        ucitajImenik();

        document.getElementById('btnDodajOsobu').addEventListener('click', () => {
            pripremiFormuZaDodavanje();
        });

        document.getElementById('drzava').addEventListener('change', () => {
            const drzavaId = document.getElementById('drzava').value;
            ucitajGradove(drzavaId);
        });

        document.getElementById('datumRodjenja').addEventListener('change', izracunajStarost);

        document.getElementById('osobaForm').addEventListener('submit', sacuvajOsobu);
    });

    function ucitajDrzave() {
        fetch('/api/drzave')
            .then(response => response.json())
            .then(data => {
                drzave = data;
                const drzavaSelect = document.getElementById('drzava');
                drzavaSelect.innerHTML = '<option value="">Odaberite državu</option>';
                drzave.forEach(drzava => {
                    const option = document.createElement('option');
                    option.value = drzava.id;
                    option.textContent = drzava.naziv;
                    drzavaSelect.appendChild(option);
                });
            });
    }

    function ucitajGradove(drzavaId) {
        fetch(`/api/gradovi/${drzavaId}`)
            .then(response => response.json())
            .then(data => {
                const gradSelect = document.getElementById('grad');
                gradSelect.innerHTML = '<option value="">Odaberite grad</option>';
                data.forEach(grad => {
                    const option = document.createElement('option');
                    option.value = grad.id;
                    option.textContent = grad.naziv;
                    gradSelect.appendChild(option);
                });
            });
    }

    function ucitajImenik() {
        fetch('/api/imenik')
            .then(response => response.json())
            .then(data => {
                const tbody = document.getElementById('imenikBody');
                tbody.innerHTML = '';
                data.forEach(osoba => {
                    const tr = document.createElement('tr');

                    tr.innerHTML = `
                        <td>${osoba.ime}</td>
                        <td>${osoba.prezime}</td>
                        <td>${osoba.telefon}</td>
                        <td>
                            <span style="display: inline-block; width: 10px; height: 10px; border-radius: 50%; background-color: ${osoba.pol === 'M' ? 'blue' : 'red'};"></span>
                        </td>
                        <td>${osoba.email}</td>
                        <td>${osoba.drzavaNaziv}</td>
                        <td>${osoba.gradNaziv}</td>
                        <td>${osoba.datumRodjenja}</td>
                        <td>${osoba.starost}</td>
                        <td>
                            <button class="btn btn-warning btn-sm" onclick="izmijeniOsobu(${osoba.id})">Izmijeni</button>
                            <button class="btn btn-danger btn-sm" onclick="obrisiOsobu(${osoba.id})">Obriši</button>
                        </td>
                    `;

                    tbody.appendChild(tr);
                });
            });
    }

    function pripremiFormuZaDodavanje() {
        document.getElementById('osobaForm').reset();
        document.getElementById('osobaId').value = '';
        document.getElementById('grad').innerHTML = '<option value="">Odaberite grad</option>';
        modal.show();
    }

    function izmijeniOsobu(id) {
        fetch(`/api/imenik/${id}`)
            .then(response => response.json())
            .then(osoba => {
                document.getElementById('osobaId').value = osoba.id;
                document.getElementById('ime').value = osoba.ime;
                document.getElementById('prezime').value = osoba.prezime;
                document.getElementById('telefon').value = osoba.telefon;
                document.getElementById('pol').value = osoba.pol;
                document.getElementById('email').value = osoba.email;
                document.getElementById('drzava').value = osoba.drzavaId;

                ucitajGradove(osoba.drzavaId);
                setTimeout(() => {
                    document.getElementById('grad').value = osoba.gradId;
                }, 500);

                document.getElementById('datumRodjenja').value = osoba.datumRodjenja;
                document.getElementById('starost').value = osoba.starost;

                modal.show();
            });
    }

    function sacuvajOsobu(e) {
        e.preventDefault();

        const osobaId = document.getElementById('osobaId').value;

        const osoba = {
            ime: document.getElementById('ime').value,
            prezime: document.getElementById('prezime').value,
            telefon: document.getElementById('telefon').value,
            pol: document.getElementById('pol').value,
            email: document.getElementById('email').value,
            drzavaId: document.getElementById('drzava').value,
            gradId: document.getElementById('grad').value,
            datumRodjenja: document.getElementById('datumRodjenja').value,
            starost: document.getElementById('starost').value
        };

        const metoda = osobaId ? 'PUT' : 'POST';
        const url = osobaId ? `/api/imenik/${osobaId}` : '/api/imenik';

        fetch(url, {
            method: metoda,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(osoba)
        })
        .then(response => {
            if (response.ok) {
                modal.hide();
                ucitajImenik();
            } else {
                alert('Greška prilikom čuvanja.');
            }
        });
    }

    function obrisiOsobu(id) {
        if (confirm('Da li ste sigurni da želite obrisati osobu?')) {
            fetch(`/api/imenik/${id}`, { method: 'DELETE' })
                .then(response => {
                    if (response.ok) {
                        ucitajImenik();
                    } else {
                        alert('Greška prilikom brisanja.');
                    }
                });
        }
    }

    function izracunajStarost() {
        const datumRodjenja = document.getElementById('datumRodjenja').value;
        const danas = new Date();
        const rodjenje = new Date(datumRodjenja);
        let godine = danas.getFullYear() - rodjenje.getFullYear();
        const mjesec = danas.getMonth() - rodjenje.getMonth();

        if (mjesec < 0 || (mjesec === 0 && danas.getDate() < rodjenje.getDate())) {
            godine--;
        }

        document.getElementById('starost').value = godine;
    }
