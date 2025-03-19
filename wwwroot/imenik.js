let drzave = [];
let modal = new bootstrap.Modal(document.getElementById('osobaModal'));

document.addEventListener('DOMContentLoaded', function() {
    ucitajOsobe();
    ucitajDrzave();

    document.getElementById('btnDodajOsobu').addEventListener('click', () => {
        pripremiFormuZaDodavanje();
    });

    document.getElementById('drzava').addEventListener('change', () => {
        const drzavaId = document.getElementById('drzava').value;
        console.log('Selektovani drzavaId:', drzavaId); // Proveri vrednost

        ucitajGradove(drzavaId);

    });


});

function ucitajOsobe() {
    fetch('http://localhost:5297/api/osobe')
        .then(response => response.json())
        .then(data => {
            const tbody = document.getElementById('imenikBody');
            tbody.innerHTML = ''; // očisti prethodne podatke

            data.forEach(osoba => {
                const tr = document.createElement('tr');
                tr.setAttribute("data-id", osoba.osobaId); // Dodaj ID osobe kao data atribut

                tr.innerHTML = `
                    <td>${osoba.ime}</td>
                    <td>${osoba.prezime}</td>
                    <td>${osoba.brojTelefona}</td>
                    <td>${osoba.pol}</td>
                    <td>${osoba.email}</td>
                    <td>${osoba.nazivGrad}</td>
                    <td>${osoba.nazivDrzava}</td>
                    <td>${osoba.datumRodjenja}</td>
                    <td>${osoba.starost}</td>
                    <td>
                        <button class="btn btn-danger btn-brisi" data-id="${osoba.osobaId}">Obriši</button>
                    </td>
                `;

                tbody.appendChild(tr);
            });

            // Dodaj event listener za dugme brisanja
            document.querySelectorAll('.btn-brisi').forEach(button => {
                button.addEventListener('click', function() {
                    const osobaId = this.getAttribute('data-id');
                    if (confirm("Da li ste sigurni da želite obrisati ovu osobu?")) {
                        fetch(`http://localhost:5297/api/osobe/${osobaId}`, {
                            method: 'DELETE'
                        })
                        .then(response => {
                            if (response.ok) {
                                alert("Osoba je uspešno obrisana.");
                                // Ukloni red iz tabele
                                this.closest('tr').remove();
                            } else {
                                alert("Došlo je do greške prilikom brisanja.");
                            }
                        })
                        .catch(error => {
                            console.error("Greška:", error);
                            alert("Došlo je do greške prilikom brisanja.");
                        });
                    }
                });
            });
        })
        .catch(error => console.error('Greška pri učitavanju osoba:', error));
}


function ucitajDrzave() {
    fetch('http://localhost:5297/api/drzava')
        .then(response => response.json())
        .then(data => {
            drzave = data;
            const drzavaSelect = document.getElementById('drzava');
            drzavaSelect.innerHTML = '<option value="">Odaberite državu</option>';
            drzave.forEach(drzava => {
                const option = document.createElement('option');
                option.value = drzava.drzavaId;
                option.textContent = drzava.nazivDrzava;
                drzavaSelect.appendChild(option);
            });
        });
}

function ucitajGradove(drzavaId) {
    console.log('Selektovani drzavaId:', drzavaId);
    fetch(`http://localhost:5297/api/Drzava/gradovi?drzavaId=`)
    .then(response => response.json())
        .then(data => {
            console.log('Selektovani drzava', data);

            const gradSelect = document.getElementById('grad');
            gradSelect.innerHTML = '<option value="">Odaberite grad</option>';
            data.forEach(grad => {
                const option = document.createElement('option');
                option.value = grad.gradId;
                option.textContent = grad.nazivGrad;
                gradSelect.appendChild(option);
            });
        });
}

function pripremiFormuZaDodavanje() {
    document.getElementById('osobaForm').reset();
    document.getElementById('osobaId').value = '';
    document.getElementById('grad').innerHTML = '<option value="">Odaberite grad</option>';
    modal.show();
}


document.querySelector("#imenikBody").addEventListener('click', function(event) {
    if (event.target.classList.contains("btn-brisi")) {
        const osobaId = event.target.getAttribute("data-id");

        if (confirm("Da li ste sigurni da želite obrisati ovu osobu?")) {
            fetch(`http://localhost:5297/api/Drzava/obrisi/${osobaId}`, {
                method: 'DELETE'
            })
            .then(response => {
                if (response.ok) {
                    alert("Osoba je uspešno obrisana.");
                    // Osvježavanje tabele ili uklanjanje reda
                    document.querySelector(`[data-id="${osobaId}"]`).parentElement.remove();
                } else {
                    alert("Došlo je do greške prilikom brisanja.");
                }
            })
            .catch(error => {
                console.error("Greška:", error);
                alert("Došlo je do greške prilikom brisanja.");
            });
        }
    }
});


