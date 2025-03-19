let selektovanaOsobaId = null;

// Funkcija za prikaz podataka u tabeli (kad dobijes podatke iz API-a)
function prikaziOsobe(osobe) {
    const tbody = document.getElementById('imenikBody');
    tbody.innerHTML = ''; // Očisti tabelu prije nego što puniš nove podatke

    osobe.forEach(osoba => {
        const tr = document.createElement('tr');
        tr.dataset.id = osoba.id;

        tr.innerHTML = `
            <td>${osoba.ime}</td>
            <td>${osoba.prezime}</td>
            <td>${osoba.telefon}</td>
            <td>${osoba.pol}</td>
            <td>${osoba.email}</td>
            <td>${osoba.drzavaNaziv}</td>
            <td>${osoba.gradNaziv}</td>
            <td>${osoba.datumRodjenja}</td>
            <td>${osoba.starost}</td>
            <td>
                <button class="btn btn-sm btn-warning btn-edit">Ažuriraj</button>
                <button class="btn btn-sm btn-danger btn-delete">Obriši</button>
            </td>
        `;

        // Klik na cijeli red (možeš i samo na dugmad, ako želiš)
        tr.addEventListener('click', function() {
            selektujRed(tr);
        });

        // Dugme Ažuriraj
        tr.querySelector('.btn-edit').addEventListener('click', function(e) {
            e.stopPropagation(); // Da ne klikne i na red
            otvoriModalZaAzuriranje(osoba);
        });

        // Dugme Obriši
        tr.querySelector('.btn-delete').addEventListener('click', function(e) {
            e.stopPropagation(); // Da ne klikne i na red
            obrisiOsobu(osoba.id);
        });

        tbody.appendChild(tr);
    });
}

function selektujRed(tr) {
    // Makni selekciju sa svih redova
    document.querySelectorAll('#imenikBody tr').forEach(row => {
        row.classList.remove('table-active'); // Bootstrap klasa za isticanje
    });

    // Selektuj kliknuti red
    tr.classList.add('table-active');

    // Zapamti ID selektovane osobe
    selektovanaOsobaId = tr.dataset.id;
}

function otvoriModalZaAzuriranje(osoba) {
    // Popuni formu u modalu s podacima osobe
    document.getElementById('osobaId').value = osoba.id;
    document.getElementById('ime').value = osoba.ime;
    document.getElementById('prezime').value = osoba.prezime;
    document.getElementById('telefon').value = osoba.telefon;
    document.getElementById('pol').value = osoba.pol;
    document.getElementById('email').value = osoba.email;
    document.getElementById('drzava').value = osoba.drzavaId;
    document.getElementById('grad').value = osoba.gradId;
    document.getElementById('datumRodjenja').value = osoba.datumRodjenja;

    // Prikazi modal
    const modal = new bootstrap.Modal(document.getElementById('osobaModal'));
    modal.show();
}

function obrisiOsobu(id) {
    if (!confirm('Da li ste sigurni da želite obrisati ovu osobu?')) {
        return;
    }

    fetch(`https://tvoj-api-url/osobe/${id}`, {
        method: 'DELETE'
    })
    .then(response => {
        if (response.ok) {
            alert('Osoba obrisana!');
            ucitajOsobe(); // Funkcija koja ponovo puni tabelu
        } else {
            alert('Greška prilikom brisanja osobe!');
        }
    });
}

// Klik na "Dodaj Osobu" dugme
document.getElementById('btnDodajOsobu').addEventListener('click', function() {
    // Resetuj formu
    document.getElementById('osobaForm').reset();
    document.getElementById('osobaId').value = '';

    const modal = new bootstrap.Modal(document.getElementById('osobaModal'));
    modal.show();
});

// Submit forme (dodavanje/azuriranje osobe)
document.getElementById('osobaForm').addEventListener('submit', function(e) {
    e.preventDefault();

    const id = document.getElementById('osobaId').value;
    const osoba = {
        ime: document.getElementById('ime').value,
        prezime: document.getElementById('prezime').value,
        telefon: document.getElementById('telefon').value,
        pol: document.getElementById('pol').value,
        email: document.getElementById('email').value,
        drzavaId: document.getElementById('drzava').value,
        gradId: document.getElementById('grad').value,
        datumRodjenja: document.getElementById('datumRodjenja').value
    };

    const method = id ? 'PUT' : 'POST';
    const url = id ? `https://tvoj-api-url/osobe/${id}` : 'https://tvoj-api-url/osobe';

    fetch(url, {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(osoba)
    })
    .then(response => {
        if (response.ok) {
            alert(id ? 'Osoba ažurirana!' : 'Osoba dodana!');
            const modal = bootstrap.Modal.getInstance(document.getElementById('osobaModal'));
            modal.hide();
            ucitajOsobe();
        } else {
            alert('Greška prilikom čuvanja osobe!');
        }
    });
});

function ucitajOsobe() {
    fetch('https://tvoj-api-url/osobe')
        .then(response => response.json())
        .then(osobe => prikaziOsobe(osobe));
}

// Pokreni kada se stranica učita
ucitajOsobe();