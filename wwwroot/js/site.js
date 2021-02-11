document.querySelector("#Status")?.addEventListener("change", (ev) => {
	const date = document.querySelector("#DateBuy");
	const price = document.querySelector("#DolarRealBuy");
	if (ev.target.value === "Purchased") {
		date.attributes.removeNamedItem("disabled");
		price.attributes.removeNamedItem("disabled");
		document.querySelector("#Priority").value = 1;
		return;
	} else {
		date.disabled = true;
		price.disabled = true;
	}
	if (ev.target.value === "Selected") {
		document.querySelector("#Priority").value = 1;
		return;
	}
	const priority = parseInt(document.querySelector("#Priority")?.value);
	ev.target.value === "Alternative" &&
		priority &&
		priority == 1 &&
		(document.querySelector("#Priority").value = 2);
});

document.querySelector("#Priority")?.addEventListener("change", (ev) => {
	const value = parseInt(ev.target.value);
	value === 1
		? (document.querySelector("#Status").value = "Selected")
		: value > 1 &&
		  (document.querySelector("#Status").value = "Alternative");
});

const template = `
			<article class="col-sm-4">
				<fieldset class="form-group mb-2">
						<label for="Store" class="control-label">Store</label>
						<input name="Store" required max-length="100" class="form-control"/>
						<span for="Store" class="text-danger"></span>
				</fieldset>
				<fieldset class="form-group mb-2">
						<label for="URLs" class="control-label">Url</label>
						<input name="URLs" required max-length="100" class="form-control"/>
						<span for="URLs" class="text-danger"></span>
				</fieldset>
				<fieldset class="form-group mb-2">
						<label for="Amount" class="control-label">Amount</label>
						<input name="Amount" required class="form-control"/>
						<span for="Amount" class="text-danger"></span>
				</fieldset>
				<fieldset class="form-group mb-2">
						<label for="Currency" class="control-label">Currency</label>
						<select name="Currency" required max-length="5" class="form-control">
							<option  value="$">(USD) Dolar</option>
							<option selected value="R$">(BRL) Real</option>
						</select>
						<span for="Currency" class="text-danger"></span>
				</fieldset>
				<button type="button" class="btn btn-danger" onclick="Remove(this)">Delete</button>
			</article>`;

document.querySelector(".add-offer")?.addEventListener("click", (ev) => {
	document
		.querySelector("#offers-panel")
		.insertAdjacentHTML("beforeend", template);
});

function Remove(button) {
	button.parentNode.remove();
}

document.querySelectorAll(".form-delete").forEach((form) =>
	form.addEventListener("submit", (ev) => {
		if (!confirm("Are you sure?")) {
			alert("cancel delete");
			ev.preventDefault();
			return false;
		}
	})
);
const filterHandler = (ev) => {
	const value = ev.target.value.toLocaleLowerCase();
	let total = 0;
	document.querySelectorAll("tbody tr").forEach((row) => {
		let passed = false;
		row.querySelectorAll("td").forEach((item, index) => {
			if (
				index < 3 &&
				item.innerHTML.toLocaleLowerCase().includes(value)
			) {
				passed = true;
			}
		});
		row.style.display = passed ? "table-row" : "none";
		total += passed ? 1 : 0;
	});
	document.querySelector("#span-showing").innerHTML = total;
};

document
	.querySelector(".filter-input")
	?.addEventListener("keyup", filterHandler);
document
	.querySelector(".filter-input")
	?.addEventListener("paste", filterHandler);

document.querySelector(".btn-prev")?.addEventListener("click", (ev) => {
	const value = parseInt(document.querySelector("#page").value);
	value > 1 && (document.querySelector("#page").value = value - 1);
	document.querySelector("form").submit();
});
document.querySelector(".btn-next")?.addEventListener("click", (ev) => {
	const value = parseInt(document.querySelector("#page").value);
	const max = parseInt(document.querySelector("#pages").value);
	max > value && (document.querySelector("#page").value = value + 1);
	document.querySelector("form").submit();
});

document.querySelectorAll(".btn-page").forEach((btn) =>
	btn.addEventListener("click", (ev) => {
		if (
			document.querySelector("#page").value !=
			ev.target.attributes["data-page"].value
		) {
			document.querySelector("#page").value =
				ev.target.attributes["data-page"].value;
			document.querySelector("form").submit();
		}
	})
);
const validate = () => {
	let valid = true;
	document.querySelectorAll(".error").forEach((input) => {
		input.nextElementSibling.innerHTML = "";
		input.classList.remove("error");
	});
	document.querySelectorAll("*[required]").forEach((input) => {
		if (!input.value) {
			input.nextElementSibling.insertAdjacentText(
				"beforeend",
				"Campo obrigatório"
			);
			input.classList.add("error");
			valid = false;
		}
	});
	document.querySelectorAll("*[max-length]").forEach((input) => {
		const max = parseInt(input.attributes["max-length"].value);
		if (input.value && input.value.length > max) {
			input.nextElementSibling.insertAdjacentText(
				"beforeend",
				`Máximo de ${max} caracteres`
			);
			input.classList.add("error");
			valid = false;
		}
	});
	return valid;
};

document.querySelector("form").addEventListener("submit", (ev) => {
	if (!validate()) {
		ev.preventDefault();
		return false;
	}
});
