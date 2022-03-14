class XpBar extends HTMLElement {
    constructor() {
        super();

        const shadow = this.attachShadow({mode: 'open'});

        const wrapper = document.createElement('div');
        wrapper.setAttribute('class', 'xp-bar-wrapper');

        const progressBar = document.createElement('div');
        progressBar.setAttribute('class', 'xp-bar-progress');

        var percent = this.getAttribute('percent');

        const style = document.createElement('style');
        console.log(style.isConnected);

        style.textContent = `
            .xp-bar-wrapper {
                width: 120px;
                height: 23px;
                border: 3px solid;
                border-image-slice: 1;
                border-width: 3px;
                border-image-source: linear-gradient(90deg, #6728EC 0%, #8AB3F0 100%);
            }

            .xp-bar-progress {
                width: ${percent}%;
                height: 100%;
                background: linear-gradient(90deg, #6728EC 0%, #8AB3F0 120px);
            }
        `;

        shadow.appendChild(style);
        console.log(style.isConnected);
        shadow.appendChild(wrapper);
        wrapper.appendChild(progressBar);
    }
}

customElements.define('xp-bar', XpBar);